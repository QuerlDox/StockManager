namespace Stock
{
    partial class ProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.productCodeDataTxtBox = new System.Windows.Forms.TextBox();
            this.productNameDataTxtBox = new System.Windows.Forms.TextBox();
            this.productStatusComboBox = new System.Windows.Forms.ComboBox();
            this.deleteProductBtn = new System.Windows.Forms.Button();
            this.addProductBtn = new System.Windows.Forms.Button();
            this.productCodeLbl = new System.Windows.Forms.Label();
            this.productNameLbl = new System.Windows.Forms.Label();
            this.statusLbl = new System.Windows.Forms.Label();
            this.productDataGridView = new System.Windows.Forms.DataGridView();
            this.productCodeData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productStatusData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.productDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // productCodeDataTxtBox
            // 
            this.productCodeDataTxtBox.Location = new System.Drawing.Point(12, 57);
            this.productCodeDataTxtBox.Name = "productCodeDataTxtBox";
            this.productCodeDataTxtBox.Size = new System.Drawing.Size(123, 20);
            this.productCodeDataTxtBox.TabIndex = 0;
            // 
            // productNameDataTxtBox
            // 
            this.productNameDataTxtBox.Location = new System.Drawing.Point(164, 57);
            this.productNameDataTxtBox.Name = "productNameDataTxtBox";
            this.productNameDataTxtBox.Size = new System.Drawing.Size(135, 20);
            this.productNameDataTxtBox.TabIndex = 1;
            // 
            // productStatusComboBox
            // 
            this.productStatusComboBox.FormattingEnabled = true;
            this.productStatusComboBox.Items.AddRange(new object[] {
            "Active",
            "Not Active"});
            this.productStatusComboBox.Location = new System.Drawing.Point(326, 57);
            this.productStatusComboBox.Name = "productStatusComboBox";
            this.productStatusComboBox.Size = new System.Drawing.Size(121, 21);
            this.productStatusComboBox.TabIndex = 2;
            // 
            // deleteProductBtn
            // 
            this.deleteProductBtn.Location = new System.Drawing.Point(490, 54);
            this.deleteProductBtn.Name = "deleteProductBtn";
            this.deleteProductBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteProductBtn.TabIndex = 3;
            this.deleteProductBtn.Text = "Delete";
            this.deleteProductBtn.UseVisualStyleBackColor = true;
            this.deleteProductBtn.Click += new System.EventHandler(this.deleteProductBtn_Click);
            // 
            // addProductBtn
            // 
            this.addProductBtn.Location = new System.Drawing.Point(596, 54);
            this.addProductBtn.Name = "addProductBtn";
            this.addProductBtn.Size = new System.Drawing.Size(75, 23);
            this.addProductBtn.TabIndex = 4;
            this.addProductBtn.Text = "Add";
            this.addProductBtn.UseVisualStyleBackColor = true;
            this.addProductBtn.Click += new System.EventHandler(this.addProductBtn_Click);
            // 
            // productCodeLbl
            // 
            this.productCodeLbl.AutoSize = true;
            this.productCodeLbl.Location = new System.Drawing.Point(12, 34);
            this.productCodeLbl.Name = "productCodeLbl";
            this.productCodeLbl.Size = new System.Drawing.Size(72, 13);
            this.productCodeLbl.TabIndex = 5;
            this.productCodeLbl.Text = "Product Code";
            // 
            // productNameLbl
            // 
            this.productNameLbl.AutoSize = true;
            this.productNameLbl.Location = new System.Drawing.Point(161, 34);
            this.productNameLbl.Name = "productNameLbl";
            this.productNameLbl.Size = new System.Drawing.Size(75, 13);
            this.productNameLbl.TabIndex = 6;
            this.productNameLbl.Text = "Product Name";
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Location = new System.Drawing.Point(323, 34);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(37, 13);
            this.statusLbl.TabIndex = 7;
            this.statusLbl.Text = "Status";
            // 
            // productDataGridView
            // 
            this.productDataGridView.AllowUserToAddRows = false;
            this.productDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productCodeData,
            this.productNameData,
            this.productStatusData});
            this.productDataGridView.Location = new System.Drawing.Point(15, 95);
            this.productDataGridView.Name = "productDataGridView";
            this.productDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.productDataGridView.Size = new System.Drawing.Size(656, 222);
            this.productDataGridView.TabIndex = 8;
            this.productDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productDataGridView_CellClick);
            this.productDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // productCodeData
            // 
            this.productCodeData.HeaderText = "Product Code";
            this.productCodeData.Name = "productCodeData";
            // 
            // productNameData
            // 
            this.productNameData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.productNameData.HeaderText = "Product Name";
            this.productNameData.Name = "productNameData";
            // 
            // productStatusData
            // 
            this.productStatusData.HeaderText = "Status ";
            this.productStatusData.Name = "productStatusData";
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.productDataGridView);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.productNameLbl);
            this.Controls.Add(this.productCodeLbl);
            this.Controls.Add(this.addProductBtn);
            this.Controls.Add(this.deleteProductBtn);
            this.Controls.Add(this.productStatusComboBox);
            this.Controls.Add(this.productNameDataTxtBox);
            this.Controls.Add(this.productCodeDataTxtBox);
            this.Name = "Products";
            this.Text = "Products";
            this.Load += new System.EventHandler(this.Products_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox productCodeDataTxtBox;
        private System.Windows.Forms.TextBox productNameDataTxtBox;
        private System.Windows.Forms.ComboBox productStatusComboBox;
        private System.Windows.Forms.Button deleteProductBtn;
        private System.Windows.Forms.Button addProductBtn;
        private System.Windows.Forms.Label productCodeLbl;
        private System.Windows.Forms.Label productNameLbl;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.DataGridView productDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn productCodeData;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameData;
        private System.Windows.Forms.DataGridViewTextBoxColumn productStatusData;
    }
}