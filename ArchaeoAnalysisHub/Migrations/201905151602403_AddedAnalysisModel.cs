namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAnalysisModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Analyses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SEMAnalysisTypeId = c.Int(nullable: false),
                        IsBulk = c.Boolean(nullable: false),
                        IsNormalised = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SemAnalysisTypes", t => t.SEMAnalysisTypeId, cascadeDelete: true)
                .Index(t => t.SEMAnalysisTypeId);
            
            CreateTable(
                "dbo.SemAnalysisTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Analyses", "SEMAnalysisTypeId", "dbo.SemAnalysisTypes");
            DropIndex("dbo.Analyses", new[] { "SEMAnalysisTypeId" });
            DropTable("dbo.SemAnalysisTypes");
            DropTable("dbo.Analyses");
        }
    }
}
