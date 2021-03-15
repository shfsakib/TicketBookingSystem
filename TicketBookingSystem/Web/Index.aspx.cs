using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BitsMasterClass;

namespace TicketBookingSystem.Web
{
    public partial class Index : System.Web.UI.Page
    {
        private MasterClass masterClass;
        private HttpCookie cookieData = HttpContext.Current.Request.Cookies["Ticket"];


        public Index()
        {
            masterClass = MasterClass.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["p"] == "1")
                {
                    Response.Write("<script language=javascript>alert('Signed up successfully.Thanks for sign up. :)');</script>");
                }
                LoadRepeater(Repeater1, @"SELECT        EventInfo.EventId, EventInfo.EventName, EventInfo.EventAddress,EventInfo.EventLocation AS Loc, EventInfo.StartTime, EventInfo.EndTime, EventInfo.EventDate, EventInfo.SeatType, EventInfo.SeatCapacity, EventInfo.Fare, 
                         EventInfo.Picture, EventInfo.CompanyId, EventInfo.Status, EventInfo.InTime, EventInfo.Type, District.Name AS EventLocation,(SELECT SUM(Convert(int,SeatName)) FROM BookTicket WHERE CoachType='Event' AND CoachId=EventId) BookedSeat
FROM            EventInfo INNER JOIN
                         District ON EventInfo.EventLocation = District.Id WHERE EventInfo.Type='Event' AND EventInfo.EventDate>'" + DateTime.Now.ToString("yyyy-MM-dd") + "'");

            }
        }
        public void LoadRepeater(Repeater ob, string query)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(masterClass.Connection);
            try
            {
                ob.Visible = true;
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                new SqlDataAdapter(new SqlCommand(query, connection)).Fill(dataTable);
                ob.DataSource = (object)dataTable;
                ob.DataBind();
                if ((uint)connection.State <= 0U)
                    return;
                connection.Close();
            }
            catch (Exception ex)
            {
                if ((uint)connection.State <= 0U)
                    return;
                connection.Close();
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

        public string Limit(string cap, string book)
        {
            if (book == "")
            {
                book ="0";
            }
            return (Convert.ToInt32(cap) - Convert.ToInt32(book)).ToString();
        }
        protected void lnkBook_OnClick(object sender, EventArgs e)
        {
            if (cookieData == null)
            {
                Response.Write("<script language=javascript>alert('Please log in first');</script>");
            }
            else
            {
                LinkButton linkButton = (LinkButton)sender;
                HiddenField EventId = (HiddenField)linkButton.Parent.FindControl("EventId");
                HiddenField CompanyId = (HiddenField)linkButton.Parent.FindControl("CompanyId");
                HiddenField SeatCapacity = (HiddenField)linkButton.Parent.FindControl("SeatCapacity");
                HiddenField Loc = (HiddenField)linkButton.Parent.FindControl("Loc");
                HiddenField EventDate = (HiddenField)linkButton.Parent.FindControl("EventDate");
                HiddenField Fare = (HiddenField)linkButton.Parent.FindControl("Fare");
                HiddenField Seat = (HiddenField)linkButton.Parent.FindControl("EventId");

                if (Seat.Value != "0")
                {
                    Response.Write("<script>window.open ('/Web/EventTicketBook.aspx?cId=" + CompanyId.Value + "&EId=" +
                                       EventId.Value + "&location=" + Loc.Value + "&dt=" + EventDate.Value + "&p=" + Fare.Value + "&S=" + SeatCapacity.Value + "','_blank');</script>");
                }
                else
                {
                    linkButton.Enabled = false;
                }
            }
        } 
    }
}