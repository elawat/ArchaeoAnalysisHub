namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLocationToArtifact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artifacts", "Country", c => c.String());
            AddColumn("dbo.Artifacts", "Site", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artifacts", "Site");
            DropColumn("dbo.Artifacts", "Country");
        }
    }
}
