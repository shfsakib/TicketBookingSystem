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
    public class RegistrationGateway
    {

        private MasterClass masterClass;
        private SqlConnection connection;
        private SqlCommand command;
        private static RegistrationGateway _instance;
        public static RegistrationGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RegistrationGateway();
            }
            return _instance;
        }
        public RegistrationGateway()
        {
            masterClass = MasterClass.GetInstance();
            connection = new SqlConnection(masterClass.Connection); 
        }

        internal bool Save(RegistrationModel model)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                transaction = connection.BeginTransaction();
                command = new SqlCommand("INSERT INTO Registration(RegId,Name,CompanyName,Email,ContactNo,Gender,DateofBirth,Address,Password,Picture,Status,Type,InTime) VALUES(@RegId,@Name,@CompanyName,@Email,@ContactNo,@Gender,@DateofBirth,@Address,@Password,@Picture,@Status,@Type,@InTime)", connection);
                command.Parameters.AddWithValue("@RegId", model.RegId);
                command.Parameters.AddWithValue("@Name", model.Name);
                command.Parameters.AddWithValue("@CompanyName", model.CompanyName);
                command.Parameters.AddWithValue("@Email", model.Email);
                command.Parameters.AddWithValue("@ContactNo", model.ContactNo);
                command.Parameters.AddWithValue("@Gender", model.Gender);
                command.Parameters.AddWithValue("@DateofBirth", model.DateofBirth);
                command.Parameters.AddWithValue("@Address", model.Address);
                command.Parameters.AddWithValue("@Password", model.Password);
                command.Parameters.AddWithValue("@Picture", model.Picture);
                command.Parameters.AddWithValue("@Status", model.Status);
                command.Parameters.AddWithValue("@Type", model.Type);
                command.Parameters.AddWithValue("@InTime", model.InTime);

                command.Transaction = transaction;
                command.ExecuteNonQuery();
                transaction.Commit();
                result = true;
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }
            return result;
        }
        internal bool Update(RegistrationModel model)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                transaction = connection.BeginTransaction();
                command = new SqlCommand("UPDATE Registration SET Picture=@Picture WHERE RegId=@RegId", connection);
                command.Parameters.AddWithValue("@Picture", model.Picture);
                command.Parameters.AddWithValue("@RegId", model.RegId);

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