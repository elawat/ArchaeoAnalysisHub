namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDataTypesInAnalysisModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Analyses", "GeneralImageId", c => c.Int());
            AlterColumn("dbo.Analyses", "SpectrumImageId", c => c.Int());
            AlterColumn("dbo.Analyses", "SpectrumNo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Analyses", "SpectrumNo", c => c.Int(nullable: false));
            AlterColumn("dbo.Analyses", "SpectrumImageId", c => c.Int(nullable: false));
            AlterColumn("dbo.Analyses", "GeneralImageId", c => c.Int(nullable: false));
        }
    }
}
