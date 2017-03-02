using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Triage.Models;
using Triage.ViewModels;

namespace Triage.Controllers
{
    public class PatientsController : Controller
    {
        //Getting data from database
        private ApplicationDbContext _context;

        public PatientsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Patients
        public ActionResult Index()
        {
            var patients = _context.Patients.ToList();

            foreach (Patient p in patients)
            {
                p.PatientRecord = _context.PatientRecords.SingleOrDefault(pr => pr.Id == p.PatientRecordId);
                p.PatientRecord.TriageLevel = _context.TriageLevels.SingleOrDefault(t => t.Id == p.PatientRecord.TriageLevelId);
                p.PatientRecord.TriageType = _context.TriageType.SingleOrDefault(t => t.Id == p.PatientRecord.TriageTypeId);
            }

            return View(patients);
        }

        //New Patient Action
        public ActionResult New()
        {
            //Get List of membership types
            var patients = _context.Patients.ToList();
            //var triageLevel = _context.TriageLevels.ToList();
            //var triageType = _context.TriageType.ToList();

            var viewModel = new PatientFormViewModel
            {
                //add Patient details to the ViewModel
                Patient = new Patient(),
                //TriageLevel = triageLevel
            };
            return View("PatientForm", viewModel);
        }

        //Save Patient
        //Data Binding
        //Here the PatientFormViewModel called formViewModel is bound to the request data.
        //Could also use the Patient object because the form componenents were all prefixed with Patient.  VS is smart enough to figure this out. 
        [HttpPost]//User HttpPost
        [ValidateAntiForgeryToken]//Use this along with the Html Anti forgery helper on the View
        public ActionResult Save(PatientFormViewModel formViewModel)
        {

            if (!ModelState.IsValid)//Use Model State when implementing validation.  You can use ModelState to chnage the flow of the application.
            {
                var viewModel = new PatientFormViewModel
                {
                    Patient = formViewModel.Patient
                };
                return View("PatientForm", viewModel);
            }

            if (formViewModel.Patient.Id == Guid.Empty)
            {
                //if creating new patient if does not exist, need to create new patient record
                var patientRecord = new PatientRecord();

                //need to add PatientRecordID to new patient object
                formViewModel.Patient.PatientRecordId = patientRecord.Id;

                //Write the new patient data to the database
                _context.Patients.Add(formViewModel.Patient);
                _context.PatientRecords.Add(patientRecord);

                _context.SaveChanges();

                //Get New PaientId to pass to PatientRecords
                var patientId = formViewModel.Patient.PatientRecordId;

                return RedirectToAction("Edit", "PatientRecords", new { id = patientId });


            }
            else
            {
                //Patient exists - updating records
                var patientInDb = _context.Patients.Single(c => c.Id == formViewModel.Patient.Id);

                //Mapper.Map(customer, customerInDB)
                patientInDb.Name = formViewModel.Patient.Name;
                patientInDb.DateOfBirth = formViewModel.Patient.DateOfBirth;
                patientInDb.HasInsuracne = formViewModel.Patient.HasInsuracne;
                //patientInDb.TriageLevelId = formViewModel.Patient.TriageLevelId;

                _context.SaveChanges();

                return RedirectToAction("Index", "Patients");
            }
        }

        //Edit Patient
        public ActionResult Edit(Guid id)
        {
            var patient = _context.Patients.SingleOrDefault(p => p.Id == id);
            //var triageLevel = _context.TriageLevels.ToList();

            if (patient == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new PatientFormViewModel
                {
                    Patient = patient,
                    //TriageLevel = triageLevel
                };
                return View("PatientForm", viewModel);
            }
        }
    }


}