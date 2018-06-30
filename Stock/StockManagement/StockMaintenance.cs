using StockSystem.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem.StockManagement
{
    internal class StockMaintenance:IStockMaintenance
    {
        private StockInformation _stockInfo;
        private string _message;
        public string Message { get { return this._message; } set { this._message = value; } }


        public StockMaintenance() {

        }
       
        public StockMaintenance(StockInformation stockInfo) {
           _stockInfo = StockInformation.Instance();
           _stockInfo = stockInfo;

        }

        public void AddProductToStock(Product product, int qty) {
            _stockInfo.Load();
            _stockInfo.AddStock(product, qty);
            _message = _stockInfo.message;
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

        public void RemoveProductFromStock(Product product) {
            _stockInfo.Load();
            _stockInfo.RemoveStock(product);
            _message = _stockInfo.message;
            _stockInfo.Save();
        }

    }
}
