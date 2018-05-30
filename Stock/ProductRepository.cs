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

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {

            using (IDbConnection idbConnection = ConnectionFactory.GetConnection()) {
                if (idbConnection.State == ConnectionState.Closed)
                    idbConnection.Open();
                return idbConnection.Query<Product>("Select ProductCode, ProductName, ProductStatus from Products").ToList();
            }
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
