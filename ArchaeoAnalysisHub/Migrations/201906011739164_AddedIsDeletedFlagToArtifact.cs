namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsDeletedFlagToArtifact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artifacts", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artifacts", "IsDeleted");
        }
    }
}
