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
    public partial class LoginForm : Form
    {
        public int mnStatus;
        public bool mbOKButtonClicked;
        public string msUserID;
        public string msUserType;
        public string msFY;
        
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            LoadFY();
            this.textBoxId.Focus();
        }

        public void LoadFY()
        {
            string[] lsFYList = MasterMechLib.MasterMechUtil.FYList();
            string lsCurrFY = MasterMechLib.MasterMechUtil.CurrFY();

            this.comboBoxFY.Items.Clear();

            for(int lnCount =0; lnCount < lsFYList.Length; lnCount++)
            {
                this.comboBoxFY.Items.Add(lsFYList[lnCount]);
                if (lsFYList[lnCount].Equals(lsCurrFY))
                    this.comboBoxFY.SelectedIndex = lnCount;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string lsMessage = "";
            if(textBoxId.Text.Length == 0)
            {
                lsMessage = "Please Enter User ID.\n";
            }
            if(textBoxPassword.Text.Length == 0)
            {
                lsMessage = "Please Enter Password.\n";
            }
            if(lsMessage.Length != 0)
            {
                MessageBox.Show(lsMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                UserDtl lObjUserDummy = new UserDtl();
                lObjUserDummy.msUserID = textBoxId.Text;
                lObjUserDummy.msPwd = MasterMechUtil.Encrypt(textBoxPassword.Text);

                if (lObjUserDummy.ValidUserID(MasterMechUtil.msConString))
                {
                    if (lObjUserDummy.ValidLogin(MasterMechUtil.msConString))
                    {
                        msUserID = lObjUserDummy.msUserID;
                        msUserType = lObjUserDummy.msUserType;
                        lObjUserDummy.UpdateLoginTime(MasterMechUtil.msConString, lObjUserDummy.msUserID);
                        mnStatus = 1;
                        this.textBoxId.Text = "";
                        this.textBoxPassword.Text = "";
                        mbOKButtonClicked = true;
                        msFY = comboBoxFY.SelectedItem.ToString();
                        LoadFY();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Password. Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.textBoxPassword.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid UserID.Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.textBoxId.Focus();
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            mnStatus = 0;
            this.Close();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!mbOKButtonClicked)
                 mnStatus = 0;
        }
    }
}
