namespace RoomManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstatuscolumntousertable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "status");
        }
    }
}
