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
    public class CoachGateway
    {
        private MasterClass masterClass;
        private SqlConnection connection;
        private SqlCommand command;
        private static CoachGateway _instance;
        public static CoachGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CoachGateway();
            }
            return _instance;
        }
        public CoachGateway()
        {
            masterClass = MasterClass.GetInstance();
            connection = new SqlConnection(masterClass.Connection);
        }
        internal bool AddBus(CoachModel model)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                transaction = connection.BeginTransaction();
                command = new SqlCommand("INSERT INTO CoachInfo(CoachName,CoachType,CoachNo,DistrictFrom,DistrictTo,StartingPoint,EndPoint,DepartureTime,ArrivalTime,TicketPrice,Status,CompanyId,InTime,SeatType,CoachStatus,SeatCapacity) VALUES(@CoachName,@CoachType,@CoachNo,@DistrictFrom,@DistrictTo,@StartingPoint,@EndPoint,@DepartureTime,@ArrivalTime,@TicketPrice,@Status,@CompanyId,@InTime,@SeatType,@CoachStatus,@SeatCapacity)", connection);
                command.Parameters.AddWithValue("@CoachName", model.CoachName);
                command.Parameters.AddWithValue("@CoachType", model.CoachType);
                command.Parameters.AddWithValue("@CoachNo", model.CoachNo);
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
                command.Parameters.AddWithValue("@SeatType", model.SeatType);
                command.Parameters.AddWithValue("@CoachStatus", model.CoachStatus);
                command.Parameters.AddWithValue("@SeatCapacity", model.SeatCapacity);

                command.Transaction = transaction;
                command.ExecuteNonQuery();
                transaction.Commit();
                result = true;
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            catch (Exception ex)
            {
                string x=ex.Message;
                transaction.Rollback();
            }
            return result;
        }
        internal bool Delete(CoachModel model)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                transaction = connection.BeginTransaction();
                command = new SqlCommand("DELETE FROM CoachInfo WHERE CoachId=@CoachId", connection);
                command.Parameters.AddWithValue("@CoachId", model.CoachId);

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
        internal bool UpdateStatus(CoachModel coachModel)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                transaction = connection.BeginTransaction();
                command = new SqlCommand("UPDATE CoachInfo SET Status=@Status WHERE CoachId=@CoachId", connection);
                command.Parameters.AddWithValue("@Status", coachModel.Status);
                command.Parameters.AddWithValue("@CoachId", coachModel.CoachId);

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