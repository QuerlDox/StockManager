using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace Stock
{
    class ProductDAO
    {

        public DataTable dataTable;
        public String messageBox;
       // StockApplicationResources stockResources = new StockApplicationResources();
       // private String mssqlDataSource = stockResources.mssqlDataSource;

        


        

       

        public ProductDAO() {
            loadData();
        }

        public void loadData()
        {
            StockApplicationResources stockResources = new StockApplicationResources();
            SqlConnection sqlConnection = new SqlConnection(stockResources.mssqlDataSource);

            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM [Stock].[dbo].[Products]", sqlConnection);
            dataTable = new DataTable();
            sda.Fill(dataTable);
           
        }


        public void addProductItem(Product product) {
            StockApplicationResources stockResources = new StockApplicationResources();
            SqlConnection sqlConnection = new SqlConnection(stockResources.mssqlDataSource);
            sqlConnection.Open();
            bool status = false;
            if (product.ProductStatus == 0)
            {
                status = true;
            }
            else
            {
                status = false;
            }

            var sqlQuery = "";

            if (IfProductsExists(sqlConnection, product.ProductCode))
            {
                sqlQuery = @"UPDATE [Products] SET [ProductName] = '" + product.ProductName + "' ,[ProductStatus] = '" + status + "' WHERE [ProductCode] = '" + product.ProductCode + "'";
            }
            else
            {
                sqlQuery = @"INSERT INTO [Stock].[dbo].[Products]
           ([ProductCode]
           ,[ProductName]
           ,[ProductStatus])
     VALUES
           ('" + product.ProductCode + "',' " + product.ProductName + "',' " + status + "')";
            }
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void deleteProductItem(Product product) {


            StockApplicationResources stockResources = new StockApplicationResources();
            SqlConnection sqlConnection = new SqlConnection(stockResources.mssqlDataSource);
            

            var sqlQuery = "";

            if (IfProductsExists(sqlConnection, product.ProductCode))
            {
                sqlQuery = @"DELETE FROM [dbo].[Products] WHERE [ProductCode] = '" + product.ProductCode + "'";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                messageBox = " delete "+ product.ProductName +" ?";

            }
            else
            {
                messageBox ="Record does not exist......";
            }


        }


        private bool IfProductsExists(SqlConnection sqlConnection, String productCode)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT 1 FROM [Stock].[dbo].[Products] WHERE [ProductCode] = '" + productCode + "'", sqlConnection);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
                return true;
            else
                return false;
        }
    }
}
