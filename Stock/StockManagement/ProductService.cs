using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem
{
    class StockMaintenanceUsingDB
    {
        public string message;

        public StockMaintenanceUsingDB() {
            loadData();
        }

        public void addProductItem(Product product) {

        
            var sqlQuery = "";

            if (IfProductsExists(product.ProductCode))
            {
                 sqlQuery = @"UPDATE [Products] SET [ProductName] = '" + product.ProductName + "' ,[ProductStatus] = '" + product.ProductStatus + "' WHERE [ProductCode] = '" + product.ProductCode + "'";
              

                using (IDbConnection idbConnection = ConnectionFactory.OpenConnection())
                {
                    idbConnection.Execute(sqlQuery);
                    
                }
            }
            else
            {
                IProductRepository productRepository = new ProductRepository();
                productRepository.Add(product);
             }
           

        }

        internal void RemoveProductFromStock(Product product)
        {
            throw new NotImplementedException();
        }

        internal void AddProductToStock(Product product, int v)
        {
            throw new NotImplementedException();
        }

        public void deleteProductItem(Product product)
        {
            

            IProductRepository productRepository = new ProductRepository();
            
            if (IfProductsExists(product.ProductCode)) {
                if (product.ProductStatus == 1)
                {
                    productRepository.Delete(product);
                    message = " delete " + product.ProductName + " ?";
                }
                else {
                    message = product.ProductName + " is still active and cannot be deleted ....";
                }
            }
            else
            {
                message = "Record does not exist......";
            }
        }

        public List<Product> loadData() {
            IProductRepository productRepository = new ProductRepository();
           return  productRepository.GetAll();

        }

        private bool IfProductsExists(String productCode)
        {
            int id = Int32.Parse(productCode);
            IProductRepository productRepository = new ProductRepository();
            Product product = productRepository.GetById(id);
            if (product != null)
                return true;
            else
                return false;
        }
    }
}
