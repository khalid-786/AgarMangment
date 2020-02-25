namespace RoomManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePublisherColumnToUserIdInBarrennessTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Barrennesses", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Barrennesses", name: "IX_User_Id", newName: "IX_UserId");
            DropColumn("dbo.Barrennesses", "PublisherId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Barrennesses", "PublisherId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Barrennesses", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Barrennesses", name: "UserId", newName: "User_Id");
        }
    }
}
