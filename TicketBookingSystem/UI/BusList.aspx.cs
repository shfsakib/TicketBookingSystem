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
    public partial class Bus_Info : System.Web.UI.Page
    {
        private MasterClass masterClass;
        private CoachModel coachModel;
        private CoachGateway coachGateway;

        public Bus_Info()
        {
            masterClass = MasterClass.GetInstance();
            coachModel = CoachModel.GetInstance();
            coachGateway = CoachGateway.GetInstance();
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
                        Response.Redirect("/UI/BookedListAll.aspx");

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
            masterClass.LoadGrid(gridBus, $@"
SELECT   DISTINCT     CoachInfo.CoachId, CoachInfo.CoachName, CoachInfo.CoachType, CoachInfo.CoachNo, CoachInfo.StartingPoint, CoachInfo.EndPoint, CoachInfo.DepartureTime, CoachInfo.ArrivalTime, CoachInfo.TicketPrice, 
                         CoachInfo.Status, CoachInfo.CompanyId, CoachInfo.InTime, A.Name AS DistrictFrom,B.Name AS DistrictTo
FROM            CoachInfo INNER JOIN
                         District A ON A.Id=CoachInfo.DistrictFrom INNER JOIN 
						 District B ON B.Id=CoachInfo.DistrictTo WHERE CoachInfo.Status='{ddlStatus.SelectedValue}' AND CoachStatus='Bus' ORDER BY CoachInfo.CoachId DESC");
        }
        protected void ddlStatus_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Load();
        }

        protected void txtSearch_OnTextChangedChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                Load();
            }
            else
            {
                masterClass.LoadGrid(gridBus, $@"
SELECT   DISTINCT     CoachInfo.CoachId, CoachInfo.CoachName, CoachInfo.CoachType, CoachInfo.CoachNo, CoachInfo.StartingPoint, CoachInfo.EndPoint, CoachInfo.DepartureTime, CoachInfo.ArrivalTime, CoachInfo.TicketPrice, 
                         CoachInfo.Status, CoachInfo.CompanyId, CoachInfo.InTime, A.Name AS DistrictFrom,B.Name AS DistrictTo
FROM            CoachInfo INNER JOIN
                         District A ON A.Id=CoachInfo.DistrictFrom INNER JOIN 
						 District B ON B.Id=CoachInfo.DistrictTo WHERE CoachInfo.Status='{ddlStatus.SelectedValue}'  AND CoachStatus='Bus' AND CoachInfo.CoachName='{txtSearch.Text}' ORDER BY CoachInfo.CoachId DESC");
            }
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
            HiddenField CoachId = (HiddenField)linkButton.Parent.FindControl("HiddenField1");
            coachModel.CoachId = Convert.ToInt32(CoachId.Value);
            coachModel.Status = "R";

            bool a = coachGateway.UpdateStatus(coachModel);
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

        protected void lnkActive_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            HiddenField CoachId = (HiddenField)linkButton.Parent.FindControl("HiddenField1");
            coachModel.CoachId = Convert.ToInt32(CoachId.Value);
            coachModel.Status = "A";

            bool a = coachGateway.UpdateStatus(coachModel);
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

        protected void lnkInactive_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            HiddenField CoachId = (HiddenField)linkButton.Parent.FindControl("HiddenField1");
            coachModel.CoachId = Convert.ToInt32(CoachId.Value);
            coachModel.Status = "I";
            bool a = coachGateway.UpdateStatus(coachModel);
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
    }
}