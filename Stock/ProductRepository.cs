using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock
{
    class ProductRepository : IProductRepository
    {
        public void Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            using (IDbConnection idbConnection = ConnectionFactory.GetConnection()) {
                 idbConnection.Query<Product>("DELETE FROM[dbo].[Products] WHERE[ProductCode] = '" + product.ProductCode + "'");
            }

        }

        public List<Product> GetAll()
        {

            using (IDbConnection idbConnection = ConnectionFactory.GetConnection()) {
                  return idbConnection.Query<Product>("Select ProductCode, ProductName, ProductStatus from Products").ToList();
            }
        }

        public Product GetById(int id)
        {
            using (IDbConnection idbConnection = ConnectionFactory.GetConnection())
            {
                return idbConnection.Query<Product>("SELECT * FROM [Stock].[dbo].[Products] WHERE [ProductCode] = @Id", new {Id = id}).FirstOrDefault();
            }
        }

        public void Add(Product product)
        {
            using (IDbConnection idbConnection = ConnectionFactory.GetConnection())
            {
                string sqlQuery =  @"INSERT INTO[Stock].[dbo].[Products] ([ProductCode],[ProductName],[ProductStatus]) VALUES ('" + product.ProductCode + "',' " + product.ProductName + "',' " + product.ProductStatus + "')";
            }
        }
    }
}
