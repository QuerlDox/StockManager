using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockSystem.StockManagement;

namespace WindowsStockManagementTests.Tests
{
    class StackComparer : Comparer<Stock>
    {
        public override int Compare(Stock x, Stock y)
        {
            if (x.Product.ProductCode.CompareTo(y.Product.ProductCode) != 0) {
                return x.Product.ProductCode.CompareTo(y.Product.ProductCode);
            }else if(x.Quantity.CompareTo(y.Quantity) != 0){
                return x.Quantity.CompareTo(y.Quantity);
            }else{
                return 0;
            }
        }
    }
}
