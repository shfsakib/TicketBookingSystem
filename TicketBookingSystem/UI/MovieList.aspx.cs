using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsMasterClass;
using TicketBookingSystem.DAL.Gateway;
using TicketBookingSystem.DAL.Model;

namespace TicketBookingSystem.UI
{
    public partial class MovieList : System.Web.UI.Page
    {
        private MasterClass masterClass;
        private EventModel eventModel;
        private EventGateway eventGateway;

        public MovieList()
        {
            masterClass=MasterClass.GetInstance();;
            eventModel=EventModel.GetInstance();
           eventGateway=EventGateway.GetInstance();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["b"] == "1")
                {
                    Response.Write("<script language=javascript>alert('Movie updated successfully');</script>");

                }
                Load();
            }
        }

        private void Load()
        {
            masterClass.LoadGrid(gridMovie,$@"SELECT        EventInfo.EventId, EventInfo.EventName, EventInfo.EventAddress, EventInfo.StartTime, EventInfo.EndTime, EventInfo.EventDate, EventInfo.SeatType, EventInfo.SeatCapacity, EventInfo.Fare, 
                         EventInfo.Picture, EventInfo.CompanyId, EventInfo.Status, EventInfo.InTime, District.Name AS EventLocation
FROM            EventInfo INNER JOIN
                         District ON District.Id = EventInfo.EventLocation WHERE EventInfo.CompanyId = '{masterClass.UserIdCookie()}' AND EventInfo.Status='{ddlStatus.SelectedValue}'");
        }
        protected void ddlStatus_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Load();
        }

        protected void txtSearch_OnTextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text=="")
            {
                Load();
            }
            else
            {
                masterClass.LoadGrid(gridMovie, $@"SELECT        EventInfo.EventId, EventInfo.EventName, EventInfo.EventAddress, EventInfo.StartTime, EventInfo.EndTime, EventInfo.EventDate, EventInfo.SeatType, EventInfo.SeatCapacity, EventInfo.Fare, 
                         EventInfo.Picture, EventInfo.CompanyId, EventInfo.Status, EventInfo.InTime, District.Name AS EventLocation
FROM            EventInfo INNER JOIN
                         District ON District.Id = EventInfo.EventLocation WHERE EventInfo.CompanyId = '{masterClass.UserIdCookie()}' AND EventInfo.Status='{ddlStatus.SelectedValue}' AND EventInfo.EventName='{txtSearch.Text}'");

            }
        }

        protected void gridMovie_OnRowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gridMovie_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridMovie.PageIndex = e.NewPageIndex;
            Load();
        }

        protected void lnkInactive_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            HiddenField eventid = (HiddenField)linkButton.Parent.FindControl("HiddenField1");
            eventModel.EventId = Convert.ToInt32(eventid.Value);
            eventModel.Status = "I";
            bool a = eventGateway.UpdateEventStatus(eventModel);
            if (a)
            {
                Response.Write("<script language=javascript>alert('Movie inactivate successfully');</script>");
                Load();
            }
            else
            {
                Response.Write("<script language=javascript>alert('Movie inactive failed');</script>");
            }
        }

        protected void lnkUpdate_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            HiddenField eventid = (HiddenField)linkButton.Parent.FindControl("HiddenField1");
            Response.Write("<script>window.open ('/UI/UpdateMovie.aspx?MId=" + eventid.Value + "','_blank');</script>");

        }

        protected void lnkRemove_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            HiddenField eventid = (HiddenField)linkButton.Parent.FindControl("HiddenField1");
            eventModel.EventId = Convert.ToInt32(eventid.Value);
            eventModel.Status = "R";
            bool a = eventGateway.UpdateEventStatus(eventModel);
            if (a)
            {
                Response.Write("<script language=javascript>alert('Movie removed successfully');</script>");
                Load();
            }
            else
            {
                Response.Write("<script language=javascript>alert('Movie removed failed');</script>");
            }
        }

        protected void lnkActive_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            HiddenField eventid = (HiddenField)linkButton.Parent.FindControl("HiddenField1");
            eventModel.EventId = Convert.ToInt32(eventid.Value);
            eventModel.Status = "A";
            bool a = eventGateway.UpdateEventStatus(eventModel);
            if (a)
            {
                Response.Write("<script language=javascript>alert('Movie inactivate successfully');</script>");
                Load();
            }
            else
            {
                Response.Write("<script language=javascript>alert('Movie inactive failed');</script>");
            }
        }
    }
}