

using System.Data.SqlClient;
using System.Configuration;

namespace k_takip
{
    public static class DatabaseHelper
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(
                ConfigurationManager.ConnectionStrings["k_takip.Properties.Settings.Database1ConnectionString"].ConnectionString
            );
        }
    }
}
