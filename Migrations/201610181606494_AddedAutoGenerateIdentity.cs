namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAutoGenerateIdentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PatientRecords", "DIRequestId", "dbo.DIRequests");
            DropForeignKey("dbo.PatientRecords", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.PatientRecords", "DxCodeId", "dbo.DxCodes");
            DropForeignKey("dbo.PatientRecords", "LimitationsId", "dbo.Limitations");
            DropForeignKey("dbo.PatientRecords", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.PatientRecords", "WorkloadId", "dbo.Workloads");
            DropPrimaryKey("dbo.DIRequests");
            DropPrimaryKey("dbo.Doctors");
            DropPrimaryKey("dbo.DxCodes");
            DropPrimaryKey("dbo.Limitations");
            DropPrimaryKey("dbo.PatientRecords");
            DropPrimaryKey("dbo.Patients");
            DropPrimaryKey("dbo.Workloads");
            AlterColumn("dbo.DIRequests", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Doctors", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.DxCodes", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Limitations", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.PatientRecords", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Patients", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Workloads", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.DIRequests", "Id");
            AddPrimaryKey("dbo.Doctors", "Id");
            AddPrimaryKey("dbo.DxCodes", "Id");
            AddPrimaryKey("dbo.Limitations", "Id");
            AddPrimaryKey("dbo.PatientRecords", "Id");
            AddPrimaryKey("dbo.Patients", "Id");
            AddPrimaryKey("dbo.Workloads", "Id");
            AddForeignKey("dbo.PatientRecords", "DIRequestId", "dbo.DIRequests", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientRecords", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientRecords", "DxCodeId", "dbo.DxCodes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientRecords", "LimitationsId", "dbo.Limitations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientRecords", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientRecords", "WorkloadId", "dbo.Workloads", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientRecords", "WorkloadId", "dbo.Workloads");
            DropForeignKey("dbo.PatientRecords", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.PatientRecords", "LimitationsId", "dbo.Limitations");
            DropForeignKey("dbo.PatientRecords", "DxCodeId", "dbo.DxCodes");
            DropForeignKey("dbo.PatientRecords", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.PatientRecords", "DIRequestId", "dbo.DIRequests");
            DropPrimaryKey("dbo.Workloads");
            DropPrimaryKey("dbo.Patients");
            DropPrimaryKey("dbo.PatientRecords");
            DropPrimaryKey("dbo.Limitations");
            DropPrimaryKey("dbo.DxCodes");
            DropPrimaryKey("dbo.Doctors");
            DropPrimaryKey("dbo.DIRequests");
            AlterColumn("dbo.Workloads", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Patients", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.PatientRecords", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Limitations", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.DxCodes", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Doctors", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.DIRequests", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Workloads", "Id");
            AddPrimaryKey("dbo.Patients", "Id");
            AddPrimaryKey("dbo.PatientRecords", "Id");
            AddPrimaryKey("dbo.Limitations", "Id");
            AddPrimaryKey("dbo.DxCodes", "Id");
            AddPrimaryKey("dbo.Doctors", "Id");
            AddPrimaryKey("dbo.DIRequests", "Id");
            AddForeignKey("dbo.PatientRecords", "WorkloadId", "dbo.Workloads", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientRecords", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientRecords", "LimitationsId", "dbo.Limitations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientRecords", "DxCodeId", "dbo.DxCodes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientRecords", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientRecords", "DIRequestId", "dbo.DIRequests", "Id", cascadeDelete: true);
        }
    }
}
