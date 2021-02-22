using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
    public partial class BusSeatBook : System.Web.UI.Page
    {
        private MasterClass masterClass;
        private DataTable dataTable;
        private DataRow dataRow;
        string fare = "";
        private int count = 0;
        Random _random = new Random();
        private BookTicketModal bookTicketModal;
        private BookTicketGateway bookTicketGateway;
        public BusSeatBook()
        {
            masterClass = MasterClass.GetInstance();
            bookTicketModal = BookTicketModal.GetInstance();
            bookTicketGateway = BookTicketGateway.GetInstance();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["cId"] == null)
                {
                    Response.Redirect("/Web/BusTicket.aspx");
                }
                Session["Grid"] = null;
                LoadSession();
                LoadSeatGrid();
                fare = Request.QueryString["p"];
                btnA.BackColor = Color.PowderBlue;
                btnS.BackColor = Color.GreenYellow;
                btnB.BackColor = Color.Purple;
                ColorButton();
                CheckSeat();
                lblRandom.Text = RandomString(8, false);
                number.InnerText =
                    masterClass.IsExist($"SELECT ContactNo FROM Registration WHERE RegId='{Request.QueryString["cId"]}'");

            }
        }
        private void LoadSeatGrid()
        {
            gridTicket.DataSource = Session["Grid"];
            gridTicket.DataBind();
            if (lblGrandTotal.Text != "0")
            {
                if (gridTicket.Rows.Count <= 3)
                {
                    lblServiceCharge.Text = "50";
                }
                else
                {
                    lblServiceCharge.Text = "100";
                }
            }


        }
        private void LoadSession()
        {
            if (Session["Grid"] == null)
            {
                dataTable = new DataTable();
                dataTable.Columns.Add("SeatName", typeof(string));
                dataTable.Columns.Add("Fare", typeof(string));
                Session["Grid"] = dataTable;
            }
        }
        //Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");

        private bool CheckRow(string seatName)
        {
            bool ans = false;
            dataTable = (DataTable)Session["Grid"];

            int rowCount = gridTicket.Rows.Count;
            for (int j = 0; j < rowCount; j++)
            {
                string name = dataTable.Rows[j][0].ToString();
                if (name == seatName)
                {
                    dataTable.Rows[j].Delete();
                    ans = true;
                    break;
                }
            }
            if (gridTicket.Rows.Count <= 3)
            {
                lblServiceCharge.Text = "50";
            }
            else
            {
                lblServiceCharge.Text = "100";
            }
            return ans;
        }
        private void CalculateSum()
        {
            double total = 0.00, gTotal = 100;
            int row = gridTicket.Rows.Count;
            dataTable = (DataTable)Session["Grid"];

            for (int i = 0; i < row; i++)
            {
                total += Convert.ToDouble(dataTable.Rows[i][1].ToString());
            }
            if (total != 0.0)
            {
                lblSubTotal.Text = total.ToString();
                gTotal += total;
                lblGrandTotal.Text = gTotal.ToString();
            }
            else
            {
                lblSubTotal.Text = lblGrandTotal.Text = lblServiceCharge.Text = "0";
            }
            if (gridTicket.Rows.Count >= 0)
            {
                paymentPercentage.InnerText = (Convert.ToDouble(lblGrandTotal.Text) * .2).ToString();
                txtAmount.Text= (Convert.ToDouble(lblGrandTotal.Text) * .2).ToString();
            }
        }


        protected void btnA1_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnA1.Text);
            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnA1.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;

                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnA1.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnA1.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();

        }

        protected void btnA2_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnA2.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnA2.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;

                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnA2.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnA2.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();

        }

        protected void btnA3_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnA3.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnA3.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;

                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnA3.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnA3.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();

        }

        protected void btnA4_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnA4.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnA4.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;

                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnA4.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnA4.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();

        }

        protected void btnB1_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnB1.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnB1.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;

                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnB1.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnB1.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();

        }

        protected void btnB2_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnB2.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnB2.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnB2.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnB2.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnB3_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnB3.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnB3.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnB3.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnB3.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnB4_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnB4.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnB4.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnB4.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnB4.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnc1_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnc1.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnc1.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnc1.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnc1.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnC2_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnC2.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnC2.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnC2.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnC2.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnC3_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnC3.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnC3.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnC3.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnC3.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnC4_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnC4.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnC4.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnC4.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnC4.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnD1_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnD1.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnD1.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnD1.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnD1.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnD2_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnD2.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnD2.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnD2.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnD2.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnD3_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnD3.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnD3.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnD3.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnD3.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnD4_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnD4.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnD4.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnD4.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnD4.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnE1_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnE1.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnE1.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnE1.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnE1.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnE2_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnE2.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnE2.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnE2.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnE2.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnE3_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnE3.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnE3.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnE3.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnE3.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnE4_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnE4.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnE4.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnE4.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnE4.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnF1_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnF1.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnF1.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnF1.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnF1.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnF2_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnF2.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnF2.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnF2.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnF2.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnF3_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnF3.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnF3.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnF3.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnF3.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnF4_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnF4.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnF4.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnF4.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnF4.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnG1_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnG1.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnG1.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnG1.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnG1.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnG2_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnG2.Text);
            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnG2.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnG2.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnG2.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnG3_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnG3.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnG3.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnG3.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnG3.BackColor = Color.PowderBlue;
            }
            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnG4_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnG4.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnG4.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnG4.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnG4.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnH1_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnH1.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnH1.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnH1.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnH1.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnH2_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnH2.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnH2.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnH2.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnH2.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnH3_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnH3.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnH3.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnH3.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnH3.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnH4_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnH4.Text);
            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnH4.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnH4.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnH4.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnI1_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnI1.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnI1.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnI1.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnI1.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnI2_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnI2.Text);
            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnI2.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnI2.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnI2.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnI3_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnI3.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnI3.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnI3.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnI3.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        protected void btnI4_OnClick(object sender, EventArgs e)
        {
            bool a = CheckRow(btnI4.Text);

            if (!a)
            {
                if (gridTicket.Rows.Count >= 6)
                {
                    Response.Write("<script language=javascript>alert('You can not book ticket more than 6');</script>");
                }
                else
                {
                    dataTable = (DataTable)Session["Grid"];
                    dataRow = dataTable.NewRow();
                    dataRow["SeatName"] = btnI4.Text;
                    dataRow["Fare"] = Request.QueryString["p"].ToString();
                    dataTable.Rows.Add(dataRow);
                    Session["Grid"] = dataTable;
                    if (gridTicket.Rows.Count < 3)
                    {
                        lblServiceCharge.Text = "50";
                    }
                    else
                    {
                        lblServiceCharge.Text = "100";
                    }
                    btnI4.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                btnI4.BackColor = Color.PowderBlue;
            }

            LoadSeatGrid();
            CalculateSum();
        }

        private void ColorButton()
        {
            btnA1.BackColor = btnA2.BackColor = btnA3.BackColor = btnA4.BackColor = btnB1.BackColor = btnB2.BackColor =
                btnB3.BackColor =
                    btnB4.BackColor = btnc1.BackColor = btnC2.BackColor = btnC3.BackColor = btnC4.BackColor =
                        btnD1.BackColor =
                            btnD2.BackColor = btnD3.BackColor = btnD4.BackColor = btnE1.BackColor = btnE2.BackColor =
                                btnE3.BackColor =
                                    btnE4.BackColor =
                                        btnF1.BackColor = btnF2.BackColor = btnF3.BackColor = btnF4.BackColor =
                                            btnG1.BackColor =
                                                btnG2.BackColor =
                                                    btnG3.BackColor =
                                                        btnG4.BackColor = btnH1.BackColor = btnH2.BackColor =
                                                            btnH3.BackColor =
                                                                btnH4.BackColor =
                                                                    btnI1.BackColor =
                                                                        btnI2.BackColor =
                                                                            btnI3.BackColor =
                                                                                btnI4.BackColor = Color.PowderBlue;
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

        protected void btnBuy_OnClick(object sender, EventArgs e)
        {
            if (gridTicket.Rows.Count < 0)
            {
                Response.Write("<script language=javascript>alert('Please choose your seat first');</script>");
            }
            else if (txtBkashNo.Text == "")
            {
                Response.Write("<script language=javascript>alert('Bkash no is required');</script>");
                txtBkashNo.Focus();
            }
            else if (txtTransNo.Text == "")
            {
                Response.Write("<script language=javascript>alert('Transaction no is required');</script>");
                txtTransNo.Focus();
            }
            else if (txtAmount.Text == "")
            {
                Response.Write("<script language=javascript>alert('Please enter transaction amount');</script>");
                txtAmount.Focus();
            }
            else if (Convert.ToDouble(txtAmount.Text) < Convert.ToDouble(paymentPercentage.InnerText))
            {
                Response.Write("<script language=javascript>alert('Please pay full advance or your booking will be cancelled');</script>");
                txtAmount.Focus();
            }
            else
            {
                bookTicketModal.CompanyId = Convert.ToInt32(Request.QueryString["cId"]);
                bookTicketModal.CoachId = Convert.ToInt32(Request.QueryString["bId"]);
                bookTicketModal.FromLocation = Convert.ToInt32(Request.QueryString["from"]);
                bookTicketModal.ToLocation = Convert.ToInt32(Request.QueryString["to"]);
                bookTicketModal.JourneyDate = Request.QueryString["dt"];
                bookTicketModal.CoachType = Request.QueryString["t"];
                bookTicketModal.SubTotal = Convert.ToDouble(lblSubTotal.Text);
                bookTicketModal.ServiceCharge = Convert.ToDouble(lblServiceCharge.Text);
                bookTicketModal.Advance = Convert.ToDouble(paymentPercentage.InnerText);
                bookTicketModal.GrandTotal = Convert.ToDouble(lblGrandTotal.Text);
                bookTicketModal.TokenId = lblRandom.Text;
                bookTicketModal.BkashNo = txtBkashNo.Text;
                bookTicketModal.TransactionNo = txtTransNo.Text;
                bookTicketModal.Amount = txtAmount.Text;
                bookTicketModal.BookTime = masterClass.Date();
                bookTicketModal.Status = "A";
                bookTicketModal.UserId = masterClass.UserIdCookie();
                bool ans = false;
                foreach (GridViewRow row in gridTicket.Rows)
                {
                    bookTicketModal.SeatName = ((Label)row.FindControl("lblSeat")).Text;
                    bookTicketModal.Fare = Convert.ToInt32(((Label)row.FindControl("lblFare")).Text);
                    ans = bookTicketGateway.BookTicket(bookTicketModal);
                }
                if (ans)
                {

                    string email =
                        masterClass.IsExist($"SELECT Email FROM Registration WHERE RegId='{masterClass.UserIdCookie()}'");
                    bool a = masterClass.SendEmail("myticket995@gmail.com", email, "Token", "<h3>Hello Passenger,</h3><br/>Your Token id is: '<b>" + lblRandom.Text + "</b>'.Use this token to print your ticket.", "@myticket1");
                    if (a)
                    {
                        Response.Redirect("/Web/BusTicket.aspx?b=1");
                    }
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Ticket booking failed');</script>");
                }
            }
        }

        private bool CheckSeatExist(string seatName)
        {
            bool a = false;
            string ans = masterClass.IsExist($"SELECT SeatName FROM BookTicket WHERE CompanyId='{Request.QueryString["cId"].ToString()}' AND CoachId='{Request.QueryString["bId"].ToString()}' AND FromLocation='{Request.QueryString["from"].ToString()}' AND JourneyDate='{Request.QueryString["dt"].ToString()}' AND SeatName='{seatName}' AND Status='A'");
            if (ans != "")
            {
                a = true;
            }
            return a;
        }
        private void CheckSeat()
        {
            if (CheckSeatExist("A1"))
            {
                btnA1.Enabled = false;
                btnA1.BackColor = Color.Purple;
            }
            if (CheckSeatExist("A2"))
            {
                btnA2.Enabled = false;
                btnA2.BackColor = Color.Purple;
            }
            if (CheckSeatExist("A3"))
            {
                btnA3.Enabled = false;
                btnA3.BackColor = Color.Purple;
            }
            if (CheckSeatExist("A4"))
            {
                btnA4.Enabled = false;
                btnA4.BackColor = Color.Purple;
            }
            if (CheckSeatExist("B1"))
            {
                btnB1.Enabled = false;
                btnB1.BackColor = Color.Purple;
            }
            if (CheckSeatExist("B2"))
            {
                btnB2.Enabled = false;
                btnB2.BackColor = Color.Purple;
            }
            if (CheckSeatExist("B3"))
            {
                btnB3.Enabled = false;
                btnB3.BackColor = Color.Purple;
            }
            if (CheckSeatExist("B4"))
            {
                btnB4.Enabled = false;
                btnB4.BackColor = Color.Purple;
            }
            if (CheckSeatExist("C1"))
            {
                btnc1.Enabled = false;
                btnc1.BackColor = Color.Purple;
            }
            if (CheckSeatExist("C2"))
            {
                btnC2.Enabled = false;
                btnC2.BackColor = Color.Purple;
            }
            if (CheckSeatExist("C3"))
            {
                btnC3.Enabled = false;
                btnC3.BackColor = Color.Purple;
            }
            if (CheckSeatExist("C4"))
            {
                btnC4.Enabled = false;
                btnC4.BackColor = Color.Purple;
            }
            if (CheckSeatExist("D1"))
            {
                btnD1.Enabled = false;
                btnD1.BackColor = Color.Purple;
            }
            if (CheckSeatExist("D2"))
            {
                btnD2.Enabled = false;
                btnD2.BackColor = Color.Purple;
            }
            if (CheckSeatExist("D3"))
            {
                btnD3.Enabled = false;
                btnD3.BackColor = Color.Purple;
            }
            if (CheckSeatExist("D4"))
            {
                btnD4.Enabled = false;
                btnD4.BackColor = Color.Purple;
            }
            if (CheckSeatExist("E1"))
            {
                btnE1.Enabled = false;
                btnE1.BackColor = Color.Purple;
            }
            if (CheckSeatExist("E2"))
            {
                btnE2.Enabled = false;
                btnE2.BackColor = Color.Purple;
            }
            if (CheckSeatExist("E3"))
            {
                btnE3.Enabled = false;
                btnE3.BackColor = Color.Purple;
            }
            if (CheckSeatExist("E4"))
            {
                btnE4.Enabled = false;
                btnE4.BackColor = Color.Purple;
            }
            if (CheckSeatExist("F1"))
            {
                btnF1.Enabled = false;
                btnF1.BackColor = Color.Purple;
            }
            if (CheckSeatExist("F2"))
            {
                btnF2.Enabled = false;
                btnF2.BackColor = Color.Purple;
            }
            if (CheckSeatExist("F3"))
            {
                btnF3.Enabled = false;
                btnF3.BackColor = Color.Purple;
            }
            if (CheckSeatExist("F4"))
            {
                btnF4.Enabled = false;
                btnF4.BackColor = Color.Purple;
            }
            if (CheckSeatExist("G1"))
            {
                btnG1.Enabled = false;
                btnG1.BackColor = Color.Purple;
            }
            if (CheckSeatExist("G2"))
            {
                btnG2.Enabled = false;
                btnG2.BackColor = Color.Purple;
            }
            if (CheckSeatExist("G3"))
            {
                btnG3.Enabled = false;
                btnG3.BackColor = Color.Purple;
            }
            if (CheckSeatExist("G4"))
            {
                btnG4.Enabled = false;
                btnG4.BackColor = Color.Purple;
            }
            if (CheckSeatExist("H1"))
            {
                btnH1.Enabled = false;
                btnH1.BackColor = Color.Purple;
            }
            if (CheckSeatExist("H2"))
            {
                btnH2.Enabled = false;
                btnH2.BackColor = Color.Purple;
            }
            if (CheckSeatExist("H3"))
            {
                btnH3.Enabled = false;
                btnH3.BackColor = Color.Purple;
            }
            if (CheckSeatExist("H4"))
            {
                btnH4.Enabled = false;
                btnH4.BackColor = Color.Purple;
            }
            if (CheckSeatExist("I1"))
            {
                btnI1.Enabled = false;
                btnI1.BackColor = Color.Purple;
            }
            if (CheckSeatExist("I2"))
            {
                btnI2.Enabled = false;
                btnI2.BackColor = Color.Purple;
            }
            if (CheckSeatExist("I3"))
            {
                btnI3.Enabled = false;
                btnI3.BackColor = Color.Purple;
            }
            if (CheckSeatExist("I4"))
            {
                btnI4.Enabled = false;
                btnI4.BackColor = Color.Purple;
            }
        }

    }
}