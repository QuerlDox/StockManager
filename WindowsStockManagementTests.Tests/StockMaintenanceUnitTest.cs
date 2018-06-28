using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockSystem;
using StockSystem.Persistence;
using StockSystem.StockManagement;

namespace StockManagementUnitTests.Tests
{
    [TestClass]
    public class StockMaintentanceUnitTest
    {
        
        
        [TestMethod]
        public void UpdateProductQty_shouldChangeProductQtyInStock()
        {
            Product buns = new Product
            {
                ProductCode = "2",
                ProductName = "Buns",
                ProductStatus = 1
            };


            int expected = 21;
            StockInformation stockInfo = StockInformation.Instance();

            StockMaintenance stockOnHand = new StockMaintenance(stockInfo);
            stockOnHand.AddProductToStock(buns, 100);
            stockOnHand.UpdateProductQty(buns, 21);
            int actual = stockOnHand.GetStockQty(buns);
            Assert.AreEqual(actual, expected);

        }



        [TestMethod]
        public void GetStockOnHand_shouldReturnStockOnHand()
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




            List<StockSystem.StockManagement.Stock> StockMockList = new List<StockSystem.StockManagement.Stock>();
            {
                StockMockList.Add(stock1);
                StockMockList.Add(stock2);
            }

            // Arrange 
            List<StockSystem.StockManagement.Stock> expected = StockMockList;

            // Action
            List<StockSystem.StockManagement.Stock> actual = new StockMaintenance().GetStockOnHand();

         
            // Assert

            CollectionAssert.AreEqual(expected, actual, new StackComparer());


        }

    }
}
