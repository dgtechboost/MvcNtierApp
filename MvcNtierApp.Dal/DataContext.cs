using System;
using System.Configuration;
using System.Data.SqlClient;

namespace MvcNtierApp.Dal
{
    public class DataContext : IDataContext
    {
        public static string CoreDatabase
        {
           get { return ConfigurationManager.ConnectionStrings["MvcNtierAppConnectionString"].ConnectionString; }
        }

        public virtual SqlConnection DbConnection()
        {
            SqlConnection cnn = new SqlConnection(CoreDatabase);
            if (cnn.ConnectionString == String.Empty)
            {
                return null;
            }
            return cnn ;
        }
    }
}
