using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock
{
    class ConnectionFactory
    {
        static string sqlServerName = "mssqlDB";
        static SqlConnection sqlConnection = new SqlConnection();
        static string sqlConnectionString = Resources.GetDBConnectionString(sqlServerName);
        public static IDbConnection GetConnection() {
            try
            {
                if (sqlConnection.State != System.Data.ConnectionState.Open)
                {
                    sqlConnection = new SqlConnection(sqlConnectionString);
                    sqlConnection.Open();
                }
                return sqlConnection;
            }
            catch (Exception) {
                throw;
            }
        }
    }
}
