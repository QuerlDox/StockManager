using Stock.StockManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;



namespace StockManagementSystemTests.Tests
{
    public class StockMaintenanceTests
    {
        
        public void enteryQty_changeProductQty() {
            // arange
            int expected = 5;
            // action
            int actual = new StockMaintenance().enterQty(5);
            // assert
            Assert.Equal(expected, actual);
        }
    }
}
