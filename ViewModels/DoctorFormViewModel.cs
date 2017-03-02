using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Triage.Models;

namespace Triage.ViewModels
{
    public class DoctorFormViewModel
    {
        public Doctor Doctor { get; set; }
        public IEnumerable<Availability> Availability { get; set; }
        public Dictionary<string,bool> DaysAvailable { get; set; }

    }
}