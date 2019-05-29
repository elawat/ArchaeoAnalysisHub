namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSampleAnalysisRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Analyses", "SampleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Analyses", "SampleId");
            AddForeignKey("dbo.Analyses", "SampleId", "dbo.Samples", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Analyses", "SampleId", "dbo.Samples");
            DropIndex("dbo.Analyses", new[] { "SampleId" });
            DropColumn("dbo.Analyses", "SampleId");
        }
    }
}
