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
    public partial class FDForm : Form
    {
        public FDForm()
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            banking_dbEntities dbe = new banking_dbEntities();
            decimal accno = Convert.ToDecimal(txtAccount.Text);
            var accounts=dbe.userAccounts.Where(x=>x.Account_No==accno).SingleOrDefault();
            FD fdform = new FD();
            fdform.Account_No = Convert.ToDecimal(txtAccount.Text);
            fdform.Mode = cboMode.SelectedItem.ToString();
            fdform.Dollar = txtDolar.Text;
            //fdform.Period = Convert.ToInt32(txtPeriod.Text);
            fdform.Interest_Rate = Convert.ToDecimal(txtInterest.Text) ;
            fdform.Start_Date = DateTime.UtcNow.ToString("MM/dd/yyyy");
            fdform.Maturity_Date = (DateTime.UtcNow.AddDays(Convert.ToInt32(txtPeriod.Text))).ToString("MM/dd/yyy") ;
            fdform.Maturity_Mount = ((Convert.ToDecimal(txtDolar.Text) * Convert.ToInt32(txtPeriod.Text) * Convert.ToDecimal(txtInterest.Text)) /
                (100 * 12 * 30)) + (Convert.ToDecimal(txtDolar.Text));

            dbe.FDs.Add(fdform);
            decimal amount = Convert.ToDecimal(txtDolar.Text);
            decimal totalamount = Convert.ToDecimal(accounts.Balance);
            decimal fdamount = totalamount - amount;
            accounts.Balance = fdamount;

            dbe.SaveChanges();
            MessageBox.Show("FD Started Now");
        }
    }
}
