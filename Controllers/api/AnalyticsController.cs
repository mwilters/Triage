using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Triage.DTOs;
using Triage.Models;

namespace Triage.Controllers.api
{
    public class AnalyticsController : ApiController
    {
        //Implement DB context
        private ApplicationDbContext _context;

        //Initialize the controller
        public AnalyticsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<PatientRecordDto> GetPatientRecords()
        {
            //Here we are use a Delegate(reference to the Mapper.Map method) to map PatientRecord to PatientRecordDTO
            return _context.PatientRecords.Include(c => c.Diagnosis).Include(d => d.Doctor).ToList().Select(Mapper.Map<PatientRecord, PatientRecordDto>);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}