using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsMasterClass;
using TicketBookingSystem.DAL.Gateway;
using TicketBookingSystem.DAL.Model;

namespace TicketBookingSystem.Web
{
    public partial class Login : System.Web.UI.Page
    {
        private MasterClass masterClass;
        HttpCookie cookieIndex = HttpContext.Current.Request.Cookies["Ticket"];
        private RegistrationModel registrationModel;
        private RegistrationGateway registrationGateway;
        public Login()
        {
            masterClass = MasterClass.GetInstance();
            registrationModel = RegistrationModel.GetInstance();
            registrationGateway = RegistrationGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtEmail.Focus();
                if (cookieIndex != null)
                {
                    string a = masterClass.TypeCookie();
                    if (masterClass.TypeCookie() == "P")
                    {
                        Response.Redirect("/Web/Index.aspx");
                    }
                    else if (masterClass.TypeCookie() == "A")
                    {
                        Response.Redirect("/UI/AddBus.aspx");
                    }
                    else if (masterClass.TypeCookie() == "Ad")
                    {
                        Response.Redirect("/UI/PassengerList.aspx");
                    }
                }
            }
        }

        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                Response.Write("<script language=javascript>alert('Email is required');</script>");
            }
            else if (txtPassword.Text == "")
            {
                Response.Write("<script language=javascript>alert('Password is required');</script>");
            }
            else
            {
                string pass =
                    masterClass.IsExist(
                        $"SELECT PASSWORD FROM Registration WHERE Email='{txtEmail.Text}' AND Status='A' COLLATE Latin1_General_CS_AI");
                if (pass == txtPassword.Text.Trim())
                {
                    HttpCookie cookie = new HttpCookie("Ticket");
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    cookie["Name"] = masterClass.IsExist($"SELECT Name FROM Registration WHERE Email='{txtEmail.Text}'");
                    cookie["Type"] = masterClass.IsExist($"SELECT Type FROM Registration WHERE Email='{txtEmail.Text}'");
                    cookie["UserId"] = masterClass.IsExist($"SELECT RegId FROM Registration WHERE Email='{txtEmail.Text}'");
                    cookie["Email"] = masterClass.IsExist($"SELECT Email FROM Registration WHERE Email='{txtEmail.Text}'");
                    cookie["Picture"] = masterClass.IsExist($"SELECT Picture FROM Registration WHERE Email='{txtEmail.Text}'");
                    cookie["Mobile"] = masterClass.IsExist($"SELECT ContactNo FROM Registration WHERE Email='{txtEmail.Text}'");
                    cookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cookie);
                    if (cookie["Type"] == "P")
                    {
                        Response.Redirect("/Web/Index.aspx");
                    }
                    else if (cookie["Type"] == "A")
                    {
                        Response.Redirect("/UI/AddBus.aspx");
                    }
                    else if (cookie["Type"] == "Ad")
                    {
                        Response.Redirect("/UI/PassengerList.aspx");
                    }
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Incorrect Password');</script>");
                }
            }
        }

        protected void lnkForgot_OnClick(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                Response.Write("<script language=javascript>alert('Type your email first, then click on forgot password');</script>");
            }
            else
            {
                string pass = masterClass.IsExist($"SELECT Password FROM Registration WHERE Email='{txtEmail.Text}'");
                if (pass == "")
                {
                    Response.Write("<script language=javascript>alert('Email id does not exist');</script>");

                }
                else
                {
                    bool ans = masterClass.SendEmail("myticket995@gmail.com", txtEmail.Text, "Password", "<h3>Hello User,</h3><br/>Your Password is: " + pass, "@myticket1");
                    if (ans)
                    {
                        Response.Write("<script language=javascript>alert('Password has been sent to your email address.');</script>");

                    }
                }

            }
        }
    }
}