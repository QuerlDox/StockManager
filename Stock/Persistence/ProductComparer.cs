using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem.Persistence
{
    [Serializable]
    internal class ProductComparer : IEqualityComparer<Product>
    {


        public bool Equals(Product x, Product y)
        {
            bool isEqual = false;
            // return (x.ProductCode == y.ProductCode&&x.ProductName == y.ProductName);
            foreach (PropertyInfo prop in x.GetType().GetProperties()) {
                isEqual = prop.GetValue(x, null).Equals(prop.GetValue(y, null));
                if (!isEqual)
                    break;
            }
            return isEqual;
                
        }

        public int GetHashCode(Product obj)
        {
            return obj.ProductCode.GetHashCode();
        }
    }
}
