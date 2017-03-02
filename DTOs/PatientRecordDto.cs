using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Triage.Models;

namespace Triage.DTOs
{
    public class PatientRecordDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Diagnosis")]
        public Guid? DiagnosisId { get; set; }
        public Diagnosis Diagnosis { get; set; }

        [Display(Name = "Date Received")]
        public DateTime? DateReceived { get; set; }

        [Display(Name = "Referal Complete For Triage")]
        public bool RefCompleteForTriage { get; set; }

        [Display(Name = "Limitations to Triage")]
        public Guid? LimitationsId { get; set; }
        public Limitations Limitations { get; set; }

        [Display(Name = "Path Review Complete")]
        public bool PathReview { get; set; }

        [Display(Name = "Consult Date")]
        public DateTime? ConsultDate { get; set; }

        [Display(Name = "Assigned Doctor")]
        public Guid? DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public TriageLevel TriageLevel { get; set; }

        [Display(Name = "Triage Level")]
        public Guid? TriageLevelId { get; set; }

        public TriageType TriageType { get; set; }

        [Display(Name = "Triage Type")]
        public Guid? TriageTypeId { get; set; }

        [Display(Name = "Triage Date")]
        public DateTime? TriageDate { get; set; }

        [Display(Name = "Workload")]
        public Guid? WorkloadId { get; set; }
        public Workload Workload { get; set; }

        [Display(Name = "Wait List")]
        public int? WaitList { get; set; }

        [Display(Name = "Clinical Trials")]
        public bool ClinicalTrials { get; set; }
    }
}