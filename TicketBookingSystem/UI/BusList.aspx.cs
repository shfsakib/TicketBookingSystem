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
    public partial class BusList : System.Web.UI.Page
    {
        private MasterClass masterClass;
        private BusModel busModel;
        private BusGateway busGateway;

        public BusList()
        {
            masterClass = MasterClass.GetInstance();
            busModel = BusModel.GetInstance();
            busGateway = BusGateway.GetInstance();
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
            masterClass.LoadGrid(gridBus, $@"
SELECT   DISTINCT     BusInfo.BusId, BusInfo.BusName, BusInfo.BusType, BusInfo.BusNo, BusInfo.StartingPoint, BusInfo.EndPoint, BusInfo.DepartureTime, BusInfo.ArrivalTime, BusInfo.TicketPrice, 
                         BusInfo.Status, BusInfo.CompanyId, BusInfo.InTime, A.Name AS DistrictFrom,B.Name AS DistrictTo
FROM            BusInfo INNER JOIN
                         District A ON A.Id=BusInfo.DistrictFrom INNER JOIN 
						 District B ON B.Id=BusInfo.DistrictTo WHERE BusInfo.Status='{ddlStatus.SelectedValue}' ORDER BY BusInfo.BusId DESC");
        }
        protected void ddlStatus_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Load();
        }


        protected void gridBus_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkRemove = (LinkButton)e.Row.FindControl("lbkRemove");
                LinkButton lnkInactive = (LinkButton)e.Row.FindControl("lnkInactive");
                LinkButton lnkActive = (LinkButton)e.Row.FindControl("lnkActive");
                if (ddlStatus.SelectedValue.ToString() == "A")
                {
                    lnkInactive.Visible = true;
                    lnkActive.Visible = false;
                }
                else
                {
                    lnkInactive.Visible = false;
                    lnkActive.Visible = true;
                }
            }
        }

        protected void gridBus_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridBus.PageIndex = e.NewPageIndex;
            Load();
        }

        protected void lbkRemove_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            HiddenField busId = (HiddenField)linkButton.Parent.FindControl("HiddenField1");
            busModel.BusId = Convert.ToInt32(busId.Value);
            busModel.Status = "R";

            bool a = busGateway.UpdateStatus(busModel);
            if (a)
            {
                Response.Write("<script language=javascript>alert('Bus removed successfully');</script>");
                Load();
            }
            else
            {
                Response.Write("<script language=javascript>alert('Bus removed failed');</script>");
            }
        }

        protected void lnkInactive_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            HiddenField busId = (HiddenField)linkButton.Parent.FindControl("HiddenField1");
            busModel.BusId = Convert.ToInt32(busId.Value);
            busModel.Status = "I";
            bool a = busGateway.UpdateStatus(busModel);
            if (a)
            {
                Response.Write("<script language=javascript>alert('Bus inactivate successfully');</script>");
                Load();
            }
            else
            {
                Response.Write("<script language=javascript>alert('Bus inactive failed');</script>");
            }
        }

        protected void lbkActive_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            HiddenField busId = (HiddenField)linkButton.Parent.FindControl("HiddenField1");
            busModel.BusId = Convert.ToInt32(busId.Value);
            busModel.Status = "A";

            bool a = busGateway.UpdateStatus(busModel);
            if (a)
            {
                Response.Write("<script language=javascript>alert('Bus activate successfully');</script>");
                Load();
            }
            else
            {
                Response.Write("<script language=javascript>alert('Bus active failed');</script>");
            }
        }

        protected void txtSearch_OnTextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                Load();
            }
            else
            {
                masterClass.LoadGrid(gridBus, $@"
SELECT   DISTINCT     BusInfo.BusId, BusInfo.BusName, BusInfo.BusType, BusInfo.BusNo, BusInfo.StartingPoint, BusInfo.EndPoint, BusInfo.DepartureTime, BusInfo.ArrivalTime, BusInfo.TicketPrice, 
                         BusInfo.Status, BusInfo.CompanyId, BusInfo.InTime, A.Name AS DistrictFrom,B.Name AS DistrictTo
FROM            BusInfo INNER JOIN
                         District A ON A.Id=BusInfo.DistrictFrom INNER JOIN 
						 District B ON B.Id=BusInfo.DistrictTo WHERE BusInfo.Status='{ddlStatus.SelectedValue}' AND BusInfo.BusName='{txtSearch.Text}' ORDER BY BusInfo.BusId DESC");
            }
        }
    }
}