using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem
{
    interface IProductRepository:IRepository<Product>
    {
        List<Product> GetAll();
    }
}
