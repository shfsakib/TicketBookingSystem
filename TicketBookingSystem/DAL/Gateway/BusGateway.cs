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
    public class BusGateway
    {
        private MasterClass masterClass;
        private SqlConnection connection;
        private SqlCommand command;
        private static BusGateway _instance;
        public static BusGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BusGateway();
            }
            return _instance;
        }
        public BusGateway()
        {
            masterClass = MasterClass.GetInstance();
            connection = new SqlConnection(masterClass.Connection);
        }
        internal bool AddBus(BusModel model)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                transaction = connection.BeginTransaction();
                command = new SqlCommand("INSERT INTO BusInfo(BusName,BusType,BusNo,DistrictFrom,DistrictTo,StartingPoint,EndPoint,DepartureTime,ArrivalTime,TicketPrice,Status,CompanyId,InTime) VALUES(@BusName,@BusType,@BusNo,@DistrictFrom,@DistrictTo,@StartingPoint,@EndPoint,@DepartureTime,@ArrivalTime,@TicketPrice,@Status,@CompanyId,@InTime)", connection);
                command.Parameters.AddWithValue("@BusName", model.BusName);
                command.Parameters.AddWithValue("@BusType", model.BusType);
                command.Parameters.AddWithValue("@BusNo", model.BusNo);
                command.Parameters.AddWithValue("@DistrictFrom", model.DistrictFrom);
                command.Parameters.AddWithValue("@DistrictTo", model.DistrictTo);
                command.Parameters.AddWithValue("@StartingPoint", model.StartingPoint);
                command.Parameters.AddWithValue("@EndPoint", model.EndPoint);
                command.Parameters.AddWithValue("@DepartureTime", model.DepartureTime);
                command.Parameters.AddWithValue("@ArrivalTime", model.ArrivalTime);
                command.Parameters.AddWithValue("@TicketPrice", model.TicketPrice);
                command.Parameters.AddWithValue("@Status", model.Status);
                command.Parameters.AddWithValue("@CompanyId", model.CompanyId);
                command.Parameters.AddWithValue("@InTime", model.InTime);

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
        internal bool Delete(BusModel model)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                transaction = connection.BeginTransaction();
                command = new SqlCommand("DELETE FROM BusInfo WHERE BusId=@BusId", connection);
                command.Parameters.AddWithValue("@BusId", model.BusId);

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
        internal bool UpdateStatus(BusModel busModel)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                transaction = connection.BeginTransaction();
                command = new SqlCommand("UPDATE BusInfo SET Status=@Status WHERE BusId=@BusId", connection);
                command.Parameters.AddWithValue("@Status", busModel.Status);
                command.Parameters.AddWithValue("@BusId", busModel.BusId);

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