namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPeriodToArtefact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artefacts", "Period", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artefacts", "Period");
        }
    }
}
