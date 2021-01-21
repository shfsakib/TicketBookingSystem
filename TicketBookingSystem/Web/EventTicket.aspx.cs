using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsMasterClass;

namespace TicketBookingSystem.Web
{
    public partial class EventTicket : System.Web.UI.Page
    {
        private MasterClass masterClass;
        private HttpCookie cookieData = HttpContext.Current.Request.Cookies["Ticket"];

        public EventTicket()
        {
            masterClass = MasterClass.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["b"] == "1")
                {
                    Response.Write(
                        "<script language=javascript>alert('Ticket booked successfully.You can print your ticket from print ticket. Please collect your ticket by pay full payment from theatre counter.');</script>");
                }
                txtLocation.Focus();
                Load();
            }
        }
        private void Load()
        {
            gridMovie.DataSource = null;
            gridMovie.DataBind();
        }
        protected void txtLocation_OnTextChanged(object sender, EventArgs e)
        {
            string from = "";
            if (txtLocation.Text.Contains("'"))
            {
                from = txtLocation.Text.Replace("'", "''");
            }
            else
            {
                from = txtLocation.Text;
            }
            ViewState["location"] = masterClass.IsExist($"SELECT ID FROM District WHERE Name LIKE '%{from}%'");
            txtLocation.Focus();
            Load();
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
           if (txtLocation.Text == "")
            {
                Response.Write("<script language=javascript>alert('Please enter to location');</script>");
            }
            else
            {
                string location = ViewState["location"].ToString();
                masterClass.LoadGrid(gridMovie,
                    @"SELECT        EventInfo.EventId, EventInfo.EventName, EventInfo.EventAddress, EventInfo.StartTime, EventInfo.EndTime, EventInfo.EventDate, EventInfo.SeatType, EventInfo.SeatCapacity, EventInfo.Fare, 
                         EventInfo.Picture, EventInfo.CompanyId, EventInfo.Status, EventInfo.InTime, EventInfo.Type, District.Name AS EventLocation
FROM            EventInfo INNER JOIN
                         District ON EventInfo.EventLocation = District.Id WHERE  EventInfo.EventLocation='" + location + "' AND EventInfo.Type='Event'  ORDER By CompanyId ASC");
            }
        }
        private void LoadPage()
        {
            masterClass.LoadGrid(gridMovie,
                    @"SELECT        EventInfo.EventId, EventInfo.EventName, EventInfo.EventAddress, EventInfo.StartTime, EventInfo.EndTime, EventInfo.EventDate, EventInfo.SeatType, EventInfo.SeatCapacity, EventInfo.Fare, 
                         EventInfo.Picture, EventInfo.CompanyId, EventInfo.Status, EventInfo.InTime, EventInfo.Type, District.Name AS EventLocation
FROM            EventInfo INNER JOIN
                         District ON EventInfo.EventLocation = District.Id WHERE EventLocation='" + ViewState["location"].ToString() + "'  AND EventInfo.Type='Event' ORDER By CompanyId ASC");

        }
        protected void gridMovie_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridMovie.PageIndex = e.NewPageIndex;
            LoadPage();
        }

        protected void gridMovie_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int eventId = Convert.ToInt32(((HiddenField)e.Row.FindControl("HiddenField2")).Value);
                Label lblSeat = (Label)e.Row.FindControl("lblSeat");
                string countSeat =
                    masterClass.IsExist(
                        $@"SELECT SUM(Convert(int, SeatName)) FROM BookTicket WHERE CoachType='Event' WHERE CoachId='{eventId}'");
                int totalSeat = (Convert.ToInt32(lblSeat.Text) - Convert.ToInt32(countSeat));
                lblSeat.Text = totalSeat.ToString();
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

        protected void lnkView_OnClick(object sender, EventArgs e)
        {
            if (cookieData == null)
            {
                Response.Write("<script language=javascript>alert('Please log in first');</script>");
            }
            else if (txtLocation.Text == "")
            {
                Response.Write("<script language=javascript>alert('Please enter district');</script>");
            }
            else
            {
                LinkButton linkButton = (LinkButton)sender;
                HiddenField companyId = (HiddenField)linkButton.Parent.FindControl("HiddenField1");
                HiddenField CoachId = (HiddenField)linkButton.Parent.FindControl("HiddenField2");
                Label price = (Label)linkButton.Parent.FindControl("lblPrice");
                Label lblSeat = (Label)linkButton.Parent.FindControl("lblSeat");
                Label lbldate = (Label)linkButton.Parent.FindControl("lbldate");
                string p = price.Text.Substring(1, price.Text.Length - 4);
                if (lblSeat.Text != "0")
                {
                    Response.Write("<script>window.open ('/Web/EventTicketBook.aspx?cId=" + companyId.Value + "&EId=" +
                                       CoachId.Value + "&location=" + ViewState["location"].ToString() + "&dt=" + lbldate.Text + "&p=" + p + "&S=" + lblSeat.Text + "','_blank');</script>");
                }
                else
                {
                    linkButton.Enabled = false;
                }
            }
        }
    }
}