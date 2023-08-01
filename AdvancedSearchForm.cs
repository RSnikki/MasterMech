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
    public partial class AdvancedSearchForm : Form
    {
        List<MasterMechLib.Customer> lObjListCust;
        public AdvancedSearchForm()
        {
            InitializeComponent();
        }

        public AdvancedSearchForm(List<MasterMechLib.Customer> iObjListCust)
        {
            InitializeComponent();
            lObjListCust = iObjListCust;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            MasterMechLib.Customer lObjCustDummy = new MasterMechLib.Customer();
            string lsFNameKey = textBoxFName.Text;
            string lsLNameKey = textBoxLName.Text;
            string lsCityKey = textBoxCity.Text;

            lObjCustDummy.AdvancedSearch(MasterMechLib.MasterMechUtil.msConString, lsFNameKey, lsLNameKey, lsCityKey, lObjListCust);
            this.Hide();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
