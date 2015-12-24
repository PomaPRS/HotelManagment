using System;

namespace HotelInfo.Models
{
    public class ReportIndexModel
    {
        public VisitorHotelReportModel VisitorHotelReport { get; set; }
        public FreeRoomReportModel FreeRoomReport { get; set; }
        public VisitorCountReportModel VisitorCountReport { get; set; }
    }

    public class VisitorHotelReportModel
    {
        public string VisitorName { get; set; }
    }

    public class FreeRoomReportModel
    {
        public string From { get; set; }
        public string To { get; set; }
    }

    public class VisitorCountReportModel
    {
        public string From { get; set; }
        public string To { get; set; }
    }

    public class VisitorHotelItemModel
    {
        public string HotelTitle { get; set; }
        public string RoomNumber { get; set; }
        public int Count { get; set; }
    }

    public class VisitorCountItemModel
    {
        public string HotelTitle { get; set; }
        public int Count { get; set; }
    }
}