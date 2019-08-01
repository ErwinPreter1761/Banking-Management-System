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
    public partial class CreditForm : Form
    {
        public CreditForm()
        {
            InitializeComponent();
            loaddate();
            loadmode();

        }

        private void loadmode()
        {
            //throw new NotImplementedException();
            cboMode.Items.Add("Cash");
            cboMode.Items.Add("Credit");

        }

        private void loaddate()
        {
            //throw new NotImplementedException();
            lblDate.Text = DateTime.UtcNow.ToString("MM/dd/yyyy");
        }

        private void btnGetDetails_Click(object sender, EventArgs e)
        {
            banking_dbEntities context = new banking_dbEntities();
            decimal b = Convert.ToDecimal(txtAccountNumber.Text);
            var item = (from u in context.userAccounts
                        where u.Account_No == b
                        select u).FirstOrDefault();

            txtName.Text = item.Name;
            txtOldBalance.Text = Convert.ToString(item.Balance);


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            banking_dbEntities context = new banking_dbEntities();
            newAccount acc = new newAccount();
            Deposit dp = new Deposit();
            dp.Date = lblDate.Text;
            dp.AccountNo = Convert.ToDecimal(txtAccountNumber.Text);
            dp.Name = txtName.Text;
            dp.OldeBalance = Convert.ToDecimal(txtOldBalance.Text);
            dp.Mode = cboMode.SelectedItem.ToString();
            dp.DipAmount = Convert.ToDecimal(txtAmount.Text);
            context.Deposits.Add(dp);
            context.SaveChanges();
            decimal b = Convert.ToDecimal(txtAccountNumber.Text);
            var item = (from u in context.userAccounts
                        where u.Account_No == b
                        select u).FirstOrDefault();

            item.Balance = item.Balance + Convert.ToDecimal(txtAmount.Text);
            context.SaveChanges();
            MessageBox.Show("Deposit Money Successfully");
        }
    }
}
