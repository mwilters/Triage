using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Triage.Models
{
    public class Doctor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name="Doctor")]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public Dictionary<string,bool> DaysAvailable { get; set; }

        public int patientCount { get; set; }

        public Doctor()
        {
            //Initialize new Dictionary of DaysAvailable
            DaysAvailable = new Dictionary<string, bool>();
            DaysAvailable.Add("Monday", false);
            DaysAvailable.Add("Tuesday", false);
            DaysAvailable.Add("Wednesday", false);
            DaysAvailable.Add("Thursday", false);
            DaysAvailable.Add("Friday", false);
            DaysAvailable.Add("Saturday", false);
            DaysAvailable.Add("Sunday", false);
        }

    }

}