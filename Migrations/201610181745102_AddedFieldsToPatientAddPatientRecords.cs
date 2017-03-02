namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFieldsToPatientAddPatientRecords : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PatientRecords", "PatientId", "dbo.Patients");
            DropIndex("dbo.PatientRecords", new[] { "PatientId" });
            AddColumn("dbo.Patients", "PatientRecordId", c => c.Guid());
            CreateIndex("dbo.Patients", "PatientRecordId");
            AddForeignKey("dbo.Patients", "PatientRecordId", "dbo.PatientRecords", "Id");
            DropColumn("dbo.PatientRecords", "PatientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PatientRecords", "PatientId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Patients", "PatientRecordId", "dbo.PatientRecords");
            DropIndex("dbo.Patients", new[] { "PatientRecordId" });
            DropColumn("dbo.Patients", "PatientRecordId");
            CreateIndex("dbo.PatientRecords", "PatientId");
            AddForeignKey("dbo.PatientRecords", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
        }
    }
}
