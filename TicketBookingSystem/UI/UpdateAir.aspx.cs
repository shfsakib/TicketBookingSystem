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
    public partial class UpdateAir : System.Web.UI.Page
    {
        private MasterClass masterClass;
        private CoachModel coachModel;
        private CoachGateway coachGateway;
        public UpdateAir()
        {
            masterClass = MasterClass.GetInstance();
            coachModel = CoachModel.GetInstance();
            coachGateway = CoachGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["CoachId"] == "")
                {
                    Response.Redirect("/UI/AddAir.aspx");
                }
                Load();
                LoadData();
            }
        }
        private void Load()
        {
            masterClass.BindDropDown(ddlDistrictFrom, "SELECT", "SELECT Name,ID FROM District ORDER By Name ASC");
            masterClass.BindDropDown(ddlDistrictTO, "SELECT", "SELECT Name,ID FROM District ORDER By Name ASC");
        }

        private void LoadData()
        {
            string coachId = Request.QueryString["CoachId"];
            txtFlightNo.Text = masterClass.IsExist($@"SELECT CoachName FROM CoachInfo WHERE CoachId='{coachId}'");
            ddlDistrictFrom.SelectedValue = masterClass.IsExist($@"SELECT DistrictFrom FROM CoachInfo WHERE CoachId='{coachId}'");
            ddlDistrictTO.Text = masterClass.IsExist($@"SELECT DistrictTo FROM CoachInfo WHERE CoachId='{coachId}'");
            txtDepartureTime.Text = masterClass.IsExist($@"SELECT DepartureTime FROM CoachInfo WHERE CoachId='{coachId}'");
            txtQuickestTime.Text = masterClass.IsExist($@"SELECT ArrivalTime FROM CoachInfo WHERE CoachId='{coachId}'");
            txtSeatCap.Text = masterClass.IsExist($@"SELECT SeatCapacity FROM CoachInfo WHERE CoachId='{coachId}'");
            txtTPrice.Text = masterClass.IsExist($@"SELECT TicketPrice FROM CoachInfo WHERE CoachId='{coachId}'");
        }
        private bool AirExist(string CoachNo)
        {
            bool ans = false;
            string s =
                masterClass.IsExist(
                    $"SELECT CoachNo FROM CoachInfo WHERE CoachNo='{CoachNo}' AND CoachId='{Request.QueryString["CoachId"]}' AND Status!='R'");
            if (s == "")
            {
                ans = true;
            }
            return ans;
        }
        protected void btnUpdate_OnClick(object sender, EventArgs e)
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
            else
            {
                coachModel.CoachId = Convert.ToInt32(Request.QueryString["CoachId"]);
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
                coachModel.CompanyId = masterClass.UserIdCookie();
                coachModel.CoachStatus = "Air";
                coachModel.SeatCapacity = txtSeatCap.Text;
                coachModel.SeatType = "";
                coachModel.InTime = masterClass.Date();
                bool ans = coachGateway.UpdateAir(coachModel);
                if (ans)
                {
                    Response.Redirect("/UI/AirList.aspx");
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Air update failed');</script>");
                }
            }
        }
    }
}