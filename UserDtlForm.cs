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

namespace MasterMech
{
    public partial class UserDtlForm : Form
    {

        private MasterMechLib.MasterMechUtil.OPMode mnMode;
        private List<int> mnErrorControls = new List<int>();
        private  string msSqlConStr = MasterMechLib.MasterMechUtil.msConString;

        public UserDtlForm()
        {
            InitializeComponent();
        }

        public UserDtlForm(MasterMechLib.MasterMechUtil.OPMode inMode)
        {
            mnMode = inMode;
            InitializeComponent();
        }

        private bool ValidateEntry(MasterMechLib.MasterMechUtil.OPMode inMode)
        {

            bool lbValid = true;
            mnErrorControls.Clear();

            if(textBoxId.Text.Length > 0)
            {
                if(inMode == MasterMechLib.MasterMechUtil.OPMode.New)
                {
                    MasterMechLib.UserDtl lObjUserDummy = new MasterMechLib.UserDtl();
                    lObjUserDummy.msUserID = textBoxId.Text.ToString();
                    if (lObjUserDummy.ValidUserID(msSqlConStr))
                    {
                        textBoxId.ForeColor = Color.Red;
                        textBoxId.Font = new Font(textBoxId.Font, FontStyle.Bold);
                        labelIDValidating.Visible = true;
                        lbValid = false;
                        mnErrorControls.Add(0);
                    }
                }
            }
            else
            {
                labelIDValidating.Visible = true;
                lbValid = false;
                mnErrorControls.Add(0);
            }

            if((!textBoxPwd.Text.Equals(textBoxCnfPass.Text)) || textBoxPwd.Text.Equals(""))
            {
                labelPwdValidating.Visible = true;
                lbValid = false;
                mnErrorControls.Add(1);
            }

            if(textBoxName.Text.Length == 0)
            {
                labelNameValidating.Visible = true;
                lbValid = false;
                mnErrorControls.Add(2);
            }

            if(textBoxMno.Text.Length == 0)
            {
                labelMNoValidating.Visible = true;
                lbValid = false;
                mnErrorControls.Add(3);
            }

            if(textBoxEid.Text.Length == 0)
            {
                labelEidValidating.Visible = true;
                lbValid = false;
                mnErrorControls.Add(4);
            }
            return lbValid;
        }

        private void UserDtlForm_Load(object sender, EventArgs e)
        {
            switch (mnMode)
            {
                case MasterMechLib.MasterMechUtil.OPMode.New:
                    textBoxLL.Enabled = false;
                    textBoxLPC.Enabled = false;
                    textBoxCreate.Enabled = false;
                    textBoxCreateBy.Enabled = false;
                    textBoxModify.Enabled = false;
                    textBoxModifyBy.Enabled = false;
                    buttonAction.Text = "Save";
                    break;
                case MasterMechLib.MasterMechUtil.OPMode.Open:
                    textBoxLL.Enabled = false;
                    textBoxLPC.Enabled = false;
                    textBoxCreate.Enabled = false;
                    textBoxCreateBy.Enabled = false;
                    textBoxModify.Enabled = false;
                    textBoxModifyBy.Enabled = false;
                    buttonAction.Text = "Save";
                    break;
                case MasterMechLib.MasterMechUtil.OPMode.Delete:
                    textBoxPwd.Enabled = false;
                    textBoxCnfPass.Enabled = false;
                    textBoxName.Enabled = false;
                    textBoxMno.Enabled = false;
                    textBoxEid.Enabled = false;
                    comboBoxUType.Enabled = false;
                    textBoxRem.Enabled = false;
                    textBoxLL.Enabled = false;
                    textBoxLPC.Enabled = false;
                    textBoxCreate.Enabled = false;
                    textBoxCreateBy.Enabled = false;
                    textBoxModify.Enabled = false;
                    textBoxModifyBy.Enabled = false;
                    buttonAction.Text = "Delete";
                    break;
            }
        }

