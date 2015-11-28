﻿namespace Hotel.Database.Model
{
    public class Room : IdentityBase
    {
        public string Description { get; set; }
        public int PlaceCount { get; set; }
        public double CostPerDay { get; set; }
        public RoomState State { get; set; }
    }
}