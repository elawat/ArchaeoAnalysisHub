namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDepicting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Depictings",
                c => new
                    {
                        AnalysisId = c.Int(nullable: false),
                        ImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AnalysisId, t.ImageId })
                .ForeignKey("dbo.Analyses", t => t.AnalysisId, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.ImageId, cascadeDelete: true)
                .Index(t => t.AnalysisId)
                .Index(t => t.ImageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Depictings", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Depictings", "AnalysisId", "dbo.Analyses");
            DropIndex("dbo.Depictings", new[] { "ImageId" });
            DropIndex("dbo.Depictings", new[] { "AnalysisId" });
            DropTable("dbo.Depictings");
        }
    }
}
