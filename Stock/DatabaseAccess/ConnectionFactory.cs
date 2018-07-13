using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem
{
    class ConnectionFactory
    {

        
        static string sqlServerName = "mssqlDB";
        static SqlConnection sqlConnection = new SqlConnection();
        static string sqlConnectionString = Resources.getDatabaseConnectionString(sqlServerName);
        
        public static IDbConnection OpenConnection() {
            try
            {
                if (sqlConnection.State != System.Data.ConnectionState.Open)
                {
                   // sqlConnection = new SqlConnection("Data Source = DESKTOP-937IC7S\\MSSQLSERVER01; Initial Catalog = Stock; Integrated Security = True");
                    sqlConnection = new SqlConnection(sqlConnectionString);
                    sqlConnection.Open();
                }
                return sqlConnection;
            }
            catch (Exception) {
                throw;
            }
        }

        public static IDbConnection CloseConnection() {
            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                return sqlConnection;
            }
            catch (Exception)
            {
                throw;
            }
        }

             
        
    }
}
