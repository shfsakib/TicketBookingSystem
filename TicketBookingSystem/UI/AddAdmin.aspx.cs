using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsMasterClass;
using TicketBookingSystem.DAL.Gateway;
using TicketBookingSystem.DAL.Model;

namespace TicketBookingSystem.UI
{
    public partial class AddAdmin : System.Web.UI.Page
    {
        private MasterClass masterClass;
        private RegistrationModel registrationModel;
        private RegistrationGateway registrationGateway;
        public AddAdmin()
        {
            masterClass = MasterClass.GetInstance(); 
            registrationModel=RegistrationModel.GetInstance();
            registrationGateway=RegistrationGateway.GetInstance();
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
            }

        }
        private bool EmailExist(string email)
        {
            bool result = false;
            string ans = masterClass.IsExist($"SELECT Email FROM Registration WHERE Email='{email}'");
            if (ans != "")
            {
                result = true;
            }
            return result;
        }
        protected void btnNext_OnClick(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                txtName.Focus();
            }
            else if (txtEmail.Text == "")
            {
                txtEmail.Focus();
            }
            else if (EmailExist(txtEmail.Text))
            {
                lblMessage.Text = "Email already exist";
                lblMessage.ForeColor = Color.Red;
                lblMessage.Focus();
            }
            else if (txtMobile.Text == "")
            {
                txtMobile.Focus();
            }
            else if (ddlGender.Text == "Select")
            {
                ddlGender.Focus();
            }
            else if (txtDob.Text == "")
            {
                txtDob.Focus();
            }
            else if (txtAddress.Text == "")
            {
                txtAddress.Focus();
            }
            else if (txtNewPass.Text == "")
            {
                txtNewPass.Focus();
            }
            else if (txtNewPass.Text.Length < 4)
            {
                lblMessage.Text = "Minimum 4 digit password required";
                lblMessage.ForeColor = Color.Red;
            }
            else if (txtConfirmPassword.Text == "")
            {
                txtConfirmPassword.Focus();
            }
            else if (txtNewPass.Text != txtConfirmPassword.Text)
            {
                lblMessage.Text = "Password mismatch";
                lblMessage.ForeColor = Color.Red;
            }
            else
            {
                ViewState["RegId"] = masterClass.GenerateId("Select Max(RegId) FROM Registration");
                registrationModel.RegId = ViewState["RegId"].ToString();
                registrationModel.Name = txtName.Text;
                registrationModel.CompanyName = "";
                registrationModel.Email = txtEmail.Text;
                registrationModel.ContactNo = txtMobile.Text;
                registrationModel.Gender = ddlGender.Text;
                registrationModel.DateofBirth = txtDob.Text;
                registrationModel.Address = txtAddress.Text;
                registrationModel.Password = txtNewPass.Text;
                registrationModel.Picture = "";
                registrationModel.Status = "A";
                registrationModel.Type = "P";
                registrationModel.InTime = masterClass.Date();
                if (FileUpload1.HasFile)
                {
                    string imagePath = Server.MapPath("/Files/") + ViewState["RegId"].ToString() + ".png";
                    FileUpload1.PostedFile.SaveAs(imagePath);
                    registrationModel.Picture = "/Files/" + ViewState["RegId"].ToString() + ".png";
                }
                else
                {
                    registrationModel.Picture = "";
                }
                bool a = registrationGateway.CreateAdmin(registrationModel);
                if (a)
                {
                    lblMessage.Text = "Admin created successfully";
                    lblMessage.ForeColor = Color.Green;
                    Refresh();
                }
                else
                {
                    lblMessage.Text = "Can't proceed next page, please try again";
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }

        private void Refresh()
        {
            txtName.Text =
                txtEmail.Text =
                    txtMobile.Text = txtDob.Text = txtAddress.Text = txtNewPass.Text = txtConfirmPassword.Text = "";
            imgUser.Src = "../ReferenceFile/images/DummyPic.png";
            ddlGender.SelectedIndex = -1;

        }
    }
}