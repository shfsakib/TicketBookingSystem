using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketBookingSystem.DAL.Model
{
    public class RegistrationModel
    {
        private static RegistrationModel _instance;
        public static RegistrationModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RegistrationModel();
            }
            return _instance;
        }

        public string RegId { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Gender { get; set; }
        public string DateofBirth { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string InTime { get; set; }
    }
}