using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsMasterClass;

namespace TicketBookingSystem.Web
{
    public partial class AirTicket : System.Web.UI.Page
    {
        private MasterClass masterClass;
        private HttpCookie cookieData = HttpContext.Current.Request.Cookies["Ticket"];

        public AirTicket()
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
                        "<script language=javascript>alert('Ticket booked successfully.You can print your ticket from print ticket. Please collect your ticket by pay full payment on journey date from starting point.');</script>");
                }
                txtDisFrom.Focus();
                Load();
            }
        }
        private void Load()
        {
            gridAir.DataSource = null;
            gridAir.DataBind();
        }
        protected void txtDisFrom_OnTextChanged(object sender, EventArgs e)
        {
            string from = "";
            if (txtDisFrom.Text.Contains("'"))
            {
                from = txtDisFrom.Text.Replace("'", "''");
            }
            else
            {
                from = txtDisFrom.Text;
            }
            ViewState["from"] = masterClass.IsExist($"SELECT ID FROM District WHERE Name LIKE '%{from}%'");
            txtDisTo.Focus();
            Load();
        }

        protected void txtDisTo_OnTextChanged(object sender, EventArgs e)
        {
            string to = "";
            if (txtDisTo.Text.Contains("'"))
            {
                to = txtDisTo.Text.Replace("'", "''");
            }
            else
            {
                to = txtDisTo.Text;
            }
            ViewState["to"] = masterClass.IsExist($"SELECT ID FROM District WHERE Name LIKE '%" + to + "%'");

            txtJourneyDate.Focus();
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            if (txtDisFrom.Text == "")
            {
                Response.Write("<script language=javascript>alert('Please enter from location');</script>");
            }
            else if (txtDisTo.Text == "")
            {
                Response.Write("<script language=javascript>alert('Please enter to location');</script>");
            }
            else if (txtJourneyDate.Text == "")
            {
                Response.Write("<script language=javascript>alert('Please enter journey date');</script>");
            }
            else
            {
                string from = ViewState["from"].ToString();
                string to = ViewState["to"].ToString();
                masterClass.LoadGrid(gridAir,
                    @"SELECT    DISTINCT    CoachInfo.CoachId, CoachInfo.CoachName,CoachInfo.SeatType, CoachInfo.CoachType, CoachInfo.CoachNo,  CoachInfo.SeatCapacity, CoachInfo.DistrictFrom, CoachInfo.DistrictTo, CoachInfo.StartingPoint, CoachInfo.EndPoint, CoachInfo.DepartureTime, CoachInfo.ArrivalTime, CoachInfo.TicketPrice, 
                         CoachInfo.Status, CoachInfo.CompanyId, CoachInfo.InTime, Registration.CompanyName,Registration.Picture
FROM            CoachInfo INNER JOIN
                         Registration ON CoachInfo.CompanyId=Registration.RegId WHERE  CoachStatus='Air' AND CoachInfo.DistrictFrom='" +
                    from + "' And CoachInfo.DistrictTo='" + to + "' ORDER By CompanyId ASC");
            }
        }
        private void LoadPage()
        {
            string from = ViewState["from"].ToString();
            string to = ViewState["to"].ToString();
            masterClass.LoadGrid(gridAir,
                    @"SELECT    DISTINCT    CoachInfo.CoachId, CoachInfo.CoachName,CoachInfo.SeatType, CoachInfo.CoachType, CoachInfo.CoachNo,  CoachInfo.SeatCapacity, CoachInfo.DistrictFrom, CoachInfo.DistrictTo, CoachInfo.StartingPoint, CoachInfo.EndPoint, CoachInfo.DepartureTime, CoachInfo.ArrivalTime, CoachInfo.TicketPrice, 
                         CoachInfo.Status, CoachInfo.CompanyId, CoachInfo.InTime, Registration.CompanyName,Registration.Picture
FROM            CoachInfo INNER JOIN
                         Registration ON CoachInfo.CompanyId=Registration.RegId WHERE  CoachStatus='Air' AND CoachInfo.DistrictFrom='" +
                    from + "' And CoachInfo.DistrictTo='" + to + "' ORDER By CompanyId ASC");

        }
        protected void lnkView_OnClick(object sender, EventArgs e)
        {
            if (cookieData == null)
            {
                Response.Write("<script language=javascript>alert('Please log in first');</script>");
            }
            else if (txtDisFrom.Text == "")
            {
                Response.Write("<script language=javascript>alert('Please enter from location');</script>");
            }
            else if (txtDisTo.Text == "")
            {
                Response.Write("<script language=javascript>alert('Please enter to location');</script>");
            }
            else if (txtJourneyDate.Text == "")
            {
                Response.Write("<script language=javascript>alert('Please enter journey date');</script>");
            }
            else
            {
                LinkButton linkButton = (LinkButton)sender;
                HiddenField companyId = (HiddenField)linkButton.Parent.FindControl("HiddenField1");
                HiddenField CoachId = (HiddenField)linkButton.Parent.FindControl("HiddenField2");
                Label price = (Label)linkButton.Parent.FindControl("lblPrice");
                Label lblSeat = (Label)linkButton.Parent.FindControl("lblSeat");
                string p = price.Text.Substring(1, price.Text.Length - 4);
                if (lblSeat.Text != "0")
                {
                    Response.Write("<script>window.open ('/Web/AirBook.aspx?cId=" + companyId.Value + "&AId=" +
                                       CoachId.Value + "&from=" + ViewState["from"].ToString() + "&to=" +
                                       ViewState["to"].ToString() + "&dt=" + txtJourneyDate.Text + "&p=" + p + "&S=" + lblSeat.Text + "','_blank');</script>");
                }
                else
                {
                    linkButton.Enabled = false;
                }
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

        protected void gridAir_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridAir.PageIndex = e.NewPageIndex;
            LoadPage();
        }

        protected void gridAir_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int CoachId = Convert.ToInt32(((HiddenField)e.Row.FindControl("HiddenField2")).Value);
                Label lblSeat = (Label)e.Row.FindControl("lblSeat");
                string countSeat =
                    masterClass.IsExist(
                        $@"SELECT SUM(Convert(int,SeatName)) FROM BookTicket  WHERE CoachId='{CoachId}' AND JourneyDate='{txtJourneyDate.Text}'");
                int totalSeat = (Convert.ToInt32(lblSeat.Text) - Convert.ToInt32(countSeat));
                lblSeat.Text = totalSeat.ToString();
            }
        }
    }
}