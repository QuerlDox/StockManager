using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockSystem;
using StockSystem.Persistence;
using StockSystem.StockManagement;

namespace StockManagementUnitTests.Tests
{
    [TestClass]
    public class StockMaintentanceUnitTest
    {

        private static StockInformation stockInfo = StockInformation.Instance();

        private static StockMaintenance stockOnHand = new StockMaintenance(stockInfo);


        [TestMethod]
        public void UpdateProductQty_shouldChangeProductQtyInStock()
        {
            Product buns = new Product
            {
                ProductCode = "2",
                ProductName = "Buns",
                ProductStatus = 1
            };

            Product beefPatty = new Product
            {
                ProductCode = "1",
                ProductName = "beefPatty",
                ProductStatus = 1
            };


            int expected = 36;

            stockOnHand.AddProductToStock(beefPatty, 20);
            stockOnHand.AddProductToStock(buns, 100);
            stockOnHand.UpdateProductQty(beefPatty, 36);
            stockOnHand.UpdateProductQty(buns, 36);

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
                Quantity = 36,
            };

            Stock stock2 = new Stock()
            {
                Product = buns,
                Quantity = 36,
            };




            List<StockSystem.StockManagement.Stock> StockMockList = new List<StockSystem.StockManagement.Stock>();
            {
                StockMockList.Add(stock1);
                StockMockList.Add(stock2);
            }

            // Arrange 
            List<StockSystem.StockManagement.Stock> expected = StockMockList;

            // Action
            List<StockSystem.StockManagement.Stock> actual = stockOnHand.GetStockOnHand();


            // Assert

            // CollectionAssert.AreEqual(expected, actual, new StackComparer());
            expected.Should().BeEquivalentTo(actual);

        }

    }
}
