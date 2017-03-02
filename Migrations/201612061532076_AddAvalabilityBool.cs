namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvalabilityBool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Availabilities", "IsAvailable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Availabilities", "IsAvailable");
        }
    }
}
