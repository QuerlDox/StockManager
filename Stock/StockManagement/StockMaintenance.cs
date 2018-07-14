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
        private IStockInformation _stockInfo;
        private string _message;
        public string Message { get { return this._message; } set { this._message = value; } }


        public StockMaintenance() {

        }
       
        public StockMaintenance(StockInformationInFile stockInfo) {

          _stockInfo = StockInformationInFile.Instance();
          _stockInfo = stockInfo;

        }

        public StockMaintenance(StockInformationSQLServer stockInfo)
        {

           
            _stockInfo = stockInfo;

        }


        public void AddProductToStock(Product product, int qty) {
          
            _stockInfo.Load();
            _stockInfo.AddStock(product, qty);
            _message = _stockInfo.GetMessage();
            
        }

        public void UpdateProductQty(Product product, int qty) {

            _stockInfo.Load();
            _stockInfo.UpdateStock(product, qty);
           // _stockInfo.Save();
           _message = _stockInfo.GetMessage();
         
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
            if (product.ProductStatus != 0)
            {
                if (_stockInfo.GetStockQty(product) == 0)
                {
                    _stockInfo.RemoveStock(product);
                    _message = _stockInfo.GetMessage();
                }
                else
                {

                    _message = product.ProductName + " stock quantity is not zero and thus cannot be deleted";
                }

            }
            else {
                _message = product.ProductName + " stock is still active, only inactive stocks can be deleted ";
            }
            
        }


    }
}
