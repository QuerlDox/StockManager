using StockSystem.StockManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using StockSystem;
using FluentAssertions;
using StockSystem.Persistence;

namespace StockManagementXUnitTests.Test
{
    public class StockMaintenanceXUnitTest
    {
        private static StockInformation stockInfo = StockInformation.Instance();

        private StockMaintenance stockOnHand = new StockMaintenance(stockInfo);

        [Fact]
        public void UpdateProductQty_shouldChangeProductQtyInStock_inXunit()
        {
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



            int expected = 5;
          
                stockOnHand.AddProductToStock(beefPatty, 20);
                stockOnHand.AddProductToStock(buns, 100);
                stockOnHand.UpdateProductQty(beefPatty, 5);
                stockOnHand.UpdateProductQty(buns, 5);
         
            int actual = stockOnHand.GetStockQty(beefPatty);
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void GetStockOnHand_shouldReturnStockOnHand_inXUnit()
        {

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

            StockSystem.StockManagement.Stock stock1 = new StockSystem.StockManagement.Stock()
            {
                Product = beefPatty,
                Quantity = 5,
            };

            StockSystem.StockManagement.Stock stock2 = new StockSystem.StockManagement.Stock()
            {
                Product = buns,
                Quantity = 5,
            };


            List<StockSystem.StockManagement.Stock> StockMockList = new List<StockSystem.StockManagement.Stock>();
            {
                StockMockList.Add(stock1);
                StockMockList.Add(stock2);
            }

            // Arrange 
            List<StockSystem.StockManagement.Stock> expected = StockMockList;

            // Action
            List<StockSystem.StockManagement.Stock> actual = stockOnHand.GetStocksOnHand();

       
            expected.Should().BeEquivalentTo(actual);

        }
    }

}