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
            masterClass=MasterClass.GetInstance();
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
                    btnLogin.Visible = btnSign.Visible = false;
                    userName.Visible = userImage.Visible = true;
                    
                }
                else
                {
                    Response.Redirect("/Web/Login.aspx");
                }
            }
        }

        protected void OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/Web/SignUpOption.aspx");
        }

        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("/Web/Login.aspx");
        }
    }
}