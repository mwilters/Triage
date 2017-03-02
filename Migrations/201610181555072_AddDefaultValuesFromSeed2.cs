namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDefaultValuesFromSeed2 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Workloads SET Description = 'Low' WHERE Id = NULL");
        }
        
        public override void Down()
        {
        }
    }
}
