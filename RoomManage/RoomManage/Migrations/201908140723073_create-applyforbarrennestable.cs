namespace RoomManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createapplyforbarrennestable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplyForBarrennes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        ApplyDate = c.DateTime(nullable: false),
                        BarrennessId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Barrennesses", t => t.BarrennessId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.BarrennessId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplyForBarrennes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplyForBarrennes", "BarrennessId", "dbo.Barrennesses");
            DropIndex("dbo.ApplyForBarrennes", new[] { "UserId" });
            DropIndex("dbo.ApplyForBarrennes", new[] { "BarrennessId" });
            DropTable("dbo.ApplyForBarrennes");
        }
    }
}
