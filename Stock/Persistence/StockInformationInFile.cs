using StockSystem.StockManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem.Persistence
{
     class StockInformationInFile: IStockInformation
    {
        private static StockInformationInFile _stockInformation;

        private IDictionary<Product, Stock> _stockDictionary;
        private BinaryFormatter _formatter;

        private string _message;
       

        private const string DATA_FILENAME = "C:\\Users\\thebr\\Documents\\_stockInformation.dat";

        

        public static StockInformationInFile Instance()
        { 
            if(_stockInformation == null) { 
            
                _stockInformation = new StockInformationInFile();
            }

            return _stockInformation;
        }
       

        private StockInformationInFile()
        {
            
                this._stockDictionary = new Dictionary<Product, Stock>(new ProductComparer());
                this._formatter = new BinaryFormatter();
          
        }

        public void AddStock(Product product, int qty) {
            if (this._stockDictionary.ContainsKey(product))
            {
                Console.WriteLine("You had already added " + product.ProductName + "before.");
                 _message = "You had already added " + product.ProductName + "before.";
           }
            else {
                this._stockDictionary.Add(product, new Stock(product, qty));
                Console.WriteLine("The product " + product.ProductName + " has been added");
                _message = "The product " + product.ProductName + " has been successfully added";
                Save();
            }
        }

        public void RemoveStock(Product product) {
            if (!this._stockDictionary.ContainsKey(product))
            {
                Console.WriteLine(product.ProductName + " had not been added before.");
                _message = product.ProductName + " had not been added before.";
             }
            else {
                if (this._stockDictionary.Remove(product))
                {
                    Console.WriteLine(product.ProductName + "had been removed successfully");
                    _message = product.ProductName + " had been removed successfully";
                    Save();
                 }
                else {

                    Console.WriteLine(" Unable to remove " + product.ProductName);
                    _message = " Unable to remove " + product.ProductName;
                 }
            }
        }

        internal void Save() {

            try
            {
                FileStream writerFileStream = new FileStream(DATA_FILENAME, FileMode.Create, FileAccess.Write);

                this._formatter.Serialize(writerFileStream, this._stockDictionary);

                writerFileStream.Close();
            }
            catch (Exception) {
                Console.WriteLine("Unable to save stock information");
                _message = "Unable to save stock information";
            }

        }



        public void Load() {
            if (File.Exists(DATA_FILENAME))
            {
                try
                {

                    FileStream readerFileStream = new FileStream(DATA_FILENAME, FileMode.Open, FileAccess.Read);
                    this._stockDictionary = (Dictionary<Product, Stock>)this._formatter.Deserialize(readerFileStream);
                    readerFileStream.Close();
                }
                catch (Exception) {
                    Console.WriteLine("There are seems to be a file that contains  stock information but somehow  there is a problem reading it and your are completely fucked ");
                    _message = "There are seems to be a file that contains  stock information but somehow  there is a problem reading it and your are completely fucked ";
                }
            }

        }

        public void Print() {

            if (this._stockDictionary.Count > 0)
            {
                Console.WriteLine("Product, Produt Quantity");
                foreach (Stock item in this._stockDictionary.Values)
                {
                    Console.WriteLine(item.Product.ProductName + "   " + item.Quantity);
                    _message = item.Product.ProductName + "   " + item.Quantity;
                 }

            }
            else {
                Console.WriteLine("There are no saved data for the stock information");
                _message = "There are no saved data for the stock information";
             }
        }


        public Product GetProduct(Product product) {
            Product _product = new Product();
            if (this._stockDictionary.Count > 0)
            {

                foreach (Stock item in this._stockDictionary.Values)
                {   // TODO create a method that tests if two objects are equal in value(all value of their properties are the same)
                    if (new ProductComparer().Equals(item.Product, product)) {
                        _product = item.Product;
                    }

                }


            }
            else
            {
                Console.WriteLine("There are no saved data for the stock information");
                _message = "There are no saved data for the stock information";
            }


            return _product;
        }



        public int GetStockQty(Product product)
        {
            
            // Stock _stock = new Stock();
            int _productQty = 0;
            if (this._stockDictionary.Count > 0)
            {
                
                foreach (Stock item in this._stockDictionary.Values)
                {
                    // TODO create a method that tests if two objects are equal in value(all value of their properties are the same)
                    if (item.Product.ProductCode == product.ProductCode)
                    {
                        _productQty = item.Quantity;
                    }

                }


            }
            else
            {
                Console.WriteLine("There are no saved data for the stock information");
            }


            return _productQty;
        }




        public void UpdateStock(Product product, int qty)
        {
            Stock _val;
            

            if (this._stockDictionary.TryGetValue(product, out _val))
            {

                this._stockDictionary[product].Quantity =  qty;
                Save();
            }
            else
            {

                Console.WriteLine(" Unable to update " + product.ProductName);
                _message = " Unable to update " + product.ProductName;
            }

        }


        public List<Stock> GetStocksOnHand()
        {
            List<Stock> _stockList = new List<Stock>();

            if (this._stockDictionary.Count > 0)
            {
                foreach (Stock item in this._stockDictionary.Values)
                {
                    _stockList.Add(item);
                }

               
            }
            else
            {
                Console.WriteLine("Not a single Stock  Found");
            }

            return _stockList;

        }

 

        public string GetMessage() {
            return this._message;
        }

        
    }

    }

 

