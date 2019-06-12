namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedIdDeletedFlags : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Analyses", "IsDeleted");
            DropColumn("dbo.AnalysisDataPoints", "IsDeleted");
            DropColumn("dbo.Samples", "IsDeleted");
            DropColumn("dbo.Artifacts", "IsDeleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Artifacts", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Samples", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.AnalysisDataPoints", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Analyses", "IsDeleted", c => c.Boolean(nullable: false));
        }
    }
}
