namespace Triage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTriageLevelDomain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TriageLevels",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Patients", "TriageLevelId", c => c.Guid());
            CreateIndex("dbo.Patients", "TriageLevelId");
            AddForeignKey("dbo.Patients", "TriageLevelId", "dbo.TriageLevels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "TriageLevelId", "dbo.TriageLevels");
            DropIndex("dbo.Patients", new[] { "TriageLevelId" });
            DropColumn("dbo.Patients", "TriageLevelId");
            DropTable("dbo.TriageLevels");
        }
    }
}
