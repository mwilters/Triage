namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvalabilityAddedAllDays : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Availabilities", "IsAvailableMon", c => c.Boolean(nullable: false));
            AddColumn("dbo.Availabilities", "IsAvailableTue", c => c.Boolean(nullable: false));
            AddColumn("dbo.Availabilities", "IsAvailableWed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Availabilities", "IsAvailableThurs", c => c.Boolean(nullable: false));
            AddColumn("dbo.Availabilities", "IsAvailableFri", c => c.Boolean(nullable: false));
            AddColumn("dbo.Availabilities", "IsAvailableSat", c => c.Boolean(nullable: false));
            AddColumn("dbo.Availabilities", "IsAvailableSun", c => c.Boolean(nullable: false));
            DropColumn("dbo.Availabilities", "IsAvailable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Availabilities", "IsAvailable", c => c.Boolean(nullable: false));
            DropColumn("dbo.Availabilities", "IsAvailableSun");
            DropColumn("dbo.Availabilities", "IsAvailableSat");
            DropColumn("dbo.Availabilities", "IsAvailableFri");
            DropColumn("dbo.Availabilities", "IsAvailableThurs");
            DropColumn("dbo.Availabilities", "IsAvailableWed");
            DropColumn("dbo.Availabilities", "IsAvailableTue");
            DropColumn("dbo.Availabilities", "IsAvailableMon");
        }
    }
}
