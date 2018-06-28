using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockSystem.StockManagement;
using StockSystem;

namespace StockManagementUnitTests.Tests
{
    class StockComparer : IEqualityComparer<StockSystem.StockManagement.Stock>
    {

        public bool Equals(Stock x, Stock y)
        {
            //Check whether the objects are the same object. 
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether the products' properties are equal. 
            return x != null && y != null && x.Product.Equals(y.Product) && x.Quantity.Equals(y.Quantity);
        }

        public int GetHashCode(Stock obj)
        {
            //Get hash code for the Name field if it is not null. 
            int hashProductName = obj.Product == null ? 0 : obj.Product.GetHashCode();

            //Get hash code for the Code field. 
            int hashProductCode = obj.Quantity.GetHashCode();

            //Calculate the hash code for the product. 
            return hashProductName ^ hashProductCode;
        }
    }
}
