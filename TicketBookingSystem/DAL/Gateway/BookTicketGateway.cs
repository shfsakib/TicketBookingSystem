using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BitsMasterClass;
using TicketBookingSystem.DAL.Model;

namespace TicketBookingSystem.DAL.Gateway
{
    public class BookTicketGateway
    {
        private MasterClass masterClass;
        private SqlConnection connection;
        private SqlCommand command;
        private static BookTicketGateway _instance;
        public static BookTicketGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BookTicketGateway();
            }
            return _instance;
        }
        public BookTicketGateway()
        {
            masterClass = MasterClass.GetInstance();
            connection = new SqlConnection(masterClass.Connection);
        }
        internal bool BookTicket(BookTicketModal modal)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                transaction = connection.BeginTransaction();
                command = new SqlCommand("INSERT INTO BookTicket(CompanyId,CoachId,FromLocation,ToLocation,JourneyDate,Fare,SeatName,CoachType,SubTotal,ServiceCharge,Advance,GrandTotal,TokenId,BkashNo,TransactionNo,Amount,BookTime,Status,UserId) VALUES(@CompanyId,@CoachId,@FromLocation,@ToLocation,@JourneyDate,@Fare,@SeatName,@CoachType,@SubTotal,@ServiceCharge,@Advance,@GrandTotal,@TokenId,@BkashNo,@TransactionNo,@Amount,@BookTime,@Status,@UserId)", connection);
                command.Parameters.AddWithValue("@CompanyId", modal.CompanyId);
                command.Parameters.AddWithValue("@CoachId", modal.CoachId);
                command.Parameters.AddWithValue("@FromLocation", modal.FromLocation);
                command.Parameters.AddWithValue("@ToLocation", modal.ToLocation);
                command.Parameters.AddWithValue("@JourneyDate", modal.JourneyDate);
                command.Parameters.AddWithValue("@Fare", modal.Fare);
                command.Parameters.AddWithValue("@SeatName", modal.SeatName);
                command.Parameters.AddWithValue("@CoachType", modal.CoachType);
                command.Parameters.AddWithValue("@SubTotal", modal.SubTotal);
                command.Parameters.AddWithValue("@ServiceCharge", modal.ServiceCharge);
                command.Parameters.AddWithValue("@Advance", modal.Advance);
                command.Parameters.AddWithValue("@GrandTotal", modal.GrandTotal);
                command.Parameters.AddWithValue("@TokenId", modal.TokenId);
                command.Parameters.AddWithValue("@BkashNo", modal.BkashNo);
                command.Parameters.AddWithValue("@TransactionNo", modal.TransactionNo);
                command.Parameters.AddWithValue("@Amount", modal.Amount);
                command.Parameters.AddWithValue("@BookTime", modal.BookTime);
                command.Parameters.AddWithValue("@Status", modal.Status);
                command.Parameters.AddWithValue("@UserId", modal.UserId);

                command.Transaction = transaction;
                command.ExecuteNonQuery();
                transaction.Commit();
                result = true;
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            return result;
        }
    }
}