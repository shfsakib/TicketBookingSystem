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
    public partial class AddBus : System.Web.UI.Page
    {
        private MasterClass masterClass;
        private CoachModel coachModel;
        private CoachGateway coachGateway;
        public AddBus()
        {
            masterClass = MasterClass.GetInstance();
            coachModel = CoachModel.GetInstance();
            coachGateway = CoachGateway.GetInstance();
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
                    }
                    else if (masterClass.TypeCookie() == "Ad")
                    {
                        Response.Redirect("/UI/PassengerList.aspx");

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
            masterClass.BindDropDown(ddlDistrictFrom, "SELECT", "SELECT Name,ID FROM District ORDER By Name ASC");
            masterClass.BindDropDown(ddlDistrictTO, "SELECT", "SELECT Name,ID FROM District ORDER By Name ASC");
        }

        private bool BusExist(string CoachNo)
        {
            bool ans = false;
            string s =
                masterClass.IsExist(
                    $"SELECT CoachNo FROM CoachInfo WHERE CoachNo='{CoachNo}' AND CompanyId='{masterClass.UserIdCookie()}' AND Status!='R'");
            if (s!="")
            {
                ans = true;
            }
            return ans;
        }
        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            if (txtCoachName.Text == "")
            {
                Response.Write("<script language=javascript>alert('Bus name is required');</script>");
                txtCoachName.Focus();
            }
            else if (txtCoachNo.Text == "")
            {
                Response.Write("<script language=javascript>alert('Bus no is required');</script>");
                txtCoachNo.Focus();
            }
            else if (BusExist(txtCoachNo.Text))
            {
                Response.Write("<script language=javascript>alert('Bus no already exist');</script>");
            }
            else if (ddlType.Text == "")
            {
                Response.Write("<script language=javascript>alert('Bus type is required');</script>");
                ddlType.Focus();
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
            else if (txtStartPoint.Text == "")
            {
                Response.Write("<script language=javascript>alert('Start point is required');</script>");
                txtStartPoint.Focus();
            }
            else if (txtEndPoint.Text == "")
            {
                Response.Write("<script language=javascript>alert('End point is required');</script>");
                txtEndPoint.Focus();
            }
            else if (txtDepartureTime.Text == "")
            {
                Response.Write("<script language=javascript>alert('Departure time is required');</script>");
                txtDepartureTime.Focus();
            }
            else if (txtArrivalTime.Text == "")
            {
                Response.Write("<script language=javascript>alert('Arrival time is required');</script>");
                txtArrivalTime.Focus();
            }
            else if (txtTPrice.Text == "")
            {
                Response.Write("<script language=javascript>alert('Ticket price is required');</script>");
                txtTPrice.Focus();
            }
            else if (ddlStatus.Text == "")
            {
                Response.Write("<script language=javascript>alert('Bus status is required');</script>");
                ddlStatus.Focus();
            }
            else
            {
                coachModel.CoachName = txtCoachName.Text;
                coachModel.CoachType = ddlType.Text;
                coachModel.CoachNo = txtCoachNo.Text;
                coachModel.DistrictFrom = Convert.ToInt32(ddlDistrictFrom.SelectedValue);
                coachModel.DistrictTo = Convert.ToInt32(ddlDistrictTO.SelectedValue);
                coachModel.StartingPoint = txtStartPoint.Text;
                coachModel.EndPoint = txtEndPoint.Text;
                coachModel.DepartureTime = txtDepartureTime.Text;
                coachModel.ArrivalTime = txtArrivalTime.Text;
                coachModel.TicketPrice = Convert.ToDouble(txtTPrice.Text);
                coachModel.Status = ddlStatus.SelectedValue;
                coachModel.CompanyId = masterClass.UserIdCookie();
                coachModel.CoachStatus = "Bus";
                coachModel.SeatCapacity = "";
                coachModel.SeatType = "";
                coachModel.InTime = masterClass.Date();
                bool a = coachGateway.AddBus(coachModel);
                if (a)
                {
                    Response.Write("<script language=javascript>alert('Bus added successfully');</script>");
                    Refresh();
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Bus added failed');</script>");

                }
            }
        }

        private void Refresh()
        {
            txtCoachName.Text =
                txtCoachNo.Text =
                    txtStartPoint.Text =
                        txtEndPoint.Text = txtDepartureTime.Text = txtArrivalTime.Text = txtTPrice.Text = "";
            ddlType.SelectedIndex =
                ddlDistrictFrom.SelectedIndex = ddlDistrictTO.SelectedIndex = ddlStatus.SelectedIndex = -1;
        }
    }
}