using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using BitsMasterClass;

namespace TicketBookingSystem
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        private MasterClass masterClass;
        private SqlConnection con;
        private SqlCommand cmd;

        public WebService()
        {
            masterClass = MasterClass.GetInstance();
            con = new SqlConnection(masterClass.Connection);
        }
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public List<string> GetPassenger(string txt)
        {
            List<string> result = new List<string>();
            try
            {

                string query = @"SELECT Name +' | '+ContactNo txt FROM Registration WHERE Name +' | '+Email +' | '+ContactNo LIKE '%" + txt + "%' AND Type='P'";
                using (cmd = new SqlCommand(query, con))
                {
                    if (con.State != System.Data.ConnectionState.Open) con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(reader["txt"].ToString().TrimEnd());
                    }
                }
            }
            catch (Exception ex) { }
            return result;
        }
        [WebMethod]
        public List<string> GetAgency(string txt)
        {
            List<string> result = new List<string>();
            try
            {

                string query = @"SELECT CompanyName +' | '+ContactNo txt FROM Registration WHERE Name +' | '+ CompanyName +' | '+Email +' | '+ContactNo LIKE '%" + txt + "%' AND Type='A'";
                using (cmd = new SqlCommand(query, con))
                {
                    if (con.State != System.Data.ConnectionState.Open) con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(reader["txt"].ToString().TrimEnd());
                    }
                }
            }
            catch (Exception ex) { }
            return result;
        }
        [WebMethod]
        public List<string> GetBus(string txt)
        {
            List<string> result = new List<string>();
            try
            {

                string query = @"SELECT CoachName txt FROM CoachInfo WHERE CoachName LIKE '%" + txt + "%' AND CoachStatus='Bus'";
                using (cmd = new SqlCommand(query, con))
                {
                    if (con.State != System.Data.ConnectionState.Open) con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(reader["txt"].ToString().TrimEnd());
                    }
                }
            }
            catch (Exception ex) { }
            return result;
        }
        [WebMethod]
        public List<string> GetLaunch(string txt)
        {
            List<string> result = new List<string>();
            try
            {

                string query = @"SELECT CoachName txt FROM CoachInfo WHERE CoachName LIKE '%" + txt + "%' AND CoachStatus='Launch'";
                using (cmd = new SqlCommand(query, con))
                {
                    if (con.State != System.Data.ConnectionState.Open) con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(reader["txt"].ToString().TrimEnd());
                    }
                }
            }
            catch (Exception ex) { }
            return result;
        }
        [WebMethod]
        public List<string> GetLocation(string txt)
        {
            List<string> result = new List<string>();
            try
            {

                string query = @"SELECT Name txt FROM District WHERE Name LIKE '%" + txt + "%'";
                using (cmd = new SqlCommand(query, con))
                {
                    if (con.State != System.Data.ConnectionState.Open) con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(reader["txt"].ToString().TrimEnd());
                    }
                }
            }
            catch (Exception ex) { }
            return result;
        }

        [WebMethod]
        public List<string> GetToken(string txt)
        {
            List<string> result = new List<string>();
            try
            {

                string query = @"SELECT DISTINCT TokenId txt FROM BookTicket WHERE TokenId LIKE '%" + txt + "%' AND UserId='" + masterClass.UserIdCookie() + "'";
                using (cmd = new SqlCommand(query, con))
                {
                    if (con.State != System.Data.ConnectionState.Open) con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(reader["txt"].ToString().TrimEnd());
                    }
                }
            }
            catch (Exception ex) { }
            return result;
        }
    }
}
