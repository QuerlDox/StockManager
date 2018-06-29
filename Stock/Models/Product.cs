using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem
{
    [Serializable]
    class Product
    {
        private string productCode;
        private string productName;
        private int productStatus;
        public String ProductCode { get { return this.productCode; } set { this.productCode = value; } }
        public String ProductName { get { return this.productName; } set { this.productName = value; } }
        public int ProductStatus { get { return this.productStatus; } set { this.productStatus = value; } }

        
    }
}
