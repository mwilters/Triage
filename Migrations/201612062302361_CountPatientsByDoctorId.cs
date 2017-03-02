namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CountPatientsByDoctorId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Phone", c => c.String(nullable: false));

            CreateStoredProcedure(
                "dbo.CountPatientsByDoctorId",
                p => new
                {
                    DoctorId = p.Guid()
                },
                body:
                    @"SELECT COUNT(Id)
                    FROM PatientRecords
                    WHERE DoctorId = @DoctorId"
                );
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "Phone");
        }
    }
}
