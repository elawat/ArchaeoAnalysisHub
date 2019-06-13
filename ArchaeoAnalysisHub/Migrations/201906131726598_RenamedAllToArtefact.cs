namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedAllToArtefact : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Samples", name: "ArtifactId", newName: "ArtefactId");
            RenameIndex(table: "dbo.Samples", name: "IX_ArtifactId", newName: "IX_ArtefactId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Samples", name: "IX_ArtefactId", newName: "IX_ArtifactId");
            RenameColumn(table: "dbo.Samples", name: "ArtefactId", newName: "ArtifactId");
        }
    }
}
