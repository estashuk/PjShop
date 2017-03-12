namespace PartyJuice.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Country = c.Int(nullable: false),
                        Town = c.String(nullable: false, maxLength: 100),
                        Street = c.String(nullable: false, maxLength: 100),
                        Number = c.String(nullable: false, maxLength: 20),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Sex = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        FatherName = c.String(maxLength: 100),
                        BirthDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Card_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DiscountCards", t => t.Card_Id)
                .Index(t => t.Card_Id);
            
            CreateTable(
                "dbo.DiscountCards",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.String(nullable: false, maxLength: 15),
                        Kind = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Client_Id = c.Guid(),
                        Producer_Id = c.Guid(),
                        PJShop_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Producers", t => t.Producer_Id)
                .ForeignKey("dbo.PJShops", t => t.PJShop_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.Producer_Id)
                .Index(t => t.PJShop_Id);
            
            CreateTable(
                "dbo.Drinks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Volume = c.Double(nullable: false),
                        Name = c.String(nullable: false, maxLength: 300),
                        IsDeleted = c.Boolean(nullable: false),
                        DrinkType_Id = c.Guid(nullable: false),
                        Price_Id = c.Guid(nullable: false),
                        Producer_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DrinkTypes", t => t.DrinkType_Id, cascadeDelete: true)
                .ForeignKey("dbo.Prices", t => t.Price_Id, cascadeDelete: true)
                .ForeignKey("dbo.Producers", t => t.Producer_Id, cascadeDelete: true)
                .Index(t => t.DrinkType_Id)
                .Index(t => t.Price_Id)
                .Index(t => t.Producer_Id);
            
            CreateTable(
                "dbo.DrinkTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 300),
                        IsDeleted = c.Boolean(nullable: false),
                        ParentDrinkType_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DrinkTypes", t => t.ParentDrinkType_Id)
                .Index(t => t.ParentDrinkType_Id);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DrinkPrice = c.Double(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 300),
                        IsDeleted = c.Boolean(nullable: false),
                        Address_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id, cascadeDelete: true)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.PJShops",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 300),
                        IsDeleted = c.Boolean(nullable: false),
                        ShopAddress_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.ShopAddress_Id, cascadeDelete: true)
                .Index(t => t.ShopAddress_Id);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 300),
                        IsDeleted = c.Boolean(nullable: false),
                        PJShop_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PJShops", t => t.PJShop_Id)
                .Index(t => t.PJShop_Id);
            
            CreateTable(
                "dbo.WarehouseElements",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Count = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Drink_Id = c.Guid(nullable: false),
                        Warehouse_Id = c.Guid(),
                        PurchaseInvoice_Id = c.Guid(),
                        SaleOrder_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drinks", t => t.Drink_Id, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.Warehouse_Id)
                .ForeignKey("dbo.PurchaseInvoices", t => t.PurchaseInvoice_Id)
                .ForeignKey("dbo.SaleOrders", t => t.SaleOrder_Id)
                .Index(t => t.Drink_Id)
                .Index(t => t.Warehouse_Id)
                .Index(t => t.PurchaseInvoice_Id)
                .Index(t => t.SaleOrder_Id);
            
            CreateTable(
                "dbo.PurchaseInvoices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.String(nullable: false, maxLength: 20),
                        CreationDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        StoreKeeper_Id = c.Guid(nullable: false),
                        Warehouse_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.StoreKeeper_Id, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.Warehouse_Id, cascadeDelete: true)
                .Index(t => t.StoreKeeper_Id)
                .Index(t => t.Warehouse_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        Role = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Login, unique: true);
            
            CreateTable(
                "dbo.SaleOrders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.String(nullable: false, maxLength: 20),
                        TotalCost = c.Double(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Client_Id = c.Guid(nullable: false),
                        Seller_Id = c.Guid(nullable: false),
                        Warehouse_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Seller_Id, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.Warehouse_Id, cascadeDelete: true)
                .Index(t => t.Client_Id)
                .Index(t => t.Seller_Id)
                .Index(t => t.Warehouse_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleOrders", "Warehouse_Id", "dbo.Warehouses");
            DropForeignKey("dbo.SaleOrders", "Seller_Id", "dbo.Users");
            DropForeignKey("dbo.WarehouseElements", "SaleOrder_Id", "dbo.SaleOrders");
            DropForeignKey("dbo.SaleOrders", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.PurchaseInvoices", "Warehouse_Id", "dbo.Warehouses");
            DropForeignKey("dbo.PurchaseInvoices", "StoreKeeper_Id", "dbo.Users");
            DropForeignKey("dbo.WarehouseElements", "PurchaseInvoice_Id", "dbo.PurchaseInvoices");
            DropForeignKey("dbo.Warehouses", "PJShop_Id", "dbo.PJShops");
            DropForeignKey("dbo.WarehouseElements", "Warehouse_Id", "dbo.Warehouses");
            DropForeignKey("dbo.WarehouseElements", "Drink_Id", "dbo.Drinks");
            DropForeignKey("dbo.PhoneNumbers", "PJShop_Id", "dbo.PJShops");
            DropForeignKey("dbo.PJShops", "ShopAddress_Id", "dbo.Addresses");
            DropForeignKey("dbo.Drinks", "Producer_Id", "dbo.Producers");
            DropForeignKey("dbo.PhoneNumbers", "Producer_Id", "dbo.Producers");
            DropForeignKey("dbo.Producers", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Drinks", "Price_Id", "dbo.Prices");
            DropForeignKey("dbo.Drinks", "DrinkType_Id", "dbo.DrinkTypes");
            DropForeignKey("dbo.DrinkTypes", "ParentDrinkType_Id", "dbo.DrinkTypes");
            DropForeignKey("dbo.PhoneNumbers", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Clients", "Card_Id", "dbo.DiscountCards");
            DropIndex("dbo.SaleOrders", new[] { "Warehouse_Id" });
            DropIndex("dbo.SaleOrders", new[] { "Seller_Id" });
            DropIndex("dbo.SaleOrders", new[] { "Client_Id" });
            DropIndex("dbo.Users", new[] { "Login" });
            DropIndex("dbo.PurchaseInvoices", new[] { "Warehouse_Id" });
            DropIndex("dbo.PurchaseInvoices", new[] { "StoreKeeper_Id" });
            DropIndex("dbo.WarehouseElements", new[] { "SaleOrder_Id" });
            DropIndex("dbo.WarehouseElements", new[] { "PurchaseInvoice_Id" });
            DropIndex("dbo.WarehouseElements", new[] { "Warehouse_Id" });
            DropIndex("dbo.WarehouseElements", new[] { "Drink_Id" });
            DropIndex("dbo.Warehouses", new[] { "PJShop_Id" });
            DropIndex("dbo.PJShops", new[] { "ShopAddress_Id" });
            DropIndex("dbo.Producers", new[] { "Address_Id" });
            DropIndex("dbo.DrinkTypes", new[] { "ParentDrinkType_Id" });
            DropIndex("dbo.Drinks", new[] { "Producer_Id" });
            DropIndex("dbo.Drinks", new[] { "Price_Id" });
            DropIndex("dbo.Drinks", new[] { "DrinkType_Id" });
            DropIndex("dbo.PhoneNumbers", new[] { "PJShop_Id" });
            DropIndex("dbo.PhoneNumbers", new[] { "Producer_Id" });
            DropIndex("dbo.PhoneNumbers", new[] { "Client_Id" });
            DropIndex("dbo.Clients", new[] { "Card_Id" });
            DropTable("dbo.SaleOrders");
            DropTable("dbo.Users");
            DropTable("dbo.PurchaseInvoices");
            DropTable("dbo.WarehouseElements");
            DropTable("dbo.Warehouses");
            DropTable("dbo.PJShops");
            DropTable("dbo.Producers");
            DropTable("dbo.Prices");
            DropTable("dbo.DrinkTypes");
            DropTable("dbo.Drinks");
            DropTable("dbo.PhoneNumbers");
            DropTable("dbo.DiscountCards");
            DropTable("dbo.Clients");
            DropTable("dbo.Addresses");
        }
    }
}
