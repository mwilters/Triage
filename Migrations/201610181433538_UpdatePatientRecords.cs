namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePatientRecords : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientRecords", "RefCompleteForTriage", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Doctors", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.PatientRecords", "DateReceived", c => c.DateTime());
            AlterColumn("dbo.PatientRecords", "ConsultDate", c => c.DateTime());
            AlterColumn("dbo.PatientRecords", "TriageDate", c => c.DateTime());
            AlterColumn("dbo.PatientRecords", "WaitList", c => c.Int());
            AlterColumn("dbo.Patients", "Acbn", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.PatientRecords", "PatientId");
            CreateIndex("dbo.PatientRecords", "LimitationsId");
            CreateIndex("dbo.PatientRecords", "DIRequestId");
            CreateIndex("dbo.PatientRecords", "DoctorId");
            CreateIndex("dbo.PatientRecords", "WorkloadId");
            CreateIndex("dbo.PatientRecords", "DxCodeId");
            AddForeignKey("dbo.PatientRecords", "DIRequestId", "dbo.DIRequests", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientRecords", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientRecords", "DxCodeId", "dbo.DxCodes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientRecords", "LimitationsId", "dbo.Limitations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientRecords", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientRecords", "WorkloadId", "dbo.Workloads", "Id", cascadeDelete: true);
            DropColumn("dbo.PatientRecords", "RefCcompleteForTriage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PatientRecords", "RefCcompleteForTriage", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.PatientRecords", "WorkloadId", "dbo.Workloads");
            DropForeignKey("dbo.PatientRecords", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.PatientRecords", "LimitationsId", "dbo.Limitations");
            DropForeignKey("dbo.PatientRecords", "DxCodeId", "dbo.DxCodes");
            DropForeignKey("dbo.PatientRecords", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.PatientRecords", "DIRequestId", "dbo.DIRequests");
            DropIndex("dbo.PatientRecords", new[] { "DxCodeId" });
            DropIndex("dbo.PatientRecords", new[] { "WorkloadId" });
            DropIndex("dbo.PatientRecords", new[] { "DoctorId" });
            DropIndex("dbo.PatientRecords", new[] { "DIRequestId" });
            DropIndex("dbo.PatientRecords", new[] { "LimitationsId" });
            DropIndex("dbo.PatientRecords", new[] { "PatientId" });
            AlterColumn("dbo.Patients", "Name", c => c.String());
            AlterColumn("dbo.Patients", "Acbn", c => c.String());
            AlterColumn("dbo.PatientRecords", "WaitList", c => c.Int(nullable: false));
            AlterColumn("dbo.PatientRecords", "TriageDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PatientRecords", "ConsultDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PatientRecords", "DateReceived", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Doctors", "Name", c => c.String());
            DropColumn("dbo.PatientRecords", "RefCompleteForTriage");
        }
    }
}
