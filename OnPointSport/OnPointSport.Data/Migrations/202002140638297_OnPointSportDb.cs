namespace OnPointSport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OnPointSportDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        CustomerCode = c.String(),
                        BookingDate = c.DateTime(nullable: false),
                        BookingDebutTime = c.DateTime(nullable: false),
                        BookingFinTime = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Description = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                        Description = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Gender = c.Boolean(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Active = c.Boolean(nullable: false),
                        Description = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Debut = c.DateTime(nullable: false),
                        Fin = c.DateTime(nullable: false),
                        Rate = c.Single(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Description = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Gender = c.Boolean(nullable: false),
                        IdCard = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Active = c.Boolean(nullable: false),
                        Description = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExchangeRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        FromAmount = c.Single(nullable: false),
                        ToAmount = c.Single(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Description = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Imports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        SupplierCode = c.String(),
                        DiscountCode = c.String(),
                        TotalPrice = c.Double(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Description = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        SaleCode = c.String(),
                        ProductServiceCode = c.String(),
                        Quantity = c.Single(nullable: false),
                        UnitPrice = c.Single(nullable: false),
                        SubTotalPrice = c.Single(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Description = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        CategoryCode = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Description = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        EmployeeCode = c.String(),
                        BasicSalary = c.Single(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Description = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        CustomerCode = c.String(),
                        DiscountCode = c.String(),
                        TotalPrice = c.Single(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Description = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StockAdjustments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        ProductServiceCode = c.String(),
                        Quantity = c.Double(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Description = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Phone = c.String(),
                        Phone2 = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Active = c.Boolean(nullable: false),
                        Description = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Password = c.String(),
                        Active = c.Boolean(nullable: false),
                        Description = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateModification = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Suppliers");
            DropTable("dbo.StockAdjustments");
            DropTable("dbo.Sales");
            DropTable("dbo.Salaries");
            DropTable("dbo.ProductServices");
            DropTable("dbo.ItemDetails");
            DropTable("dbo.Imports");
            DropTable("dbo.ExchangeRates");
            DropTable("dbo.Employees");
            DropTable("dbo.Discounts");
            DropTable("dbo.Customers");
            DropTable("dbo.Categories");
            DropTable("dbo.Bookings");
        }
    }
}
