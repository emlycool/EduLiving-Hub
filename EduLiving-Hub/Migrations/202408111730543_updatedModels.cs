namespace EduLiving_Hub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Authors", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Books", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Books", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Genres", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Genres", "UpdatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Genres", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Books", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Books", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Authors", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Authors", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
