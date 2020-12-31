using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BitsMasterClass;

namespace TicketBookingSystem.Web
{
    public partial class BusTicket : System.Web.UI.Page
    {
        private MasterClass masterClass;

        public BusTicket()
        {
            masterClass = MasterClass.GetInstance();
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
            masterClass.LoadGrid(gridBuses, @"SELECT    DISTINCT    BusInfo.BusId, BusInfo.BusName, BusInfo.BusType, BusInfo.BusNo, BusInfo.DistrictFrom, BusInfo.DistrictTo, BusInfo.StartingPoint, BusInfo.EndPoint, BusInfo.DepartureTime, BusInfo.ArrivalTime, BusInfo.TicketPrice, 
                         BusInfo.Status, BusInfo.CompanyId, BusInfo.InTime, Registration.CompanyName
FROM            BusInfo INNER JOIN
                         Registration ON BusInfo.CompanyId=Registration.RegId WHERE BusInfo.BusType='"+ddlType.Text+"' ORDER By CompanyId ASC");
        }
        protected void txtDisFrom_OnTextChanged(object sender, EventArgs e)
        {
            ViewState["from"] = masterClass.IsExist($"SELECT ID FROM District WHERE Name LIKE '%{txtDisFrom.Text}%'");
        }

        protected void txtDisTo_OnTextChanged(object sender, EventArgs e)
        {
            ViewState["to"] = masterClass.IsExist($"SELECT ID FROM District WHERE Name LIKE '%{txtDisTo.Text}%'");
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            if (txtDisFrom.Text=="")
            {
                
            }
                Response.Write("<script language=javascript>alert('Activate failed');</script>");

        }

        public string TimeC(string time)
        {
            string cTime = "";
            if (time!="")
            {
               DateTime dateTime=new DateTime();
                dateTime = Convert.ToDateTime(time);
                cTime = dateTime.ToString("hh:mm tt");
            }
            return cTime;
        }
        protected void gridBuses_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
        }
    }
}