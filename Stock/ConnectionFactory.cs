﻿using System;
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
        static string sqlConnectionString = Resources.getDatabaseConnectionString(sqlServerName);
        
        public static IDbConnection GetConnection() {
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



       
        /*
        static StockApplicationResources stockResources = new StockApplicationResources();
        static SqlConnection sqlConnection = new SqlConnection();
        public static IDbConnection GetConnection()
        {
            try
            {
                if (sqlConnection.State != System.Data.ConnectionState.Open)
                {
                    sqlConnection = new SqlConnection(stockResources.mssqlDataSource);
                    sqlConnection.Open();
                }
                return sqlConnection;
            }
            catch (Exception)
            {
                throw;
            }
        }
        */
    }
}
