namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvalabilityAddedAllDaysRevert : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Availabilities", "IsAvailable", c => c.Boolean(nullable: false));
            DropColumn("dbo.Availabilities", "Monday");
            DropColumn("dbo.Availabilities", "Tuesday");
            DropColumn("dbo.Availabilities", "Wednesday");
            DropColumn("dbo.Availabilities", "Thursday");
            DropColumn("dbo.Availabilities", "Friday");
            DropColumn("dbo.Availabilities", "Saturday");
            DropColumn("dbo.Availabilities", "Sunday");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Availabilities", "Sunday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Availabilities", "Saturday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Availabilities", "Friday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Availabilities", "Thursday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Availabilities", "Wednesday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Availabilities", "Tuesday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Availabilities", "Monday", c => c.Boolean(nullable: false));
            DropColumn("dbo.Availabilities", "IsAvailable");
        }
    }
}
