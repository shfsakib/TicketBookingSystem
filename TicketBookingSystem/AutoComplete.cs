using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BitsMasterClass;

namespace TicketBookingSystem
{
    public class AutoComplete
    {
        private MasterClass masterClass;
        private SqlConnection con;
        private SqlCommand cmd;

        public AutoComplete()
        {
            masterClass = MasterClass.GetInstance();
            con = new SqlConnection(masterClass.Connection);
        }
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
    }
}