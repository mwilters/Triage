namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFieldsToPatientAddPatientRecordsAddedNullablePart2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PatientRecords", "RefCompleteForTriage", c => c.Boolean());
            AlterColumn("dbo.PatientRecords", "ContactWithPatient", c => c.Boolean());
            AlterColumn("dbo.PatientRecords", "ContactWithReferringMD", c => c.Boolean());
            AlterColumn("dbo.PatientRecords", "PathReview", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PatientRecords", "PathReview", c => c.Boolean(nullable: false));
            AlterColumn("dbo.PatientRecords", "ContactWithReferringMD", c => c.Boolean(nullable: false));
            AlterColumn("dbo.PatientRecords", "ContactWithPatient", c => c.Boolean(nullable: false));
            AlterColumn("dbo.PatientRecords", "RefCompleteForTriage", c => c.Boolean(nullable: false));
        }
    }
}
