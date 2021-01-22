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
    public partial class UserList : System.Web.UI.Page
    {
        private MasterClass masterClass;
        private RegistrationModel registrationModel;
        private RegistrationGateway registrationGateway;

        public UserList()
        {
            masterClass = MasterClass.GetInstance();
            registrationModel = RegistrationModel.GetInstance();
            registrationGateway = RegistrationGateway.GetInstance();
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
                        Response.Redirect("/UI/AddBus.aspx");
                    }
                    else if (masterClass.TypeCookie() == "Ad")
                    {


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
            masterClass.LoadGrid(gridUser, $@"SELECT * FROM Registration WHERE Type='p' AND Status='{ddlType.SelectedValue}' ORDER BY Name ASC");
        }
        protected void gridUser_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkInactive = (LinkButton)e.Row.FindControl("lnkInactive");
                LinkButton lnkActive = (LinkButton)e.Row.FindControl("lbkActive");
                if (ddlType.SelectedValue.ToString() == "A")
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

        protected void gridUser_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridUser.PageIndex = e.NewPageIndex;
            Load();
        }

        protected void lnkInactive_OnClick(object sender, EventArgs e)
        {
            LinkButton lnkInactive = (LinkButton)sender;
            HiddenField regId = (HiddenField)lnkInactive.Parent.FindControl("HiddenField1");
            registrationModel.RegId = regId.Value;
            registrationModel.Status = "I";
            bool a = registrationGateway.UpdateStatus(registrationModel);
            if (a)
            {
                Response.Write("<script language=javascript>alert('Restricted successfully');</script>");
                Load();
            }
            else
            {
                Response.Write("<script language=javascript>alert('Restrict failed');</script>");
            }
        }

        protected void lbkActive_OnClick(object sender, EventArgs e)
        {
            LinkButton lnkInactive = (LinkButton)sender;
            HiddenField regId = (HiddenField)lnkInactive.Parent.FindControl("HiddenField1");
            registrationModel.RegId = regId.Value;
            registrationModel.Status = "A";
            bool a = registrationGateway.UpdateStatus(registrationModel);
            if (a)
            {
                Response.Write("<script language=javascript>alert('Activate successfully');</script>");
                Load();
            }
            else
            {
                Response.Write("<script language=javascript>alert('Activate failed');</script>");
            }
        }

        protected void ddlType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Load();
        }

        protected void txtSearch_OnTextChanged(object sender, EventArgs e)
        {
            masterClass.LoadGrid(gridUser, $@"SELECT * FROM Registration WHERE Type='p' AND Status='{ddlType.SelectedValue}' AND Name +' | '+ContactNo LIKE '%" + txtSearch.Text + "%' ORDER BY Name ASC");
        }
    }
}