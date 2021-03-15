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
                if (Request.QueryString["b"] == "1")
                {
                    Response.Write("<script language=javascript>alert('Ticket booked successfully.You can print your ticket from print ticket. Please collect your ticket by pay full payment on journey date from starting point.');</script>");
                }
                txtDisFrom.Focus();
                Load();
            }
        }

        private void Load()
        {
            //            if (txtDisFrom.Text != "" && txtDisTo.Text != "" || txtJourneyDate.Text != "")
            //            {
            //                masterClass.LoadGrid(gridBuses, @"SELECT    DISTINCT    CoachInfo.CoachId, CoachInfo.CoachName, CoachInfo.CoachType, CoachInfo.CoachNo, CoachInfo.DistrictFrom, CoachInfo.DistrictTo, CoachInfo.StartingPoint, CoachInfo.EndPoint, CoachInfo.DepartureTime, CoachInfo.ArrivalTime, CoachInfo.TicketPrice, 
            //                         CoachInfo.Status, CoachInfo.CompanyId, CoachInfo.InTime, Registration.CompanyName
            //FROM            CoachInfo INNER JOIN
            //                         Registration ON CoachInfo.CompanyId=Registration.RegId WHERE CoachInfo.CoachType='" + ddlType.Text + "' AND CoachStatus='Bus' ORDER By CompanyId ASC");
            //            }
            //            else
            //            {
            gridBuses.DataSource = null;
            gridBuses.DataBind();
            //}
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
                masterClass.LoadGrid(gridBuses, @"SELECT    DISTINCT    CoachInfo.CoachId, CoachInfo.CoachName, CoachInfo.CoachType, CoachInfo.CoachNo, CoachInfo.DistrictFrom, CoachInfo.DistrictTo, CoachInfo.StartingPoint, CoachInfo.EndPoint, CoachInfo.DepartureTime, CoachInfo.ArrivalTime, CoachInfo.TicketPrice, 
                         CoachInfo.Status, CoachInfo.CompanyId, CoachInfo.InTime, Registration.CompanyName
FROM            CoachInfo INNER JOIN
                         Registration ON CoachInfo.CompanyId=Registration.RegId WHERE CoachInfo.CoachType='" + ddlType.Text + "' AND CoachStatus='Bus' AND CoachInfo.DistrictFrom='" + from + "' And CoachInfo.DistrictTo='" + to + "' ORDER By CompanyId ASC");
            }
            //  Response.Write("<script language=javascript>alert('Activate failed');</script>");

        }
        private void LoadPage()
        {
            string from = ViewState["from"].ToString();
            string to = ViewState["to"].ToString();
            masterClass.LoadGrid(gridBuses, @"SELECT    DISTINCT    CoachInfo.CoachId, CoachInfo.CoachName, CoachInfo.CoachType, CoachInfo.CoachNo, CoachInfo.DistrictFrom, CoachInfo.DistrictTo, CoachInfo.StartingPoint, CoachInfo.EndPoint, CoachInfo.DepartureTime, CoachInfo.ArrivalTime, CoachInfo.TicketPrice, 
                         CoachInfo.Status, CoachInfo.CompanyId, CoachInfo.InTime, Registration.CompanyName
FROM            CoachInfo INNER JOIN
                         Registration ON CoachInfo.CompanyId=Registration.RegId WHERE CoachInfo.CoachType='" + ddlType.Text + "' AND CoachStatus='Bus' AND CoachInfo.DistrictFrom='" + from + "' And CoachInfo.DistrictTo='" + to + "' ORDER By CompanyId ASC");
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
            LoadPage();
        }

        protected void ddlType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
//            if (txtDisFrom.Text != "" && txtDisTo.Text != "" && txtJourneyDate.Text != "")
//            {
//                masterClass.LoadGrid(gridBuses, @"SELECT    DISTINCT    CoachInfo.CoachId, CoachInfo.CoachName, CoachInfo.CoachType, CoachInfo.CoachNo, CoachInfo.DistrictFrom, CoachInfo.DistrictTo, CoachInfo.StartingPoint, CoachInfo.EndPoint, CoachInfo.DepartureTime, CoachInfo.ArrivalTime, CoachInfo.TicketPrice, 
//                         CoachInfo.Status, CoachInfo.CompanyId, CoachInfo.InTime, Registration.CompanyName
//FROM            CoachInfo INNER JOIN
//                         Registration ON CoachInfo.CompanyId=Registration.RegId WHERE CoachInfo.CoachType='" + ddlType.Text + "' AND CoachStatus='Bus' AND CoachInfo.DistrictFrom='" + ViewState["from"].ToString() + "' And CoachInfo.DistrictTo='" + ViewState["to"].ToString() + "' ORDER By CompanyId ASC");
//            }
//            else
//            {
//                Load();
//            }
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
                    Response.Write("<script>window.open ('/Web/BusSeatBookNAc.aspx?cId=" + companyId.Value + "&bId=" + CoachId.Value + "&from=" + ViewState["from"].ToString() + "&to=" + ViewState["to"].ToString() + "&dt=" + txtJourneyDate.Text + "&p=" + p + "&t=" + ddlType.Text + "','_blank');</script>");
                }
                else
                {
                    linkButton.Enabled = false;
                }

                // Response.Redirect("/Web/BusSeatBook.aspx?cId=" + companyId.Value + "&bId=" + CoachId.Value + "&from=" + ViewState["from"].ToString() + "&to=" + ViewState["to"].ToString() + "&dt=" + txtJourneyDate.Text + "");
            }
        }

        protected void gridBuses_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int CoachId = Convert.ToInt32(((HiddenField)e.Row.FindControl("HiddenField2")).Value);
                Label lblSeat = (Label)e.Row.FindControl("lblSeat");
                string countSeat =
                    masterClass.IsExist(
                        $"SELECT COUNT(SeatName) FROM BookTicket WHERE CoachId='{CoachId}' AND JourneyDate='{txtJourneyDate.Text}'");
                int totalSeat = (Convert.ToInt32(lblSeat.Text) - Convert.ToInt32(countSeat));
                lblSeat.Text = totalSeat.ToString();
            }
        }
    }
}