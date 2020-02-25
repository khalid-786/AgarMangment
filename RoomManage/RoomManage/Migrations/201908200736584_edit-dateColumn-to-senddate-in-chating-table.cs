namespace RoomManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editdateColumntosenddateinchatingtable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chatings", "sendDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Chatings", "date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Chatings", "date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Chatings", "sendDate");
        }
    }
}
