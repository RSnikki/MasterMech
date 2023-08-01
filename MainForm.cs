using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterMech
{
    public partial class MainForm : Form
        
    {
       public bool ExitApp;
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(string isUserId, string isUserType)
        {
            InitializeComponent();
            toolStripLabelUserId.Text = "USER ID: " + isUserId;
            toolStripLabelUserType.Text = "USER TYPE: " + isUserType;
            
            loadToolStripComboBox(MasterMechLib.MasterMechUtil.FYList());
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserDtlForm lObjUserForm = new UserDtlForm(MasterMechLib.MasterMechUtil.OPMode.New);
            lObjUserForm.ShowDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserDtlForm lObjUserForm = new UserDtlForm(MasterMechLib.MasterMechUtil.OPMode.Open);
            lObjUserForm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserDtlForm lObjUserForm = new UserDtlForm(MasterMechLib.MasterMechUtil.OPMode.Delete);
            lObjUserForm.ShowDialog();
        }

        private void nEWToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ItemForm f1 = new ItemForm(MasterMechLib.MasterMechUtil.OPMode.New);
            f1.ShowDialog();
        }

        private void oPENToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ItemForm f2 = new ItemForm(MasterMechLib.MasterMechUtil.OPMode.Open);
            f2.ShowDialog();
        }

        private void dELETEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ItemForm f3 = new ItemForm(MasterMechLib.MasterMechUtil.OPMode.Delete);
            f3.ShowDialog();
        }

        private void uSERACCOUNTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserAccountForm lObjUserAccountForm = new UserAccountForm();
            lObjUserAccountForm.ShowDialog();
        }

        private void uPDATEPASSWORDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdatePasswordForm lObjUpdatePasswordForm = new UpdatePasswordForm();
            lObjUpdatePasswordForm.ShowDialog();
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nEWToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CustomerForm lObjcustomerForm = new CustomerForm(MasterMechLib.MasterMechUtil.OPMode.New);
            lObjcustomerForm.ShowDialog();
        }

        private void oPENToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CustomerForm lObjCustomerForm = new CustomerForm(MasterMechLib.MasterMechUtil.OPMode.Open);
            lObjCustomerForm.ShowDialog();
        }

        private void dELETEToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CustomerForm lObjCustomerForm = new CustomerForm(MasterMechLib.MasterMechUtil.OPMode.Delete);
            lObjCustomerForm.ShowDialog();
        }

        private void newToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            InvoiceForm lObjInvoiceForm = new InvoiceForm(MasterMechLib.MasterMechUtil.OPMode.New);
            lObjInvoiceForm.ShowDialog();
        }

        private void openToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            InvoiceForm lObjInvoiceForm = new InvoiceForm(MasterMechLib.MasterMechUtil.OPMode.Open);
            lObjInvoiceForm.ShowDialog();
        }

        private void deleteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            InvoiceForm lObjInvoiceForm = new InvoiceForm(MasterMechLib.MasterMechUtil.OPMode.Delete);
            lObjInvoiceForm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonNewInvoice_Click(object sender, EventArgs e)
        {
            InvoiceForm lObjDummyInvoice = new InvoiceForm(MasterMechLib.MasterMechUtil.OPMode.New);
            lObjDummyInvoice.ShowDialog();
        }

        private void changeSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripComboBoxSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            MasterMechLib.MasterMechUtil.sFY = Convert.ToString(toolStripComboBoxSession.SelectedItem);
        }

        public void loadToolStripComboBox(string[] fYList)
        {
            foreach(string fY in fYList)
            {
                toolStripComboBoxSession.Items.Add(fY);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
