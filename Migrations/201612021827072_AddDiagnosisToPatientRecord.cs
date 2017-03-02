namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDiagnosisToPatientRecord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientRecords", "DiagnosisId", c => c.Guid());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientRecords", "DiagnosisId");
        }
    }
}
