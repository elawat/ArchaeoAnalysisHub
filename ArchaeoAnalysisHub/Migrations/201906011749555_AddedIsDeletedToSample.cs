namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsDeletedToSample : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Samples", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Samples", "IsDeleted");
        }
    }
}
