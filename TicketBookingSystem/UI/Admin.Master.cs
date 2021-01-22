using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsMasterClass;

namespace TicketBookingSystem.UI
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        HttpCookie cookieIndex = HttpContext.Current.Request.Cookies["Ticket"];
        private MasterClass masterClass;
        
        public Admin()
        {
            masterClass=MasterClass.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (cookieIndex != null)
                {
                    
                }
                else
                {
                    Response.Redirect("/Web/Login.aspx");
                }
            }
        }

        protected void OnServerClick(object sender, EventArgs e)
        {
            masterClass.Logout();
        }
    }
}