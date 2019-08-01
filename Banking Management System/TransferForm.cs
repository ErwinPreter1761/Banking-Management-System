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
    public partial class TransferForm : Form
    {
        public TransferForm()
        {
            InitializeComponent();
            loaddate();

        }

        private void loaddate()
        {
            //throw new NotImplementedException();
            lblDate.Text = DateTime.UtcNow.ToString("MM/dd/yyyy");
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            banking_dbEntities dbe = new banking_dbEntities();
            decimal b = Convert.ToDecimal(txtFromAccountNumber.Text);
            var item = (from u in dbe.userAccounts
                        where u.Account_No == b
                        select u).FirstOrDefault();
            txtName.Text = item.Name;
            txtCurrentAmount.Text = Convert.ToString(item.Balance);
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            banking_dbEntities dbe = new banking_dbEntities();
            decimal b = Convert.ToDecimal(txtFromAccountNumber.Text);
            var item = (from u in dbe.userAccounts
                        where u.Account_No == b
                        select u).FirstOrDefault();
            decimal b1 = Convert.ToDecimal(item.Balance);
            decimal totalbal = Convert.ToDecimal(txtTransferAmount.Text);
            decimal transferacc = Convert.ToDecimal(txtDestinationAmount.Text);
            if(b1>totalbal)
            {
                userAccount item2 = (from u in dbe.userAccounts
                                     where u.Account_No == transferacc
                                     select u).FirstOrDefault();

                item2.Balance = item2.Balance + totalbal;
                item.Balance = item.Balance - totalbal;
                
                Transfer transfer = new Transfer();
                transfer.Account_No=Convert.ToDecimal(txtFromAccountNumber.Text);
                transfer.ToTransfer = Convert.ToDecimal(txtDestinationAmount.Text);
                transfer.Date = DateTime.UtcNow.ToString();
                transfer.Name = txtName.Text;
                transfer.Balance = Convert.ToDecimal(txtTransferAmount.Text);
                dbe.Transfers.Add(transfer);
                dbe.SaveChanges();
                MessageBox.Show("Transfer Money Succesfully");
            }
        }
    }
}
