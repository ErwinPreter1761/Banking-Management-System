using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banking_Management_System
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            banking_dbEntities dbe = new banking_dbEntities();
            if (txtPassword.Text != string.Empty || txtPassword.Text != string.Empty)
            {
                var user1 = dbe.Admin_Table.FirstOrDefault(a => a.UserName.Equals(txtUserName.Text));
                if (user1 != null)
                {
                    if (user1.Password.Equals(txtPassword.Text))
                    {
                        Menu m1 = new Menu();
                        m1.ShowDialog();
                        this.Close();
                        
                    }
                    else
                    {
                        MessageBox.Show("Password Incorrect");
                        txtPassword.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Null Value");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Username Anda Password");
            }

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
