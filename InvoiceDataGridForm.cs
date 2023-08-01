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
    public partial class InvoiceDataGridForm : Form
    {
        public int mnSelectedRow = 1;
        public bool mbSelected = false;
        public string noSelectMsg;
        public bool mbShowSelect = true;
        public InvoiceDataGridForm()
        {
            InitializeComponent();
        }

        private void InvoiceDataGridForm_Resize(object sender, EventArgs e)
        {
            this.dataGridViewInvoice.Left = this.Padding.Left + 10;
            this.dataGridViewInvoice.Width = this.Width - this.Padding.Right - this.Padding.Left - 40;
        }

        private void InvoiceDataGridForm_Load(object sender, EventArgs e)
        {
            this.dataGridViewInvoice.Left = this.Padding.Left + 10;
            this.dataGridViewInvoice.Width = this.Width - this.Padding.Right - this.Padding.Left - 40;
            buttonSelect.Visible = mbShowSelect;
        }

        private void dataGridViewInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.dataGridViewInvoice.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dataGridViewInvoice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridViewInvoice.Rows[e.RowIndex].Selected = true;
            mnSelectedRow = this.dataGridViewInvoice.SelectedRows[0].Index;
            mbSelected = true;
            this.Hide();
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            if(this.dataGridViewInvoice.SelectedRows.Count == 0)
            {
                MessageBox.Show(noSelectMsg);
                return;
            }
            else
            {
                mnSelectedRow = this.dataGridViewInvoice.SelectedRows[0].Index;
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
