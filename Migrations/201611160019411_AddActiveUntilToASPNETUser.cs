namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActiveUntilToASPNETUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "active_until", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "active_until");
        }
    }
}
