using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Triage.Models;

namespace Triage.ViewModels
{
    public class AllPatientsViewModel
    {
        public List<Patient> Patients { get; set; }
    }
}