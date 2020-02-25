namespace RoomManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createchatingtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        applyId = c.Int(nullable: false),
                        sender = c.String(),
                        reciver = c.String(),
                        message = c.String(),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Chatings");
        }
    }
}
