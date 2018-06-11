using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockSystem;
using StockSystem.StockManagement;

namespace WindowsStockManagementTests.Tests
{
    [TestClass]
    public class StockMaintentanceUnitTest
    {
        [TestMethod]
        public void EnterQty_shouldChangeQty()
        {
            int expected = 5;
            int actual = new StockMaintenance().enterQty(5);
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

            StockSystem.StockManagement.Stock stock1 = new StockSystem.StockManagement.Stock()
            {
                Product = beefPatty,
                Quantity = 10,
            };

            StockSystem.StockManagement.Stock stock2 = new StockSystem.StockManagement.Stock()
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
