namespace RoomManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editLeaseDateToPublishDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Barrennesses", "publishDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Barrennesses", "leaseDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Barrennesses", "leaseDate", c => c.String());
            DropColumn("dbo.Barrennesses", "publishDate");
        }
    }
}
