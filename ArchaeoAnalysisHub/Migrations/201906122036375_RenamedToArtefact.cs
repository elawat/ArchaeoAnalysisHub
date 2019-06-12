namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedToArtefact : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Artifacts", newName: "Artefacts");
            RenameTable(name: "dbo.ArtifactTypes", newName: "ArtefactTypes");
            RenameColumn(table: "dbo.Artefacts", name: "ArtifactTypeId", newName: "ArtefactTypeId");
            RenameIndex(table: "dbo.Artefacts", name: "IX_ArtifactTypeId", newName: "IX_ArtefactTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Artefacts", name: "IX_ArtefactTypeId", newName: "IX_ArtifactTypeId");
            RenameColumn(table: "dbo.Artefacts", name: "ArtefactTypeId", newName: "ArtifactTypeId");
            RenameTable(name: "dbo.ArtefactTypes", newName: "ArtifactTypes");
            RenameTable(name: "dbo.Artefacts", newName: "Artifacts");
        }
    }
}
