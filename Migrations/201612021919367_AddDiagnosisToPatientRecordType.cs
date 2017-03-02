namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDiagnosisToPatientRecordType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "Acbn", c => c.String(nullable: false, maxLength: 10));
            CreateIndex("dbo.PatientRecords", "DiagnosisId");
            AddForeignKey("dbo.PatientRecords", "DiagnosisId", "dbo.Diagnosis", "Id");
            DropColumn("dbo.PatientRecords", "Diagnosis");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PatientRecords", "Diagnosis", c => c.String());
            DropForeignKey("dbo.PatientRecords", "DiagnosisId", "dbo.Diagnosis");
            DropIndex("dbo.PatientRecords", new[] { "DiagnosisId" });
            AlterColumn("dbo.Patients", "Acbn", c => c.String(nullable: false));
        }
    }
}
