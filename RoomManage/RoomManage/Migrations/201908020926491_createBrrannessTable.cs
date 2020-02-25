namespace RoomManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createBrrannessTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Barrennesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        barrenessDescription = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        leasePrice = c.String(nullable: false),
                        paymentMethod = c.String(nullable: false),
                        Number = c.Int(nullable: false),
                        leaseDate = c.DateTime(nullable: false),
                        PublisherId = c.Int(nullable: false),
                        state = c.String(nullable: false),
                        fullLocation = c.String(nullable: false),
                        status = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Barrennesses", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Barrennesses", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Barrennesses", new[] { "User_Id" });
            DropIndex("dbo.Barrennesses", new[] { "CategoryId" });
            DropTable("dbo.Barrennesses");
        }
    }
}
