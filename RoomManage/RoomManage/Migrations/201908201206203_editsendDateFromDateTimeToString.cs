namespace RoomManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editsendDateFromDateTimeToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Chatings", "sendDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Chatings", "sendDate", c => c.DateTime(nullable: false));
        }
    }
}
