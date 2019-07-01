namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequiredForNames : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Analyses", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Samples", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Samples", "Name", c => c.String());
            AlterColumn("dbo.Analyses", "Name", c => c.String());
        }
    }
}
