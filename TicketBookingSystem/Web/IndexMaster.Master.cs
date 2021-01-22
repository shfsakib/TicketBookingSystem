using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsMasterClass;

namespace TicketBookingSystem.Web
{
    public partial class IndexMaster : System.Web.UI.MasterPage
    {
        HttpCookie cookieIndex = HttpContext.Current.Request.Cookies["Ticket"];
        private MasterClass masterClass;

        public IndexMaster()
        {
            masterClass = MasterClass.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (cookieIndex != null)
            {
                if (masterClass.TypeCookie() == "A")
                {
                    Response.Redirect("/UI/AddBus.aspx");
                }
                else if (masterClass.TypeCookie() == "Ad")
                {
                    Response.Redirect("/UI/PassengerList.aspx");
                }
                else if (masterClass.TypeCookie() == "P")
                {
                    logA.Visible = btnSign.Visible = false;
                    userName.Visible = logP.Visible = menuDiv.Visible = true;
                }
                else
                {
                    Response.Redirect("/Web/Login.aspx");
                }
            }
        }

        protected void OnClick(object sender, EventArgs e)
        {
            Response.Write("<script>window.open ('/Web/SignUpOption.aspx','_blank');</script>");
            //Response.Redirect("");
        }

        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            Response.Write("<script>window.open ('/Web/Login.aspx','_blank');</script>");
        }

        protected void logOut_OnServerClick(object sender, EventArgs e)
        {
            masterClass.Logout();
        }
    }
}