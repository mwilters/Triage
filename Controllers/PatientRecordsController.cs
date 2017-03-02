using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Triage.Models;
using Triage.ViewModels;
using System.Web.Script.Serialization;
using SendGrid;
using SendGrid.Helpers.Mail; // Include if you want to use the Mail Helper
using System.Threading.Tasks;

namespace Triage.Controllers
{
    public class PatientRecordsController : Controller
    {
        private ApplicationDbContext _context;

        public PatientRecordsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: PatientRecords
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New(Guid patientId)
        {
            var triageLevels = _context.TriageLevels.ToList();
            var triageTypes = _context.TriageType.ToList();
            var diagnosis = _context.Diagnosis.ToList();
            var patientRecord = new PatientRecord();
            var viewModel = new PatientRecordsFormViewModel();

            return View("PatientRecordsForm", viewModel);
        }

        //Save Patient Records
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PatientRecordsFormViewModel formViewModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new PatientRecordsFormViewModel
                {
                    PatientRecord = formViewModel.PatientRecord
                };
                return View("PatientRecordsForm", viewModel);
            }

            if (formViewModel.PatientRecord.Id == Guid.Empty)
            {
                _context.PatientRecords.Add(formViewModel.PatientRecord);
            }
            else
            {
                var patientRecordInDb = _context.PatientRecords.Single(c => c.Id == formViewModel.PatientRecord.Id);

                //Change to AutoMapper
                patientRecordInDb.DiagnosisId = formViewModel.PatientRecord.DiagnosisId;
                patientRecordInDb.DateReceived = formViewModel.PatientRecord.DateReceived;
                patientRecordInDb.ClinicalTrials = formViewModel.PatientRecord.ClinicalTrials;
                patientRecordInDb.ConsultDate = formViewModel.PatientRecord.ConsultDate;
                patientRecordInDb.DoctorId = formViewModel.PatientRecord.DoctorId;
                patientRecordInDb.LimitationsId = formViewModel.PatientRecord.LimitationsId;
                patientRecordInDb.PathReview = formViewModel.PatientRecord.PathReview;
                patientRecordInDb.WorkloadId = formViewModel.PatientRecord.WorkloadId;
                patientRecordInDb.Comment = formViewModel.PatientRecord.Comment;
                patientRecordInDb.ContactWithPatient = formViewModel.PatientRecord.ContactWithPatient;
                patientRecordInDb.ReferMD = formViewModel.PatientRecord.ReferMD;
                patientRecordInDb.TriageLevelId = formViewModel.PatientRecord.TriageLevelId;
                patientRecordInDb.TriageTypeId = formViewModel.PatientRecord.TriageTypeId;
            }

            _context.SaveChanges();

            if(formViewModel.DoctorId != formViewModel.PatientRecord.DoctorId)
            {
                //Send Email to Doctor if new patientRecord created or doctor changed.
                //Get Patient details
                var patientDetails = _context.Patients.Single(p => p.PatientRecordId == formViewModel.PatientRecord.Id);

                //Get Doctor details
                var doctorDetails = _context.Doctors.Single(d => d.Id == formViewModel.PatientRecord.DoctorId);
                Execute(patientDetails, doctorDetails).Wait();
            }
            return RedirectToAction("Index", "Patients");
        }

        //Edit Patient Records
        public ActionResult Edit(Guid id)
        {
            var patientRecord = _context.PatientRecords.SingleOrDefault(p => p.Id == id);
            var patient = _context.Patients.SingleOrDefault(pa => pa.PatientRecordId == id);

            if (patientRecord == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new PatientRecordsFormViewModel
                {
                    PatientRecord = patientRecord,
                    Patient = patient,
                    Doctor = _context.Doctors.ToList(),
                    Workload = _context.Workloads.ToList(),
                    Limitations = _context.Limitations.ToList(),
                    Diagnosis = _context.Diagnosis.ToList(),
                    DoctorId = patientRecord.DoctorId,
                    TriageLevel = _context.TriageLevels.ToList(),
                    TriageType = _context.TriageType.ToList()
                };
                return View("PatientRecordsForm", viewModel);
            }
        }

        //Send Mail Task
        static async Task Execute(Patient patient, Doctor doctor)
        {
            string apiKey = Environment.GetEnvironmentVariable("SendGridKey", EnvironmentVariableTarget.Machine);
            dynamic sg = new SendGridAPIClient(apiKey);

            
            Email from = new Email("test@triageme.com");
            string subject = "New patient created";
            Email to = new Email("mwilters@telus.net");
            Content content = new Content("text/plain", "Hello " + doctor.Name + ".  You have a new patient. Patient name is " + patient.Name + ".  The patients PHN is " + patient.Acbn + ".");
            Mail mail = new Mail(from, subject, to, content);
            mail.TemplateId = "4dcfa9f7-e30a-42ec-9ab5-51bcaa0bfc54";

            dynamic response = await sg.client.mail.send.post(requestBody: mail.Get());
        }
    }
}