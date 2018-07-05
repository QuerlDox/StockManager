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
                string message = "You had already added " + product.ProductName + "before.";
                SetMessage(message);
            }
            else {
                this._stockDictionary.Add(product, new Stock(product, qty));
                Console.WriteLine("The product " + product.ProductName + " has been added");
                string message = "The product " + product.ProductName + " has been successfully added";
                SetMessage(message); 
            }
        }

        public void RemoveStock(Product product) {
            if (!this._stockDictionary.ContainsKey(product))
            {
                Console.WriteLine(product.ProductName + " had not been added before.");
                string message = product.ProductName + " had not been added before.";
                SetMessage(message);
            }
            else {
                if (this._stockDictionary.Remove(product))
                {
                    Console.WriteLine(product.ProductName + "had been removed successfully");
                    string message = product.ProductName + "had been removed successfully";
                    SetMessage(message);
                }
                else {

                    Console.WriteLine(" Unable to remove " + product.ProductName);
                    string message = " Unable to remove " + product.ProductName;
                    SetMessage(message);
                }
            }
        }

        public void Save() {

            try
            {
                FileStream writerFileStream = new FileStream(DATA_FILENAME, FileMode.Create, FileAccess.Write);

                this._formatter.Serialize(writerFileStream, this._stockDictionary);

                writerFileStream.Close();
            }
            catch (Exception) {
                Console.WriteLine("Unable to save stock information");
                string message = "Unable to save stock information";
                SetMessage(message);
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
                    string message = "There are seems to be a file that contains  stock information but somehow  there is a problem reading it and your are completely fucked ";
                    SetMessage(message);
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
                    string message = item.Product.ProductName + "   " + item.Quantity;
                    SetMessage(message);

                }

            }
            else {
                Console.WriteLine("There are no saved data for the stock information");
                string message = "There are no saved data for the stock information";
                SetMessage(message);
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
                string message = "There are no saved data for the stock information";
                SetMessage(message);
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
            string message;

            if (this._stockDictionary.TryGetValue(product, out _val))
            {

                this._stockDictionary[product].Quantity =  qty;
            }
            else
            {

                Console.WriteLine(" Unable to update " + product.ProductName);
                message = " Unable to update " + product.ProductName;
                SetMessage(message);
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

        public void SetMessage(string msg) {
            this._message = msg;

        }

        public string GetMessage() {
            return this._message;
        }

        
    }

    }

 

