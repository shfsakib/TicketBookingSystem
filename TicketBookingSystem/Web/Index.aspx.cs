using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsMasterClass;

namespace TicketBookingSystem.Web
{
    public partial class Index : System.Web.UI.Page
    {
        private MasterClass masterClass;

        public Index()
        {
            masterClass=MasterClass.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["p"]=="1")
                {
                    Response.Write("<script language=javascript>alert('Signed up successfully. Thanks for sign up. :)');</script>");
                }
            }
        }
    }
}