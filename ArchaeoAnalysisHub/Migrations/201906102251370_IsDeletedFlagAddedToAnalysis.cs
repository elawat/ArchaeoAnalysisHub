namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsDeletedFlagAddedToAnalysis : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Analyses", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Analyses", "IsDeleted");
        }
    }
}
