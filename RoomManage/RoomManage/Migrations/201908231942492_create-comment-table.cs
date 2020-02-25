namespace RoomManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createcommenttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        sender = c.String(),
                        message = c.String(),
                        sendDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Comments");
        }
    }
}
