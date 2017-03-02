namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlanStripeName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plans", "StripePlan", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Plans", "StripePlan");
        }
    }
}
