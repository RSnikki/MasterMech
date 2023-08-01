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
    public partial class UpdatePasswordForm : Form
    {
        public UpdatePasswordForm()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            UserDtl lObjUserDummy = new UserDtl();
            lObjUserDummy.msUserID = MasterMechUtil.sUserID;
            lObjUserDummy.msPwd = MasterMechUtil.Encrypt(textBoxOldPwd.Text);

            if (lObjUserDummy.ValidLogin(MasterMechUtil.msConString))
            {
                if(textBoxNewPwd.Text == textBoxCPwd.Text)
                {
                    if (lObjUserDummy.UpdatePassword(MasterMechUtil.msConString, MasterMechUtil.sUserID, MasterMechUtil.Encrypt(textBoxNewPwd.Text)))
                    {
                        MessageBox.Show("Password Updated Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Error!");
                    }
                }
                else
                {
                    MessageBox.Show("New Password and Confirm Password doesnot matches.");
                }
               
            }
            else
            {
                MessageBox.Show("Wrong Password! Try again!");
            }
        }

        private void textBoxOldPwd_Validating(object sender, CancelEventArgs e)
        {
            if(textBoxOldPwd.Text.Length == 0)
            {
                labelOldPwd.Visible = true;
                e.Cancel = true;
            }
        }

        private void textBoxOldPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelOldPwd.Visible = false;
        }

        private void textBoxNewPwd_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxNewPwd.Text.Length == 0)
            {
                labelNewPwd.Visible = true;
                e.Cancel = true;
            }
        }

        private void textBoxNewPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
                labelNewPwd.Visible = false;
        }

        private void textBoxCPwd_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxCPwd.Text.Length == 0)
            {
                labelCPwd.Text = "Confirm Password is blank. Confirm your Password!";
                labelNewPwd.Visible = true;
                e.Cancel = true;
            }
            if(textBoxNewPwd.Text != textBoxCPwd.Text)
            {
                labelCPwd.Text = "Confirm Password doenot matches with New Password.";
                labelNewPwd.Visible = true;
                e.Cancel = true;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
