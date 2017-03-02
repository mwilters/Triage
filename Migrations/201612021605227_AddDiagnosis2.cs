namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDiagnosis2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diagnosis",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Diagnosis");
        }
    }
}
