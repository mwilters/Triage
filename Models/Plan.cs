using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Triage.Models
{
    public class Plan
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string StripePlan { get; set; }
    }
}