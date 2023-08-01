using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace MasterMech
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

       

        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            this.CloseTimer.Enabled = true;
            labelV.Visible = true;
            labelV.Text = "V: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

       
    }
}
