namespace SportsStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ImageData", c => c.Binary());
            AddColumn("dbo.Product", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "ImageMimeType");
            DropColumn("dbo.Product", "ImageData");
        }
    }
}
