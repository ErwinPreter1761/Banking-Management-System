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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            banking_dbEntities dbe = new banking_dbEntities();
            if (txtOldPassword.Text != string.Empty || txtNewPassword.Text != string.Empty || txtRetype.Text != string.Empty)
            {
                Admin_Table user1 = dbe.Admin_Table.FirstOrDefault(a=>a.UserName.Equals(txtUsername.Text));
                if (user1 != null)
                {
                    if (user1.Password.Equals(txtOldPassword.Text))
                    {
                        user1.Password = txtNewPassword.Text;
                        dbe.SaveChanges();
                        MessageBox.Show("Password Change Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Password Incorrect");
                    }
                }
            }
               
            
        }
    }
}
