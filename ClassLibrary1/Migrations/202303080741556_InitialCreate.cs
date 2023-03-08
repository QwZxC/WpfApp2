namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubGroup = c.Int(nullable: false),
                        ClassRoom = c.Int(nullable: false),
                        StartYear = c.Int(nullable: false),
                        Special_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Specials", t => t.Special_Id)
                .Index(t => t.Special_Id);
            
            CreateTable(
                "dbo.Specials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        PasswordHash = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "Special_Id", "dbo.Specials");
            DropIndex("dbo.Groups", new[] { "Special_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Specials");
            DropTable("dbo.Groups");
        }
    }
}
