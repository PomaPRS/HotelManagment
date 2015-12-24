namespace Hotel.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class temp3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Rooms", new[] { "HotelId" });
            AlterColumn("dbo.Hotels", "Title", c => c.String(maxLength: 50));
            AlterColumn("dbo.Hotels", "IndividualId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Rooms", "Number", c => c.String(maxLength: 50));
            AlterColumn("dbo.Workers", "IndividualId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Positions", "Title", c => c.String(maxLength: 50));
            CreateIndex("dbo.Hotels", "Title", unique: true, name: "HotelTitle_Index");
            CreateIndex("dbo.Hotels", "IndividualId", unique: true, name: "HotelIndividualId_Index");
            CreateIndex("dbo.Rooms", new[] { "Number", "HotelId" }, unique: true, name: "Room_HotelId_Number");
            CreateIndex("dbo.Rooms", "CostPerDay", name: "Room_CostPreDay");
            CreateIndex("dbo.Reservations", "ArrivalDate", name: "ReservationArrivalDate");
            CreateIndex("dbo.Reservations", "DepartureDate", name: "ReservationDepartureDate");
            CreateIndex("dbo.Workers", "IndividualId", unique: true, name: "WorkerIndividualId");
            CreateIndex("dbo.Positions", "Title", unique: true, name: "PositionTitle");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Positions", "PositionTitle");
            DropIndex("dbo.Workers", "WorkerIndividualId");
            DropIndex("dbo.Reservations", "ReservationDepartureDate");
            DropIndex("dbo.Reservations", "ReservationArrivalDate");
            DropIndex("dbo.Rooms", "Room_CostPreDay");
            DropIndex("dbo.Rooms", "Room_HotelId_Number");
            DropIndex("dbo.Hotels", "HotelIndividualId_Index");
            DropIndex("dbo.Hotels", "HotelTitle_Index");
            AlterColumn("dbo.Positions", "Title", c => c.String());
            AlterColumn("dbo.Workers", "IndividualId", c => c.String());
            AlterColumn("dbo.Rooms", "Number", c => c.String());
            AlterColumn("dbo.Hotels", "IndividualId", c => c.String());
            AlterColumn("dbo.Hotels", "Title", c => c.String());
            CreateIndex("dbo.Rooms", "HotelId");
        }
    }
}
