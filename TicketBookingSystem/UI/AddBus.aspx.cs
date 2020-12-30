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
        private BusModel busModel;
        private BusGateway busGateway;
        public AddBus()
        {
            masterClass = MasterClass.GetInstance();
            busModel = BusModel.GetInstance();
            busGateway = BusGateway.GetInstance();
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
            masterClass.BindDropDown(ddlDistrictFrom, "Select", "SELECT Name,ID FROM District ORDER By Name ASC");
            masterClass.BindDropDown(ddlDistrictTO, "SELECT", "SELECT Name,ID FROM District ORDER By Name ASC");
        }

        private bool BusExist(string BusNo)
        {
            bool ans = false;
            string s =
                masterClass.IsExist(
                    $"SELECT BusNo FROM BusInfo WHERE BusNo='{BusNo}'");
            if (s!="")
            {
                ans = true;
            }
            return ans;
        }
        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            if (txtBusName.Text == "")
            {
                Response.Write("<script language=javascript>alert('Bus name is required');</script>");
                txtBusName.Focus();
            }
            else if (txtBusNo.Text == "")
            {
                Response.Write("<script language=javascript>alert('Bus no is required');</script>");
                txtBusNo.Focus();
            }
            else if (BusExist(txtBusNo.Text))
            {
                Response.Write("<script language=javascript>alert('Bus no already exist');</script>");
            }
            else if (ddlType.Text == "")
            {
                Response.Write("<script language=javascript>alert('Bus type is required');</script>");
                ddlType.Focus();
            }
            else if (ddlDistrictFrom.Text == "")
            {
                Response.Write("<script language=javascript>alert('District from is required');</script>");
                ddlDistrictFrom.Focus();
            }
            else if (ddlDistrictTO.Text == "")
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
                busModel.BusName = txtBusName.Text;
                busModel.BusType = ddlType.Text;
                busModel.BusNo = txtBusNo.Text;
                busModel.DistrictFrom = Convert.ToInt32(ddlDistrictFrom.SelectedValue);
                busModel.DistrictTo = Convert.ToInt32(ddlDistrictTO.SelectedValue);
                busModel.StartingPoint = txtStartPoint.Text;
                busModel.EndPoint = txtEndPoint.Text;
                busModel.DepartureTime = txtDepartureTime.Text;
                busModel.ArrivalTime = txtArrivalTime.Text;
                busModel.TicketPrice = Convert.ToDouble(txtTPrice.Text);
                busModel.Status = ddlStatus.SelectedValue;
                busModel.CompanyId = masterClass.UserIdCookie();
                busModel.InTime = masterClass.Date();
                bool a = busGateway.AddBus(busModel);
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
            txtBusName.Text =
                txtBusNo.Text =
                    txtStartPoint.Text =
                        txtEndPoint.Text = txtDepartureTime.Text = txtArrivalTime.Text = txtTPrice.Text = "";
            ddlType.SelectedIndex =
                ddlDistrictFrom.SelectedIndex = ddlDistrictTO.SelectedIndex = ddlStatus.SelectedIndex = -1;
        }
    }
}