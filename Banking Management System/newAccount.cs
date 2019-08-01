using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Banking_Management_System
{
    public partial class newAccount : Form
    {
        string gender = string.Empty;
        string m_status = string.Empty;
        decimal no;
        banking_dbEntities BSE;
        MemoryStream ms;

        public newAccount()
        {
            InitializeComponent();
            loaddate();
            loadaccount();
            loadstate();
        }

        private void loadstate()
        {
            cboState.Items.Add("Jakarta");
            cboState.Items.Add("Bandung");
        }

        private void loadaccount()
        {
            BSE = new banking_dbEntities();
            var item = BSE.userAccounts.ToArray();
            //no = item.LastOrDefault().Account_No + 1;
            txtAccountNumber.Text = Convert.ToString(no);
        }

        private void loaddate()
        {
            lblDate.Text = DateTime.Now.ToString("MM/dd/yyy");
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfd = new OpenFileDialog();
            if (openfd.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(openfd.FileName);
                pictureBox1.Image = img;
                ms = new MemoryStream();
                img.Save(ms, img.RawFormat);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rdbMale.Checked)
            {
                gender = "Male";
            }
            else if (rdbFemale.Checked)
            {
                gender = "Female";
            }

            if (rdbMarried.Checked)
            {
                m_status = "Married";
            }
            else if (rdbUnmarried.Checked)
            {
                m_status = "Unmarried";
            }

            BSE = new banking_dbEntities();
            userAccount acc = new userAccount();
            acc.Account_No = Convert.ToDecimal(txtAccountNumber.Text);
            acc.Name = txtName.Text;
            acc.DOB = dtpDOB.Text;
            acc.PhoneNo = txtPhoneNumber.Text;
            acc.Address = txtAddress.Text;
            acc.District = txtDist.Text;
            acc.State = cboState.SelectedItem.ToString();
            acc.Gender = gender;
            acc.Martital_Status = m_status;
            acc.Mother_Name = txtMotherName.Text;
            acc.Father_Name = txtFatherName.Text;
            acc.Balance = Convert.ToDecimal(txtBalance.Text);
            acc.Date = lblDate.Text;
            acc.Picture = ms.ToArray();
            BSE.userAccounts.Add(acc);
            BSE.SaveChanges();
            MessageBox.Show("File Saved");
        }
    }
}
