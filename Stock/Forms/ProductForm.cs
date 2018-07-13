using StockSystem.Persistence;
using StockSystem.ProductManagement;
using StockSystem.StockManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace StockSystem
{
    public partial class ProductForm : Form
    {
      // private StockMaintenanceUsingDB _stockMaintenance;
       private  Product product;
       
        private ProductMaintenance _productMaintenance;
        //  private StockInformationInFile stockInfo;
        private StockInformationSQLServer stockInfo;
        private StockMaintenance _stockMaintenance;

        public ProductForm()
        {
            InitializeComponent();
            //  stockInfo = StockInformationInFile.Instance();
            stockInfo = new StockInformationSQLServer();
            _stockMaintenance = new StockManagement.StockMaintenance(stockInfo);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Products_Load(object sender, EventArgs e)
        {
            productStatusComboBox.SelectedIndex = 0;
            showProductTable();
        }

        private void addProductBtn_Click(object sender, EventArgs e)
        {
           
            product = new Product();
            _productMaintenance = new ProductMaintenance(stockInfo);
            product.ProductCode = productCodeDataTxtBox.Text;
            product.ProductName = productNameDataTxtBox.Text;
            product.ProductStatus = productStatusComboBox.SelectedIndex;

            _productMaintenance.AddProduct(product);
           
            MessageBox.Show(_productMaintenance.Message);

            productCodeDataTxtBox.Clear();
            productNameDataTxtBox.Clear();

            // Read the Data from the Products table
            showProductTable();

        }

       

        

        private void productDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            productCodeDataTxtBox.Text = productDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            productNameDataTxtBox.Text = productDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            productStatusComboBox.Text = productDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            if (productDataGridView.SelectedRows[0].Cells[2].Value.ToString() == "Active")
            {
                productStatusComboBox.SelectedIndex = 0;
            }
            else
            {
                productStatusComboBox.SelectedIndex = 1;
            }
        }

        private void deleteProductBtn_Click(object sender, EventArgs e)
        {
            

            product = new Product();
            _productMaintenance = new ProductMaintenance(stockInfo);

            product.ProductCode = productCodeDataTxtBox.Text;
            product.ProductName = productNameDataTxtBox.Text;
            product.ProductStatus = productStatusComboBox.SelectedIndex;

            _productMaintenance.deleteProduct(product);
            MessageBox.Show(_productMaintenance.Message);

            productCodeDataTxtBox.Clear();
            productNameDataTxtBox.Clear();


            // Read the Data from the Products table
          //  MessageBox.Show(_productMaintenance._message);
            showProductTable();
            

        }

        public void showProductTable() {

            productDataGridView.Rows.Clear();
                   

            foreach (Product item in _stockMaintenance.GetStocksOnHand().Select(c => c.Product))
            {
                int n = productDataGridView.Rows.Add();
                productDataGridView.Rows[n].Cells[0].Value = item.ProductCode;
                productDataGridView.Rows[n].Cells[1].Value = item.ProductName;
                if (item.ProductStatus == 0)
                {
                    productDataGridView.Rows[n].Cells[2].Value = "Active";
                }
                else
                {
                    productDataGridView.Rows[n].Cells[2].Value = "Not Active";
                }

            }


            productDataGridView.Sort(productDataGridView.Columns[0], ListSortDirection.Ascending);

        } // end ProductTable()



    }
}
