namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAddedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Analyses", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Samples", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Artifacts", "AddedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artifacts", "AddedDate");
            DropColumn("dbo.Samples", "AddedDate");
            DropColumn("dbo.Analyses", "AddedDate");
        }
    }
}
