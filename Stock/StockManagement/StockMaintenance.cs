using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem.StockManagement
{
    internal class StockMaintenance
    {
        public int enterQty(int qty) {
            return qty;
        }

        public List<Stock> GetStockOnHand() {

            Product beefPatty = new Product
            {
                ProductCode = "1",
                ProductName = "beefPatty",
                ProductStatus = 1
            };


            Product buns = new Product
            {
                ProductCode = "2",
                ProductName = "Buns",
                ProductStatus = 1
            };

            Stock stock1 = new Stock()
            {
                Product = beefPatty,
                Quantity = 10,
            };

            Stock stock2 = new Stock()
            {
                Product = buns,
                Quantity = 100,
            };

            List<Stock> StockOnHand = new List<Stock>();
            StockOnHand.Add(stock1);
            StockOnHand.Add(stock2);

            return StockOnHand;


        }

    }
}
