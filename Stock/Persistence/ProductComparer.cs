using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem.Persistence
{
    [Serializable]
    internal class ProductComparer : IEqualityComparer<Product>
    {


        public bool Equals(Product x, Product y)
        {
            return (x.ProductCode == y.ProductCode);
        }

        public int GetHashCode(Product obj)
        {
            return obj.ProductCode.GetHashCode();
        }
    }
}
