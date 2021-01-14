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
                if (Request.QueryString["cId"] == "")
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
            
        }
    }
}