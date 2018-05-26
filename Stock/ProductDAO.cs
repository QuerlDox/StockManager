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
       // StockResources stockResources = new StockResources();
       // private String dataSource = stockResources.dataSource;

        


        

       

        public ProductDAO() {
            loadData();
        }

        public void loadData()
        {
            StockResources stockResources = new StockResources();
            SqlConnection sqlConnection = new SqlConnection(stockResources.dataSource);

            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM [Stock].[dbo].[Products]", sqlConnection);
            dataTable = new DataTable();
            sda.Fill(dataTable);
           
        }


        public void addProductItem(Product product) {
            StockResources stockResources = new StockResources();
            SqlConnection sqlConnection = new SqlConnection(stockResources.dataSource);
            sqlConnection.Open();
            bool status = false;
            if (product.status == 0)
            {
                status = true;
            }
            else
            {
                status = false;
            }

            var sqlQuery = "";

            if (IfProductsExists(sqlConnection, product.productCode))
            {
                sqlQuery = @"UPDATE [Products] SET [ProductName] = '" + product.productName + "' ,[ProductStatus] = '" + status + "' WHERE [ProductCode] = '" + product.productCode + "'";
            }
            else
            {
                sqlQuery = @"INSERT INTO [Stock].[dbo].[Products]
           ([ProductCode]
           ,[ProductName]
           ,[ProductStatus])
     VALUES
           ('" + product.productCode + "',' " + product.productName + "',' " + status + "')";
            }
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void deleteProductItem(Product product) {


            StockResources stockResources = new StockResources();
            SqlConnection sqlConnection = new SqlConnection(stockResources.dataSource);
            

            var sqlQuery = "";

            if (IfProductsExists(sqlConnection, product.productCode))
            {
                sqlQuery = @"DELETE FROM [dbo].[Products] WHERE [ProductCode] = '" + product.productCode + "'";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                messageBox = " delete "+ product.productName +" ?";

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
