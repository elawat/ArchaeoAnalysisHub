namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOwners : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Analyses", "OwnerId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Samples", "OwnerId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Artifacts", "OwnerId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Analyses", "OwnerId");
            CreateIndex("dbo.Samples", "OwnerId");
            CreateIndex("dbo.Artifacts", "OwnerId");
            AddForeignKey("dbo.Analyses", "OwnerId", "dbo.AspNetUsers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Artifacts", "OwnerId", "dbo.AspNetUsers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Samples", "OwnerId", "dbo.AspNetUsers", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Samples", "OwnerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Artifacts", "OwnerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Analyses", "OwnerId", "dbo.AspNetUsers");
            DropIndex("dbo.Artifacts", new[] { "OwnerId" });
            DropIndex("dbo.Samples", new[] { "OwnerId" });
            DropIndex("dbo.Analyses", new[] { "OwnerId" });
            DropColumn("dbo.Artifacts", "OwnerId");
            DropColumn("dbo.Samples", "OwnerId");
            DropColumn("dbo.Analyses", "OwnerId");
        }
    }
}
