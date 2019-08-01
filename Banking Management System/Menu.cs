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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void newAcoountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newAccount newacc = new newAccount();
            newacc.MdiParent = this;
            newacc.Show();
        }

        private void updateSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdationForm up = new UpdationForm();
            up.MdiParent=this;
            up.Show();
        }

        private void allCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustumerList Cl = new CustumerList();
            Cl.MdiParent = this;
            Cl.Show();
        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreditForm crdfrm = new CreditForm();
            crdfrm.MdiParent = this;
            crdfrm.Show();
        }

        private void wirhdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebitForm dpf = new DebitForm();
            dpf.MdiParent = this;
            dpf.Show();
        }

        private void transferToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TransferForm Tf = new TransferForm();
            Tf.MdiParent = this;
            Tf.Show();
        }

        private void fDTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDForm fds = new FDForm();
            fds.MdiParent = this;
            fds.Show();
        }

        private void balanceSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            balanceSheet bls = new balanceSheet();
            bls.MdiParent = this;
            bls.Show();
        }

        private void fDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewFD viewFD = new ViewFD();
            viewFD.MdiParent = this;
            viewFD.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword();
            cp.MdiParent = this;
            cp.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            banking_dbEntities log = new banking_dbEntities();
            
        }
    }
}
