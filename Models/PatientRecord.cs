using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Triage.Models
{
    public class PatientRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        //public Guid PatientId { get; set; }
        //public Patient Patient { get; set; }

        [Display(Name = "Diagnosis")]
        public Guid? DiagnosisId { get; set; }
        public Diagnosis Diagnosis { get; set; }

        [Display(Name="Referring MD")]
        public string ReferMD { get; set; }

        [Display(Name = "Date Received")]
        public DateTime? DateReceived { get; set; }

        [Display(Name = "Referal Complete For Triage")]
        public bool RefCompleteForTriage { get; set; }

        [Display(Name="Limitations to Triage")]
        public Guid? LimitationsId { get; set; }
        public Limitations Limitations { get; set; }

        [Display(Name = "Contact With Patient")]
        public bool ContactWithPatient { get; set; }

        [Display(Name = "Contact With Referring Doctor")]
        public bool ContactWithReferringMD { get; set; }

        [Display(Name = "Path Review Complete")]
        public bool PathReview { get; set; }

        [Display(Name = "Diagnostic Imaging Request")]
        public Guid? DIRequestId { get; set; }
        public DIRequest DIRequest { get; set; }

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

        [Display(Name = "Dx Code")]
        public Guid? DxCodeId { get; set; }
        public DxCode DxCode { get; set; }

        public string Comment { get; set; }

    }
}