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
    public partial class CustomerGridForm : Form
    {
        public int mnSelectedRow = 0;
        public bool mbSelected = false;
        public string noSelectMsg;
        public bool mbShowSelect = true;

        public CustomerGridForm()
        {
            InitializeComponent();
        }

        private void CustomerGridForm_Resize(object sender, EventArgs e)
        {
            this.dataGridViewCustomer.Left = this.Padding.Left + 10;
            this.dataGridViewCustomer.Width = this.Width - this.Padding.Right - this.Padding.Left - 40;
        }

        private void CustomerGridForm_Load(object sender, EventArgs e)
        {
            this.dataGridViewCustomer.Left = this.Padding.Left + 10;
            this.dataGridViewCustomer.Width = this.Width - this.Padding.Right - this.Padding.Left - 40;
            buttonSelect.Visible = mbShowSelect;
        }

        private void dataGridViewCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                this.dataGridViewCustomer.Rows[e.RowIndex].Selected = true;
        }

        private void dataGridViewCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridViewCustomer.Rows[e.RowIndex].Selected = true;
            mnSelectedRow = this.dataGridViewCustomer.SelectedRows[0].Index;
            mbSelected = true;
            this.Hide();
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if(this.dataGridViewCustomer.SelectedRows.Count == 0)
            {
                MessageBox.Show(noSelectMsg);
                return;
            }
            else
            {
                mnSelectedRow = this.dataGridViewCustomer.SelectedRows[0].Index;
                mbSelected = true;
                this.Hide();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