        public void FormDataLoad(MasterMechLib.UserDtl lObjUser)
        {
            textBoxId.Text = lObjUser.msUserID;
            textBoxPwd.Text = MasterMechLib.MasterMechUtil.Decrypt(lObjUser.msPwd);
            textBoxCnfPass.Text = MasterMechLib.MasterMechUtil.Decrypt(lObjUser.msPwd);
            textBoxName.Text = lObjUser.msUserName;
            if(lObjUser.msMobNo is null)
            {
                textBoxMno.Text = "";
            }
            else
            {
                textBoxMno.Text = lObjUser.msMobNo.ToString();
            }
            if (lObjUser.msEmailID is null)
            {
                textBoxEid.Text = "";
            }
            else
            {
                textBoxEid.Text = lObjUser.msEmailID.ToString();
            }
            comboBoxUType.Text = lObjUser.msUserType;
            if (lObjUser.msRemarks is null)
            {
                textBoxRem.Text = "";
            }
            else
            {
                textBoxRem.Text = lObjUser.msRemarks.ToString();
            }
            if (lObjUser.mdLastLoginTime is null)
            {
                textBoxLL.Text = "";
            }
            else
            {
                textBoxLL.Text = Convert.ToString(lObjUser.mdLastLoginTime);
            }
            if (lObjUser.mdLastPwdChangeTime is null)
            {
                textBoxLPC.Text = "";
            }
            else
            {
                textBoxLPC.Text = Convert.ToString(lObjUser.mdLastPwdChangeTime);
            }
            if (lObjUser.mdCreated is null)
            {
                textBoxCreate.Text = "";
            }
            else
            {
                textBoxCreate.Text = Convert.ToString(lObjUser.mdCreated);
            }
            if (lObjUser.msCreatedBy is null)
            {
                textBoxCreateBy.Text = "";
            }
            else
            {
                textBoxCreateBy.Text = lObjUser.msCreatedBy.ToString();
            }
            if (lObjUser.msModifiedBy is null)
            {
                textBoxModify.Text = "";
            }
            else
            {
                textBoxModify.Text = lObjUser.msModifiedBy.ToString();
            }
            if (lObjUser.msModifiedBy is null)
            {
                textBoxModifyBy.Text = "";
            }
            else
            {
                textBoxModifyBy.Text = lObjUser.msModifiedBy.ToString();
            }
            
        }

        public void SearchUsers()
        {
            MasterMechLib.UserDtl lObjUserDummy = new MasterMechLib.UserDtl();

            List<MasterMechLib.UserDtl> lObjUserList = new List<MasterMechLib.UserDtl>();

            string lsSearchKey = textBoxId.Text;

            lObjUserDummy.SearchUser(msSqlConStr, lsSearchKey, lObjUserList);

            UserDataGridForm lObjUDGForm = new UserDataGridForm();
            lObjUDGForm.noSelectMsg = "No User Selected. Select a user row and then click select.";

            //Build the header
            lObjUDGForm.dataGridViewUserSrch.ReadOnly = true;
            lObjUDGForm.dataGridViewUserSrch.AllowUserToAddRows = false;
            lObjUDGForm.dataGridViewUserSrch.ColumnCount = 13;
            lObjUDGForm.dataGridViewUserSrch.Columns[0].Name = "S. No.";
            lObjUDGForm.dataGridViewUserSrch.Columns[1].Name = "UserID";
            lObjUDGForm.dataGridViewUserSrch.Columns[2].Name = "User Name";
            lObjUDGForm.dataGridViewUserSrch.Columns[3].Name = "Mobile No";
            lObjUDGForm.dataGridViewUserSrch.Columns[4].Name = "Email Id";
            lObjUDGForm.dataGridViewUserSrch.Columns[5].Name = "User Type";
            lObjUDGForm.dataGridViewUserSrch.Columns[6].Name = "Last Login Time";
            lObjUDGForm.dataGridViewUserSrch.Columns[7].Name = "Last Pwd Change Time";
            lObjUDGForm.dataGridViewUserSrch.Columns[8].Name = "Remarks";
            lObjUDGForm.dataGridViewUserSrch.Columns[9].Name = "Created";
            lObjUDGForm.dataGridViewUserSrch.Columns[10].Name = "Created By";
            lObjUDGForm.dataGridViewUserSrch.Columns[11].Name = "Modified";
            lObjUDGForm.dataGridViewUserSrch.Columns[12].Name = "Modified By";
            
            int lnCnt = 1;

            if (lObjUserList.Count == 0)
            {
                MessageBox.Show("No Test Found!");
                this.textBoxId.Focus();
                return;
            }
            else if (lObjUserList.Count == 1)
            {
                lObjUserDummy.Load(msSqlConStr, lObjUserList[0].msUserID);
                FormDataLoad(lObjUserDummy);

            }
            else if (lObjUserList.Count > 1)
            {
                foreach (MasterMechLib.UserDtl User in lObjUserList)
                {
                    lObjUDGForm.dataGridViewUserSrch.Rows.Add(lnCnt++, User.msUserID, User.msUserName, User.msMobNo, User.msEmailID, User.msUserType, User.mdLastLoginTime, User.mdLastPwdChangeTime, User.msRemarks, User.mdCreated, User.msCreatedBy, User.mdModified, User.msModifiedBy);

                }
                lObjUDGForm.ShowDialog();
                int lnSelectedRow = lObjUDGForm.mnSelectedRow;
                string lnUserId = Convert.ToString(lObjUDGForm.dataGridViewUserSrch.Rows[lnSelectedRow].Cells[1].Value);
                if (lObjUDGForm.mbSelected)
                {
                    if (lObjUserDummy.Load(msSqlConStr, lnUserId))
                    {
                        FormDataLoad(lObjUserDummy);
                    }
                }
                else
                {
                    textBoxId.Focus();
                }
            }

        }

