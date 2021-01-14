using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketBookingSystem.DAL.Model
{
    public class EventModel
    {
        private static EventModel _instance;
        public static EventModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new EventModel();
            }
            return _instance;
        }

        public int EventId { get; set; }
        public string EventName { get; set; }
        public string Picture { get; set; }
        public int EventLocation { get; set; }
        public string EventAddress { get; set; }
        public double Fare { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string SeatType { get; set; }
        public int SeatCapacity { get; set; }
        public string EventDate { get; set; }
        public int CompanyId { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string InTime { get; set; }
    }
}