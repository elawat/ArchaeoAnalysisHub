namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedArtifactModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artifacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ArtifactTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArtifactTypes", t => t.ArtifactTypeId, cascadeDelete: true)
                .Index(t => t.ArtifactTypeId);
            
            CreateTable(
                "dbo.ArtifactTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SampleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Samples", "ArtifactId", c => c.Int(nullable: false));
            AddColumn("dbo.Samples", "SampleTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Samples", "ArtifactId");
            CreateIndex("dbo.Samples", "SampleTypeId");
            AddForeignKey("dbo.Samples", "ArtifactId", "dbo.Artifacts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Samples", "SampleTypeId", "dbo.SampleTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Samples", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Samples", "Amount", c => c.Int(nullable: false));
            DropForeignKey("dbo.Samples", "SampleTypeId", "dbo.SampleTypes");
            DropForeignKey("dbo.Samples", "ArtifactId", "dbo.Artifacts");
            DropForeignKey("dbo.Artifacts", "ArtifactTypeId", "dbo.ArtifactTypes");
            DropIndex("dbo.Samples", new[] { "SampleTypeId" });
            DropIndex("dbo.Samples", new[] { "ArtifactId" });
            DropIndex("dbo.Artifacts", new[] { "ArtifactTypeId" });
            DropColumn("dbo.Samples", "SampleTypeId");
            DropColumn("dbo.Samples", "ArtifactId");
            DropTable("dbo.SampleTypes");
            DropTable("dbo.ArtifactTypes");
            DropTable("dbo.Artifacts");
        }
    }
}
