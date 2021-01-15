using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsMasterClass;
using TicketBookingSystem.DAL.Gateway;
using TicketBookingSystem.DAL.Model;

namespace TicketBookingSystem.Web
{
    public partial class MovieTicketBook : System.Web.UI.Page
    {
        private MasterClass masterClass;
        private BookTicketModal bookTicketModal;
        private BookTicketGateway bookTicketGateway;
        Random _random = new Random();
        private string charge = "";
        public MovieTicketBook()
        {
            masterClass = MasterClass.GetInstance();
            bookTicketModal = BookTicketModal.GetInstance();
            bookTicketGateway = BookTicketGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["cId"]== null)
                {
                    Response.Redirect("/Web/MovieTicket.aspx");
                }
                txtSeatAvailable.Text = Request.QueryString["S"];
                lblRandom.Text = RandomString(8, false);
                txtSeatNo.Focus();
            }
        }
        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
        protected void txtSeatNo_OnTextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtSeatNo.Text) <= 3)
            {
                charge = "50";
            }
            else if (Convert.ToInt32(txtSeatNo.Text) <= 6)
            {
                charge = "100";
            }
            if (txtSeatNo.Text != "" || txtSeatNo.Text != "0")
            {
                int seat = Convert.ToInt32(txtSeatNo.Text);
                double price = Convert.ToDouble(Request.QueryString["p"]);
                double subtotal = seat * price;
                txtSubTotal.Text = subtotal.ToString();
                txtService.Text = charge.Trim();
                double total = Convert.ToDouble(txtSubTotal.Text) + Convert.ToDouble(txtService.Text);
                txtTotal.Text = total.ToString();
                txtAmount.Text = (Convert.ToDouble(total) * .2).ToString();
                paymentPercentage.InnerText = txtAmount.Text;

            }

        }

        protected void btnBuy_OnClick(object sender, EventArgs e)
        {
            if (txtSeatNo.Text == "" || txtSeatNo.Text == "0")
            {
                Response.Write("<script language=javascript>alert('Please choose seat first');</script>");
            }
            else if (txtBkashNo.Text == "")
            {
                Response.Write("<script language=javascript>alert('Bkash no is required');</script>");
            }
            else if (txtTransNo.Text == "")
            {
                Response.Write("<script language=javascript>alert('Transaction no is required');</script>");
            }
            else if (txtAmount.Text == "")
            {
                Response.Write("<script language=javascript>alert('Amount is required');</script>");
            }
            else
            {
                bookTicketModal.CompanyId = Convert.ToInt32(Request.QueryString["cId"]);
                bookTicketModal.CoachId = Convert.ToInt32(Request.QueryString["MId"]);
                bookTicketModal.FromLocation = Convert.ToInt32(Request.QueryString["location"]);
                bookTicketModal.ToLocation = 0;
                bookTicketModal.JourneyDate = Request.QueryString["dt"];
                bookTicketModal.CoachType = "Event";
                bookTicketModal.SubTotal = Convert.ToDouble(txtSubTotal.Text);
                bookTicketModal.ServiceCharge = Convert.ToDouble(txtService.Text);
                bookTicketModal.Advance = Convert.ToDouble(paymentPercentage.InnerText);
                bookTicketModal.GrandTotal = Convert.ToDouble(txtTotal.Text);
                bookTicketModal.TokenId = lblRandom.Text;
                bookTicketModal.BkashNo = txtBkashNo.Text;
                bookTicketModal.TransactionNo = txtTransNo.Text;
                bookTicketModal.SeatName = txtSeatNo.Text;
                bookTicketModal.Amount = txtAmount.Text;
                bookTicketModal.BookTime = masterClass.Date();
                bookTicketModal.Status = "A";
                bookTicketModal.Fare = Convert.ToDouble(Request.QueryString["p"]);
                bookTicketModal.UserId = masterClass.UserIdCookie();
                bool ans = bookTicketGateway.BookTicket(bookTicketModal);
                if (ans)
                {
                    string email =
                        masterClass.IsExist($"SELECT Email FROM Registration WHERE RegId='{masterClass.UserIdCookie()}'");
                    bool a = masterClass.SendEmail("myticket995@gmail.com", email, "Token", "<h3>Hello Passenger,</h3><br/>Your Token id is: '<b>" + lblRandom.Text + "</b>'.Use this token to print your ticket.", "@myticket1");
                    if (a)
                    {
                        Response.Redirect("/Web/MovieTicket.aspx?b=1");
                    }
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Ticket booking failed');</script>");
                }
            }
        }
    }
}