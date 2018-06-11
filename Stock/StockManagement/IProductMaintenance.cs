using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem.StockManagement
{
    internal interface IProductMaintenance
    {
        void addProduct(Product product);
        void removeProduct(Product product);
        void editProduct(Product product, string field, string value);
    }
}   
