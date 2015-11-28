namespace Hotel.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        IdividualId = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        HotelId = c.Long(nullable: false),
                        IdividualId = c.String(),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        MiddleName = c.String(),
                        PositionId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hotels", t => t.HotelId, cascadeDelete: true)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .Index(t => t.HotelId)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ArrivalDate = c.DateTime(nullable: false),
                        DepartureDate = c.DateTime(nullable: false),
                        VisitorId = c.Long(nullable: false),
                        RoomId = c.Long(nullable: false),
                        Advance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Visitors", t => t.VisitorId, cascadeDelete: true)
                .Index(t => t.VisitorId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Description = c.String(),
                        PlaceCount = c.Int(nullable: false),
                        CostPerDay = c.Double(nullable: false),
                        State = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        MiddleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "VisitorId", "dbo.Visitors");
            DropForeignKey("dbo.Reservations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Workers", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Workers", "HotelId", "dbo.Hotels");
            DropIndex("dbo.Reservations", new[] { "RoomId" });
            DropIndex("dbo.Reservations", new[] { "VisitorId" });
            DropIndex("dbo.Workers", new[] { "PositionId" });
            DropIndex("dbo.Workers", new[] { "HotelId" });
            DropTable("dbo.Visitors");
            DropTable("dbo.Rooms");
            DropTable("dbo.Reservations");
            DropTable("dbo.Positions");
            DropTable("dbo.Workers");
            DropTable("dbo.Hotels");
        }
    }
}
