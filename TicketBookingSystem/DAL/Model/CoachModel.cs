using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketBookingSystem.DAL.Model
{
    public class CoachModel
    {
        private static CoachModel _instance;
        public static CoachModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CoachModel();
            }
            return _instance;
        }

        public int CoachId { get; set; }
        public string CoachName { get; set; }
        public string CoachType { get; set; }
        public string CoachNo { get; set; }
        public int DistrictFrom { get; set; }
        public int DistrictTo { get; set; }
        public string StartingPoint { get; set; }
        public string EndPoint { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public double TicketPrice { get; set; }
        public string Status { get; set; }
        public string CompanyId { get; set; }
        public string InTime { get; set; }
        public string SeatType { get; set; }
        public string CoachStatus { get; set; }
        public string SeatCapacity { get; set; }
    }
}