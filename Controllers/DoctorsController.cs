using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Triage.Models;
using Triage.ViewModels;
using AutoMapper;

namespace Triage.Controllers
{
    public class DoctorsController : Controller
    {
        //Getting data from database
        private ApplicationDbContext _context;

        public DoctorsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Doctors
        public ActionResult Index()
        {
            var doctors = _context.Doctors.ToList();
            var count = 0;
            foreach (Doctor doc in doctors)
            {
                count = _context.PatientRecords.Where(d => d.DoctorId == doc.Id).Count();
                doc.patientCount = count;
            }
            
            return View(doctors);
        }

        //New Doctor Action
        public ActionResult New()
        {
            var doctor = new Doctor();
            var viewModel = new DoctorFormViewModel
            {
                Doctor = doctor
            };

            return View("DoctorForm", viewModel);
        }

        //Save Doctor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Doctor doctor)
        {
            //Use Model State when implementing validation.  You can use ModelState to chnage the flow of the application.
            if (!ModelState.IsValid)
            {
                Doctor Doctor = new Doctor();
                return View("DoctorForm", Doctor);
            }

            if (doctor.Id == Guid.Empty)
            {
                _context.Doctors.Add(doctor);
                _context.SaveChanges();

                //Add New Availability
                AddNewAvailability(doctor);
            }
            else
            {
                var doctorInDb = _context.Doctors.Single(d => d.Id == doctor.Id);

                doctorInDb.Name = doctor.Name;
                doctorInDb.Email = doctor.Email;
                doctorInDb.Phone = doctor.Phone;

                //Call function to manage DaysAvailable
                DaysAvailableHelper(doctor);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Doctors");
        }

        //AddNewAvailability
        public void AddNewAvailability(Doctor doctor)
        {
            var availability = new Availability();

            for (var i = 0; i < doctor.DaysAvailable.Count; i++)
            {
                var item = doctor.DaysAvailable.ElementAt(i);
                var key = item.Key;
                var value = item.Value;

                if (key == "Monday")
                {
                    availability.Monday = value;
                }
                if (key == "Tuesday")
                {
                    availability.Tuesday = value;
                }
                if (key == "Wednesday")
                {
                    availability.Wednesday = value;
                }
                if (key == "Thursday")
                {
                    availability.Thursday = value;
                }
                if (key == "Friday")
                {
                    availability.Friday = value;
                }
                if (key == "Saturday")
                {
                    availability.Saturday = value;
                }
                if (key == "Sunday")
                {
                    availability.Sunday = value;
                }

            }

            var availabilityinDb = _context.Availability.Add(availability);

            availabilityinDb.Id = Guid.NewGuid();
            availabilityinDb.DoctorId = doctor.Id;

            _context.SaveChanges();
        }

        //DaysAvailableHelper
        public void DaysAvailableHelper(Doctor doctor)
        {
            var availabilityinDb = _context.Availability.Single(d => d.DoctorId == doctor.Id);

            for (var i = 0; i < doctor.DaysAvailable.Count; i++)
            {
                var item = doctor.DaysAvailable.ElementAt(i);
                var key = item.Key;
                var value = item.Value;

                if (key == "Monday")
                {
                    availabilityinDb.Monday = value;
                }
                if (key == "Tuesday")
                {
                    availabilityinDb.Tuesday = value;
                }
                if (key == "Wednesday")
                {
                    availabilityinDb.Wednesday = value;
                }
                if (key == "Thursday")
                {
                    availabilityinDb.Thursday = value;
                }
                if (key == "Friday")
                {
                    availabilityinDb.Friday = value;
                }
                if (key == "Saturday")
                {
                    availabilityinDb.Saturday = value;
                }
                if (key == "Sunday")
                {
                    availabilityinDb.Sunday = value;
                }

            }
        }

        //Edit Doctor
        public ActionResult Edit(Guid id)
        {
            var doctor = _context.Doctors.SingleOrDefault(d => d.Id == id);

            if (doctor == null)
            {
                return HttpNotFound();
            }
            else
            {
                var availability = _context.Availability
                .Where(a => a.DoctorId == doctor.Id).ToList();

                var days = new Dictionary<string, bool>();

                foreach(Availability daysAvailable in availability)
                {
                    if (daysAvailable.Monday)
                    {
                        days.Add("Monday", true);
                    }
                    else
                    {
                        days.Add("Monday", false);

                    }
                    if (daysAvailable.Tuesday)
                    {
                        days.Add("Tuesday", true);
                    }
                    else
                    {
                        days.Add("Tuesday", false);

                    }
                    if (daysAvailable.Wednesday)
                    {
                        days.Add("Wednesday", true);
                    }
                    else
                    {
                        days.Add("Wednesday", false);

                    }
                    if (daysAvailable.Thursday)
                    {
                        days.Add("Thursday", true);
                    }
                    else
                    {
                        days.Add("Thursday", false);

                    }
                    if (daysAvailable.Friday)
                    {
                        days.Add("Friday", true);
                    }
                    else
                    {
                        days.Add("Friday", false);

                    }
                    if (daysAvailable.Saturday)
                    {
                        days.Add("Saturday", true);
                    }
                    else
                    {
                        days.Add("Saturday", false);

                    }
                    if (daysAvailable.Sunday)
                    {
                        days.Add("Sunday", true);
                    }
                    else
                    {
                        days.Add("Sunday", false);

                    }
                }

                doctor.DaysAvailable = days;

                var viewModel = new DoctorFormViewModel
                {
                    Doctor = doctor,
                    Availability = availability,
                    DaysAvailable = days,
                    
                };
                return View("DoctorForm", viewModel);
            }
        }
    }
}