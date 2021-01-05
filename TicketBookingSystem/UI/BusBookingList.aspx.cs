using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsMasterClass;

namespace TicketBookingSystem.UI
{
    public partial class BusBookingList : System.Web.UI.Page
    {
        private MasterClass masterClass;

        public BusBookingList()
        {
            masterClass=MasterClass.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load();
            }
        }
        private void Load()
        {
            masterClass.LoadGrid(gridBooking, @"SELECT    DISTINCT  BookTicket.UserId, BookTicket.BusId,  BookTicket.JourneyDate, BookTicket.Fare, BookTicket.BusType, BookTicket.SubTotal, 
                         BookTicket.ServiceCharge, BookTicket.Advance, BookTicket.GrandTotal, BookTicket.TokenId, BookTicket.BkashNo, BookTicket.TransactionNo, BookTicket.Amount, BookTicket.BookTime, BookTicket.Status, 
                         Registration.Name,Registration.Email, BusInfo.BusName, A.Name FromLocation, B.Name AS ToLocation, BusInfo.DepartureTime,(SELECT COUNT(SeatName) Seat FROM BookTicket WHERE TokenId=BookTicket.TokenId) Seat
FROM    BookTicket   INNER JOIN  Registration ON
 BookTicket.UserId=Registration.RegId  INNER JOIN 
  District A ON A.Id=BookTicket.FromLocation INNER JOIN
  District B ON B.Id=BookTicket.ToLocation INNER JOIN
                         BusInfo ON BookTicket.BusId = BusInfo.BusId WHERE BookTicket.CompanyId='" + masterClass.UserIdCookie() + "' ORDER BY BookTicket.BookTime DESC");
        }
        protected void gridBooking_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridBooking.PageIndex = e.NewPageIndex;
            Load();
        }

        protected void gridBooking_OnRowDataBound_(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField tokenId = (HiddenField)e.Row.FindControl("HiddenField2");
                DataList DataListSeat = (DataList)e.Row.FindControl("DataListSeat");
                masterClass.LoadDataList(DataListSeat, @"SELECT SeatName FROM BookTicket WHERE TokenId='" + tokenId.Value + "'");

            }
        }
        public string TimeC(string time)
        {
            string cTime = "";
            if (time != "")
            {
                DateTime dateTime = new DateTime();
                dateTime = Convert.ToDateTime(time);
                cTime = dateTime.ToString("hh:mm tt");
            }
            return cTime;
        }
        public string SubValue(string value)
        {
            if (value != "")
            {
                value = value.Substring(0, value.Length - 3);
            }
            return value;
        }
    }
}