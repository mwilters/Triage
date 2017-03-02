using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Triage.DTOs;
using Triage.Models;

namespace Triage.Controllers.api
{
    public class PatientsController : ApiController
    {
        //Implement DB context
        private ApplicationDbContext _context;

        //Initialize the controller
        public PatientsController()
        {
            _context = new ApplicationDbContext();
        }

        //Get a list of all patients /api/patients
        [HttpGet]
        public IEnumerable<PatientDto> GetPatients()
        {
            return _context.Patients.ToList().Select(Mapper.Map<Patient, PatientDto>);
            //Here we are use a Delegate(reference to the Mapper.Map method) to map Customer to CustomerDTO
        }

        //Get a single patient /api/patients/id
        [HttpGet]
        public IHttpActionResult GetPatient(Guid id) //return type needs to the DTO object
        {
            //Get record from DB
            var patient = _context.Patients.SingleOrDefault(c => c.Id == id);

            if (patient == null)
            {
                //if patient is not found throw standart not found exception
                return NotFound();
            }
            else
            {
                //This will return the mapped customer that was returned from the DbContext.  Use the Ok Http helper method to wrap the 
                //return result
                return Ok(Mapper.Map<Patient, PatientDto>(patient));

            }
        }

        //Post create a new patient /api/patient
        [HttpPost] //This decoration flags that method will only ge called if a post request is sent
        //In RestAPI convention the result code of a Create request is 201.  We need to use IHttpActionResult to have more control ver this action.
        public IHttpActionResult CreatePatient(PatientDto patientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); //This is a Http helper method
            }
            else
            {
                var patient = Mapper.Map<PatientDto, Patient>(patientDto);
                _context.Patients.Add(patient);
                _context.SaveChanges();

                //Here we need to pass the Id that was created by the DB back to the customerDto object
                patientDto.Id = patient.Id;

                return Created(new Uri(Request.RequestUri + "/" + patient.Id), patientDto);
            }
        }

        //Put /api/patients/id
        [HttpPut]
        public void UpdatePatient(Guid id, PatientDto patientDto) //Need to pass in the patient and id from the request
        {
            //Check the state of the data
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                //Get the patient data from DB
                var patientInDb = _context.Patients.SingleOrDefault(p => p.Id == id);

                if (patientInDb == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    //Here we are mapping the DTO object to the domain object and need to pass both arguments to the Map method.
                    Mapper.Map(patientDto, patientInDb);
                    _context.SaveChanges();
                }
            }
        }

        //Delete api/patients/id
        [HttpDelete]
        public void DeletePatient(Guid id)
        {
            //Get the patient data from DB
            var patientInDb = _context.Patients.SingleOrDefault(p => p.Id == id);

            //Check if the data returned is good
            if (patientInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                //Mark the record to be removed
                _context.Patients.Remove(patientInDb);
                //Save changes to remove the record
                _context.SaveChanges();
            }

        }
    }
}
