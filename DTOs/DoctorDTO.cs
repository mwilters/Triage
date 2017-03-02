using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Triage.Models;

namespace Triage.DTOs
{
    public class DoctorDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Doctor")]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public List<Availability> DaysAvailable { get; set; }
    }
}