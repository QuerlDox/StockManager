using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem
{
    class ProductRepository : IProductRepository
    {
        public void Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            using (IDbConnection idbConnection = ConnectionFactory.OpenConnection()) {
                 idbConnection.Query<Product>("DELETE FROM[dbo].[Products] WHERE[ProductCode] = '" + product.ProductCode + "'");
                idbConnection.Close();
            }

        }

        public List<Product> GetAll()
        {

            using (IDbConnection idbConnection = ConnectionFactory.OpenConnection()) {
                  List<Product> product = idbConnection.Query<Product>("Select ProductCode, ProductName, ProductStatus from Products").ToList();
                 idbConnection.Close();
                 return product;
            }
        }

        public Product GetById(int id)
        {
            using (IDbConnection idbConnection = ConnectionFactory.OpenConnection())
            {
                Product product = idbConnection.Query<Product>("SELECT * FROM [Stock].[dbo].[Products] WHERE [ProductCode] = @Id", new {Id = id}).FirstOrDefault();
                idbConnection.Close();
                return product;
            }
        }

        public void Add(Product product)
        {
            using (IDbConnection idbConnection = ConnectionFactory.OpenConnection())
            {
                string sqlQuery =  @"INSERT INTO[Stock].[dbo].[Products] ([ProductCode],[ProductName],[ProductStatus]) VALUES ('" + product.ProductCode + "',' " + product.ProductName + "',' " + product.ProductStatus + "')";
                idbConnection.Execute(sqlQuery);
                idbConnection.Close();
                
            }
        }


    }
}
