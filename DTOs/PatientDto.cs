using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Triage.Models;

namespace Triage.DTOs
{
    public class PatientDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Acbn { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool HasInsuracne { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Guid? PatientRecordId { get; set; }

        public Guid? TriageLevelId { get; set; }
    }
}