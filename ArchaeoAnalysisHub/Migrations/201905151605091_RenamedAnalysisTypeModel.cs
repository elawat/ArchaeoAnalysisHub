namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedAnalysisTypeModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SemAnalysisTypes", newName: "AnalysisTypes");
            RenameColumn(table: "dbo.Analyses", name: "SEMAnalysisTypeId", newName: "AnalysisTypeId");
            RenameIndex(table: "dbo.Analyses", name: "IX_SEMAnalysisTypeId", newName: "IX_AnalysisTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Analyses", name: "IX_AnalysisTypeId", newName: "IX_SEMAnalysisTypeId");
            RenameColumn(table: "dbo.Analyses", name: "AnalysisTypeId", newName: "SEMAnalysisTypeId");
            RenameTable(name: "dbo.AnalysisTypes", newName: "SemAnalysisTypes");
        }
    }
}
