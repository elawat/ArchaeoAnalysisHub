namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAnalysisDataPointModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnalysisDataPoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Symbol = c.String(),
                        ResultInPercentage = c.Double(nullable: false),
                        AnalysisId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Analyses", t => t.AnalysisId, cascadeDelete: true)
                .Index(t => t.AnalysisId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnalysisDataPoints", "AnalysisId", "dbo.Analyses");
            DropIndex("dbo.AnalysisDataPoints", new[] { "AnalysisId" });
            DropTable("dbo.AnalysisDataPoints");
        }
    }
}
