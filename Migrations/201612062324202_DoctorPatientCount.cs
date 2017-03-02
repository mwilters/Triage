namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoctorPatientCount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "patientCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "patientCount");
        }
    }
}
