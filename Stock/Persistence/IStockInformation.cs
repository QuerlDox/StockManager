using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockSystem.StockManagement;

namespace StockSystem.Persistence
{
    interface IStockInformation
    {
        

        void AddStock(Product product, int qty);
        void Load();
      //  void Save();
        void UpdateStock(Product product, int qty);
        List<Stock> GetStocksOnHand();
        int GetStockQty(Product product);
        void RemoveStock(Product product);
        string GetMessage();
    }
}
