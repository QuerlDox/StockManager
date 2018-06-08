﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Stock
{
    public partial class ProductForm : Form
    {
       private ProductService productService;
       private  Product product;
       

        public ProductForm()
        {
            InitializeComponent();
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
            productService = new ProductService();
            product.ProductCode = productCodeDataTxtBox.Text;
            product.ProductName = productNameDataTxtBox.Text;
            product.ProductStatus = productStatusComboBox.SelectedIndex;

            productService.addProductItem(product);

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

            product.ProductCode = productCodeDataTxtBox.Text;
            product.ProductName = productNameDataTxtBox.Text;
            product.ProductStatus = productStatusComboBox.SelectedIndex;

            productService.deleteProductItem(product);

            productCodeDataTxtBox.Clear();
            productNameDataTxtBox.Clear();


            // Read the Data from the Products table
            MessageBox.Show(productService.message);
            showProductTable();
            

        }

        public void showProductTable() {
            productDataGridView.Rows.Clear();
            productService = new ProductService();
          
            

           // foreach (DataRow item in productDao.dataTable.Rows)
               foreach(Product item in productService.loadData())
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
        }
    }
}