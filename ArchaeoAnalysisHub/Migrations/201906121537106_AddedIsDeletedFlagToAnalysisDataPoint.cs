namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsDeletedFlagToAnalysisDataPoint : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnalysisDataPoints", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AnalysisDataPoints", "IsDeleted");
        }
    }
}
