namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFieldsToPatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "HasInsuracne", c => c.Boolean(nullable: false));
            AddColumn("dbo.Patients", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "DateOfBirth");
            DropColumn("dbo.Patients", "HasInsuracne");
        }
    }
}
