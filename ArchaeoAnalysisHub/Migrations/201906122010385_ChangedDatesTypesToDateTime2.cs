namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDatesTypesToDateTime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Analyses", "AddedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Samples", "AddedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Artifacts", "AddedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Artifacts", "AddedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Samples", "AddedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Analyses", "AddedDate", c => c.DateTime(nullable: false));
        }
    }
}
