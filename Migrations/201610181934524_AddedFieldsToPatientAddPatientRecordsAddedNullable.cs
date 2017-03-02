namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFieldsToPatientAddPatientRecordsAddedNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PatientRecords", "DIRequestId", "dbo.DIRequests");
            DropForeignKey("dbo.PatientRecords", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.PatientRecords", "DxCodeId", "dbo.DxCodes");
            DropForeignKey("dbo.PatientRecords", "LimitationsId", "dbo.Limitations");
            DropForeignKey("dbo.PatientRecords", "WorkloadId", "dbo.Workloads");
            DropIndex("dbo.PatientRecords", new[] { "LimitationsId" });
            DropIndex("dbo.PatientRecords", new[] { "DIRequestId" });
            DropIndex("dbo.PatientRecords", new[] { "DoctorId" });
            DropIndex("dbo.PatientRecords", new[] { "WorkloadId" });
            DropIndex("dbo.PatientRecords", new[] { "DxCodeId" });
            AlterColumn("dbo.PatientRecords", "LimitationsId", c => c.Guid());
            AlterColumn("dbo.PatientRecords", "DIRequestId", c => c.Guid());
            AlterColumn("dbo.PatientRecords", "DoctorId", c => c.Guid());
            AlterColumn("dbo.PatientRecords", "WorkloadId", c => c.Guid());
            AlterColumn("dbo.PatientRecords", "ClinicalTrials", c => c.Boolean());
            AlterColumn("dbo.PatientRecords", "DxCodeId", c => c.Guid());
            CreateIndex("dbo.PatientRecords", "LimitationsId");
            CreateIndex("dbo.PatientRecords", "DIRequestId");
            CreateIndex("dbo.PatientRecords", "DoctorId");
            CreateIndex("dbo.PatientRecords", "WorkloadId");
            CreateIndex("dbo.PatientRecords", "DxCodeId");
            AddForeignKey("dbo.PatientRecords", "DIRequestId", "dbo.DIRequests", "Id");
            AddForeignKey("dbo.PatientRecords", "DoctorId", "dbo.Doctors", "Id");
            AddForeignKey("dbo.PatientRecords", "DxCodeId", "dbo.DxCodes", "Id");
            AddForeignKey("dbo.PatientRecords", "LimitationsId", "dbo.Limitations", "Id");
            AddForeignKey("dbo.PatientRecords", "WorkloadId", "dbo.Workloads", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientRecords", "WorkloadId", "dbo.Workloads");
            DropForeignKey("dbo.PatientRecords", "LimitationsId", "dbo.Limitations");
            DropForeignKey("dbo.PatientRecords", "DxCodeId", "dbo.DxCodes");
            DropForeignKey("dbo.PatientRecords", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.PatientRecords", "DIRequestId", "dbo.DIRequests");
            DropIndex("dbo.PatientRecords", new[] { "DxCodeId" });
            DropIndex("dbo.PatientRecords", new[] { "WorkloadId" });
            DropIndex("dbo.PatientRecords", new[] { "DoctorId" });
            DropIndex("dbo.PatientRecords", new[] { "DIRequestId" });
            DropIndex("dbo.PatientRecords", new[] { "LimitationsId" });
            AlterColumn("dbo.PatientRecords", "DxCodeId", c => c.Guid(nullable: false));
            AlterColumn("dbo.PatientRecords", "ClinicalTrials", c => c.Boolean(nullable: false));
            AlterColumn("dbo.PatientRecords", "WorkloadId", c => c.Guid(nullable: false));
            AlterColumn("dbo.PatientRecords", "DoctorId", c => c.Guid(nullable: false));
            AlterColumn("dbo.PatientRecords", "DIRequestId", c => c.Guid(nullable: false));
            AlterColumn("dbo.PatientRecords", "LimitationsId", c => c.Guid(nullable: false));
            CreateIndex("dbo.PatientRecords", "DxCodeId");
            CreateIndex("dbo.PatientRecords", "WorkloadId");
            CreateIndex("dbo.PatientRecords", "DoctorId");
            CreateIndex("dbo.PatientRecords", "DIRequestId");
            CreateIndex("dbo.PatientRecords", "LimitationsId");
            AddForeignKey("dbo.PatientRecords", "WorkloadId", "dbo.Workloads", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientRecords", "LimitationsId", "dbo.Limitations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientRecords", "DxCodeId", "dbo.DxCodes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientRecords", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientRecords", "DIRequestId", "dbo.DIRequests", "Id", cascadeDelete: true);
        }
    }
}
