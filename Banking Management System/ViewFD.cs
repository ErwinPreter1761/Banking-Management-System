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
    public partial class ViewFD : Form
    {
        BindingList<FD> bl;
        banking_dbEntities dbe;
        public ViewFD()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            bl = new BindingList<FD>();
            dbe = new banking_dbEntities();
            string date = dtpCtt.Value.ToString("MM/dd/yyyy");
            MessageBox.Show(date);
            var item = dbe.FDs.Where(a=>a.Start_Date.Equals(date));
            dgvData.DataSource = item.ToList();
        }
    }
}
