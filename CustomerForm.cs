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
    public partial class CustomerForm : Form
    {
        public MasterMechUtil.OPMode mnMode;
        public List<int> mnErrors = new List<int>();
        public CustomerForm()
        {
            InitializeComponent();
        }

        public CustomerForm(MasterMechUtil.OPMode inMode)
        {
            mnMode = inMode;
            InitializeComponent();
            LoadComboBoxStatus();
            LoadComboBoxType();
        }

        public void LoadComboBoxStatus()
        {
            List<string> lListStatus = new List<string>();
        
            Customer.GetStatus(lListStatus);
            foreach(string x in lListStatus)
            {
                comboBoxStatus.Items.Add(x);
            }
        }

        public void LoadComboBoxType()
        {
            List<string> lListType = new List<string>();
            Customer.GetTypes(lListType);
            foreach (string x in lListType)
            {
                comboBoxType.Items.Add(x);
            }
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            switch (mnMode)
            {
                case MasterMechUtil.OPMode.New:
                    labelKeySearch.Visible = false;
                    textBoxKeySearch.Visible = false;
                    buttonSearch.Visible = false;
                    buttonASearchForm.Visible = false;
                    textBoxCustNo.Enabled = false;
                    textBoxCreated.Enabled = false;
                    textBoxCreatedBy.Enabled = false;
                    textBoxModified.Enabled = false;
                    textBoxModifiedBy.Enabled = false;
                    textBoxLastVisit.Enabled = false;
                    break;
                case MasterMechUtil.OPMode.Open:
                    textBoxCustNo.ReadOnly = true;
                    textBoxCreated.ReadOnly = true; ;
                    textBoxCreatedBy.ReadOnly = true;
                    textBoxModified.ReadOnly = true;
                    textBoxModifiedBy.ReadOnly = true;
                    textBoxLastVisit.ReadOnly = true;
                    break;
                case MasterMechUtil.OPMode.Delete:
                    textBoxCustNo.ReadOnly = true;
                    textBoxFirstName.ReadOnly = true;
                    textBoxLastName.ReadOnly = true;
                    textBoxMNo.ReadOnly = true;
                    textBoxEID.ReadOnly = true;
                    comboBoxStatus.Enabled = false;
                    comboBoxType.Enabled = false;
                    textBoxStreet.ReadOnly = true;
                    textBoxArea.ReadOnly = true;
                    textBoxCity.ReadOnly = true;
                    textBoxState.ReadOnly = true;
                    textBoxPinCode.ReadOnly = true;
                    textBoxCountry.ReadOnly = true;
                    textBoxGSTNo.ReadOnly = true;
                    textBoxLastVisit.ReadOnly = true;
                    textBoxRemarks.ReadOnly = true;
                    textBoxCreated.ReadOnly = true;
                    textBoxCreatedBy.ReadOnly = true;
                    textBoxModified.ReadOnly = true;
                    textBoxModifiedBy.ReadOnly = true;
                    buttonAction.Text = "Delete";
                    break;
            }
        }

        public void ClearFormData()
        {
            textBoxCustNo.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxMNo.Clear();
            textBoxEID.Clear();
            comboBoxStatus.SelectedIndex = -1;
            comboBoxType.SelectedIndex = -1;
            textBoxStreet.Clear();
            textBoxArea.Clear();
            textBoxCity.Clear();
            textBoxState.Clear();
            textBoxPinCode.Clear();
            textBoxCountry.Clear();
            textBoxGSTNo.Clear();
            textBoxLastVisit.Clear();
            textBoxRemarks.Clear();
            textBoxCreated.Clear();
            textBoxCreatedBy.Clear();
            textBoxModified.Clear();
            textBoxModifiedBy.Clear();
        }


        public void LoadFormData(Customer lObjCust)
        {
            textBoxCustNo.Text = Convert.ToString(lObjCust.mnCustomerNo);
            textBoxFirstName.Text = lObjCust.msCustomerFName;
            textBoxLastName.Text = lObjCust.msCustomerLName;
            textBoxMNo.Text = lObjCust.msCustomerMNo;
            textBoxEID.Text = lObjCust.msCustomerEmail;
            comboBoxStatus.SelectedItem = lObjCust.msCustomerStatus;
            comboBoxType.SelectedItem = lObjCust.msCustomerType;

            //if (lObjCust.msCustomerStAddr is null)
            //{
            //    textBoxStreet.Text = String.Empty;
            //}
            //else
            //{
            //    textBoxStreet.Text = lObjCust.msCustomerStAddr;
            //}

            //if (lObjCust.msCustomerArAddr is null)
            //{
            //    textBoxArea.Text = String.Empty;
            //}
            //else
            //{
            //    textBoxArea.Text = lObjCust.msCustomerArAddr;
            //}

            //if (lObjCust.msCustomerCity is null)
            //{
            //    textBoxCity.Text = String.Empty;
            //}
            //else
            //{
            //    textBoxCity.Text = lObjCust.msCustomerCity;
            //}

            //if (lObjCust.msCustomerState is null)
            //{
            //    textBoxState.Text = String.Empty;
            //}
            //else
            //{
            //    textBoxState.Text = lObjCust.msCustomerState;
            //}

            //if (lObjCust.msCustomerPinCode is null)
            //{
            //    textBoxPinCode.Text = String.Empty;
            //}
            //else
            //{
            //    textBoxPinCode.Text = lObjCust.msCustomerPinCode;
            //}

            //if (lObjCust.msCustomerCountry is null)
            //{
            //    textBoxCountry.Text = String.Empty;
            //}
            //else
            //{
            //    textBoxCountry.Text = lObjCust.msCustomerCountry;
            //}

            //if (lObjCust.msCustomerGSTNo is null)
            //{
            //    textBoxGSTNo.Text = String.Empty;
            //}
            //else
            //{
            //    textBoxGSTNo.Text = lObjCust.msCustomerGSTNo;
            //}

            //if (lObjCust.mdCustomerLastVisit is null)
            //{
            //    textBoxLastVisit.Text = String.Empty;
            //}
            //else
            //{
            //    textBoxLastVisit.Text = Convert.ToString(lObjCust.mdCustomerLastVisit);
            //}

            //if (lObjCust.msCustomerRemarks is null)
            //{
            //    textBoxRemarks.Text = String.Empty;
            //}
            //else
            //{
            //    textBoxRemarks.Text = lObjCust.msCustomerRemarks;
            //}

            //if (lObjCust.mdCreated is null)
            //{
            //    textBoxCreated.Text = String.Empty;
            //}
            //else
            //{
            //    textBoxCreated.Text = Convert.ToString(lObjCust.mdCreated);
            //}

            //if (lObjCust.msCreatedBy is null)
            //{
            //    textBoxCreatedBy.Text = String.Empty;
            //}
            //else
            //{
            //    textBoxCreatedBy.Text = lObjCust.msCreatedBy;
            //}

            //if (lObjCust.mdModified is null)
            //{
            //    textBoxModified.Text = String.Empty;
            //}
            //else
            //{
            //    textBoxModified.Text = Convert.ToString(lObjCust.mdModified);
            //}

            //if (lObjCust.msModifiedBy is null)
            //{
            //    textBoxModifiedBy.Text = String.Empty;
            //}
            //else
            //{
            //    textBoxModifiedBy.Text = lObjCust.msModifiedBy;
            //}

            textBoxStreet.Text = (lObjCust.msCustomerStAddr is null) ? String.Empty : lObjCust.msCustomerStAddr;
            textBoxArea.Text = lObjCust.msCustomerArAddr is null ? String.Empty : lObjCust.msCustomerArAddr;
            textBoxCity.Text = (lObjCust.msCustomerCity is null) ? String.Empty : lObjCust.msCustomerCity;
            textBoxState.Text = (lObjCust.msCustomerState is null) ? String.Empty : lObjCust.msCustomerState;
            textBoxPinCode.Text = (lObjCust.msCustomerPinCode is null) ? String.Empty : lObjCust.msCustomerPinCode;
            textBoxCountry.Text = (lObjCust.msCustomerCountry is null) ? String.Empty : lObjCust.msCustomerCountry;
            textBoxGSTNo.Text = (lObjCust.msCustomerGSTNo is null) ? String.Empty : lObjCust.msCustomerGSTNo;
            textBoxLastVisit.Text = (lObjCust.mdCustomerLastVisit is null) ? String.Empty : Convert.ToString(lObjCust.mdCustomerLastVisit);
            textBoxRemarks.Text = (lObjCust.msCustomerRemarks is null) ? String.Empty : lObjCust.msCustomerRemarks;
            textBoxCreated.Text = (lObjCust.mdCreated is null ) ? String.Empty : Convert.ToString(lObjCust.mdCreated);
            textBoxCreatedBy.Text = (lObjCust.msCreatedBy is null) ? String.Empty : lObjCust.msCreatedBy;
            textBoxModified.Text = (lObjCust.mdModified is null) ? String.Empty : Convert.ToString(lObjCust.mdModified);
            textBoxModifiedBy.Text = (lObjCust.msModifiedBy is null) ? String.Empty : lObjCust.msModifiedBy;
        }

        public void LoadDataToObj(Customer lObjCust)
        {
            lObjCust.msCustomerFName = textBoxFirstName.Text;
            lObjCust.msCustomerLName = textBoxLastName.Text;
            lObjCust.msCustomerMNo = textBoxMNo.Text;
            lObjCust.msCustomerEmail = textBoxEID.Text;
            lObjCust.msCustomerStatus = Convert.ToString(comboBoxStatus.SelectedItem);
            lObjCust.msCustomerType = Convert.ToString(comboBoxType.SelectedItem);
            lObjCust.msCustomerStAddr = textBoxStreet.Text.Equals(String.Empty) ? null : textBoxStreet.Text;
            lObjCust.msCustomerArAddr = textBoxArea.Text.Equals(String.Empty) ? null : textBoxArea.Text;
            lObjCust.msCustomerCity = textBoxCity.Text.Equals(String.Empty) ? null : textBoxCity.Text;
            lObjCust.msCustomerState = textBoxState.Text.Equals(String.Empty) ? null : textBoxState.Text;
            lObjCust.msCustomerPinCode = textBoxPinCode.Text.Equals(String.Empty) ? null : textBoxPinCode.Text;
            lObjCust.msCustomerCountry = textBoxCountry.Text.Equals(String.Empty) ? null : textBoxCountry.Text;
            lObjCust.msCustomerGSTNo = textBoxGSTNo.Text.Equals(string.Empty) ? null : textBoxGSTNo.Text;
            lObjCust.msCustomerRemarks = textBoxRemarks.Text.Equals(String.Empty) ? null : textBoxRemarks.Text;
        }

        public bool ValidateEntry()
        {
            bool lbValid = true;
            mnErrors.Clear();
            if (textBoxFirstName.Text.Length == 0)
            {
                labelFNameError.Visible = true;
                mnErrors.Add(0);
            }
            if(textBoxLastName.Text.Length == 0)
            {
                labelLNameError.Visible = true;
                mnErrors.Add(1);
            }
            if(textBoxMNo.Text.Length == 0)
            {
                labelMNoError.Text = "Mobile No. is blank.";
                labelMNoError.Visible = true;
                mnErrors.Add(2);
            }
            else
            {
               bool lbValidMobNO = Regex.IsMatch(this.textBoxMNo.Text, @"^(\d{10})$", RegexOptions.IgnoreCase);
               if (!lbValidMobNO)
               {
                  textBoxMNo.ForeColor = Color.Red;
                  textBoxMNo.Font = new Font(textBoxMNo.Font, FontStyle.Bold);
                  labelMNoError.Text = "Mobile No. is in incorrect format.";
                  labelMNoError.Visible = true;
                  mnErrors.Add(2);
               }
                
            }
            if(textBoxEID.Text.Length == 0)
            {
                labelEIDError.Text = "Email ID is blank";
                labelEIDError.Visible = true;
                mnErrors.Add(3);
            }
            else
            {
                bool lbValidEmail = Regex.IsMatch(this.textBoxEID.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                 if (!lbValidEmail)
                 {
                    textBoxEID.ForeColor = Color.Red;
                    textBoxEID.Font = new Font(textBoxEID.Font, FontStyle.Bold);
                    labelEIDError.Text = "Email ID is in incorrect format";
                    labelEIDError.Visible = true;
                    mnErrors.Add(3);
                 }
                
            }

            if(comboBoxStatus.SelectedIndex == -1)
            {
                labelStatusError.Visible = true;
                mnErrors.Add(4);
            }

            if(comboBoxType.SelectedIndex == -1)
            {
                labelTypeError.Visible = true;
                mnErrors.Add(5);
            }

            if(textBoxPinCode.Text.Length > 0 && textBoxPinCode.Text.Length != 6)
            {
                labelPinError.Visible = true;
                mnErrors.Add(6);
            }

            if(textBoxGSTNo.Text.Length > 0 && textBoxGSTNo.Text.Length != 15)
            {
                labelGSTError.Visible = true;
                mnErrors.Add(7);
            }

            if(mnErrors.Count > 0)
            {
                lbValid = false;
            }
            return lbValid;
        }

        private void textBoxFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelFNameError.Visible = false;
        }

        private void textBoxLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelLNameError.Visible = false;
        }

        private void textBoxMNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxMNo.ForeColor = Color.Black;
            textBoxMNo.Font = new Font(textBoxMNo.Font, FontStyle.Regular);
            labelMNoError.Visible = false;
        }

        private void textBoxEID_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxEID.ForeColor = Color.Black;
            textBoxEID.Font = new Font(textBoxEID.Font, FontStyle.Regular);
            labelEIDError.Visible = false;
        }

        private void comboBoxStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelStatusError.Visible = false;
        }

        private void comboBoxType_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelTypeError.Visible = false;
        }

        private void textBoxPinCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelPinError.Visible = false;
        }

        private void textBoxGSTNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelGSTError.Visible = false;
        }

        

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAction_Click(object sender, EventArgs e)
        {
            switch (mnMode)
            {
                case MasterMechUtil.OPMode.New:
                    if (!ValidateEntry())
                    {
                        int lnError = mnErrors.Min();
                        switch (lnError)
                        {
                            case 0: textBoxFirstName.Focus();  break;
                            case 1: textBoxLastName.Focus();   break;
                            case 2: textBoxMNo.Focus();  break;
                            case 3: textBoxEID.Focus();  break;
                            case 4: comboBoxStatus.Focus();  break;
                            case 5: comboBoxType.Focus();  break;
                            case 6: textBoxPinCode.Focus();  break;
                            case 7: textBoxGSTNo.Focus();  break;
                        }
                        return;
                    }
                    else
                    {
                        SaveCustomer(mnMode == MasterMechUtil.OPMode.New);
                    }
                    break;
                case MasterMechUtil.OPMode.Open:
                    if(textBoxCustNo.Text.Length > 0)
                    {
                        if (!ValidateEntry())
                        {
                            int lnError = mnErrors.Min();
                            switch (lnError)
                            {
                                case 0: textBoxFirstName.Focus(); break;
                                case 1: textBoxLastName.Focus(); break;
                                case 2: textBoxMNo.Focus(); break;
                                case 3: textBoxEID.Focus(); break;
                                case 4: comboBoxStatus.Focus(); break;
                                case 5: comboBoxType.Focus(); break;
                                case 6: textBoxPinCode.Focus(); break;
                                case 7: textBoxGSTNo.Focus(); break;
                            }
                            return;
                        }
                        else
                        {
                            SaveCustomer(mnMode == MasterMechUtil.OPMode.New);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Select the Customer to update.");
                    }
                    
                    break;
                case MasterMechUtil.OPMode.Delete:
                    DeleteCustomer();
                    break;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SearchCustomers();
        }

        public void SaveCustomer(bool ibMode)
        {
            Customer lObjDummyCust = new Customer();
            if (ibMode)
            {
                LoadDataToObj(lObjDummyCust);
                if(lObjDummyCust.Save(MasterMechUtil.msConString, MasterMechUtil.sUserID, ibMode))
                {
                    MessageBox.Show("New Customer successfully added.");
                    ClearFormData();
                }
                else
                {
                    MessageBox.Show("Error! Unable to add new customer.");
                }
            }
            else
            {
                lObjDummyCust.mnCustomerNo = Convert.ToInt32(textBoxCustNo.Text);
                LoadDataToObj(lObjDummyCust);
                if (lObjDummyCust.Save(MasterMechUtil.msConString, MasterMechUtil.sUserID, ibMode))
                {
                    MessageBox.Show("Customer details updated successfully.");
                    ClearFormData();
                }
                else
                {
                    MessageBox.Show("Error! Unable to update customer details.");
                }
            }
        }

        public void DeleteCustomer()
        {
            if(textBoxCustNo.Text.Length == 0)
            {
                MessageBox.Show("Select the Customer to delete.");
            }
            else
            {
                Customer lObjDummyCust = new Customer();
                lObjDummyCust.mnCustomerNo = Convert.ToInt32(textBoxCustNo.Text);
                if(lObjDummyCust.Delete(MasterMechUtil.msConString, MasterMechUtil.sUserID))
                {
                    MessageBox.Show("Customer successfully deleted.");
                    ClearFormData();
                }
                else
                {
                    MessageBox.Show("Unable to delete customer.");
                }
            }
        }

        public void SearchCustomers()
        {
            Customer lObjDummyCust = new Customer();
            List<Customer> lObjCustomerList = new List<Customer>();
            if (textBoxKeySearch.Text.Length == 0)
            {
                lObjDummyCust.ShowAll(MasterMechUtil.msConString, lObjCustomerList);
                LoadDataToGrid(lObjCustomerList);
            }
            else
            {
                string lsSearchKey = textBoxKeySearch.Text;
                lObjDummyCust.Search(MasterMechUtil.msConString, lsSearchKey, lObjCustomerList);
                LoadDataToGrid(lObjCustomerList);
            }
        }

        public void LoadDataToGrid(List<Customer> lObjCustList)
        {
            CustomerGridForm lObjCustGrid = new CustomerGridForm();
            lObjCustGrid.noSelectMsg = "No Customer selected. Select a customer row and then click select.";

            //Build the header
            lObjCustGrid.dataGridViewCustomer.ReadOnly = true;
            lObjCustGrid.dataGridViewCustomer.AllowUserToAddRows = false;
            lObjCustGrid.dataGridViewCustomer.ColumnCount = 17;
            lObjCustGrid.dataGridViewCustomer.Columns[0].Name = "S. No.";
            lObjCustGrid.dataGridViewCustomer.Columns[1].Name = "CustNo";
            lObjCustGrid.dataGridViewCustomer.Columns[2].Name = "CustFName";
            lObjCustGrid.dataGridViewCustomer.Columns[3].Name = "CustLName";
            lObjCustGrid.dataGridViewCustomer.Columns[4].Name = "CustMobNo";
            lObjCustGrid.dataGridViewCustomer.Columns[5].Name = "CustEmail";
            lObjCustGrid.dataGridViewCustomer.Columns[6].Name = "CustSts";
            lObjCustGrid.dataGridViewCustomer.Columns[7].Name = "CustType";
            lObjCustGrid.dataGridViewCustomer.Columns[8].Name = "CustStAddr";
            lObjCustGrid.dataGridViewCustomer.Columns[9].Name = "CustArAddr";
            lObjCustGrid.dataGridViewCustomer.Columns[10].Name = "CustCity";
            lObjCustGrid.dataGridViewCustomer.Columns[11].Name = "CustState";
            lObjCustGrid.dataGridViewCustomer.Columns[12].Name = "CustPinCode";
            lObjCustGrid.dataGridViewCustomer.Columns[13].Name = "CustCountry";
            lObjCustGrid.dataGridViewCustomer.Columns[14].Name = "CustGSTNo";
            lObjCustGrid.dataGridViewCustomer.Columns[15].Name = "CustlLastVisit";
            lObjCustGrid.dataGridViewCustomer.Columns[16].Name = "CustRemarks";

            int lnCnt = 1;
            Customer lObjDummyCust = new Customer(); 

            if (lObjCustList.Count == 0)
            {
                MessageBox.Show("No Customers Found!");
                this.textBoxKeySearch.Focus();
                return;
            }
            else if(lObjCustList.Count == 1)
            {
                lObjDummyCust.Load(MasterMechUtil.msConString, Convert.ToInt32(lObjCustList[0].mnCustomerNo));
                LoadFormData(lObjDummyCust);
            }
            else if(lObjCustList.Count > 1)
            {
                foreach(Customer Cust in lObjCustList)
                {
                    lObjCustGrid.dataGridViewCustomer.Rows.Add(lnCnt++, Cust.mnCustomerNo, Cust.msCustomerFName, Cust.msCustomerLName, Cust.msCustomerMNo, Cust.msCustomerEmail, Cust.msCustomerStatus, Cust.msCustomerType, Cust.msCustomerStAddr, Cust.msCustomerArAddr, Cust.msCustomerCity, Cust.msCustomerState, Cust.msCustomerPinCode, Cust.msCustomerCountry, Cust.msCustomerGSTNo,Cust.mdCustomerLastVisit, Cust.msCustomerRemarks);
                }
                lObjCustGrid.ShowDialog();
                int lnSelectedRow = lObjCustGrid.mnSelectedRow;
                
                if (lObjCustGrid.mbSelected)
                {
                    int lnCNo = Convert.ToInt32(lObjCustGrid.dataGridViewCustomer.Rows[lnSelectedRow].Cells[1].Value);
                    if (lObjDummyCust.Load(MasterMechUtil.msConString, lnCNo))
                    {
                        LoadFormData(lObjDummyCust);
                    }
                    else
                    {
                        this.textBoxKeySearch.Focus();
                    }
                }
            }
        }

        public void LoadDataToGrid(List<Customer> lObjCustList, Customer lObjDummyCust)
        {
            CustomerGridForm lObjCustGrid = new CustomerGridForm();
            lObjCustGrid.noSelectMsg = "No Customer selected. Select a customer row and then click select.";

            //Build the header
            lObjCustGrid.dataGridViewCustomer.ReadOnly = true;
            lObjCustGrid.dataGridViewCustomer.AllowUserToAddRows = false;
            lObjCustGrid.dataGridViewCustomer.ColumnCount = 17;
            lObjCustGrid.dataGridViewCustomer.Columns[0].Name = "S. No.";
            lObjCustGrid.dataGridViewCustomer.Columns[1].Name = "CustNo";
            lObjCustGrid.dataGridViewCustomer.Columns[2].Name = "CustFName";
            lObjCustGrid.dataGridViewCustomer.Columns[3].Name = "CustLName";
            lObjCustGrid.dataGridViewCustomer.Columns[4].Name = "CustMobNo";
            lObjCustGrid.dataGridViewCustomer.Columns[5].Name = "CustEmail";
            lObjCustGrid.dataGridViewCustomer.Columns[6].Name = "CustSts";
            lObjCustGrid.dataGridViewCustomer.Columns[7].Name = "CustType";
            lObjCustGrid.dataGridViewCustomer.Columns[8].Name = "CustStAddr";
            lObjCustGrid.dataGridViewCustomer.Columns[9].Name = "CustArAddr";
            lObjCustGrid.dataGridViewCustomer.Columns[10].Name = "CustCity";
            lObjCustGrid.dataGridViewCustomer.Columns[11].Name = "CustState";
            lObjCustGrid.dataGridViewCustomer.Columns[12].Name = "CustPinCode";
            lObjCustGrid.dataGridViewCustomer.Columns[13].Name = "CustCountry";
            lObjCustGrid.dataGridViewCustomer.Columns[14].Name = "CustGSTNo";
            lObjCustGrid.dataGridViewCustomer.Columns[15].Name = "CustlLastVisit";
            lObjCustGrid.dataGridViewCustomer.Columns[16].Name = "CustRemarks";

            int lnCnt = 1;

            if (lObjCustList.Count == 0)
            {
                MessageBox.Show("No Customers Found!");
                this.textBoxKeySearch.Focus();
                return;
            }
            else if (lObjCustList.Count == 1)
            {
                lObjDummyCust.Load(MasterMechUtil.msConString, Convert.ToInt32(lObjCustList[0].mnCustomerNo));
                LoadFormData(lObjDummyCust);
            }
            else if (lObjCustList.Count > 1)
            {
                foreach (Customer Cust in lObjCustList)
                {
                    lObjCustGrid.dataGridViewCustomer.Rows.Add(lnCnt++, Cust.mnCustomerNo, Cust.msCustomerFName, Cust.msCustomerLName, Cust.msCustomerMNo, Cust.msCustomerEmail, Cust.msCustomerStatus, Cust.msCustomerType, Cust.msCustomerStAddr, Cust.msCustomerArAddr, Cust.msCustomerCity, Cust.msCustomerState, Cust.msCustomerPinCode, Cust.msCustomerCountry, Cust.msCustomerGSTNo, Cust.mdCustomerLastVisit, Cust.msCustomerRemarks);
                }
                lObjCustGrid.ShowDialog();
                int lnSelectedRow = lObjCustGrid.mnSelectedRow;

                if (lObjCustGrid.mbSelected)
                {
                    int lnCNo = Convert.ToInt32(lObjCustGrid.dataGridViewCustomer.Rows[lnSelectedRow].Cells[1].Value);
                    lObjDummyCust.Load(MasterMechUtil.msConString, lnCNo);
                }
            }
        }

        private void buttonASearchForm_Click(object sender, EventArgs e)
        {
            List<Customer> lObjCustList = new List<Customer>();
            AdvancedSearchForm lObjASearchForm = new AdvancedSearchForm(lObjCustList);
            lObjASearchForm.ShowDialog();
            LoadDataToGrid(lObjCustList);
        }

        

        private void textBoxFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxFirstName.Text.Length == 0)
            {
                labelFNameError.Visible = true;
                mnErrors.Add(0);
            }
        }

        private void textBoxLastName_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxLastName.Text.Length == 0)
            {
                labelLNameError.Visible = true;
                e.Cancel = false;
            }
        }

        private void textBoxMNo_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxMNo.Text.Length == 0)
            {
                labelMNoError.Text = "Mobile No. is blank.";
                labelMNoError.Visible = true;
                e.Cancel = false;
            }
            else
            {
                bool lbValidMobNO = Regex.IsMatch(this.textBoxMNo.Text, @"^(\d{10})$", RegexOptions.IgnoreCase);
                if (!lbValidMobNO)
                {
                    textBoxMNo.ForeColor = Color.Red;
                    textBoxMNo.Font = new Font(textBoxMNo.Font, FontStyle.Bold);
                    labelMNoError.Text = "Mobile No. is in incorrect format.";
                    labelMNoError.Visible = true;
                    e.Cancel = false;
                }

            }
        }

        private void textBoxEID_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxEID.Text.Length == 0)
            {
                labelEIDError.Text = "Email ID is blank";
                labelEIDError.Visible = true;
                e.Cancel = false;
            }
            else
            {
                bool lbValidEmail = Regex.IsMatch(this.textBoxEID.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (!lbValidEmail)
                {
                    textBoxEID.ForeColor = Color.Red;
                    textBoxEID.Font = new Font(textBoxEID.Font, FontStyle.Bold);
                    labelEIDError.Text = "Email ID is in incorrect format";
                    labelEIDError.Visible = true;
                    e.Cancel = false;
                }

            }
        }

        private void comboBoxStatus_Validating(object sender, CancelEventArgs e)
        {
            if (comboBoxStatus.SelectedIndex == -1)
            {
                labelStatusError.Visible = true;
                e.Cancel = false;
            }
        }

        private void comboBoxType_Validating(object sender, CancelEventArgs e)
        {
            if (comboBoxType.SelectedIndex == -1)
            {
                labelTypeError.Visible = true;
                e.Cancel = false;
            }
        }

        private void textBoxPinCode_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxPinCode.Text.Length > 0 && textBoxPinCode.Text.Length != 6)
            {
                labelPinError.Visible = true;
                e.Cancel = false;
            }
        }

        private void textBoxGSTNo_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxGSTNo.Text.Length > 0 && textBoxGSTNo.Text.Length != 15)
            {
                labelGSTError.Visible = true;
                e.Cancel = false;
            }
        }

        private void comboBoxStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            labelStatusError.Visible = false;
        }

        private void comboBoxType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            labelTypeError.Visible = false;
        }
    }
}
