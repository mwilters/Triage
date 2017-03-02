namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDefaultValuesFromSeed3 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Workloads SET Description = 'Low'");
        }
        
        public override void Down()
        {
        }
    }
}
