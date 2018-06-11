using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem
{
    public static class Resources
    {
        public static string getDatabaseConnectionString(string connectionName) {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }
    }
}
