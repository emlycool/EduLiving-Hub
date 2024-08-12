namespace EduLiving_Hub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigratedModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Bio = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PublishDate = c.Int(nullable: false),
                        Plot = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: true),
                        RecipeId = c.Int(nullable: true),
                        UserId = c.String(nullable: true),
                        PropertyListingId = c.Int(nullable: true),
                        Disk = c.String(),
                        Tag = c.String(),
                        FileName = c.String(),
                        Extension = c.String(),
                        FileSize = c.String(),
                        CreatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PropertyListings", t => t.PropertyListingId, cascadeDelete: true)
                .Index(t => t.PropertyListingId);
            
            CreateTable(
                "dbo.PropertyListings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slug = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NoBedRooms = c.Int(nullable: false),
                        NoBathRooms = c.Int(nullable: false),
                        SquareFootage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvailabilityDate = c.DateTime(),
                        Description = c.String(),
                        Status = c.String(),
                        Type = c.String(),
                        Features = c.String(nullable: true),
                        LeaseTerm = c.String(),
                        LandLordPhoneNumber = c.String(nullable: true),
                        LandlordEmail = c.String(nullable: true),
                        UserId = c.String(maxLength: 128, nullable: true),
                        PublishedAt = c.DateTime(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PropertyListings", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Media", "PropertyListingId", "dbo.PropertyListings");
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.PropertyListings", new[] { "UserId" });
            DropIndex("dbo.Media", new[] { "PropertyListingId" });
            DropIndex("dbo.Books", new[] { "GenreId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.PropertyListings");
            DropTable("dbo.Media");
            DropTable("dbo.Genres");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
