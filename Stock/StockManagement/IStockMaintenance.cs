using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem.StockManagement
{
    interface IStockMaintenance
    {
        void AddProductToStock(Product product, int qty);
        void UpdateProductQty(Product product, int qty);
        List<Stock> GetStocksOnHand();
        int GetStockQty(Product product);
        void RemoveProductFromStock(Product product);
    }
}
