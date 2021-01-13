using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsMasterClass;

namespace TicketBookingSystem.Web
{
    public partial class PrintTicket : System.Web.UI.Page
    {
        private MasterClass masterClass;

        public PrintTicket()
        {
            masterClass = MasterClass.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        private void Load()
        {
            lblFrom.Text = masterClass.IsExist($@"SELECT     DISTINCT  District.Name
FROM            BookTicket Inner JOIN
                         District ON District.Id = BookTicket.FromLocation WHERE BookTicket.TokenId='{ViewState["TokenId"].ToString()}'");
            lblTo.Text = masterClass.IsExist($@"SELECT  DISTINCT  District.Name
FROM            BookTicket Inner JOIN
                         District ON District.Id = BookTicket.ToLocation WHERE BookTicket.TokenId='{ViewState["TokenId"].ToString()}'");
            lblToken.Text = ViewState["TokenId"].ToString();
            ViewState["CompanyId"] =
                masterClass.IsExist(
                    $"SELECT CompanyId FROM BookTicket WHERE TokenId='{ViewState["TokenId"].ToString()}'");
            lblCompany.Text = masterClass.IsExist($"SELECT CompanyName FROM Registration WHERE RegId='{ViewState["CompanyId"].ToString()}'");
            lblBookTime.Text = masterClass.IsExist($"SELECT BookTime FROM BookTicket WHERE TokenId='{ViewState["TokenId"].ToString()}'");
            lblJourney.Text = masterClass.IsExist($"SELECT JourneyDate FROM BookTicket WHERE TokenId='{ViewState["TokenId"].ToString()}'");
           string CoachId= masterClass.IsExist($"SELECT CoachId FROM BookTicket WHERE TokenId='{ViewState["TokenId"].ToString()}'");
            DateTime date=new DateTime();
            date = Convert.ToDateTime(masterClass.IsExist($"SELECT DepartureTime FROM CoachInfo WHERE CoachId='{CoachId}'"));
            lblDeparture.Text= date.ToString("hh:mm tt");
            string type= masterClass.IsExist($"SELECT CoachStatus FROM CoachInfo WHERE CoachId='{CoachId}'");
            if (type=="Bus")
            {
                lblSeat.Text =
                masterClass.IsExist(
                    $"SELECT COUNT(SeatName) FROM BookTicket WHERE TokenId='{ViewState["TokenId"].ToString()}'");
            }
            else if(type== "Launch")
            {
                lblSeat.Text =masterClass.IsExist($"SELECT SeatName FROM BookTicket WHERE TokenId='{ViewState["TokenId"].ToString()}'");
                seatname.Visible = lblSeatName.Visible = false;
            }else if (type == "Air")
            {
                lblSeat.Text =masterClass.IsExist($"SELECT SeatName FROM BookTicket WHERE TokenId='{ViewState["TokenId"].ToString()}'");
                seatname.Visible = lblSeatName.Visible = startP.Visible=lblStart.Visible=lblEnd.Visible = endP.Visible = false;
            }
            lblStart.Text = masterClass.IsExist($"SELECT StartingPoint FROM CoachInfo WHERE CoachId='{CoachId}'");
            lblEnd.Text = masterClass.IsExist($"SELECT EndPoint FROM CoachInfo WHERE CoachId='{CoachId}'");
            lblName.Text = masterClass.NameCookie();
            lblEmail.Text = masterClass.EmailCookie();
            lblSeatFare.Text= masterClass.IsExist(
                    $"SELECT Fare FROM BookTicket WHERE TokenId='{ViewState["TokenId"].ToString()}'");
            lblService.Text= masterClass.IsExist(
                    $"SELECT ServiceCharge FROM BookTicket WHERE TokenId='{ViewState["TokenId"].ToString()}'");
            lblAdvance.Text= masterClass.IsExist(
                    $"SELECT Advance FROM BookTicket WHERE TokenId='{ViewState["TokenId"].ToString()}'");
            lblTotal.Text= masterClass.IsExist(
                    $"SELECT GrandTotal FROM BookTicket WHERE TokenId='{ViewState["TokenId"].ToString()}'");
            masterClass.LoadGrid(gridSeat,$@"SELECT SEATNAME FROM BookTicket WHERE TokenId='{ViewState["TokenId"].ToString()}'");
            if (gridSeat.Rows.Count>=0)
            {
                string sn = "";
                foreach (GridViewRow row in gridSeat.Rows)
                {
                    sn += ((Label)row.FindControl("SeatName")).Text+",";
                }
                lblSeatName.Text = sn.Substring(0, sn.Length - 1);
            }
        }

        private bool IsTokenExist()
        {
            bool a = false;
            string token = masterClass.IsExist($"SELECT TokenId FROM BookTicket WHERE TokenId='{txtToken.Text}' AND UserId='{masterClass.UserIdCookie()}'");
            if (token != "")
            {
                ViewState["TokenId"] = token;
                a = true;
            }
            return a;
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            if (IsTokenExist())
            {
                printDiv.Visible = true;
                Load();

            }
            else
            {
                Response.Write("<script language=javascript>alert('Token id does not exist');</script>");

            }

        }
    }
}