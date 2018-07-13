using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using StockSystem.StockManagement;

namespace StockSystem.Persistence
{
    class StockInformationSQLServer : IStockInformation
    {
        private IDictionary<string, int> _stockDictionary;
        private List<Product> _productList;
        private List<Stock> _stockList;
        
        private string _message;

        public void AddStock(Product product, int qty)
        {
            if (this._stockDictionary.ContainsKey(product.ProductCode))
            {
                _message = "You had already added " + product.ProductName + "before.";
            }
            else
            {
                try
                {
                    using (IDbConnection idbConnection = ConnectionFactory.OpenConnection())
                    {

                        string sqlQuery = "INSERT INTO Product (ProductCode,ProductName,ProductStatus) values(@productCode,@productName,@productStatus); SELECT CAST(SCOPE_IDENTITY() as int);";
                        idbConnection.Execute(sqlQuery, new { productCode = product.ProductCode, productName = product.ProductName, productStatus = product.ProductStatus });
                        sqlQuery = "INSERT INTO Stock (ProductCode,Quantity) values(@productCode,@stockQuantity); SELECT CAST(SCOPE_IDENTITY() as int);";
                        idbConnection.Execute(sqlQuery, new { productCode = product.ProductCode, stockQuantity = qty });
                        ConnectionFactory.CloseConnection();

                        _message = "The product " + product.ProductName + " was successfully added";
                    }
                }
                catch (Exception e) { _message = e.Message; }

            }
        }

        public string GetMessage()
        {

                return this._message;
           
        }

        public int GetStockQty(Product product)
        {
            int _productQty = 0;
            if (_stockDictionary.ContainsKey(product.ProductCode))
            {
                _productQty = _stockDictionary[product.ProductCode];               
            }
            else
            {
                Console.WriteLine("There are no saved data for the stock information");
            }


            return _productQty;
        

    }

    public List<Stock> GetStocksOnHand()
        {
            _stockList = new List<Stock>();

            foreach (Product product in _productList)
            {
                

                if (_stockDictionary.ContainsKey(product.ProductCode))
                {

                    Stock stock = new Stock()
                    {
                        Product = product,
                        Quantity = _stockDictionary[product.ProductCode]
                    };

                   
                    _stockList.Add(stock);
                }



            }
            return _stockList;
        }

        public void Load()
        {

            try
            {
                using (IDbConnection idbConnection = ConnectionFactory.OpenConnection())
                {

                    _productList = idbConnection.Query<Product>("Select ProductCode, ProductName, ProductStatus from Product").ToList();
                    _stockDictionary = idbConnection.Query("Select ProductCode, Quantity from Stock").ToDictionary(row => (string)row.ProductCode, row => (int)row.Quantity);
                    ConnectionFactory.CloseConnection();

                }
            }
            catch (Exception e) { _message = e.Message; }
            
        }

        public void RemoveStock(Product product)
        {
            if (!this._stockDictionary.ContainsKey(product.ProductCode))
            {
                Console.WriteLine(product.ProductName + " had not been added before.");
                _message = "No product named " + product.ProductName + " found in the stock";
            }
            else
            {
                try
                {
                    using (IDbConnection idbConnection = ConnectionFactory.OpenConnection())
                    {

                        string sqlQuery = "DELETE FROM [dbo].[Stock] WHERE ProductCode=@productCode";
                        idbConnection.Execute(sqlQuery, new { productCode = product.ProductCode });
                        sqlQuery = "DELETE FROM [dbo].[Product] WHERE ProductCode=@productCode";
                        idbConnection.Execute(sqlQuery, new { productCode = product.ProductCode });
                        ConnectionFactory.CloseConnection();
                        _message =  product.ProductName + " was removed from the stock";
                    }
                }
                catch (Exception e) { _message = e.Message; };

            }
          
        }

     

        public void UpdateStock(Product product, int qty)
        {
            try {
                using (IDbConnection idbConnection = ConnectionFactory.OpenConnection()) {
                    string sqlQuery = "Update [dbo].[Stock]  set Quantity = @quantity where ProductCode = @productCode";
                    idbConnection.Execute(sqlQuery, new { quantity = qty,productCode = product.ProductCode });
                    ConnectionFactory.CloseConnection();
                    _message = product.ProductName + " update was successfull";
                }
            }
            catch (Exception e) { _message = e.Message; }
        }
    }
}
