namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvalabilityAddedAllDaysChangedColumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Availabilities", "Monday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Availabilities", "Tuesday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Availabilities", "Wednesday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Availabilities", "Thursday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Availabilities", "Friday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Availabilities", "Saturday", c => c.Boolean(nullable: false));
            AddColumn("dbo.Availabilities", "Sunday", c => c.Boolean(nullable: false));
            DropColumn("dbo.Availabilities", "IsAvailableMon");
            DropColumn("dbo.Availabilities", "IsAvailableTue");
            DropColumn("dbo.Availabilities", "IsAvailableWed");
            DropColumn("dbo.Availabilities", "IsAvailableThurs");
            DropColumn("dbo.Availabilities", "IsAvailableFri");
            DropColumn("dbo.Availabilities", "IsAvailableSat");
            DropColumn("dbo.Availabilities", "IsAvailableSun");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Availabilities", "IsAvailableSun", c => c.Boolean(nullable: false));
            AddColumn("dbo.Availabilities", "IsAvailableSat", c => c.Boolean(nullable: false));
            AddColumn("dbo.Availabilities", "IsAvailableFri", c => c.Boolean(nullable: false));
            AddColumn("dbo.Availabilities", "IsAvailableThurs", c => c.Boolean(nullable: false));
            AddColumn("dbo.Availabilities", "IsAvailableWed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Availabilities", "IsAvailableTue", c => c.Boolean(nullable: false));
            AddColumn("dbo.Availabilities", "IsAvailableMon", c => c.Boolean(nullable: false));
            DropColumn("dbo.Availabilities", "Sunday");
            DropColumn("dbo.Availabilities", "Saturday");
            DropColumn("dbo.Availabilities", "Friday");
            DropColumn("dbo.Availabilities", "Thursday");
            DropColumn("dbo.Availabilities", "Wednesday");
            DropColumn("dbo.Availabilities", "Tuesday");
            DropColumn("dbo.Availabilities", "Monday");
        }
    }
}
