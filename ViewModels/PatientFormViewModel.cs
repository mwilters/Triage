using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Triage.Models;

namespace Triage.ViewModels
{
    public class PatientFormViewModel
    {
        public Patient Patient { get; set; }
        public PatientRecord PatientRecord { get; set; }
        //public List<TriageLevel> TriageLevel { get; set; }
    }
}