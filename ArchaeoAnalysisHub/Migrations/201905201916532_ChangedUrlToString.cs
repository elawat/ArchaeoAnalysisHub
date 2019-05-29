namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUrlToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Images", "Url", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Images", "Url", c => c.Int(nullable: false));
        }
    }
}
