namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNameForSampleAndAnalysis : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Analyses", "Name", c => c.String());
            AddColumn("dbo.Samples", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Samples", "Name");
            DropColumn("dbo.Analyses", "Name");
        }
    }
}
