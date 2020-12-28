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

namespace TicketBookingSystem.Web
{
    public partial class SignAgent : System.Web.UI.Page
    {
        private MasterClass masterClass;
        private RegistrationModel registrationModel;
        private RegistrationGateway registrationGateway;
        Random random = new Random();
        public SignAgent()
        {
            masterClass = MasterClass.GetInstance();
            registrationModel = RegistrationModel.GetInstance();
            registrationGateway = RegistrationGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
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
            }else if (txtCompanyName.Text=="")
            {
                txtCompanyName.Focus();
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
            else if (txtAddress.Text == "")
            {
                txtAddress.Focus();
            }
            else if (txtNewPass.Text == "")
            {
                txtNewPass.Focus();
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
                registrationModel.CompanyName = txtCompanyName.Text;
                registrationModel.Email = txtEmail.Text;
                registrationModel.ContactNo = txtMobile.Text;
                registrationModel.Gender = ddlGender.Text;
                registrationModel.DateofBirth = "";
                registrationModel.Address = txtAddress.Text;
                registrationModel.Password = txtNewPass.Text;
                registrationModel.Picture = "";
                registrationModel.Status = "A";
                registrationModel.Type = "A";
                registrationModel.InTime = masterClass.Date();
                bool a = registrationGateway.Save(registrationModel);
                if (a)
                {
                    MultiView1.ActiveViewIndex = 1;
                }
                else
                {
                    lblMessage.Text = "Can't proceed next page, please try again";
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }

        protected void btnSign_OnClick(object sender, EventArgs e)
        {
            hiddenRandom.Value = random.Next(111111, 999999).ToString();
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
            bool a = registrationGateway.Update(registrationModel);
            if (a)
            {
                bool ans = masterClass.SendEmail("myticket995@gmail.com", txtEmail.Text, "Email Verification Code", "<h3>Hello User,</h3><br/>Your verification code is: " + hiddenRandom.Value, "@myticket1");
                if (ans)
                {
                    MultiView1.ActiveViewIndex = 2;
                }
                else
                {
                    lblMessage.Text = "Can't proceed next page, please try again";
                    lblMessage.ForeColor = Color.Red;
                }
            }
            else
            {
                lblMessage.Text = "Can't proceed next page, please try again";
                lblMessage.ForeColor = Color.Red;
            }
        }

        protected void btnConfirm_OnClick(object sender, EventArgs e)
        {

            if (txtCode.Text == "" || txtCode.Text != hiddenRandom.Value)
            {
                lblCode.Text = "Your code is invalid";
                lblCode.ForeColor = Color.Red;
                txtCode.Focus();
            }
            else if (txtCode.Text == hiddenRandom.Value)
            {
                Response.Redirect("/Web/Index.aspx?p=1");
            }
        }
    }
}