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
            bool accountExists = false;
            String username = userNameTxtBox.Text;
            String password = passwordTxtBox.Text;
            Login login = new Login();
            accountExists = login.IsAuthenticated(username, password);
            if (accountExists)
            {
                this.Hide();
                StockMain main = new StockMain();
                main.Show();
            }
            else {
                MessageBox.Show("Invalid Username and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearBtn_Click(sender, e);
            }



         }

    }
}
