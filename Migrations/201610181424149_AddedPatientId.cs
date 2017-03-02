namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPatientId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientRecords", "PatientId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientRecords", "PatientId");
        }
    }
}
