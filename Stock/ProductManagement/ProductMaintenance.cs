using StockSystem.Persistence;
using StockSystem.StockManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem.ProductManagement
{
    class ProductMaintenance:IProductMaintenance
    {
        private StockMaintenance _stockMaintenance;
        private string _message;
        public string Message { get { return this._message; } set { this._message = value; } }



        public ProductMaintenance()
        {

        }

        public ProductMaintenance(StockInformationInFile stockInfo)
        {
            _stockMaintenance = new StockMaintenance(stockInfo);
            

        }

        public ProductMaintenance(StockInformationSQLServer stockInfo) {
            _stockMaintenance = new StockMaintenance(stockInfo);
        }


        public void AddProduct(Product product) {
            if (this.ProductCodeInUse(product.ProductCode))
            {
                _message = " Sorry the product code " + product.ProductCode + " is already in use, please try a different number.";
            }
            else
            {
                _stockMaintenance.AddProductToStock(product, 0);
                _message = _stockMaintenance.Message;
            }
        }

        public void deleteProduct(Product product)
        {
            _stockMaintenance.RemoveProductFromStock(product);
            _message = _stockMaintenance.Message;

        }

        public List<string> GetProductCodeList() {
            List<string> productCodeList = new List<string>();
            foreach (Stock item in _stockMaintenance.GetStocksOnHand()) {
                productCodeList.Add(item.Product.ProductCode);
            }
            return productCodeList;
        }

        internal bool ProductCodeInUse(string productCode) {

            bool itemInUse = false;
            foreach (string item in GetProductCodeList()) {
                if (item.Equals(productCode)) {
                    itemInUse = true;
                }
            }

            return itemInUse;
        }
        

    }
   
}
