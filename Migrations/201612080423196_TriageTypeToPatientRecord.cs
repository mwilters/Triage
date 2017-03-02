namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TriageTypeToPatientRecord : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TriageTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PatientRecords", "TriageLevelId", c => c.Guid());
            AddColumn("dbo.PatientRecords", "TriageTypeId", c => c.Guid());
            CreateIndex("dbo.PatientRecords", "TriageLevelId");
            CreateIndex("dbo.PatientRecords", "TriageTypeId");
            AddForeignKey("dbo.PatientRecords", "TriageLevelId", "dbo.TriageLevels", "Id");
            AddForeignKey("dbo.PatientRecords", "TriageTypeId", "dbo.TriageTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientRecords", "TriageTypeId", "dbo.TriageTypes");
            DropForeignKey("dbo.PatientRecords", "TriageLevelId", "dbo.TriageLevels");
            DropIndex("dbo.PatientRecords", new[] { "TriageTypeId" });
            DropIndex("dbo.PatientRecords", new[] { "TriageLevelId" });
            DropColumn("dbo.PatientRecords", "TriageTypeId");
            DropColumn("dbo.PatientRecords", "TriageLevelId");
            DropTable("dbo.TriageTypes");
        }
    }
}
