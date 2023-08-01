using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MasterMechLib;

namespace MasterMech
{
    public partial class InvoiceAdvanceSearchForm : Form
    {
        List<Invoice> mObjListInvoice;

        public InvoiceAdvanceSearchForm()
        {
            InitializeComponent();
        }

        public InvoiceAdvanceSearchForm(List<Invoice> IObjListInvoice)
        {
            mObjListInvoice = IObjListInvoice;
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string lsFName = textBoxSearchCustFirstName.Text;
            string lsVehReg = textBoxSearchVehicleReg.Text;
            string lsCity = textBoxSearchCity.Text;
            string lsAssociate = textBoxSearchAsso.Text;
            Invoice lObjInvoice = new Invoice(MasterMechUtil.msConString, MasterMechUtil.sUserID);
            lObjInvoice.AdvancedSearch(lsFName, lsVehReg, lsCity, lsAssociate, mObjListInvoice);
            this.Hide();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