        public void SaveUser(bool ibNewMode)
        {
            MasterMechLib.UserDtl lObjUserDummy = new MasterMechLib.UserDtl();
            if (ibNewMode)
            {
                lObjUserDummy.msUserID = textBoxId.Text;
                lObjUserDummy.msPwd = MasterMechLib.MasterMechUtil.Encrypt(textBoxCnfPass.Text);
                lObjUserDummy.msUserName = textBoxName.Text;
                lObjUserDummy.msMobNo = textBoxMno.Text;
                lObjUserDummy.msEmailID = textBoxEid.Text;
                lObjUserDummy.msUserType = comboBoxUType.SelectedItem.ToString();
                lObjUserDummy.msRemarks = textBoxRem.Text;

                if(lObjUserDummy.Save(msSqlConStr, MasterMechLib.MasterMechUtil.sUserID, ibNewMode))
                {
                    MessageBox.Show("User successfully added!");
                }
                else
                {
                    MessageBox.Show("Unable to add user!");
                }
            }
            else
            {
                lObjUserDummy.msUserID = textBoxId.Text;
                lObjUserDummy.msPwd = textBoxCnfPass.Text;
                lObjUserDummy.msUserName = textBoxName.Text;
                lObjUserDummy.msMobNo = textBoxMno.Text;
                lObjUserDummy.msEmailID = textBoxEid.Text;
                lObjUserDummy.msUserType = comboBoxUType.SelectedItem.ToString();
                lObjUserDummy.msRemarks = textBoxRem.Text;

                if (lObjUserDummy.Save(msSqlConStr, MasterMechLib.MasterMechUtil.sUserID, ibNewMode))
                {
                    MessageBox.Show("User detail successfully updated!");
                }
                else
                {
                    MessageBox.Show("Unable to update user details!");
                }
            }
            
            
        }

        public void DeleteUser()
        {
            MasterMechLib.UserDtl lObjUserDummy = new MasterMechLib.UserDtl();
            lObjUserDummy.msUserID = textBoxId.Text;
            if (textBoxId.Text.Length != 0)
            {
                if(lObjUserDummy.Delete(msSqlConStr, MasterMechLib.MasterMechUtil.sUserID))
                {
                    MessageBox.Show("User Successfully deleted!");
                }
                else
                {
                    MessageBox.Show("User not deleted or not available to delete.");
                }
            }
            
        }

