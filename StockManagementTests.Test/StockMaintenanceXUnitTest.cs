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
        private static StockInformationInFile stockInfo = StockInformationInFile.Instance();

        private StockSystem.StockManagement.StockMaintenance stockMaintenanceObj = new StockSystem.StockManagement.StockMaintenance(stockInfo);

        private Product beefPatty;
        private Product buns;

        private StockSystem.StockManagement.Stock stock1;
        private StockSystem.StockManagement.Stock stock2;



        [Fact]
        public void AddProductToStock_shouldAddProductToStock() {

            initializeStockFile();

            // additional Product
            Product lettuce = new Product
            {
                ProductCode = "3",
                ProductName = "Lettuce",
                ProductStatus = 0
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


            initializeStockFile();

            int expected = 5;
          
                stockMaintenanceObj.AddProductToStock(beefPatty, 20);
                stockMaintenanceObj.AddProductToStock(buns, 100);
                stockMaintenanceObj.UpdateProductQty(beefPatty, 5);
                stockMaintenanceObj.UpdateProductQty(buns, 3);
         

            int actual = stockMaintenanceObj.GetStockQty(beefPatty);
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void GetStockOnHand_shouldReturnStockOnHand_inXUnit()
        {

            initializeStockFile();

            // additional Product
            Product lettuce = new Product
            {
                ProductCode = "3",
                ProductName = "Lettuce",
                ProductStatus = 0
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


        internal void initializeStockFile() {

             beefPatty = new Product
            {
                ProductCode = "1",
                ProductName = "beefPatty",
                ProductStatus = 0
            };


             buns = new Product
            {
                ProductCode = "2",
                ProductName = "Buns",
                ProductStatus = 0
            };


                stock1 = new StockSystem.StockManagement.Stock()
            {
                Product = beefPatty,
                Quantity = 5,
            };

                stock2 = new StockSystem.StockManagement.Stock()
            {
                Product = buns,
                Quantity = 3,
            };

        }

        [Fact] 
        public void GetStockQuantity_shouldReturnQtyOfProductInStock() {
           
            // Arrange
            initializeStockFile();

            int expected = 3;

            // Assert
            int actual = stockMaintenanceObj.GetStockQty(buns);

            Assert.Equal(expected, actual);
         
        }

        [Fact]
        public void RemoveProductFromStock_shouldRemovetTheProductFromTheStock() {
            // Arrange
            initializeStockFile();

            List<StockSystem.StockManagement.Stock> StockMockList = new List<StockSystem.StockManagement.Stock>();
            {
                StockMockList.Add(stock1);
                StockMockList.Add(stock2);
               
            }


            // Arrange 
            List<StockSystem.StockManagement.Stock> expected = StockMockList;


            // additional Product
            Product lettuce = new Product
            {
                ProductCode = "3",
                ProductName = "Lettuce",
                ProductStatus = 0
            };




            // Action
            stockMaintenanceObj.RemoveProductFromStock(lettuce);
            List<Stock> actual = stockMaintenanceObj.GetStocksOnHand();

            expected.Should().BeEquivalentTo(actual);

        }


    }

}