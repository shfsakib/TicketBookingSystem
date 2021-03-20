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
    public partial class BookedListAll : System.Web.UI.Page
    {
        private MasterClass masterClass;
        private BookTicketModal bookTicketModal;
        private BookTicketGateway bookTicketGateway;
        public BookedListAll()
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
                        Response.Redirect("/Web/Index.aspx");
                    }
                    else if (masterClass.TypeCookie() == "A")
                    {
                        Response.Redirect("/Web/index.aspx");
                    }
                    else if (masterClass.TypeCookie() == "Ad")
                    {
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
            masterClass.LoadGrid(gridBooking, @"SELECT DISTINCT X.*  FROM (SELECT    DISTINCT  BookTicket.UserId,BookTicket.CompanyId, BookTicket.CoachId,  BookTicket.JourneyDate, BookTicket.Fare, BookTicket.CoachType, BookTicket.SubTotal, 
                         BookTicket.ServiceCharge, BookTicket.Advance, BookTicket.GrandTotal, BookTicket.TokenId, BookTicket.BkashNo, BookTicket.TransactionNo, BookTicket.Amount, BookTicket.BookTime, BookTicket.Status, 
                         Registration.Name,Registration.Email, CoachInfo.CoachName,CoachInfo.CoachStatus, CoachInfo.DepartureTime,CAST((BookTicket.SubTotal/BookTicket.Fare) AS int) Seat
FROM    BookTicket   INNER JOIN  Registration ON
 BookTicket.UserId=Registration.RegId  INNER JOIN  
                         CoachInfo ON BookTicket.CoachId = CoachInfo.CoachId)X INNER JOIN BookTicket ON BookTicket.TokenId=X.TokenId ORDER BY X.BookTime DESC");
            masterClass.BindDropDown(ddlCompany, "Select", @"SELECT DISTINCT CompanyName Name,RegId ID FROM Registration WHERE CompanyName!='' ORDER By CompanyName ASC");
        }
        protected void ddlCompany_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCompany.Text != "--SELECT--")
            {
                masterClass.LoadGrid(gridBooking, $@"SELECT DISTINCT X.*  FROM (SELECT    DISTINCT  BookTicket.UserId,BookTicket.CompanyId, BookTicket.CoachId,  BookTicket.JourneyDate, BookTicket.Fare, BookTicket.CoachType, BookTicket.SubTotal, 
                         BookTicket.ServiceCharge, BookTicket.Advance, BookTicket.GrandTotal, BookTicket.TokenId, BookTicket.BkashNo, BookTicket.TransactionNo, BookTicket.Amount, BookTicket.BookTime, BookTicket.Status, 
                         Registration.Name,Registration.Email, CoachInfo.CoachName,CoachInfo.CoachStatus,   CoachInfo.DepartureTime,CAST((BookTicket.SubTotal/BookTicket.Fare) AS int) Seat
FROM    BookTicket   INNER JOIN  Registration ON
 BookTicket.UserId=Registration.RegId  INNER JOIN 
  District A ON A.Id=BookTicket.FromLocation INNER JOIN
  District B ON B.Id=BookTicket.ToLocation INNER JOIN
                         CoachInfo ON BookTicket.CoachId = CoachInfo.CoachId)X INNER JOIN BookTicket ON BookTicket.TokenId=X.TokenId WHERE X.CompanyId='{ddlCompany.SelectedValue}' ORDER BY X.BookTime DESC");

            }
            else
            {
                Load();
            }
        }

        protected void ddlCoach_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCompany.Text != "--SELECT--")
            {
                if (ddlCoach.Text == "Event")
                {
                    masterClass.LoadGrid(gridBooking, $@"SELECT DISTINCT X.*  FROM (SELECT    DISTINCT  BookTicket.UserId,BookTicket.CompanyId, BookTicket.CoachId,  BookTicket.JourneyDate, BookTicket.Fare, BookTicket.CoachType, BookTicket.SubTotal, 
                         BookTicket.ServiceCharge, BookTicket.Advance, BookTicket.GrandTotal, BookTicket.TokenId, BookTicket.BkashNo, BookTicket.TransactionNo, BookTicket.Amount, BookTicket.BookTime, BookTicket.Status, 
                         Registration.Name,Registration.Email, CoachInfo.CoachName,CoachInfo.CoachStatus,  CoachInfo.DepartureTime,CAST((BookTicket.SubTotal/BookTicket.Fare) AS int) Seat
FROM    BookTicket   INNER JOIN  Registration ON
 BookTicket.UserId=Registration.RegId  INNER JOIN  
                         CoachInfo ON BookTicket.CoachId = CoachInfo.CoachId)X INNER JOIN BookTicket ON BookTicket.TokenId=X.TokenId WHERE (X.CompanyId='{ddlCompany.SelectedValue}' AND X.CoachType='Event') AND (X.CompanyId='{ddlCompany.SelectedValue}' AND X.CoachType!='Movie') ORDER BY X.BookTime DESC");

                }
                else if (ddlCoach.Text == "Movie")
                {
                    masterClass.LoadGrid(gridBooking, $@"SELECT DISTINCT X.*  FROM (SELECT    DISTINCT  BookTicket.UserId,BookTicket.CompanyId, BookTicket.CoachId,  BookTicket.JourneyDate, BookTicket.Fare, BookTicket.CoachType, BookTicket.SubTotal, 
                         BookTicket.ServiceCharge, BookTicket.Advance, BookTicket.GrandTotal, BookTicket.TokenId, BookTicket.BkashNo, BookTicket.TransactionNo, BookTicket.Amount, BookTicket.BookTime, BookTicket.Status, 
                         Registration.Name,Registration.Email, CoachInfo.CoachName,CoachInfo.CoachStatus,   CoachInfo.DepartureTime,CAST((BookTicket.SubTotal/BookTicket.Fare) AS int) Seat
FROM    BookTicket   INNER JOIN  Registration ON
 BookTicket.UserId=Registration.RegId  INNER JOIN 
                         CoachInfo ON BookTicket.CoachId = CoachInfo.CoachId)X INNER JOIN BookTicket ON BookTicket.TokenId=X.TokenId WHERE (X.CompanyId='{ddlCompany.SelectedValue}' AND X.CoachType!='Event') AND (X.CompanyId='{ddlCompany.SelectedValue}' AND X.CoachType='Movie') ORDER BY X.BookTime DESC");
                }
                else if (ddlCoach.Text != "--SELECT--")
                {
                    masterClass.LoadGrid(gridBooking, $@"SELECT DISTINCT X.*  FROM (SELECT    DISTINCT  BookTicket.UserId,BookTicket.CompanyId, BookTicket.CoachId,  BookTicket.JourneyDate, BookTicket.Fare, BookTicket.CoachType, BookTicket.SubTotal, 
                         BookTicket.ServiceCharge, BookTicket.Advance, BookTicket.GrandTotal, BookTicket.TokenId, BookTicket.BkashNo, BookTicket.TransactionNo, BookTicket.Amount, BookTicket.BookTime, BookTicket.Status, 
                         Registration.Name,Registration.Email, CoachInfo.CoachName,CoachInfo.CoachStatus,   CoachInfo.DepartureTime,CAST((BookTicket.SubTotal/BookTicket.Fare) AS int) Seat
FROM    BookTicket   INNER JOIN  Registration ON
 BookTicket.UserId=Registration.RegId  INNER JOIN  
                         CoachInfo ON BookTicket.CoachId = CoachInfo.CoachId)X INNER JOIN BookTicket ON BookTicket.TokenId=X.TokenId WHERE (X.CompanyId='{ddlCompany.SelectedValue}' AND X.CoachStatus='{ddlCoach.Text}' AND X.CoachType!='Event') AND (X.CompanyId='{ddlCompany.SelectedValue}' AND X.CoachStatus='{ddlCoach.Text}' AND X.CoachType!='Movie') ORDER BY X.BookTime DESC");

                }
                else
                {
                    Load();
                }

            }
        }

        protected void gridBooking_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridBooking.PageIndex = e.NewPageIndex;
            Load();
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