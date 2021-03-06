﻿using StockSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockSystem
{
    public partial class StockMain : Form
    {
       

        public StockMain()
        {
            InitializeComponent();
        }

        private void StockMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            productForm.MdiParent = this;
            productForm.Show();

        }

        private void MenuItemStock_Click(object sender, EventArgs e)
        {
            StockInventoryForm stockInventoryForm = new StockInventoryForm();
            stockInventoryForm.MdiParent = this;
            stockInventoryForm.Show();
        }
    }
}
