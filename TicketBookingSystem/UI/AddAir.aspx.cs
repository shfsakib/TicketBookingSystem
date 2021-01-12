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
    public partial class AddAir : System.Web.UI.Page
    {
        private MasterClass masterClass;
        private CoachModel coachModel;
        private CoachGateway coachGateway;
        public AddAir()
        {
            masterClass = MasterClass.GetInstance();
            coachModel = CoachModel.GetInstance();
            coachGateway = CoachGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Load();
            }
        }
        private void Load()
        {
            masterClass.BindDropDown(ddlDistrictFrom, "SELECT", "SELECT Name,ID FROM District ORDER By Name ASC");
            masterClass.BindDropDown(ddlDistrictTO, "SELECT", "SELECT Name,ID FROM District ORDER By Name ASC");
        }
        private bool AirExist(string CoachNo)
        {
            bool ans = false;
            string s =
                masterClass.IsExist(
                    $"SELECT CoachNo FROM CoachInfo WHERE CoachNo='{CoachNo}' AND CompanyId='{masterClass.UserIdCookie()}' AND Status!='R'");
            if (s != "")
            {
                ans = true;
            }
            return ans;
        }
        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            if (txtFlightNo.Text == "")
            {
                Response.Write("<script language=javascript>alert('Flight no is required');</script>");
                txtFlightNo.Focus();
            }
            else if (AirExist(txtFlightNo.Text))
            {
                Response.Write("<script language=javascript>alert('Flight no already exist');</script>");
            }
            else if (ddlDistrictFrom.Text == "--SELECT--")
            {
                Response.Write("<script language=javascript>alert('District from is required');</script>");
                ddlDistrictFrom.Focus();
            }
            else if (ddlDistrictTO.Text == "--SELECT--")
            {
                Response.Write("<script language=javascript>alert('District to is required');</script>");
                ddlDistrictTO.Focus();
            }
            else if (txtDepartureTime.Text == "")
            {
                Response.Write("<script language=javascript>alert('Departure time is required');</script>");
                txtDepartureTime.Focus();
            }
            else if (txtQuickestTime.Text == "")
            {
                Response.Write("<script language=javascript>alert('Quickest time is required');</script>");
                txtQuickestTime.Focus();
            }
            else if (txtTPrice.Text == "")
            {
                Response.Write("<script language=javascript>alert('Ticket price is required');</script>");
                txtTPrice.Focus();
            }
            else if (ddlStatus.Text == "")
            {
                Response.Write("<script language=javascript>alert('Air status is required');</script>");
                ddlStatus.Focus();
            }
            else
            {
                coachModel.CoachName = txtFlightNo.Text;
                coachModel.CoachType = "N/A";
                coachModel.CoachNo = txtFlightNo.Text;
                coachModel.DistrictFrom = Convert.ToInt32(ddlDistrictFrom.SelectedValue);
                coachModel.DistrictTo = Convert.ToInt32(ddlDistrictTO.SelectedValue);
                coachModel.StartingPoint = "N/A";
                coachModel.EndPoint = "N/A";
                coachModel.DepartureTime = txtDepartureTime.Text;
                coachModel.ArrivalTime = txtQuickestTime.Text;
                coachModel.TicketPrice = Convert.ToDouble(txtTPrice.Text);
                coachModel.Status = ddlStatus.SelectedValue;
                coachModel.CompanyId = masterClass.UserIdCookie();
                coachModel.CoachStatus = "Air";
                coachModel.SeatCapacity = txtSeatCap.Text;
                coachModel.SeatType = "";
                coachModel.InTime = masterClass.Date();
                bool a = coachGateway.AddBus(coachModel);
                if (a)
                {
                    Response.Write("<script language=javascript>alert('Air added successfully');</script>");
                    Refresh();
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Air added failed');</script>");

                }
            }
        }
        private void Refresh()
        {
            txtFlightNo.Text =txtDepartureTime.Text = txtQuickestTime.Text = txtTPrice.Text=txtSeatCap.Text = "";
           ddlDistrictFrom.SelectedIndex = ddlDistrictTO.SelectedIndex = ddlStatus.SelectedIndex =  -1;
        }
    }
}