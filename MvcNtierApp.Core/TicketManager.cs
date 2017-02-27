using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MvcNtierApp.Dal;

namespace MvcNtierApp.Core
{
    public class TicketManager
    {
        readonly DataContext _dataContext = new DataContext();

        public List<UserTicketCount> Get()
        {
            var connection = _dataContext.DbConnection();

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.Connection = connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UserTicketCount";
            connection.Open();
            var returnedObject = new List<UserTicketCount>();

            try
            {
                if (connection.State == ConnectionState.Closed) { connection.Open(); }
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {

                    returnedObject.Add(
                                         new UserTicketCount()
                                         {
                                             Name = (string)reader["Name"],
                                             Open = (int)reader["Open"],
                                             WIP = (int)reader["WIP"],
                                             Closed = (int)reader["Closed"]
                                         }
                                        );
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            connection.Close();
            return returnedObject;
        }
    }
}