        private void buttonAction_Click(object sender, EventArgs e)
        {
            bool lbMode;

            if (!ValidateEntry(mnMode))
            {
                if(mnErrorControls.Count > 0)
                {
                    int lnFirstControl = mnErrorControls.Min();
                    switch (lnFirstControl) 
                    {
                        case 0: textBoxId.Focus(); break;
                        case 1: textBoxPwd.Focus(); break;
                        case 2: textBoxName.Focus(); break;
                        case 3: textBoxMno.Focus(); break;
                        case 4: textBoxEid.Focus(); break;
                    }

                }
                return;
            }
            if(mnMode == MasterMechLib.MasterMechUtil.OPMode.New)
            {
                lbMode = true;
                SaveUser(lbMode);
            }
            else if (mnMode == MasterMechLib.MasterMechUtil.OPMode.Open)
            {
                lbMode = false;
                SaveUser(lbMode);
            }
            else if (mnMode == MasterMechLib.MasterMechUtil.OPMode.Delete)
            {
                DeleteUser();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void buttonSrch_Click(object sender, EventArgs e)
        {
            if(mnMode == MasterMechLib.MasterMechUtil.OPMode.Open || mnMode == MasterMechLib.MasterMechUtil.OPMode.Delete)
            {
                if (textBoxId.Text.Length > 0)
                {
                    SearchUsers();
                }
                else
                {
                    MessageBox.Show("Please provide valid key to search user!");
                }
            }

            else if(mnMode == MasterMechLib.MasterMechUtil.OPMode.New)
            {
                if (textBoxId.Text.Length > 0)
                {
                    MasterMechLib.UserDtl lObjUserDummy = new MasterMechLib.UserDtl();
                    lObjUserDummy.msUserID = textBoxId.Text;
                    if (lObjUserDummy.ValidUserID(msSqlConStr))
                    {
                        MessageBox.Show("UserID already exists. Please choose a new UserID.");
                    }
                }
                else
                {
                    MessageBox.Show("Please provide valid key to search user!");
                }
            }
            
        }


        private void textBoxId_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxId.Text.Length == 0)
            {
                labelIDValidating.Visible = true;
                labelIDValidating.Text = "UserID is Blank. Choose a new UserID.";
                e.Cancel = false;
            }
            
        }


        private void textBoxName_Validating(object sender, CancelEventArgs e)
        {
            if(textBoxName.Text.Length == 0)
            {
                labelNameValidating.Visible = true;
                e.Cancel = false;
            }
           
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
                    labelMNoValidating.Visible = true;
                    e.Cancel = false;
                }
            }
        }

        private void textBoxCnfPass_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxCnfPass.Text.Length == 0)
            {
                labelPwdValidating.Text = "Rewrite your password.";
                labelPwdValidating.Visible = true;
                e.Cancel = false;
            }
            else if (textBoxCnfPass.Text != textBoxPwd.Text)
            {
                labelPwdValidating.Text = "Confirm Password donot match.";
                labelPwdValidating.Visible = true;
                e.Cancel = false;
            }
        }

        private void textBoxPwd_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxPwd.Text.Length == 0)
            {
                labelPwdValidating.Text = "Password is blank.";
                labelPwdValidating.Visible = true;
                e.Cancel = false;
            }
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
                    labelEidValidating.Visible = true;
                    e.Cancel = false;
                }
            }
        }

        private void textBoxId_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelIDValidating.Visible = false;
        }

        private void textBoxPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelPwdValidating.Visible = false;
        }

        private void textBoxCnfPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelPwdValidating.Visible = false;
        }

       

        private void textBoxMno_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxMno.ForeColor = Color.Black;
            textBoxMno.Font = new Font(textBoxMno.Font, FontStyle.Regular);
            labelMNoValidating.Visible = false;
        }

        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelNameValidating.Visible = false;
        }

        private void textBoxEid_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxEid.ForeColor = Color.Black;
            textBoxEid.Font = new Font(textBoxEid.Font, FontStyle.Regular);
            labelEidValidating.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBoxPwd.PasswordChar = '\0';
                textBoxCnfPass.PasswordChar = '\0';
                checkBox1.Text = "Hide";
            }
            else
            {
                textBoxPwd.PasswordChar = '*';
                textBoxCnfPass.PasswordChar = '*';
                checkBox1.Text = "Show";
            }
        }

        
    }
}
