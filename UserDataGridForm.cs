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
    public partial class UserDataGridForm : Form
    {
        public int mnSelectedRow = 0;
        public bool mbSelected = false;
        public string noSelectMsg;
        public bool mbShowSelect = true;
        public UserDataGridForm()
        {
            InitializeComponent();
        }

        private void UserDataGridForm_Load(object sender, EventArgs e)
        {
            btnSelect.Visible = mbShowSelect;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewUserSrch.SelectedRows.Count == 0)
            {
                MessageBox.Show(noSelectMsg);
                return;
            }
            else
            {
                mnSelectedRow = this.dataGridViewUserSrch.SelectedRows[0].Index;
                mbSelected = true;
                this.Hide();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mnSelectedRow = 0;
            mbSelected = false;
            this.Hide();
        }

        private void dataGridViewUserSrch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                this.dataGridViewUserSrch.Rows[e.RowIndex].Selected = true;
        }

        private void dataGridViewUserSrch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridViewUserSrch.Rows[e.RowIndex].Selected = true;
            mnSelectedRow = this.dataGridViewUserSrch.SelectedRows[0].Index;
            mbSelected = true;
            this.Hide();
        }
    }
}
