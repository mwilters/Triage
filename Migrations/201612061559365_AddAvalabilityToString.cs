namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvalabilityToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Availabilities", "DayOfWeek", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Availabilities", "DayOfWeek", c => c.Int(nullable: false));
        }
    }
}
