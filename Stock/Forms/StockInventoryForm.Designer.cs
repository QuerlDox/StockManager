namespace StockSystem.Forms
{
    partial class StockInventoryForm
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
            this.stockInventoryDataGridView = new System.Windows.Forms.DataGridView();
            this.stockInventoryFormSaveBtn = new System.Windows.Forms.Button();
            this.productCodeData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNameData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productStatusData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productQtyData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.stockInventoryDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // stockInventoryDataGridView
            // 
            this.stockInventoryDataGridView.AllowUserToAddRows = false;
            this.stockInventoryDataGridView.AllowUserToDeleteRows = false;
            this.stockInventoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stockInventoryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productCodeData,
            this.productNameData,
            this.productStatusData,
            this.productQtyData});
            this.stockInventoryDataGridView.Location = new System.Drawing.Point(12, 12);
            this.stockInventoryDataGridView.Name = "stockInventoryDataGridView";
            this.stockInventoryDataGridView.Size = new System.Drawing.Size(478, 357);
            this.stockInventoryDataGridView.TabIndex = 0;
            this.stockInventoryDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.stockInventoryDataGridView_CellValueChanged);
            // 
            // stockInventoryFormSaveBtn
            // 
            this.stockInventoryFormSaveBtn.Location = new System.Drawing.Point(415, 404);
            this.stockInventoryFormSaveBtn.Name = "stockInventoryFormSaveBtn";
            this.stockInventoryFormSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.stockInventoryFormSaveBtn.TabIndex = 1;
            this.stockInventoryFormSaveBtn.Text = "Save";
            this.stockInventoryFormSaveBtn.UseVisualStyleBackColor = true;
            this.stockInventoryFormSaveBtn.Click += new System.EventHandler(this.stockInventoryFormSaveBtn_Click);
            // 
            // productCodeData
            // 
            this.productCodeData.HeaderText = "Product Code";
            this.productCodeData.Name = "productCodeData";
            this.productCodeData.ReadOnly = true;
            // 
            // productNameData
            // 
            this.productNameData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.productNameData.HeaderText = "Product Name";
            this.productNameData.Name = "productNameData";
            this.productNameData.ReadOnly = true;
            // 
            // productStatusData
            // 
            this.productStatusData.HeaderText = "Status";
            this.productStatusData.Name = "productStatusData";
            this.productStatusData.ReadOnly = true;
            this.productStatusData.Visible = false;
            // 
            // productQtyData
            // 
            this.productQtyData.HeaderText = "Quantity";
            this.productQtyData.Name = "productQtyData";
            // 
            // StockInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.stockInventoryFormSaveBtn);
            this.Controls.Add(this.stockInventoryDataGridView);
            this.Name = "StockInventoryForm";
            this.Text = "StockInventoryForm";
            this.Load += new System.EventHandler(this.StockInventoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stockInventoryDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView stockInventoryDataGridView;
        private System.Windows.Forms.Button stockInventoryFormSaveBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productCodeData;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameData;
        private System.Windows.Forms.DataGridViewTextBoxColumn productStatusData;
        private System.Windows.Forms.DataGridViewTextBoxColumn productQtyData;
    }
}