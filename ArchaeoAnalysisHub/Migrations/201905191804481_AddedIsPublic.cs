namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsPublic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Analyses", "IsPublic", c => c.Boolean(nullable: false));
            AddColumn("dbo.Samples", "IsPublic", c => c.Boolean(nullable: false));
            AddColumn("dbo.Artifacts", "IsPublic", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artifacts", "IsPublic");
            DropColumn("dbo.Samples", "IsPublic");
            DropColumn("dbo.Analyses", "IsPublic");
        }
    }
}
