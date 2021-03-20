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
    public partial class UpdateMovie : System.Web.UI.Page
    {
        private MasterClass masterClass;
        private EventModel eventModel;
        private EventGateway eventGateway;
        public UpdateMovie()
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
                if (Request.QueryString["MId"] == null)
                {
                    Response.Redirect("/UI/MovieList.aspx");
                }
                masterClass.BindDropDown(ddlDistrict, "SELECT", "SELECT Name,ID FROM District ORDER By Name ASC");
                LoadData();
            }
        }

        private void LoadData()
        {
            string movieId = Request.QueryString["MId"];
            txtMovieName.Text = masterClass.IsExist(@"SELECT EventName FROm EventInfo WHERE EventId='" + movieId + "'");
            txtAddress.Text = masterClass.IsExist(@"SELECT EventAddress FROm EventInfo WHERE EventId='" + movieId + "'");
            ddlDistrict.SelectedValue = masterClass.IsExist(@"SELECT EventLocation FROm EventInfo WHERE EventId='" + movieId + "'");
            txtStartTime.Text = masterClass.IsExist(@"SELECT StartTime FROm EventInfo WHERE EventId='" + movieId + "'");
            txtEndTime.Text = masterClass.IsExist(@"SELECT EndTime FROm EventInfo WHERE EventId='" + movieId + "'");
            txtDate.Text = masterClass.IsExist(@"SELECT EventDate FROm EventInfo WHERE EventId='" + movieId + "'");
            ddlSeatType.SelectedValue = masterClass.IsExist(@"SELECT SeatType FROm EventInfo WHERE EventId='" + movieId + "'");
            txtSeatCapa.Text = masterClass.IsExist(@"SELECT SeatCapacity FROm EventInfo WHERE EventId='" + movieId + "'");
            txtTPrice.Text = masterClass.IsExist(@"SELECT Fare FROm EventInfo WHERE EventId='" + movieId + "'");
            ViewState["img"] = masterClass.IsExist(@"SELECT Picture FROm EventInfo WHERE EventId='" + movieId + "'");
            if (ViewState["img"].ToString() == "")
            {
                imgPre.ImageUrl = "../ReferenceFile/images/DummyPic.png";
            }
            else
                imgPre.ImageUrl = ViewState["img"].ToString();
            ddlStatus.SelectedValue = masterClass.IsExist(@"SELECT Status FROm EventInfo WHERE EventId='" + movieId + "'");
        }
        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            if (txtMovieName.Text == "")
            {
                Response.Write("<script language=javascript>alert('Movie name is required');</script>");
                txtMovieName.Focus();
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
            else if (ddlSeatType.Text == "Select")
            {
                Response.Write("<script language=javascript>alert('Seat type is required');</script>");
                ddlSeatType.Focus();
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
            else if (ddlStatus.Text == "Select")
            {
                Response.Write("<script language=javascript>alert('Movie status is required');</script>");
                ddlStatus.Focus();
            }
            else
            {
                eventModel.EventId= Convert.ToInt32(Request.QueryString["MId"]);
                eventModel.EventName = txtMovieName.Text;
                eventModel.EventAddress = txtAddress.Text;
                eventModel.EventLocation = Convert.ToInt32(ddlDistrict.SelectedValue);
                eventModel.StartTime = txtStartTime.Text;
                eventModel.EndTime = txtEndTime.Text;
                eventModel.EventDate = txtDate.Text;
                eventModel.SeatType = ddlSeatType.SelectedValue;
                eventModel.SeatCapacity = Convert.ToInt32(txtSeatCapa.Text);
                eventModel.Fare = Convert.ToDouble(txtTPrice.Text);
                if (fileMovie.HasFile)
                {
                    string imagePath = Server.MapPath("/Files/") + fileMovie.FileName;
                    fileMovie.PostedFile.SaveAs(imagePath);
                    eventModel.Picture = "/Files/" + fileMovie.FileName;
                }
                else
                {
                    eventModel.Picture = ViewState["img"].ToString();
                }
                eventModel.CompanyId = Convert.ToInt32(masterClass.UserIdCookie());
                eventModel.Status = ddlStatus.SelectedValue;
                eventModel.InTime = masterClass.Date();
                bool ans = eventGateway.UpdateEvent(eventModel);
                if (ans)
                {
                    Response.Redirect("/UI/MovieList.aspx?b=1");
                    Refresh();
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Movie updated failed');</script>");
                }
            }
        }
        private void Refresh()
        {
            txtMovieName.Text =
                txtAddress.Text =
                    txtStartTime.Text = txtEndTime.Text = txtDate.Text = txtSeatCapa.Text = txtTPrice.Text = "";
            ddlDistrict.SelectedIndex = ddlStatus.SelectedIndex = ddlSeatType.SelectedIndex = -1;
            imgPre.ImageUrl = "../ReferenceFile/images/DummyPic.png";

        }
    }
}