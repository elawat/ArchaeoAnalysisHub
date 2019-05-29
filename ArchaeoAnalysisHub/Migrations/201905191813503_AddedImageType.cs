namespace ArchaeoAnalysisHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Images", "Description", c => c.String());
            AddColumn("dbo.Images", "ImageTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Images", "ImageTypeId");
            AddForeignKey("dbo.Images", "ImageTypeId", "dbo.ImageTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "ImageTypeId", "dbo.ImageTypes");
            DropIndex("dbo.Images", new[] { "ImageTypeId" });
            DropColumn("dbo.Images", "ImageTypeId");
            DropColumn("dbo.Images", "Description");
            DropTable("dbo.ImageTypes");
        }
    }
}
