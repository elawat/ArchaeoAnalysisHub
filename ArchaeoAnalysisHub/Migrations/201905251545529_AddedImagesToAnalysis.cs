namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImagesToAnalysis : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Analyses", "GeneralImageId");
            CreateIndex("dbo.Analyses", "SpectrumImageId");
            AddForeignKey("dbo.Analyses", "GeneralImageId", "dbo.Images", "Id");
            AddForeignKey("dbo.Analyses", "SpectrumImageId", "dbo.Images", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Analyses", "SpectrumImageId", "dbo.Images");
            DropForeignKey("dbo.Analyses", "GeneralImageId", "dbo.Images");
            DropIndex("dbo.Analyses", new[] { "SpectrumImageId" });
            DropIndex("dbo.Analyses", new[] { "GeneralImageId" });
        }
    }
}
