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
    public partial class AirList : System.Web.UI.Page
    {
        private MasterClass masterClass;
        private CoachModel coachModel;
        private CoachGateway coachGateway;

        public AirList()
        {
            masterClass = MasterClass.GetInstance();
            coachModel = CoachModel.GetInstance();
            coachGateway = CoachGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["b"]=="1")
                {
                    Response.Write("<script language=javascript>alert('Air updated successfully');</script>");

                }
                Load();
            }
        }
        private void Load()
        {
            masterClass.LoadGrid(gridAir, $@"SELECT   DISTINCT     CoachInfo.CoachId, CoachInfo.CoachName, CoachInfo.CoachType, CoachInfo.CoachNo, CoachInfo.StartingPoint, CoachInfo.EndPoint, CoachInfo.DepartureTime, CoachInfo.ArrivalTime, CoachInfo.TicketPrice, 
                         CoachInfo.Status, CoachInfo.CompanyId,CoachInfo.SeatType, CoachInfo.InTime, A.Name AS DistrictFrom,B.Name AS DistrictTo
FROM            CoachInfo INNER JOIN
                         District A ON A.Id=CoachInfo.DistrictFrom INNER JOIN 
						 District B ON B.Id=CoachInfo.DistrictTo WHERE CoachInfo.Status='{ddlStatus.SelectedValue}'  AND CoachStatus='Air' ORDER BY CoachInfo.CoachId DESC");
        }
        protected void ddlStatus_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Load();
        }

        protected void txtSearch_OnTextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                Load();
            }
            else
            {
                masterClass.LoadGrid(gridAir, $@"
SELECT   DISTINCT     CoachInfo.CoachId, CoachInfo.CoachName, CoachInfo.CoachType, CoachInfo.CoachNo, CoachInfo.StartingPoint, CoachInfo.EndPoint, CoachInfo.DepartureTime, CoachInfo.ArrivalTime, CoachInfo.TicketPrice, 
                         CoachInfo.Status, CoachInfo.CompanyId, CoachInfo.InTime, A.Name AS DistrictFrom,B.Name AS DistrictTo
FROM            CoachInfo INNER JOIN
                         District A ON A.Id=CoachInfo.DistrictFrom INNER JOIN 
						 District B ON B.Id=CoachInfo.DistrictTo WHERE CoachInfo.Status='{ddlStatus.SelectedValue}'  AND CoachStatus='Air' AND CoachInfo.CoachName='{txtSearch.Text}' ORDER BY CoachInfo.CoachId DESC");
            }
        }

        protected void gridAir_OnRowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gridAir_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridAir.PageIndex = e.NewPageIndex;
            Load();
        }

        protected void lnkUpdate_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            HiddenField CoachId = (HiddenField)linkButton.Parent.FindControl("HiddenField1");
            Response.Write("<script>window.open ('/UI/UpdateAir.aspx?CoachId=" + CoachId.Value+ "','_blank');</script>");

        }

        protected void lnkRemove_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            HiddenField CoachId = (HiddenField)linkButton.Parent.FindControl("HiddenField1");
            coachModel.CoachId = Convert.ToInt32(CoachId.Value);
            coachModel.Status = "R";

            bool a = coachGateway.UpdateStatus(coachModel);
            if (a)
            {
                Response.Write("<script language=javascript>alert('Air removed successfully');</script>");
                Load();
            }
            else
            {
                Response.Write("<script language=javascript>alert('Air removed failed');</script>");
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
                Response.Write("<script language=javascript>alert('Air inactivate successfully');</script>");
                Load();
            }
            else
            {
                Response.Write("<script language=javascript>alert('Air inactive failed');</script>");
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
                Response.Write("<script language=javascript>alert('Air activate successfully');</script>");
                Load();
            }
            else
            {
                Response.Write("<script language=javascript>alert('Air active failed');</script>");
            }
        }
    }
}