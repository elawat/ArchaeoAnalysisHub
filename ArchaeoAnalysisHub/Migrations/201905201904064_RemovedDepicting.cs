namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedDepicting : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Depictings", "AnalysisId", "dbo.Analyses");
            DropForeignKey("dbo.Depictings", "ImageId", "dbo.Images");
            DropIndex("dbo.Depictings", new[] { "AnalysisId" });
            DropIndex("dbo.Depictings", new[] { "ImageId" });
            DropTable("dbo.Depictings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Depictings",
                c => new
                    {
                        AnalysisId = c.Int(nullable: false),
                        ImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AnalysisId, t.ImageId });
            
            CreateIndex("dbo.Depictings", "ImageId");
            CreateIndex("dbo.Depictings", "AnalysisId");
            AddForeignKey("dbo.Depictings", "ImageId", "dbo.Images", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Depictings", "AnalysisId", "dbo.Analyses", "Id", cascadeDelete: true);
        }
    }
}
