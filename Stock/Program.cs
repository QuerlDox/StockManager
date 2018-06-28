using StockSystem.Persistence;
using StockSystem.StockManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
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

  
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
            
        }
    }
}
