using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock
{
    class ProductService
    {
        public string message;

        public ProductService() {
            loadData();
        }

        public void addProductItem(Product product) {

            
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

            if (IfProductsExists(product.ProductCode))
            {
                 sqlQuery = @"UPDATE [Products] SET [ProductName] = '" + product.ProductName + "' ,[ProductStatus] = '" + status + "' WHERE [ProductCode] = '" + product.ProductCode + "'";
              

                using (IDbConnection idbConnection = ConnectionFactory.GetConnection())
                {
                    idbConnection.Execute(sqlQuery);
                    //idbConnection.Close();
                }
            }
            else
            {
                IProductRepository productRepository = new ProductRepository();
                productRepository.Add(product);
             }
           

        }


        public void deleteProductItem(Product product)
        {
            

            IProductRepository productRepository = new ProductRepository();
            
            if (IfProductsExists(product.ProductCode)) {

                productRepository.Delete(product);
                message = " delete " + product.ProductName + " ?";
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
