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

        public ProductMaintenance(StockInformation stockInfo)
        {
            _stockMaintenance = new StockMaintenance(stockInfo);
            

        }


        public void AddProduct(Product product) {

            _stockMaintenance.AddProductToStock(product, 0);
            _message = _stockMaintenance.Message;
        }

        public void deleteProduct(Product product)
        {
            _stockMaintenance.RemoveProductFromStock(product);
            _message = _stockMaintenance.Message;

        }


    }
   
}
