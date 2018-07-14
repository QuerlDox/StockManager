using FluentAssertions;
using StockSystem;
using StockSystem.Persistence;
using StockSystem.ProductManagement;
using StockSystem.StockManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StockManagementTests.Test
{

   public class ProductMaintenanceXUnitTest
    {
        private Product beefPatty;
        private Product buns;
        private Stock stock1;
        private Stock stock2;

        private static StockInformationInFile stockInfo =  StockInformationInFile.Instance();
        private ProductMaintenance productMaintenanceObj = new ProductMaintenance(stockInfo);
        private StockMaintenance stockMaintenanceObj = new StockMaintenance(stockInfo);
        

        [Fact]
        public void AddProduct_shouldAddProductToStock() {
           

            //new product
            Product lettuce = new Product {
                ProductCode = "3",
                ProductName = "Lettuce",
                ProductStatus = 0
            };

            // new stock
            Stock stock3 = new Stock
            {
                Product = lettuce,
                Quantity = 0
            };

            // Arrange
            initializeStockFile();

            List<Stock> MockStockList = new List<Stock>();
            {
                MockStockList.Add(stock1);
                MockStockList.Add(stock2);
                MockStockList.Add(stock3);
            }

            List<Stock> expected = MockStockList;

            // Action
            productMaintenanceObj.AddProduct(lettuce);
            List<Stock> actual = stockMaintenanceObj.GetStocksOnHand();


            // Assert

            expected.Should().BeEquivalentTo(actual);
        }


        [Fact]
        public void DeleteProduct_ShouldDeleteProductFromStock() {

            initializeStockFile();

            // Arrange
            Product lettuce = new Product
            {
                ProductCode = "3",
                ProductName = "Lettuce",
                ProductStatus = 0
            };

            // Action

            List<Stock> MockStockList = new List<Stock>();
            {
                MockStockList.Add(stock1);
                MockStockList.Add(stock2);
            }

            List<Stock> expected = MockStockList;
             productMaintenanceObj.deleteProduct(lettuce);
            List<Stock> actual = stockMaintenanceObj.GetStocksOnHand();
            expected.Should().BeEquivalentTo(actual);


        }

        [Fact]
        public void GetProductCodeList_shouldReturnTheListOfProductCodeOfProductsInStocks() {

            // Arrange
            List<string> expected = new List<string>() { "1", "2" };

            // Action
            List<string> actual = productMaintenanceObj.GetProductCodeList();

            // Assert
            expected.Should().BeEquivalentTo(actual);

        }


        internal void initializeStockFile()
        {

            beefPatty = new Product
            {
                ProductCode = "1",
                ProductName = "Beef Patty",
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


    }
  

}
