using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Triage.Models;

namespace Triage.ViewModels
{
    public class PatientRecordsFormViewModel
    {
        public PatientRecord PatientRecord { get; set; }
        public Patient Patient { get; set; }

        public IEnumerable<Diagnosis> Diagnosis { get; set; }
        public IEnumerable<Doctor> Doctor { get; set; }
        public IEnumerable<Limitations> Limitations { get; set; }
        public IEnumerable<Workload> Workload { get; set; }
        public IEnumerable<DxCode> DxCode { get; set; }
        public IEnumerable<DIRequest> DiRequest { get; set; }
        public IEnumerable<TriageLevel> TriageLevel { get; set; }
        public IEnumerable<TriageType> TriageType { get; set; }

        public Guid? DoctorId { get; set; }

       
    }
}