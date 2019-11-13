using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestApi.Entities;

namespace TestApi.Repositories
{
    public static class DapperExtensions
    {
        public static List<T> Query<T>(string command, string connection) where T : BaseEntity
        {
            using (IDbConnection db = new MySqlConnection(connection))
            {
                return db.Query<T>(command).ToList();
            }
        }

        public static T QueryFirst<T>(string command, string connection) where T : BaseEntity
        {
            using (IDbConnection db = new MySqlConnection(connection))
            {
                return db.QueryFirstOrDefault<T>(command);
            }
        }
    }
}