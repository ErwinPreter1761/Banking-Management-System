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
    public partial class DebitForm : Form
    {
        public DebitForm()
        {
            InitializeComponent();
            loaddate();
            loadcombo();

        }

        private void loadcombo()
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDate();
        }

        private void SaveDate()
        {
            banking_dbEntities dbe = new banking_dbEntities();
            newAccount nacc = new newAccount();
            debit dp = new debit();
            dp.Date = lblDate.Text;
            dp.AccountNo = Convert.ToDecimal(txtAccountNumber.Text);
            dp.Name = txtName.Text;
            dp.OldBalancae = Convert.ToDecimal(txtOldBalance.Text);
            dp.Mode = cboMode.SelectedItem.ToString();
            dp.DebAmount = Convert.ToDecimal(txtAmount.Text);
            dbe.debits.Add(dp);
            dbe.SaveChanges();

            decimal b = Convert.ToDecimal(txtAccountNumber.Text);

            var item = (from u in dbe.userAccounts
                        where u.Account_No == b
                        select u).FirstOrDefault();

            item.Balance = item.Balance - Convert.ToDecimal(txtAmount.Text);
            dbe.SaveChanges();
            MessageBox.Show("Debit Money");
        }

        private void btnGetDetail_Click(object sender, EventArgs e)
        {
            ReviewData();
        }

        private void ReviewData()
        {
            banking_dbEntities dbe = new banking_dbEntities();
            decimal b = Convert.ToDecimal(txtAccountNumber.Text);
            var item = (from u in dbe.userAccounts
                        where u.Account_No == b
                        select u).FirstOrDefault();

            txtName.Text = item.Name;
            txtOldBalance.Text = Convert.ToString(item.Balance);
        }
    }
}
