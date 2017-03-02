namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveValueFieldFromTables : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DIRequests", "Value");
            DropColumn("dbo.DxCodes", "Value");
            DropColumn("dbo.Limitations", "Value");
            DropColumn("dbo.Workloads", "Value");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workloads", "Value", c => c.Int(nullable: false));
            AddColumn("dbo.Limitations", "Value", c => c.Int(nullable: false));
            AddColumn("dbo.DxCodes", "Value", c => c.Int(nullable: false));
            AddColumn("dbo.DIRequests", "Value", c => c.Int(nullable: false));
        }
    }
}
