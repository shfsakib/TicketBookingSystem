using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsMasterClass;

namespace TicketBookingSystem.Web
{
    public partial class BusTicket : System.Web.UI.Page
    {
        private MasterClass masterClass;
        HttpCookie cookieData = HttpContext.Current.Request.Cookies["Ticket"];
        public BusTicket()
        {
            masterClass = MasterClass.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDisFrom.Focus();
                Load();
            }
        }

        private void Load()
        {
            masterClass.LoadGrid(gridBuses, @"SELECT    DISTINCT    BusInfo.BusId, BusInfo.BusName, BusInfo.BusType, BusInfo.BusNo, BusInfo.DistrictFrom, BusInfo.DistrictTo, BusInfo.StartingPoint, BusInfo.EndPoint, BusInfo.DepartureTime, BusInfo.ArrivalTime, BusInfo.TicketPrice, 
                         BusInfo.Status, BusInfo.CompanyId, BusInfo.InTime, Registration.CompanyName
FROM            BusInfo INNER JOIN
                         Registration ON BusInfo.CompanyId=Registration.RegId WHERE BusInfo.BusType='" + ddlType.Text + "' ORDER By CompanyId ASC");
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
            ViewState["to"] = masterClass.IsExist($"SELECT ID FROM District WHERE Name LIKE '%" +to+ "%'");

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
                masterClass.LoadGrid(gridBuses, @"SELECT    DISTINCT    BusInfo.BusId, BusInfo.BusName, BusInfo.BusType, BusInfo.BusNo, BusInfo.DistrictFrom, BusInfo.DistrictTo, BusInfo.StartingPoint, BusInfo.EndPoint, BusInfo.DepartureTime, BusInfo.ArrivalTime, BusInfo.TicketPrice, 
                         BusInfo.Status, BusInfo.CompanyId, BusInfo.InTime, Registration.CompanyName
FROM            BusInfo INNER JOIN
                         Registration ON BusInfo.CompanyId=Registration.RegId WHERE BusInfo.BusType='" + ddlType.Text + "' AND BusInfo.DistrictFrom='" + from + "' And BusInfo.DistrictTo='" +to + "' ORDER By CompanyId ASC");
            }
            //  Response.Write("<script language=javascript>alert('Activate failed');</script>");

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
        protected void gridBuses_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridBuses.PageIndex = e.NewPageIndex;
            Load();
        }

        protected void ddlType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtDisFrom.Text != "" && txtDisTo.Text != "" && txtJourneyDate.Text != "")
            {
                masterClass.LoadGrid(gridBuses, @"SELECT    DISTINCT    BusInfo.BusId, BusInfo.BusName, BusInfo.BusType, BusInfo.BusNo, BusInfo.DistrictFrom, BusInfo.DistrictTo, BusInfo.StartingPoint, BusInfo.EndPoint, BusInfo.DepartureTime, BusInfo.ArrivalTime, BusInfo.TicketPrice, 
                         BusInfo.Status, BusInfo.CompanyId, BusInfo.InTime, Registration.CompanyName
FROM            BusInfo INNER JOIN
                         Registration ON BusInfo.CompanyId=Registration.RegId WHERE BusInfo.BusType='" + ddlType.Text + "' AND BusInfo.DistrictFrom='" + ViewState["from"].ToString() + "' And BusInfo.DistrictTo='" + ViewState["to"].ToString() + "' ORDER By CompanyId ASC");
            }
            else
            {
                Load();
            }
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
                HiddenField busId = (HiddenField)linkButton.Parent.FindControl("HiddenField2");
                Label price = (Label) linkButton.Parent.FindControl("lblPrice");
                string p = price.Text.Substring(1, price.Text.Length-4);
                Response.Write("<script>window.open ('/Web/BusSeatBookNAc.aspx?cId=" + companyId.Value + "&bId=" + busId.Value + "&from=" + ViewState["from"].ToString() + "&to=" + ViewState["to"].ToString() + "&dt=" + txtJourneyDate.Text + "&p="+ p + "','_blank');</script>");

               // Response.Redirect("/Web/BusSeatBook.aspx?cId=" + companyId.Value + "&bId=" + busId.Value + "&from=" + ViewState["from"].ToString() + "&to=" + ViewState["to"].ToString() + "&dt=" + txtJourneyDate.Text + "");
            }
        }
    }
}