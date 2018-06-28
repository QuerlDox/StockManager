using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem.StockManagement
{
    [Serializable]
    class Stock
    {
        private Product _product;
        private int _quantity;
        public Product Product { get {return this._product; } set { this._product = value; } }
        public int Quantity { get { return this._quantity; } set {this._quantity = value; } }

        public Stock() {

        }

        public Stock(Product product, int qty) {
            this._product = product;
            this._quantity = qty;
        }
    }
}
