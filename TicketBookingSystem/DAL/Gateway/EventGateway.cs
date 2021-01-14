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
    public class EventGateway
    {
        private MasterClass masterClass;
        private SqlConnection connection;
        private SqlCommand command;
        private static EventGateway _instance;
        public static EventGateway GetInstance()
        {
            if (_instance == null)
            {
                _instance = new EventGateway();
            }
            return _instance;
        }
        public EventGateway()
        {
            masterClass = MasterClass.GetInstance();
            connection = new SqlConnection(masterClass.Connection);
        }
        internal bool InsertEvent(EventModel model)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                transaction = connection.BeginTransaction();
                command = new SqlCommand("INSERT INTO EventInfo(EventName,EventAddress,EventLocation,StartTime,EndTime,EventDate,SeatType,SeatCapacity,Fare,Picture,CompanyId,Status,InTime,Type) VALUES(@EventName,@EventAddress,@EventLocation,@StartTime,@EndTime,@EventDate,@SeatType,@SeatCapacity,@Fare,@Picture,@CompanyId,@Status,@InTime,@Type)", connection);
                command.Parameters.AddWithValue("@EventName", model.EventName);
                command.Parameters.AddWithValue("@EventAddress", model.EventAddress);
                command.Parameters.AddWithValue("@EventLocation", model.EventLocation);
                command.Parameters.AddWithValue("@StartTime", model.StartTime);
                command.Parameters.AddWithValue("@EndTime", model.EndTime);
                command.Parameters.AddWithValue("@EventDate", model.EventDate);
                command.Parameters.AddWithValue("@SeatType", model.SeatType);
                command.Parameters.AddWithValue("@SeatCapacity", model.SeatCapacity);
                command.Parameters.AddWithValue("@Fare", model.Fare);
                command.Parameters.AddWithValue("@Picture", model.Picture);
                command.Parameters.AddWithValue("@CompanyId", model.CompanyId);
                command.Parameters.AddWithValue("@Status", model.Status);
                command.Parameters.AddWithValue("@InTime", model.InTime);
                command.Parameters.AddWithValue("@Type", model.Type);

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

        internal bool UpdateEventStatus(EventModel model)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                transaction = connection.BeginTransaction();
                command = new SqlCommand("UPDATE EventInfo SET Status=@Status WHERE EventId=@EventId", connection);
                command.Parameters.AddWithValue("@Status", model.Status);
                command.Parameters.AddWithValue("@EventId", model.EventId);

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
        internal bool UpdateEvent(EventModel model)
        {
            bool result = false;
            SqlTransaction transaction = null;
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                transaction = connection.BeginTransaction();
                command = new SqlCommand("UPDATE EventInfo SET  EventName=@EventName, EventAddress=@EventAddress,EventLocation=@EventLocation,StartTime=@StartTime,EndTime=@EndTime,EventDate=@EventDate,SeatType=@SeatType,SeatCapacity=@SeatCapacity,Fare=@Fare,Picture=@Picture,Status=@Status WHERE EventId=@EventId", connection);
                command.Parameters.AddWithValue("@EventAddress", model.EventAddress);
                command.Parameters.AddWithValue("@EventLocation", model.EventLocation);
                command.Parameters.AddWithValue("@StartTime", model.StartTime);
                command.Parameters.AddWithValue("@EndTime", model.EndTime);
                command.Parameters.AddWithValue("@EventDate", model.EventDate);
                command.Parameters.AddWithValue("@SeatType", model.SeatType);
                command.Parameters.AddWithValue("@SeatCapacity", model.SeatCapacity);
                command.Parameters.AddWithValue("@Fare", model.Fare);
                command.Parameters.AddWithValue("@Picture", model.Picture);
                command.Parameters.AddWithValue("@Status", model.Status);
                command.Parameters.AddWithValue("@EventName", model.EventName);
                command.Parameters.AddWithValue("@EventId", model.EventId);

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
    }
}