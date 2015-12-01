namespace Hotel.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class temp2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "Number", c => c.String());
            AddColumn("dbo.Rooms", "HotelId", c => c.Long(nullable: false));
            CreateIndex("dbo.Rooms", "HotelId");
            AddForeignKey("dbo.Rooms", "HotelId", "dbo.Hotels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "HotelId", "dbo.Hotels");
            DropIndex("dbo.Rooms", new[] { "HotelId" });
            DropColumn("dbo.Rooms", "HotelId");
            DropColumn("dbo.Rooms", "Number");
        }
    }
}
