namespace OnlineShoppingStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Products",
            //    c => new
            //        {
            //            ProductId = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false),
            //            Description = c.String(nullable: false),
            //            Price = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Category = c.String(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Products");
        }
    }
}
