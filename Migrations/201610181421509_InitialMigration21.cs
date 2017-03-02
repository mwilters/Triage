namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration21 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DIRequests",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DxCodes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Limitations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PatientRecords",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Diagnosis = c.String(),
                        ReferMD = c.String(),
                        DateReceived = c.DateTime(nullable: false),
                        RefCcompleteForTriage = c.Boolean(nullable: false),
                        LimitationsId = c.Guid(nullable: false),
                        ContactWithPatient = c.Boolean(nullable: false),
                        ContactWithReferringMD = c.Boolean(nullable: false),
                        PathReview = c.Boolean(nullable: false),
                        DIRequestId = c.Guid(nullable: false),
                        ConsultDate = c.DateTime(nullable: false),
                        DoctorId = c.Guid(nullable: false),
                        TriageDate = c.DateTime(nullable: false),
                        WorkloadId = c.Guid(nullable: false),
                        WaitList = c.Int(nullable: false),
                        ClinicalTrials = c.Boolean(nullable: false),
                        DxCodeId = c.Guid(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Acbn = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Workloads",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Workloads");
            DropTable("dbo.Patients");
            DropTable("dbo.PatientRecords");
            DropTable("dbo.Limitations");
            DropTable("dbo.DxCodes");
            DropTable("dbo.Doctors");
            DropTable("dbo.DIRequests");
        }
    }
}
