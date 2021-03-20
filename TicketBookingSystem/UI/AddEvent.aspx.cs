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
    public partial class AddEvent : System.Web.UI.Page
    {
        private MasterClass masterClass;
        private EventModel eventModel;
        private EventGateway eventGateway;
        public AddEvent()
        {
            masterClass = MasterClass.GetInstance();
            eventModel = EventModel.GetInstance();
            eventGateway = EventGateway.GetInstance();
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
                        Response.Redirect("/UI/BookedListAll.aspx");

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
                masterClass.BindDropDown(ddlDistrict, "SELECT", "SELECT Name,ID FROM District ORDER By Name ASC");
            }
        }
        private bool EventExist(string movieName, string start, string end, string date)
        {
            bool ans = false;
            string s =
                masterClass.IsExist(
                    $"SELECT EventName FROM EventInfo WHERE EventName='{movieName}' AND CompanyId='{masterClass.UserIdCookie()}' StartTime='{start}' AND EndTime='{end}' AND EventDate='{date}' AND  Status!='R'");
            if (s != "")
            {
                ans = true;
            }
            return ans;
        }
        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            if (txtEventName.Text == "")
            {
                Response.Write("<script language=javascript>alert('Event name is required');</script>");
                txtEventName.Focus();
            }
            else if (txtAddress.Text == "")
            {
                Response.Write("<script language=javascript>alert('Address is required');</script>");
                txtAddress.Focus();
            }
            else if (ddlDistrict.Text == "Select")
            {
                Response.Write("<script language=javascript>alert('District is required');</script>");
                ddlDistrict.Focus();
            }
            else if (txtStartTime.Text == "")
            {
                Response.Write("<script language=javascript>alert('Start time is required');</script>");
                txtStartTime.Focus();
            }
            else if (txtEndTime.Text == "")
            {
                Response.Write("<script language=javascript>alert('End time is required');</script>");
                txtEndTime.Focus();
            }
            else if (txtDate.Text == "")
            {
                Response.Write("<script language=javascript>alert('Premier date is required');</script>");
                txtDate.Focus();
            }
            else if (txtSeatCapa.Text == "")
            {
                Response.Write("<script language=javascript>alert('Minimum 30 seats is required');</script>");
                txtSeatCapa.Focus();
            }
            else if (txtTPrice.Text == "")
            {
                Response.Write("<script language=javascript>alert('Ticket price is required');</script>");
                txtTPrice.Focus();
            }
            else if (EventExist(txtEventName.Text, txtStartTime.Text, txtEndTime.Text, txtDate.Text))
            {
                Response.Write("<script language=javascript>alert('Movie already exist');</script>");
            }
            else if (ddlStatus.Text == "Select")
            {
                Response.Write("<script language=javascript>alert('Movie status is required');</script>");
                ddlStatus.Focus();
            }
            else
            {
                eventModel.EventName = txtEventName.Text;
                eventModel.EventAddress = txtAddress.Text;
                eventModel.EventLocation = Convert.ToInt32(ddlDistrict.SelectedValue);
                eventModel.StartTime = txtStartTime.Text;
                eventModel.EndTime = txtEndTime.Text;
                eventModel.EventDate = txtDate.Text;
                eventModel.SeatType = "N/A";
                eventModel.SeatCapacity = Convert.ToInt32(txtSeatCapa.Text);
                eventModel.Fare = Convert.ToDouble(txtTPrice.Text);
                eventModel.Type = "Event";
                if (fileMovie.HasFile)
                {
                    string imagePath = Server.MapPath("/Files/") + fileMovie.FileName;
                    fileMovie.PostedFile.SaveAs(imagePath);
                    eventModel.Picture = "/Files/" + fileMovie.FileName;
                }
                else
                {
                    eventModel.Picture = "";
                }
                eventModel.CompanyId = Convert.ToInt32(masterClass.UserIdCookie());
                eventModel.Status = ddlStatus.SelectedValue;
                eventModel.InTime = masterClass.Date();
                bool ans = eventGateway.InsertEvent(eventModel);
                if (ans)
                {
                    Response.Write("<script language=javascript>alert('Event added successfully');</script>");
                    Refresh();
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Event added failed');</script>");
                }
            }
        }

        private void Refresh()
        {
            txtEventName.Text =
                txtAddress.Text =
                    txtStartTime.Text = txtEndTime.Text = txtDate.Text = txtSeatCapa.Text = txtTPrice.Text = "";
            ddlDistrict.SelectedIndex = ddlStatus.SelectedIndex = -1;
            imgPre.ImageUrl = "../ReferenceFile/images/DummyPic.png";

        }
    }
}