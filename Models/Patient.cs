using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Triage.Models
{
    public class Patient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Personal Health Number")]
        [RegularExpression(@"[0-9]{5}-[0-9]{4}", ErrorMessage = "Invalid PHN")]
        [MaxLength(10)]
        public string Acbn { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool HasInsuracne { get; set; }

        [Display(Name="Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        public PatientRecord PatientRecord { get; set; }

        [Display(Name = "Patient Record")]
        public Guid? PatientRecordId { get; set; }

        public TriageLevel TriageLevel { get; set; }

        [Display(Name = "Triage Level")]
        public Guid? TriageLevelId { get; set; }
    }
}