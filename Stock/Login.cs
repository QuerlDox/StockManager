using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock
{
    
    class Login
    {
        // check if eligible to be logged in
        internal bool IsAuthenticated(string username, string pass) {
            StockApplicationResources stockResources = new StockApplicationResources();
            String sqlQuery = @"SELECT COUNT(*) FROM [Stock].[dbo].[Login] Where UserName = @username and Password = @password";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(stockResources.mssqlDataSource))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@username", username));
                        sqlCommand.Parameters.Add(new SqlParameter("@password", pass));

                        int result = (int)sqlCommand.ExecuteScalar();
                        if (result > 0)
                        {
                            return true;
                          
                        }
                        else
                        {
                            return false;
                            
                        }

                    }

                }


            }
            catch (Exception ex)
            {
              throw  ex;
            }



        }


    }
}
