namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvalability2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Availabilities", "DoctorId");
            AddForeignKey("dbo.Availabilities", "DoctorId", "dbo.Doctors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Availabilities", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Availabilities", new[] { "DoctorId" });
        }
    }
}
