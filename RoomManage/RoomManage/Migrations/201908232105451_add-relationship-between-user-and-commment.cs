namespace RoomManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrelationshipbetweenuserandcommment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Comments", "UserId");
            AddForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Comments", "sender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "sender", c => c.String());
            DropForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropColumn("dbo.Comments", "UserId");
        }
    }
}
