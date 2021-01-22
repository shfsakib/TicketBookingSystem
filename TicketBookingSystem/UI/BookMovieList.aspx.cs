using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsMasterClass;
using TicketBookingSystem.DAL.Gateway;
using TicketBookingSystem.DAL.Model;

namespace TicketBookingSystem.UI
{
    public partial class BookMovieList : System.Web.UI.Page
    {
        private MasterClass masterClass;
        private BookTicketModal bookTicketModal;
        private BookTicketGateway bookTicketGateway;

        public BookMovieList()
        {
            masterClass = MasterClass.GetInstance();
            bookTicketModal = BookTicketModal.GetInstance();
            bookTicketGateway = BookTicketGateway.GetInstance();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cookieIndex = HttpContext.Current.Request.Cookies["Ticket"];

                if (cookieIndex != null)
                {

                    if (masterClass.TypeCookie() == "")
                    {
                        Response.Redirect("/Web/Login.aspx");
                    }
                    else if (masterClass.TypeCookie() == "A")
                    {
                    }
                    else if (masterClass.TypeCookie() == "Ad")
                    {
                        Response.Redirect("/UI/PassengerList.aspx");

                    }
                    else if (masterClass.TypeCookie() == "P")
                    {
                        Response.Redirect("/Web/index.aspx");
                    }
                    else
                    {
                        Response.Redirect("/Web/Login.aspx");
                    }
                }
                else
                {
                    Response.Redirect("/Web/index.aspx");
                }
                Load();
            }
        }
        private void Load()
        {
            masterClass.LoadGrid(gridBooking, @"SELECT DISTINCT 
                         BookTicket.UserId, BookTicket.CompanyId, BookTicket.CoachId,BookTicket.Fare, BookTicket.CoachType, BookTicket.SubTotal, BookTicket.ServiceCharge, BookTicket.Advance, BookTicket.GrandTotal, 
                         BookTicket.TokenId, BookTicket.BkashNo, BookTicket.TransactionNo, BookTicket.Amount, BookTicket.BookTime, BookTicket.Status, Registration.Name, Registration.Email, A.Name AS EventLocation, BookTicket.SeatName, 
                         EventInfo.EventName, EventInfo.EventAddress,EventInfo.StartTime, EventInfo.EndTime, EventInfo.EventDate, EventInfo.SeatType
FROM            BookTicket INNER JOIN
                         Registration ON BookTicket.UserId = Registration.RegId INNER JOIN
                         District AS A ON A.Id = BookTicket.FromLocation INNER JOIN
                         EventInfo ON BookTicket.CoachId = EventInfo.EventId AND A.Id = EventInfo.EventLocation WHERE BookTicket.CoachType='Movie' AND BookTicket.CompanyId='" + masterClass.UserIdCookie() + "' ORDER BY BookTicket.BookTime DESC");
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

        protected void lnkDel_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            HiddenField HiddenField2 = (HiddenField)linkButton.Parent.FindControl("HiddenField2");
            bookTicketModal.TokenId = HiddenField2.Value;
            bookTicketModal.Status = "R";
            bool ans = bookTicketGateway.UpdateStatus(bookTicketModal);
            if (ans)
            {
                Load();
            }
        }

        protected void gridBooking_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridBooking.PageIndex = e.NewPageIndex;
            Load();
        }

        protected void gridBooking_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField tokenId = (HiddenField)e.Row.FindControl("HiddenField2"); 
                HiddenField HiddenField3 = (HiddenField)e.Row.FindControl("HiddenField3");
                LinkButton lnkDel = (LinkButton)e.Row.FindControl("lnkDel");
                if (HiddenField3.Value == "A")
                {
                    lnkDel.Visible = true;
                }
                else if (HiddenField3.Value == "R")
                {
                    lnkDel.Visible = false;
                }
            }
        }
    }
}