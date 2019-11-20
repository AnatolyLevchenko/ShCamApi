using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace Api
{
    public static class Helper
    {
         static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;

        public static IDbConnection CreateConnection()
        {
            var conn = new MySqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }



    }


}