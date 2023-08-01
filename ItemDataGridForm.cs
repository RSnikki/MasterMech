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
    public partial class ItemDataGridForm : Form
    {
        public int mnSelectedRow = 0;
        public bool mbSelected = false;
        public string noSelectMsg;
        public bool mbShowSelect = true;

        public ItemDataGridForm()
        {
            InitializeComponent();
        }

        private void ItemDataGridForm_Load(object sender, EventArgs e)
        {
            buttonSelect.Visible = mbShowSelect;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if (this.dataGridItemView.SelectedRows.Count == 0)
            {
                MessageBox.Show(noSelectMsg);
                return;
            }
            else
            {
                mnSelectedRow = this.dataGridItemView.SelectedRows[0].Index;
                mbSelected = true;
                this.Hide();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            mnSelectedRow = 0;
            mbSelected = false;
            this.Hide();
        }

        private void dataGridItemView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                this.dataGridItemView.Rows[e.RowIndex].Selected = true;
        }

        private void dataGridItemView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridItemView.Rows[e.RowIndex].Selected = true;
            mnSelectedRow = this.dataGridItemView.SelectedRows[0].Index;
            mbSelected = true;
            this.Hide();
        }
    }
}
