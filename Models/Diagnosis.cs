using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Triage.Models
{
    public class Diagnosis
    {
        
        public Guid Id { get; set; }

        [Required]
        public string Description { get; set; }
    }
}