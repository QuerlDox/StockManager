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

        private StockSystem.StockManagement.StockMaintenance stockMaintenanceObj = new StockSystem.StockManagement.StockMaintenance(stockInfo);




        [Fact]
        public void AddProductToStock_shouldAddProductToStock() {
            Product beefPatty = new Product
            {
                ProductCode = "1",
                ProductName = "beefPatty",
                ProductStatus = 0
            };


            Product buns = new Product
            {
                ProductCode = "2",
                ProductName = "Buns",
                ProductStatus = 0
            };


            // additional Product
            Product lettuce = new Product
            {
                ProductCode = "3",
                ProductName = "Lettuce",
                ProductStatus = 0
            };

            StockSystem.StockManagement.Stock stock1 = new StockSystem.StockManagement.Stock()
            {
                Product = beefPatty,
                Quantity = 5
            };

            StockSystem.StockManagement.Stock stock2 = new StockSystem.StockManagement.Stock()
            {
                Product = buns,
                Quantity = 5
            };

            // additional stock
            StockSystem.StockManagement.Stock stock3 = new StockSystem.StockManagement.Stock() {

                Product = lettuce,
                 Quantity = 0
            };


            List<StockSystem.StockManagement.Stock> StockMockList = new List<StockSystem.StockManagement.Stock>();
            {
                StockMockList.Add(stock1);
                StockMockList.Add(stock2);
                StockMockList.Add(stock3);
            }

            
            // Arrange 
            List<StockSystem.StockManagement.Stock> expected = StockMockList;

            // Action
            stockMaintenanceObj.AddProductToStock(lettuce,0);
            List<StockSystem.StockManagement.Stock> actual = stockMaintenanceObj.GetStocksOnHand();

            expected.Should().BeEquivalentTo(actual);

        }



        [Fact]
        public void UpdateProductQty_shouldChangeProductQtyInStock_inXunit()
        {
            Product beefPatty = new Product
            {
                ProductCode = "1",
                ProductName = "beefPatty",
                ProductStatus = 0
            };

            Product buns = new Product
            {
                ProductCode = "2",
                ProductName = "Buns",
                ProductStatus = 0
            };



            int expected = 5;
          
                stockMaintenanceObj.AddProductToStock(beefPatty, 20);
                stockMaintenanceObj.AddProductToStock(buns, 100);
                stockMaintenanceObj.UpdateProductQty(beefPatty, 5);
                stockMaintenanceObj.UpdateProductQty(buns, 5);
         

            int actual = stockMaintenanceObj.GetStockQty(beefPatty);
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void GetStockOnHand_shouldReturnStockOnHand_inXUnit()
        {

            Product beefPatty = new Product
            {
                ProductCode = "1",
                ProductName = "beefPatty",
                ProductStatus = 0
            };


            Product buns = new Product
            {
                ProductCode = "2",
                ProductName = "Buns",
                ProductStatus = 0
            };

            // additional Product
            Product lettuce = new Product
            {
                ProductCode = "3",
                ProductName = "Lettuce",
                ProductStatus = 0
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


            // added stock

            StockSystem.StockManagement.Stock stock3 = new StockSystem.StockManagement.Stock()
            {
                Product = lettuce,
                Quantity = 0,
            };

            List<StockSystem.StockManagement.Stock> StockMockList = new List<StockSystem.StockManagement.Stock>();
            {
                StockMockList.Add(stock1);
                StockMockList.Add(stock2);
                StockMockList.Add(stock3);
            }


           

            // Arrange 
            List<StockSystem.StockManagement.Stock> expected = StockMockList;

            // Action
            List<StockSystem.StockManagement.Stock> actual = stockMaintenanceObj.GetStocksOnHand();

       
            expected.Should().BeEquivalentTo(actual);

        }


     }

}