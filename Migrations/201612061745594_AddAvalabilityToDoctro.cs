namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvalabilityToDoctro : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Availabilities", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Availabilities", new[] { "DoctorId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Availabilities", "DoctorId");
            AddForeignKey("dbo.Availabilities", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
        }
    }
}
