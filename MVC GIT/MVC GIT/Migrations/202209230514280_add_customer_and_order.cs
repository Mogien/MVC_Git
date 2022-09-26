namespace MVC_GIT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_customer_and_order : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(maxLength: 64),
                        MiddleName = c.String(maxLength: 64),
                        LastName = c.String(maxLength: 64),
                        Gender = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        No = c.String(maxLength: 10),
                        OrderDate = c.DateTime(nullable: false),
                        OrderName = c.String(maxLength: 64),
                        CustomerId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
