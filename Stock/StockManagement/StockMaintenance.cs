using StockSystem.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem.StockManagement
{
    internal class StockMaintenance
    {
        private StockInformation _stockInfo;

        public StockMaintenance() {

        }
       
        public StockMaintenance(StockInformation stockInfo) {
           _stockInfo = StockInformation.Instance();
           _stockInfo = stockInfo;

        }

        public void AddProductToStock(Product product, int qty) {
            _stockInfo.Load();
            _stockInfo.AddStock(product, qty);
            _stockInfo.Save();
        }

        public void UpdateProductQty(Product product, int qty) {
        
            _stockInfo.Load();
            _stockInfo.UpdateStock(product, qty);
            _stockInfo.Save();
        }



        public List<Stock> GetStocksOnHand() {
            _stockInfo.Load();
              return  _stockInfo.GetStocksOnHand();
        }


        public int GetStockQty(Product product) {
            _stockInfo.Load();
           return  _stockInfo.GetStockQty(product);
        }

    }
}
