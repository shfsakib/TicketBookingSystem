using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketBookingSystem.DAL.Model
{
    public class BookTicketModal
    {
        private static BookTicketModal _instance;
        public static BookTicketModal GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BookTicketModal();
            }
            return _instance;
        }

        public int BookId { get; set; }
        public int CompanyId { get; set; }
        public int CoachId { get; set; }
        public int FromLocation { get; set; }
        public int ToLocation { get; set; }
        public string JourneyDate { get; set; }
        public double Fare { get; set; }
        public string SeatName { get; set; }
        public string CoachType { get; set; }
        public double SubTotal { get; set; }
        public double ServiceCharge { get; set; }
        public double Advance { get; set; }
        public double GrandTotal { get; set; }
        public string TokenId { get; set; }
        public string BkashNo { get; set; }
        public string TransactionNo { get; set; }
        public string Amount { get; set; }
        public string BookTime { get; set; }
        public string Status { get; set; }
        public string UserId { get; set; }
    }
}