using System.Data.SqlClient;

namespace MvcNtierApp.Dal
{
    public interface IDataContext
    {
        SqlConnection DbConnection();
    }
}
