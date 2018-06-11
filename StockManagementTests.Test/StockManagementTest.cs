using StockSystem.StockManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using StockSystem;
using FluentAssertions;


namespace StockManagementTests.Test
{
    public class StockManagementTest
    {
        [Fact]
        public void EnterQty_shouldChangeQty()
        {
            int expected = 5;
            int actual = new StockMaintenance().enterQty(5);
            Assert.Equal(actual, expected);
        }

        [Fact]
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

       
            expected.Should().BeEquivalentTo(actual);

        }
    }

}