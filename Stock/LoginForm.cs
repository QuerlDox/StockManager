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

namespace Stock
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            
            userNameTxtBox.Text = "";
            passwordTxtBox.Clear();
            userNameTxtBox.Focus();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            // TODO Check login user name and password
            StockResources stockResources = new StockResources();
            String username = userNameTxtBox.Text;
            String password = passwordTxtBox.Text;

            String sqlQuery = @"SELECT COUNT(*) FROM [Stock].[dbo].[Login] Where UserName = @username and Password = @password";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(stockResources.dataSource))
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@username", username));
                        sqlCommand.Parameters.Add(new SqlParameter("@password", password));

                        int result = (int)sqlCommand.ExecuteScalar();
                        if (result > 0)
                        {
                            this.Hide();
                            StockMain main = new StockMain();
                            main.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            clearBtn_Click(sender, e);
                        }

                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

    }
}
