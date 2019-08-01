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
    public partial class UpdationForm : Form
    {
        banking_dbEntities dbe;
        MemoryStream ms;
        BindingList<userAccount> bi;

        public UpdationForm()
        {
            InitializeComponent();

        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            bi = new BindingList<userAccount>();
            dbe = new banking_dbEntities();
            decimal accno = Convert.ToDecimal(txtAccountNumber.Text);
            var item = dbe.userAccounts.Where(a => a.Account_No == accno);
            foreach (var item1 in item)
            {
                bi.Add(item1);
            }
            dataGridView1.DataSource = bi;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bi = new BindingList<userAccount>();
            dbe = new banking_dbEntities();
            var item = dbe.userAccounts.Where(a => a.Name == txtName.Text);
            foreach (var item1 in item)
            {
                bi.Add(item1);
            }
            dataGridView1.DataSource = bi;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dbe = new banking_dbEntities();
            decimal accno = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            var item = dbe.userAccounts.Where(a=>a.Account_No==accno).FirstOrDefault();
            txtAccountNumber.Text = item.Account_No.ToString();
            txtName.Text = item.Name;
            txtMotherName.Text = item.Mother_Name;
            txtFatherName.Text = item.Father_Name;
            txtPhoneNumber.Text = item.PhoneNo;
            txtAddress.Text = item.Address;
            byte[] img = item.Picture;
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);
            txtDistrict.Text = item.District;
            txtState.Text = item.State;
            if (item.Gender == "male")
            {
                rdbMale.Checked = true;
            }
            else if (item.Gender=="female")
            {
                rdbFemale.Checked = true;
            }
            if (item.Martital_Status == "Married")
            {
                rdbMarried.Checked = true;
            }
            else if (item.Martital_Status== "Unmarried")
            {
                rdbUnmarried.Checked = true;
            }

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bi.RemoveAt(dataGridView1.SelectedRows[0].Index);
            dbe = new banking_dbEntities();
            decimal a = Convert.ToDecimal(txtAccountNumber.Text);
            userAccount acc = dbe.userAccounts.First(s=>s.Account_No.Equals(a));
            dbe.userAccounts.Remove(acc);
            dbe.SaveChanges();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dbe = new banking_dbEntities();
            decimal accountno = Convert.ToDecimal(txtAccountNumber.Text);
            userAccount useraccount = dbe.userAccounts.First(s => s.Account_No.Equals(accountno));
            useraccount.Account_No = Convert.ToDecimal(txtAccountNumber.Text);
            useraccount.Name = txtName.Text;
            useraccount.Date = dateTimePicker1.Value.ToString();
            useraccount.Mother_Name = txtMotherName.Text;
            useraccount.Father_Name = txtFatherName.Text;
            useraccount.PhoneNo = txtPhoneNumber.Text;
            if (rdbMale.Checked == true)
            {
                useraccount.Gender = "Male";
            }
            else
            {
                if (rdbFemale.Checked == true)
                {
                    useraccount.Gender = "Female";
                }
            }
            if (rdbMarried.Checked == true)
            {
                useraccount.Martital_Status = "Married";
            }
            else
            {
                if (rdbUnmarried.Checked == true)
                    useraccount.Martital_Status = "Unmarried";
            }
            Image img = pictureBox1.Image;
            if (img.RawFormat!=null)
            {
                if (ms != null)
                {
                    img.Save(ms, img.RawFormat);
                    useraccount.Picture = ms.ToArray();

                }
            }
            useraccount.Address = txtAddress.Text;
            useraccount.District = txtDistrict.Text;
            useraccount.State = txtState.Text;
            dbe.SaveChanges();
            MessageBox.Show("Record Updates ");
        }
    }
}
