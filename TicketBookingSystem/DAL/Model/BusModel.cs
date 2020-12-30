using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketBookingSystem.DAL.Model
{
    public class BusModel
    {
        private static BusModel _instance;
        public static BusModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BusModel();
            }
            return _instance;
        }

        public int BusId { get; set; }
        public string BusName { get; set; }
        public string BusType { get; set; }
        public string BusNo { get; set; }
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
    }
}