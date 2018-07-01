using StockSystem.Persistence;
using StockSystem.StockManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockSystem.Forms
{
    public partial class StockInventoryForm : Form
    {
        private List<Stock> stockList;
        private Product product;
        private Stock stock;
        private static StockInformation stockInfo = StockInformation.Instance();
        private IStockMaintenance _stockMaintenance = new StockManagement.StockMaintenance(stockInfo);

        public StockInventoryForm()
        {
            InitializeComponent();
        }



        public void showStockInventoryTable()
        {

            stockInventoryDataGridView.Rows.Clear();


            foreach (Stock item in _stockMaintenance.GetStocksOnHand())
            {
                int n = stockInventoryDataGridView.Rows.Add();
                stockInventoryDataGridView.Rows[n].Cells[0].Value = item.Product.ProductCode;
                stockInventoryDataGridView.Rows[n].Cells[1].Value = item.Product.ProductName;
                if (item.Product.ProductStatus == 0)
                {
                    stockInventoryDataGridView.Rows[n].Cells[2].Value = "Active";
                }
                else
                {
                    stockInventoryDataGridView.Rows[n].Cells[2].Value = "Not Active";
                }

                stockInventoryDataGridView.Rows[n].Cells[3].Value = item.Quantity;

            }

            stockInventoryDataGridView.Sort(stockInventoryDataGridView.Columns[0], ListSortDirection.Ascending);

        }

        private void StockInventoryForm_Load(object sender, EventArgs e)
        {
            showStockInventoryTable();
        }

        private void stockInventoryDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            
            stockList = new List<Stock>();

            foreach (DataGridViewRow row in stockInventoryDataGridView.Rows)
            {

                if (stockInventoryDataGridView.Columns[e.ColumnIndex].Name == "productQtyData")
                {
                    product = new Product();
                    stock = new Stock();
                    int qty;
                    
                    product.ProductCode =  row.Cells[0].Value.ToString();
                    product.ProductName =  row.Cells[1].Value.ToString();
                    if (row.Cells[2].Value.ToString() == "Active")
                    {
                        product.ProductStatus = 0;
                    }
                    else
                    {
                        product.ProductStatus = 1;
                    }

                    qty = Int32.Parse(row.Cells[3].Value.ToString());
                    stock.Product = product;
                    stock.Quantity = qty;
                    stockList.Add(stock);
                }
            }
        }

        private void stockInventoryFormSaveBtn_Click(object sender, EventArgs e)
        {
            foreach (Stock item in stockList) {
                _stockMaintenance.UpdateProductQty(item.Product, item.Quantity);
                
            }
            MessageBox.Show("Stock Inventory Saved");
            showStockInventoryTable();
            this.Close();

        }
    }
}
