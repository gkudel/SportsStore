namespace SportsStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Product", "Category", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Category", c => c.String());
            AlterColumn("dbo.Product", "Description", c => c.String());
            AlterColumn("dbo.Product", "Name", c => c.String());
        }
    }
}
