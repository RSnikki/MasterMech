using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MasterMechLib;

namespace MasterMech
{
    public partial class UserAccountForm : Form
    {
        public UserAccountForm()
        {
            InitializeComponent();
        }

        public void LoadFormData(UserDtl lObjUser)
        {
            textBoxName.Text = lObjUser.msUserName;
            textBoxMno.Text = lObjUser.msMobNo;
            textBoxEid.Text = lObjUser.msEmailID;
            textBoxUserType.Text = lObjUser.msUserType;
            textBoxLL.Text = Convert.ToString(lObjUser.mdLastLoginTime);
            textBoxLPC.Text = Convert.ToString(lObjUser.mdLastPwdChangeTime);
            textBoxCreated.Text = Convert.ToString(lObjUser.mdCreated);
            textBoxCreatedBy.Text = lObjUser.msCreatedBy;
            textBoxModified.Text = Convert.ToString(lObjUser.mdModified);
            textBoxModifiedBy.Text = lObjUser.msModifiedBy;

            textBoxUserType.Enabled = false;
            textBoxLL.Enabled = false;
            textBoxLPC.Enabled = false;
            textBoxCreated.Enabled = false;
            textBoxCreatedBy.Enabled = false;
            textBoxModified.Enabled = false;
            textBoxModifiedBy.Enabled = false;
        }

        public void GetDetails()
        {
            UserDtl lObjUserDummy = new UserDtl();
            lObjUserDummy.Load(MasterMechUtil.msConString, MasterMechUtil.sUserID);
            LoadFormData(lObjUserDummy);
        }

        public void GetGeneralInfo(UserDtl lObjUser)
        {
            lObjUser.msUserName = textBoxName.Text;
            lObjUser.msMobNo = textBoxMno.Text;
            lObjUser.msEmailID = textBoxEid.Text;
        }

        private void UserAccountForm_Load(object sender, EventArgs e)
        {
            GetDetails();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            UserDtl lObjUserDummy = new UserDtl();
            lObjUserDummy.msUserID = MasterMechUtil.sUserID;
            GetGeneralInfo(lObjUserDummy);
            if(lObjUserDummy.UpdateUserGeneralInfo(MasterMechUtil.msConString, MasterMechUtil.sUserID))
            {
                MessageBox.Show("General Info updated Successfully.");
            }
            else
            {
                MessageBox.Show("Error");
            }
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxName_Validating(object sender, CancelEventArgs e)
        {
            if(textBoxName.Text.Length == 0)
            {
                labelNameError.Visible = true;
                e.Cancel = true;
            }
        }

        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelNameError.Visible = false;
        }

        private void textBoxMno_Validating(object sender, CancelEventArgs e)
        {
            if (this.textBoxMno.Text.Length > 0) // Checking if there is some value in the text box
            {
                bool lbValidMobNO = Regex.IsMatch(this.textBoxMno.Text, @"^(\d{10})$", RegexOptions.IgnoreCase);
                if (!lbValidMobNO)
                {
                    textBoxMno.ForeColor = Color.Red;
                    textBoxMno.Font = new Font(textBoxMno.Font, FontStyle.Bold);
                    labelMnoError.Visible = true;
                    e.Cancel = true;
                }
            }
        }

        private void textBoxMno_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelMnoError.Visible = false;
        }

        private void textBoxEid_Validating(object sender, CancelEventArgs e)
        {
            if (this.textBoxEid.Text.Length > 0)
            {
                bool lbValidEmail = Regex.IsMatch(this.textBoxEid.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (!lbValidEmail)
                {
                    textBoxEid.ForeColor = Color.Red;
                    textBoxEid.Font = new Font(textBoxEid.Font, FontStyle.Bold);
                    labelEid.Visible = true;
                    e.Cancel = true;
                }
            }
        }

        private void textBoxEid_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelEid.Visible = false;
        }
    }
}
