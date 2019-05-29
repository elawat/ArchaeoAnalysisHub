namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageIdsToAnalysis : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Analyses", "GeneralImageId", c => c.Int(nullable: false));
            AddColumn("dbo.Analyses", "SpectrumImageId", c => c.Int(nullable: false));
            AddColumn("dbo.Analyses", "SpectrumNo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Analyses", "SpectrumNo");
            DropColumn("dbo.Analyses", "SpectrumImageId");
            DropColumn("dbo.Analyses", "GeneralImageId");
        }
    }
}
