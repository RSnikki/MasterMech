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
    public partial class InvoiceForm : Form
    {
        public MasterMechUtil.OPMode mnMode;
        public Invoice lObjDummyInvoice = new Invoice(MasterMechUtil.msConString, MasterMechUtil.sUserID);
        public bool mbSameState;
        public int mnSelectedRow;
        public bool mbSelected;
        static int lnCnt = 1;
        public List<int> mnErrors = new List<int>();
        public List<int?> ExistingItemToDel = new List<int?>();
        public enum LineItemMode
        {
            Add,
            UpdateOrDelete
        }
        public LineItemMode iMode;

        public InvoiceForm()
        {
            InitializeComponent();
        }

        public InvoiceForm(MasterMechUtil.OPMode iMode)
        {
            mnMode = iMode;
            InitializeComponent();
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            List<string> lObjListType = new List<string>();
            List<string> lObjListStatus = new List<string>();
            List<string> lObjListServiceType = new List<string>();
            Invoice.GetCustType(lObjListType);
            Invoice.GetCustStatus(lObjListStatus);
            Invoice.GetServiceType(lObjListServiceType);

            mnErrors.Clear();
            ExistingItemToDel.Clear();
            lnCnt = 1;

            foreach (string Type in lObjListType)
            {
                comboBoxType.Items.Add(Type);
            }
            foreach(string Status in lObjListStatus)
            {
                comboBoxStatus.Items.Add(Status);
            }
            foreach(string ServiceType in lObjListServiceType)
            {
                comboBoxServiceType.Items.Add(ServiceType);
            }
            switch (mnMode)
            {
                case MasterMechUtil.OPMode.New:
                    
                    labelInvoiceSearchKey.Visible = false;
                    textBoxInvoiceSearchKey.Visible = false;
                    buttonInvoiceSearch.Visible = false;
                    buttonAInvoiceSearch.Visible = false;
                    labelInvoiceNo.Visible = false;
                    textBoxInvoiceNo.Visible = false;
                    labelInvoiceDate.Visible = false;
                    textBoxInvoiceDate.Visible = false;
                    buttonAction.Text = "Save";
                    labelCreated.Visible = false;
                    labelCreatedBy.Visible = false;
                    textBoxCreated.Visible = false;
                    textBoxCreatedBy.Visible = false;
                    labelModified.Visible = false;
                    labelModifiedBy.Visible = false;
                    textBoxModified.Visible = false;
                    textBoxModifiedBy.Visible = false;
                    buttonPrint.Visible = false;
                    break;
                case MasterMechUtil.OPMode.Open:
                    labelInvoiceSearchKey.Visible = true;
                    textBoxInvoiceSearchKey.Visible = true;
                    buttonInvoiceSearch.Visible = true;
                    buttonAInvoiceSearch.Visible = true;
                    labelInvoiceNo.Visible = true;
                    textBoxInvoiceNo.Visible = true;
                    labelInvoiceDate.Visible = true;
                    textBoxInvoiceDate.Visible = true;
                    buttonAction.Text = "Save";

                    textBoxMNoCustSearch.ReadOnly = true;
                    textBoxCustNo.ReadOnly = true;
                    textBoxFirstName.ReadOnly = true;
                    textBoxLastName.ReadOnly = true;
                    textBoxCustMNo.ReadOnly = true;
                    textBoxCustEID.ReadOnly = true;
                    textBoxCustLV.ReadOnly = true;
                    textBoxCustStAdd.ReadOnly = true;
                    textBoxcCustAAdd.ReadOnly = true;
                    textBoxCustCity.ReadOnly = true;
                    textBoxCustState.ReadOnly = true;
                    textBoxCustPin.ReadOnly = true;
                    textBoxCustCountry.ReadOnly = true;
                    comboBoxType.Enabled = false;
                    comboBoxStatus.Enabled = false;
                    textBoxCustGSTNo.ReadOnly = true;
                    textBoxCustRemarks.ReadOnly = true;

                    labelCreated.Visible = true;
                    labelCreatedBy.Visible = true;
                    textBoxCreated.Visible = true;
                    textBoxCreatedBy.Visible = true;
                    labelModified.Visible = true;
                    labelModifiedBy.Visible = true;
                    textBoxModified.Visible = true;
                    textBoxModifiedBy.Visible = true;

                    buttonCustSearch.Enabled = false;
                    buttonCustomerAS.Enabled = false;
                    break;
                case MasterMechUtil.OPMode.Delete:
                    labelInvoiceSearchKey.Visible = true;
                    textBoxInvoiceSearchKey.Visible = true;
                    buttonInvoiceSearch.Visible = true;
                    textBoxInvoiceNo.Visible = true;
                    buttonAInvoiceSearch.Visible = true;
                    labelInvoiceNo.Visible = true;
                    labelInvoiceDate.Visible = true;
                    textBoxInvoiceDate.Visible = true;
                    buttonAction.Text = "Delete";
                    labelCreated.Visible = true;
                    labelCreatedBy.Visible = true;
                    textBoxCreated.Visible = true;
                    textBoxCreatedBy.Visible = true;
                    labelModified.Visible = true;
                    labelModifiedBy.Visible = true;
                    textBoxModified.Visible = true;
                    textBoxModifiedBy.Visible = true;

                    textBoxMNoCustSearch.ReadOnly = true;
                    textBoxCustNo.ReadOnly = true;
                    textBoxFirstName.ReadOnly = true;
                    textBoxLastName.ReadOnly = true;
                    textBoxCustMNo.ReadOnly = true;
                    textBoxCustEID.ReadOnly = true;
                    textBoxCustLV.ReadOnly = true;
                    textBoxCustStAdd.ReadOnly = true;
                    textBoxcCustAAdd.ReadOnly = true;
                    textBoxCustCity.ReadOnly = true;
                    textBoxCustState.ReadOnly = true;
                    textBoxCustPin.ReadOnly = true;
                    textBoxCustCountry.ReadOnly = true;
                    comboBoxType.Enabled = false;
                    comboBoxStatus.Enabled = false;
                    textBoxCustGSTNo.ReadOnly = true;
                    textBoxCustRemarks.ReadOnly = true;
                    textBoxIDesc.ReadOnly = true;
                    textBoxQty.ReadOnly = true;
                    textBoxDiscount.ReadOnly = true;
                    textBoxIRemarks.ReadOnly = true;

                    buttonCustSearch.Enabled = false;
                    buttonCustomerAS.Enabled = false;
                    buttonItemSearch.Enabled = false;
                    buttonIAdd.Enabled = false;
                    buttonIDelete.Enabled = false;
                    buttonICancel.Enabled = false;
                    break;
            }
        }

        public void ClearInvoiceForm()
        {
            textBoxInvoiceSearchKey.Clear();
            textBoxInvoiceNo.Clear();
            textBoxInvoiceDate.Clear();
            textBoxMNoCustSearch.Clear();
            textBoxCustNo.Clear();
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxCustMNo.Clear();
            textBoxCustEID.Clear();
            textBoxCustLV.Clear();
            textBoxCustStAdd.Clear();
            textBoxcCustAAdd.Clear();
            textBoxCustCity.Clear();
            textBoxCustState.Clear();
            textBoxCustPin.Clear();
            textBoxCustCountry.Clear();
            comboBoxType.SelectedIndex = -1;
            comboBoxStatus.SelectedIndex = -1;
            textBoxCustGSTNo.Clear();
            textBoxCustRemarks.Clear();

            textBoxItemNo.Clear();
            textBoxIDesc.Clear();
            textBoxIPrice.Clear();
            textBoxUOM.Clear();
            textBoxQty.Clear();
            textBoxINetAmt.Clear();
            textBoxDiscount.Clear();
            textBoxICGSTP.Clear();
            textBoxICGSTA.Clear();
            textBoxISGSTP.Clear();
            textBoxISGSTA.Clear();
            textBoxIIGSTP.Clear();
            textBoxIIGSTA.Clear();
            textBoxTax.Clear();
            textBoxGAmount.Clear();
            textBoxTotalAmt.Clear();

            dataGridViewLineItems.Rows.Clear();

            textBoxCreated.Clear();
            textBoxCreatedBy.Clear();
            textBoxModified.Clear();
            textBoxModifiedBy.Clear();

            textBoxRegNo.Clear();
            textBoxModel.Clear();
            textBoxChassisNo.Clear();
            textBoxEngineNo.Clear();
            textBoxMileage.Clear();
            comboBoxServiceType.SelectedIndex = -1;
            textBoxSAName.Clear();
            textBoxSAMNo.Clear();

            textBoxPTotal.Clear();
            textBoxPCGST.Clear();
            textBoxPSGST.Clear();
            textBoxpigst.Clear();
            textBoxPTotal.Clear();
            textBoxPCGST.Clear();
            textBoxPSGST.Clear();
            textBoxpigst.Clear();

            textBoxLTotal.Clear();
            textBoxLCGST.Clear();
            textBoxLSGST.Clear();
            textBoxLIGST.Clear();
            textBoxLTotal.Clear();
            textBoxLCGST.Clear();
            textBoxLSGST.Clear();
            textBoxLIGST.Clear();

            textBoxTNAmount.Clear();
            textBoxTCGST.Clear();
            textBoxTSGST.Clear();
            textBoxTIGST.Clear();

            textBoxTDiscount.Clear();
            textBoxTTax.Clear();
            textBoxGTotal.Clear();
            textBoxIRemarks.Clear();

            mnErrors.Clear();
            ExistingItemToDel.Clear();
            lnCnt = 1;
        }

        public void ClearInvoiceObjData()
        {
            lObjDummyInvoice.msInnvoiceNo = null;
            lObjDummyInvoice.mnInvoiceSNo = null;
            lObjDummyInvoice.mdInvoiceDate = DateTime.MinValue;
            lObjDummyInvoice.msInvoiceStatus = null;

            lObjDummyInvoice.InvoiceCustomer.mnCustomerNo = null;
            lObjDummyInvoice.InvoiceCustomer.msCustomerFName = null;
            lObjDummyInvoice.InvoiceCustomer.msCustomerLName = null;
            lObjDummyInvoice.InvoiceCustomer.msCustomerMNo = null;
            lObjDummyInvoice.InvoiceCustomer.msCustomerEmail = null;
            lObjDummyInvoice.InvoiceCustomer.msCustomerStatus = null;
            lObjDummyInvoice.InvoiceCustomer.msCustomerType = null;
            lObjDummyInvoice.InvoiceCustomer.msCustomerStAddr = null;
            lObjDummyInvoice.InvoiceCustomer.msCustomerArAddr = null;
            lObjDummyInvoice.InvoiceCustomer.msCustomerCity = null;
            lObjDummyInvoice.InvoiceCustomer.msCustomerState = null;
            lObjDummyInvoice.InvoiceCustomer.msCustomerPinCode = null;
            lObjDummyInvoice.InvoiceCustomer.msCustomerCountry = null;
            lObjDummyInvoice.InvoiceCustomer.msCustomerGSTNo = null;
            lObjDummyInvoice.InvoiceCustomer.mdCustomerLastVisit = null;
            lObjDummyInvoice.InvoiceCustomer.msCustomerRemarks = null;
            lObjDummyInvoice.InvoiceCustomer.mdCreated = null;
            lObjDummyInvoice.InvoiceCustomer.msCreatedBy = null;
            lObjDummyInvoice.InvoiceCustomer.mdModified = null;
            lObjDummyInvoice.InvoiceCustomer.msModifiedBy = null;
            lObjDummyInvoice.InvoiceCustomer.msDeleted = null;
            lObjDummyInvoice.InvoiceCustomer.mdDeletedOn = null;
            lObjDummyInvoice.InvoiceCustomer.msDeletedBy = null;

            lObjDummyInvoice.InvoiceItems.Clear();

            lObjDummyInvoice.msVehicleRegNo = null;
            lObjDummyInvoice.msVehicleModel = null;
            lObjDummyInvoice.msChassisNo = null;
            lObjDummyInvoice.msEngineNo = null;
            lObjDummyInvoice.mnMileage = null;
            lObjDummyInvoice.msServiceType = null;
            lObjDummyInvoice.msServiceAssoName = null;
            lObjDummyInvoice.msServiceAssoMobNo = null;
            lObjDummyInvoice.mnPartsTotal = null;
            lObjDummyInvoice.mnLabourTotal = null;
            lObjDummyInvoice.mnPartsCGSTTotal = null;
            lObjDummyInvoice.mnLabourCGSTTotal = null;
            lObjDummyInvoice.mnPartsSGSTTotal = null;
            lObjDummyInvoice.mnLabourSGSTTotal = null;
            lObjDummyInvoice.mnPartsIGSTTotal = null;
            lObjDummyInvoice.mnLabourIGSTTotal  = null;
            lObjDummyInvoice.mnTotalCGST  = null;
            lObjDummyInvoice.mnTotalSGST  = null;
            lObjDummyInvoice.mnTotalIGST  = null;
            lObjDummyInvoice.mnTotalTax = null;
            lObjDummyInvoice.mnTotalAmount = null;
            lObjDummyInvoice.mnGrandTotal = null;
            lObjDummyInvoice.mnDiscountAmount = null;
            lObjDummyInvoice.mnInvoiceTotal = null;
            lObjDummyInvoice.msInvoiceRemarks = null;
            lObjDummyInvoice.mdCreated = null;
            lObjDummyInvoice.msCreatedBy = null;
            lObjDummyInvoice.mdModified = null;
            lObjDummyInvoice.msModifiedBy = null;
            lObjDummyInvoice.msDeleted = null;
            lObjDummyInvoice.mdDeletedOn = null;
            lObjDummyInvoice.msDeletedBy = null;
        }

        public bool ValidateCustomer()
        {
            bool lbValid = true;
            mnErrors.Clear();
            if (textBoxFirstName.Text.Length == 0)
            {
                labelFNameError.Visible = true;
                mnErrors.Add(0);
            }
            if (textBoxLastName.Text.Length == 0)
            {
                labelLNameError.Visible = true;
                mnErrors.Add(1);
            }
            if (textBoxCustMNo.Text.Length == 0)
            {
                labelMNoError.Text = "Mobile No. is blank.";
                labelMNoError.Visible = true;
                mnErrors.Add(2);
            }
            else
            {
                bool lbValidMobNO = Regex.IsMatch(this.textBoxCustMNo.Text, @"^(\d{10})$", RegexOptions.IgnoreCase);
                if (!lbValidMobNO)
                {
                    textBoxCustMNo.ForeColor = Color.Red;
                    textBoxCustMNo.Font = new Font(textBoxCustMNo.Font, FontStyle.Bold);
                    labelMNoError.Text = "Mobile No. is in incorrect format.";
                    labelMNoError.Visible = true;
                    mnErrors.Add(2);
                }

            }
            if (textBoxCustEID.Text.Length == 0)
            {
                labelEIDError.Text = "Email ID is blank.";
                labelEIDError.Visible = true;
                mnErrors.Add(3);
            }
            else
            {
                bool lbValidEmail = Regex.IsMatch(this.textBoxCustEID.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (!lbValidEmail)
                {
                    textBoxCustEID.ForeColor = Color.Red;
                    textBoxCustEID.Font = new Font(textBoxCustEID.Font, FontStyle.Bold);
                    labelEIDError.Text = "Email ID is in incorrect format.";
                    labelEIDError.Visible = true;
                    mnErrors.Add(3);
                }

            }

            if (comboBoxStatus.SelectedIndex == -1)
            {
                labelStatusError.Visible = true;
                mnErrors.Add(4);
            }

            if (comboBoxType.SelectedIndex == -1)
            {
                labelTypeError.Visible = true;
                mnErrors.Add(5);
            }

            if (textBoxCustPin.Text.Length > 0 && textBoxCustPin.Text.Length != 6)
            {
                labelPinCodeError.Visible = true;
                mnErrors.Add(6);
            }

            if (textBoxCustGSTNo.Text.Length > 0 && textBoxCustGSTNo.Text.Length != 15)
            {
                labelGSTError.Visible = true;
                mnErrors.Add(7);
            }

            if (mnErrors.Count > 0)
            {
                lbValid = false;
            }
            return lbValid;
        }

        public void LoadCustomerToForm(Customer lObjDummyCust)
        {
            textBoxCustNo.Text = Convert.ToString(lObjDummyCust.mnCustomerNo);
            textBoxFirstName.Text = lObjDummyCust.msCustomerFName;
            textBoxLastName.Text = lObjDummyCust.msCustomerLName;
            textBoxCustMNo.Text = lObjDummyCust.msCustomerMNo;
            textBoxCustEID.Text = lObjDummyCust.msCustomerEmail;
            textBoxCustLV.Text = (lObjDummyCust.mdCustomerLastVisit is null) ? null : Convert.ToString(lObjDummyCust.mdCustomerLastVisit);
            textBoxCustStAdd.Text = (lObjDummyCust.msCustomerStAddr is null) ? null : lObjDummyCust.msCustomerStAddr;
            textBoxcCustAAdd.Text = (lObjDummyCust.msCustomerArAddr is null) ? null : lObjDummyCust.msCustomerArAddr;
            textBoxCustCity.Text = (lObjDummyCust.msCustomerCity is null) ? null : lObjDummyCust.msCustomerCity;
            textBoxCustState.Text = (lObjDummyCust.msCustomerState is null) ? null : lObjDummyCust.msCustomerState;
            textBoxCustPin.Text = (lObjDummyCust.msCustomerPinCode is null) ? null : lObjDummyCust.msCustomerPinCode;
            textBoxCustCountry.Text = (lObjDummyCust.msCustomerCountry is null) ? null : lObjDummyCust.msCustomerCountry;
            comboBoxType.SelectedItem = lObjDummyCust.msCustomerType;
            comboBoxStatus.SelectedItem = lObjDummyCust.msCustomerStatus;
            textBoxCustGSTNo.Text = (lObjDummyCust.msCustomerGSTNo is null) ? null : lObjDummyCust.msCustomerGSTNo;
            textBoxCustRemarks.Text = (lObjDummyCust.msCustomerRemarks is null) ? null : lObjDummyCust.msCustomerRemarks;
        }

        public void LoadItemToForm(Item lObjDummyItem)
        {
            textBoxItemNo.Text = Convert.ToString(lObjDummyItem.mnItemNo);
            textBoxIDesc.Text = lObjDummyItem.msItemDesc;
            textBoxIPrice.Text = Convert.ToString(lObjDummyItem.mnItemPrice);
            textBoxUOM.Text = lObjDummyItem.msUOM;
            textBoxICGSTP.Text = (lObjDummyItem.mnCGST is null) ? String.Empty : Convert.ToString(lObjDummyItem.mnCGST);
            textBoxISGSTP.Text = (lObjDummyItem.mnSGST is null) ? String.Empty : Convert.ToString(lObjDummyItem.mnSGST);
            textBoxIIGSTP.Text = (lObjDummyItem.mnIGST is null) ? String.Empty : Convert.ToString(lObjDummyItem.mnIGST);
            textBoxItemType.Text = lObjDummyItem.msItemType;
            textBoxItemCatg.Text = lObjDummyItem.msItemCategory;
            textBoxItemSts.Text = lObjDummyItem.msStatus;
            textBoxUPC.Text = (lObjDummyItem.msUPC is null) ? String.Empty : lObjDummyItem.msUPC;
            textBoxHSN.Text = (lObjDummyItem.msHSN is null) ? String.Empty : lObjDummyItem.msHSN;
            textBoxSAC.Text = (lObjDummyItem.msSAC is null) ? String.Empty : lObjDummyItem.msSAC;

        }

        private void textBoxQty_Validating(object sender, CancelEventArgs e)
        {
            if(textBoxQty.Text == string.Empty)
            {
                labelQtyError.Visible = true;
                e.Cancel = true;
            }
        }

        private void textBoxQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelQtyError.Visible = false;
        }

        private void textBoxDiscount_Validating(object sender, CancelEventArgs e)
        {
            if(textBoxDiscount.Text == string.Empty)
            {
                labelDiscError.Visible = true;
                e.Cancel = true;
            }
        }

        private void textBoxDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelDiscError.Visible = false;
        }

        private void textBoxQty_Validated(object sender, EventArgs e)
        {
            double lnTotalTax = 0;
            double lnItemDiscount = 0;
            double lnTotalPrice = 0;
            double lnDiscountedPrice = 0;

            if(textBoxDiscount.Text.Length == 0)
            {
                lnItemDiscount = 0;
            }
            else
            {
                lnItemDiscount = Convert.ToDouble(textBoxDiscount.Text);
            }

            lnTotalPrice = Convert.ToDouble(textBoxIPrice.Text) * Convert.ToDouble(textBoxQty.Text);
            lnDiscountedPrice = lnTotalPrice - lnItemDiscount;

            if (textBoxCustState.Text == MasterMechUtil.BusinessState)
            {
                mbSameState = true;
            }
            else
            {
                mbSameState = false;
            }

            if (textBoxICGSTP.Text.Length > 0 && mbSameState)
            {
                textBoxICGSTA.Text = Convert.ToString(lnDiscountedPrice * Convert.ToDouble(textBoxICGSTP.Text) / 100);
                
                lnTotalTax = Convert.ToDouble(textBoxICGSTA.Text);
            }
            if (textBoxISGSTP.Text.Length > 0 && mbSameState)
            {
                textBoxISGSTA.Text = Convert.ToString(lnDiscountedPrice * Convert.ToDouble(textBoxISGSTP.Text) / 100);
                lnTotalTax += Convert.ToDouble(textBoxISGSTA.Text);
            }
            if (textBoxIIGSTP.Text.Length > 0 && !mbSameState)
            {
                textBoxIIGSTA.Text = Convert.ToString(lnDiscountedPrice * Convert.ToDouble(textBoxIIGSTP.Text) / 100);
                lnTotalTax = Convert.ToDouble(textBoxIIGSTA.Text);
            }

            textBoxINetAmt.Text = Convert.ToString(lnDiscountedPrice);
            textBoxGAmount.Text = Convert.ToString(lnTotalPrice);
            textBoxTax.Text = Convert.ToString(lnTotalTax);

            textBoxTotalAmt.Text = Convert.ToString(lnDiscountedPrice + lnTotalTax);
        }

        private void textBoxDiscount_Validated(object sender, EventArgs e)
        {
            double lnTotalTax = 0;
            double lnItemDiscount = 0;
            double lnTotalPrice = 0;
            double lnDiscountedPrice = 0;

            lnTotalPrice = Convert.ToDouble(textBoxIPrice.Text) * Convert.ToDouble(textBoxQty.Text);
            lnItemDiscount = Convert.ToDouble(textBoxDiscount.Text);
            lnDiscountedPrice = lnTotalPrice - lnItemDiscount;

            if (textBoxCustState.Text == MasterMechUtil.BusinessState)
            {
                mbSameState = true;
            }
            else
            {
                mbSameState = false;
            }

            if (textBoxICGSTP.Text.Length > 0 && mbSameState)
            {
                textBoxICGSTA.Text = Convert.ToString(lnDiscountedPrice * Convert.ToDouble(textBoxICGSTP.Text) / 100);
                lnTotalTax = Convert.ToDouble(textBoxICGSTA.Text);
            }
            if (textBoxISGSTP.Text.Length > 0 && mbSameState)
            {
                textBoxISGSTA.Text = Convert.ToString(lnDiscountedPrice * Convert.ToDouble(textBoxISGSTP.Text) / 100);
                lnTotalTax += Convert.ToDouble(textBoxISGSTA.Text);
            }
            if (textBoxIIGSTP.Text.Length > 0 && !mbSameState)
            {
                textBoxIIGSTA.Text = Convert.ToString(lnDiscountedPrice * Convert.ToDouble(textBoxIIGSTP.Text) / 100);
                lnTotalTax = Convert.ToDouble(textBoxIIGSTA.Text);
            }

            textBoxINetAmt.Text = Convert.ToString(lnDiscountedPrice);
            textBoxGAmount.Text = Convert.ToString(lnTotalPrice);
            textBoxTax.Text = Convert.ToString(lnTotalTax);

            textBoxTotalAmt.Text = Convert.ToString(lnDiscountedPrice + lnTotalTax);
        }

        private void buttonCustSearch_Click(object sender, EventArgs e)
        {
            Customer lObjDummyCust = new Customer();
            List<Customer> lObjCustomerList = new List<Customer>();
            if (textBoxMNoCustSearch.Text.Length == 0)
            {
                lObjDummyCust.ShowAll(MasterMechUtil.msConString, lObjCustomerList);
                CustomerForm lObjCustForm = new CustomerForm();
                lObjCustForm.LoadDataToGrid(lObjCustomerList, lObjDummyCust);
                LoadCustomerToForm(lObjDummyCust);
            }
            else
            {
                string lsSearchKey = textBoxMNoCustSearch.Text;
                lObjDummyCust.Search(MasterMechUtil.msConString, lsSearchKey, lObjCustomerList);
                CustomerForm lObjCustForm = new CustomerForm();
                lObjCustForm.LoadDataToGrid(lObjCustomerList, lObjDummyCust);
                LoadCustomerToForm(lObjDummyCust);
            }
        }

        private void buttonCustomerAS_Click(object sender, EventArgs e)
        {
            Customer lObjDummyCust = new Customer();
            List<Customer> lObjCustomerList = new List<Customer>();
            AdvancedSearchForm lObjCustAdvancSearchForm = new AdvancedSearchForm(lObjCustomerList);
            lObjCustAdvancSearchForm.ShowDialog();
            CustomerForm lObjCustForm = new CustomerForm();
            lObjCustForm.LoadDataToGrid(lObjCustomerList, lObjDummyCust);
            LoadCustomerToForm(lObjDummyCust);
        }

        public void LoadDataToInvoiceCustObj()
        { 
            if (textBoxCustNo.Text == String.Empty)
            {
                lObjDummyInvoice.InvoiceCustomer.mnCustomerNo = null;
            }
            else
            {
                lObjDummyInvoice.InvoiceCustomer.mnCustomerNo = Convert.ToInt32(textBoxCustNo.Text);
            }
            lObjDummyInvoice.InvoiceCustomer.msCustomerFName = textBoxFirstName.Text;
            lObjDummyInvoice.InvoiceCustomer.msCustomerLName = textBoxLastName.Text;
            lObjDummyInvoice.InvoiceCustomer.msCustomerMNo = textBoxCustMNo.Text;
            lObjDummyInvoice.InvoiceCustomer.msCustomerEmail = textBoxCustEID.Text;
            lObjDummyInvoice.InvoiceCustomer.msCustomerType = Convert.ToString(comboBoxType.SelectedItem);
            lObjDummyInvoice.InvoiceCustomer.msCustomerStatus = Convert.ToString(comboBoxStatus.SelectedItem);
            lObjDummyInvoice.InvoiceCustomer.msCustomerStAddr = (textBoxCustStAdd.Text == String.Empty) ? null : textBoxCustStAdd.Text;
            lObjDummyInvoice.InvoiceCustomer.msCustomerArAddr = (textBoxcCustAAdd.Text == String.Empty) ? null : textBoxcCustAAdd.Text;
            lObjDummyInvoice.InvoiceCustomer.msCustomerCity = (textBoxCustCity.Text == String.Empty) ? null : textBoxCustCity.Text;
            lObjDummyInvoice.InvoiceCustomer.msCustomerState = (textBoxCustState.Text == String.Empty) ? null : textBoxCustState.Text;
            lObjDummyInvoice.InvoiceCustomer.msCustomerPinCode = (textBoxCustPin.Text == String.Empty) ? null : textBoxCustPin.Text;
            lObjDummyInvoice.InvoiceCustomer.msCustomerCountry = (textBoxCustCountry.Text == String.Empty) ? null : textBoxCustCountry.Text;
            lObjDummyInvoice.InvoiceCustomer.msCustomerGSTNo = (textBoxCustGSTNo.Text == String.Empty) ? null : textBoxCustGSTNo.Text;
            lObjDummyInvoice.InvoiceCustomer.msCustomerRemarks = (textBoxCustRemarks.Text == String.Empty) ? null : textBoxCustRemarks.Text;

        }


        private void buttonItemSearch_Click(object sender, EventArgs e)
        {
            Item lObjDummyItem = new Item();
            List<Item> lObjItemList = new List<Item>();
            if(textBoxIDesc.Text.Length == 0)
            {
                lObjDummyItem.ShowAll(MasterMechUtil.msConString, lObjItemList);
                ItemForm lObjItemForm = new ItemForm();
                lObjItemForm.LoadDataToGrid(lObjItemList, lObjDummyItem);
                LoadItemToForm(lObjDummyItem);
            }
            else
            {
                string lsSearchKey = textBoxIDesc.Text;
                lObjDummyItem.SearchItems(MasterMechUtil.msConString, lsSearchKey, lObjItemList);
                ItemForm lObjItemForm = new ItemForm();
                lObjItemForm.LoadDataToGrid(lObjItemList, lObjDummyItem);
                LoadItemToForm(lObjDummyItem);
            }
        }

        public void LoadDataToLineItemObj(InvoiceItem lObjDummyLineItem)
        {
            lObjDummyLineItem.mnItemNo = Convert.ToInt32(textBoxItemNo.Text);
            lObjDummyLineItem.msItemDesc = textBoxIDesc.Text;
            lObjDummyLineItem.msItemType = textBoxItemType.Text;
            lObjDummyLineItem.msItemCatg = textBoxItemCatg.Text;
            lObjDummyLineItem.mnItemPrice = Convert.ToDouble(textBoxIPrice.Text);
            lObjDummyLineItem.msItemUOM = textBoxUOM.Text;
            lObjDummyLineItem.msItemSts = textBoxItemSts.Text;
            lObjDummyLineItem.mnQty = Convert.ToInt32(textBoxQty.Text);
            if (textBoxICGSTP.Text.Equals(String.Empty))
            {
                lObjDummyLineItem.mnCGSTRate = null;
            }
            else
            {
                lObjDummyLineItem.mnCGSTRate = Convert.ToDouble(textBoxICGSTP.Text);
            }

            if (textBoxISGSTP.Text.Equals(String.Empty))
            {
                lObjDummyLineItem.mnSGSTRate = null;
            }
            else
            {
                lObjDummyLineItem.mnSGSTRate = Convert.ToDouble(textBoxISGSTP.Text);
            }

            if (textBoxIIGSTP.Text.Equals(String.Empty))
            {
                lObjDummyLineItem.mnIGSTRate = null;
            }
            else
            {
                lObjDummyLineItem.mnIGSTRate = Convert.ToDouble(textBoxIIGSTP.Text);
            }

            if (textBoxUPC.Text.Equals(String.Empty))
            {
                lObjDummyLineItem.msUPCCode = null;
            }
            else
            {
                lObjDummyLineItem.msUPCCode = textBoxUPC.Text;
            }

            if (textBoxHSN.Text.Equals(String.Empty))
            {
                lObjDummyLineItem.msHSNCode = null;
            }
            else
            {
                lObjDummyLineItem.msHSNCode = textBoxHSN.Text;
            }

            if (textBoxSAC.Text.Equals(String.Empty))
            {
                lObjDummyLineItem.msSACCode = null;
            }
            else
            {
                lObjDummyLineItem.msSACCode = textBoxSAC.Text;
            }

            if (textBoxICGSTA.Text.Equals(String.Empty))
            {
                lObjDummyLineItem.mnCGSTAmount = null;
            }
            else
            {
                lObjDummyLineItem.mnCGSTAmount = Convert.ToDouble(textBoxICGSTA.Text);
            }

            if (textBoxISGSTA.Text.Equals(String.Empty))
            {
                lObjDummyLineItem.mnSGSTAmount = null;
            }
            else
            {
                lObjDummyLineItem.mnSGSTAmount = Convert.ToDouble(textBoxISGSTA.Text);
            }

            if (textBoxIIGSTA.Text.Equals(String.Empty))
            {
                lObjDummyLineItem.mnIGSTAmount = null;
            }
            else
            {
                lObjDummyLineItem.mnIGSTAmount = Convert.ToDouble(textBoxIIGSTA.Text);
            }

            if (textBoxDiscount.Text.Equals(String.Empty))
            {
                lObjDummyLineItem.mnDiscountAmount = null;
            }
            else
            {
                lObjDummyLineItem.mnDiscountAmount = Convert.ToDouble(textBoxDiscount.Text);
            }

            if (textBoxTotalAmt.Text.Equals(String.Empty))
            {
                lObjDummyLineItem.mnTotalAmount = null;
            }
            else
            {
                lObjDummyLineItem.mnTotalAmount = Convert.ToDouble(textBoxTotalAmt.Text);
            }
        }

        public void LoadItemToLineItemsGrid(InvoiceItem lObjLineItem)
        {
            dataGridViewLineItems.ReadOnly = true;
            dataGridViewLineItems.AllowUserToAddRows = false;
            dataGridViewLineItems.ColumnCount = 18;
            dataGridViewLineItems.Columns[0].Name = "S. No.";
            dataGridViewLineItems.Columns[1].Name = "Item No.";
            dataGridViewLineItems.Columns[2].Name = "Description";
            dataGridViewLineItems.Columns[3].Name = "Item Type";
            dataGridViewLineItems.Columns[4].Name = "Price";
            dataGridViewLineItems.Columns[5].Name = "UOM";
            dataGridViewLineItems.Columns[6].Name = "Qty";
            dataGridViewLineItems.Columns[7].Name = "Discount";
            dataGridViewLineItems.Columns[8].Name = "CGST%";
            dataGridViewLineItems.Columns[9].Name = "CGST Amount";
            dataGridViewLineItems.Columns[10].Name = "SGST%";
            dataGridViewLineItems.Columns[11].Name = "SGST Amount";
            dataGridViewLineItems.Columns[12].Name = "IGST%";
            dataGridViewLineItems.Columns[13].Name = "IGST Amount";
            dataGridViewLineItems.Columns[14].Name = "Tax";
            dataGridViewLineItems.Columns[15].Name = "Gross Amount";
            dataGridViewLineItems.Columns[16].Name = "Net Amount";
            dataGridViewLineItems.Columns[17].Name = "Total Amount";

            double lnTax = Convert.ToDouble(lObjLineItem.mnCGSTAmount) + Convert.ToDouble(lObjLineItem.mnSGSTAmount) + Convert.ToDouble(lObjLineItem.mnIGSTAmount);
            double lnGrossAmount = Convert.ToDouble(lObjLineItem.mnQty) * Convert.ToDouble(lObjLineItem.mnItemPrice);
            double lnNetAmount = Convert.ToDouble(lObjLineItem.mnQty) * Convert.ToDouble(lObjLineItem.mnItemPrice) - Convert.ToDouble(lObjLineItem.mnDiscountAmount);
            //                               0                1                       2                         3                        4                         5                       6                   7                              8                        9                          10                       11                         12                       13               14         15            16           17
            dataGridViewLineItems.Rows.Add(lnCnt++, lObjLineItem.mnItemNo, lObjLineItem.msItemDesc, lObjLineItem.msItemType, lObjLineItem.mnItemPrice, lObjLineItem.msItemUOM, lObjLineItem.mnQty, lObjLineItem.mnDiscountAmount, lObjLineItem.mnCGSTRate, lObjLineItem.mnCGSTAmount, lObjLineItem.mnSGSTRate, lObjLineItem.mnSGSTAmount, lObjLineItem.mnIGSTRate, lObjLineItem.mnIGSTAmount, lnTax, lnGrossAmount, lnNetAmount, lObjLineItem.mnTotalAmount);
        }

        public void UpdateDataGridItem(int inSelectedRow)
        {
            dataGridViewLineItems.Rows[inSelectedRow].Cells[6].Value = lObjDummyInvoice.InvoiceItems[inSelectedRow].mnQty;
            dataGridViewLineItems.Rows[inSelectedRow].Cells[7].Value = lObjDummyInvoice.InvoiceItems[inSelectedRow].mnDiscountAmount;
            dataGridViewLineItems.Rows[inSelectedRow].Cells[9].Value = lObjDummyInvoice.InvoiceItems[inSelectedRow].mnCGSTAmount;
            dataGridViewLineItems.Rows[inSelectedRow].Cells[11].Value = lObjDummyInvoice.InvoiceItems[inSelectedRow].mnSGSTAmount;
            dataGridViewLineItems.Rows[inSelectedRow].Cells[13].Value = lObjDummyInvoice.InvoiceItems[inSelectedRow].mnIGSTAmount;
            dataGridViewLineItems.Rows[inSelectedRow].Cells[14].Value = Convert.ToDouble(lObjDummyInvoice.InvoiceItems[inSelectedRow].mnCGSTAmount) + Convert.ToDouble(lObjDummyInvoice.InvoiceItems[inSelectedRow].mnSGSTAmount) + Convert.ToDouble(lObjDummyInvoice.InvoiceItems[inSelectedRow].mnIGSTAmount);
            dataGridViewLineItems.Rows[inSelectedRow].Cells[15].Value = Convert.ToDouble(lObjDummyInvoice.InvoiceItems[inSelectedRow].mnQty) * Convert.ToDouble(lObjDummyInvoice.InvoiceItems[inSelectedRow].mnItemPrice);
            dataGridViewLineItems.Rows[inSelectedRow].Cells[16].Value = Convert.ToDouble(lObjDummyInvoice.InvoiceItems[inSelectedRow].mnQty) * Convert.ToDouble(lObjDummyInvoice.InvoiceItems[inSelectedRow].mnItemPrice) - Convert.ToDouble(lObjDummyInvoice.InvoiceItems[inSelectedRow].mnDiscountAmount);
            dataGridViewLineItems.Rows[inSelectedRow].Cells[17].Value = Convert.ToDouble(dataGridViewLineItems.Rows[inSelectedRow].Cells[14].Value) + Convert.ToDouble(dataGridViewLineItems.Rows[inSelectedRow].Cells[16].Value);
        }

        private void ClearItemFormPart()
        {
            textBoxItemNo.Clear();
            textBoxIDesc.Clear();
            textBoxIPrice.Clear();
            textBoxUOM.Clear();

            textBoxItemType.Clear();
            textBoxItemCatg.Clear();
            textBoxItemSts.Clear();
            textBoxUPC.Clear();
            textBoxHSN.Clear();
            textBoxSAC.Clear();
            textBoxQty.Clear();
            textBoxDiscount.Clear();

            textBoxICGSTP.Clear();
            textBoxISGSTP.Clear();
            textBoxIIGSTP.Clear();
            textBoxICGSTA.Clear();
            textBoxISGSTA.Clear();
            textBoxIIGSTA.Clear();
            textBoxTax.Clear();
            textBoxGAmount.Clear();
            textBoxINetAmt.Clear();
            textBoxTotalAmt.Clear();
        }

        public void LoadLineItemToForm(InvoiceItem LineItem)
        {
            textBoxItemNo.Text = Convert.ToString(LineItem.mnItemNo);
            textBoxIDesc.Text = LineItem.msItemDesc;
            textBoxItemType.Text = LineItem.msItemType;
            textBoxItemCatg.Text = LineItem.msItemCatg;
            textBoxIPrice.Text = Convert.ToString(LineItem.mnItemPrice);
            textBoxUOM.Text = LineItem.msItemUOM;
            textBoxQty.Text = Convert.ToString(LineItem.mnQty);
            textBoxItemSts.Text = LineItem.msItemSts;
            textBoxICGSTP.Text = (LineItem.mnCGSTRate is null) ? String.Empty : Convert.ToString(LineItem.mnCGSTRate);
            textBoxISGSTP.Text = (LineItem.mnSGSTRate is null) ? String.Empty : Convert.ToString(LineItem.mnSGSTRate);
            textBoxIIGSTP.Text = (LineItem.mnIGSTRate is null) ? String.Empty : Convert.ToString(LineItem.mnIGSTRate);
            textBoxUPC.Text = (LineItem.msUPCCode is null) ? String.Empty : LineItem.msUPCCode;
            textBoxHSN.Text = (LineItem.msHSNCode is null) ? String.Empty : LineItem.msHSNCode;
            textBoxSAC.Text = (LineItem.msSACCode is null) ? String.Empty : LineItem.msSACCode;
            textBoxQty.Text = (LineItem.mnQty is null) ? String.Empty : Convert.ToString(LineItem.mnQty);
            textBoxICGSTA.Text = (LineItem.mnCGSTAmount is null) ? String.Empty : Convert.ToString(LineItem.mnCGSTAmount);
            textBoxISGSTA.Text = (LineItem.mnSGSTAmount is null) ? String.Empty : Convert.ToString(LineItem.mnSGSTAmount);
            textBoxIIGSTA.Text = (LineItem.mnIGSTAmount is null) ? String.Empty : Convert.ToString(LineItem.mnIGSTAmount);
            textBoxDiscount.Text = (LineItem.mnDiscountAmount is null) ? String.Empty : Convert.ToString(LineItem.mnDiscountAmount);
            textBoxTotalAmt.Text = (LineItem.mnTotalAmount is null) ? String.Empty : Convert.ToString(LineItem.mnTotalAmount);
        }

        private void dataGridViewLineItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.dataGridViewLineItems.Rows[e.RowIndex].Selected = true;
                mnSelectedRow = this.dataGridViewLineItems.SelectedRows[0].Index;
                mbSelected = true;

                foreach (InvoiceItem LineItem in lObjDummyInvoice.InvoiceItems)
                {
                    if (LineItem.mnItemNo == Convert.ToInt32(dataGridViewLineItems.Rows[mnSelectedRow].Cells[1].Value))
                    {
                        LoadLineItemToForm(LineItem);
                        textBoxTax.Text = (dataGridViewLineItems.Rows[mnSelectedRow].Cells[13].Value is null) ? String.Empty : Convert.ToString(dataGridViewLineItems.Rows[mnSelectedRow].Cells[13].Value);
                        textBoxGAmount.Text = (dataGridViewLineItems.Rows[mnSelectedRow].Cells[14].Value is null) ? String.Empty : Convert.ToString(dataGridViewLineItems.Rows[mnSelectedRow].Cells[14].Value);
                        textBoxINetAmt.Text = (dataGridViewLineItems.Rows[mnSelectedRow].Cells[15].Value is null) ? String.Empty : Convert.ToString(dataGridViewLineItems.Rows[mnSelectedRow].Cells[15].Value);
                        textBoxTotalAmt.Text = (dataGridViewLineItems.Rows[mnSelectedRow].Cells[16].Value is null) ? String.Empty : Convert.ToString(dataGridViewLineItems.Rows[mnSelectedRow].Cells[16].Value);
                    }
                }
                buttonIAdd.Text = "Update";
                buttonIDelete.Enabled = true;
                iMode = LineItemMode.UpdateOrDelete;
                buttonICancel.Enabled = true;
            }

        }

        public void UpdateLineItemsSNo(int inSelectedRow)
        {
            for(int i = inSelectedRow; i < dataGridViewLineItems.Rows.Count; i++)
            {
                dataGridViewLineItems.Rows[i].Cells[0].Value = i+1;
            }
            lnCnt = lnCnt - 1;
        }

        private void buttonIAdd_Click(object sender, EventArgs e)
        {
            if(textBoxItemNo.Text == String.Empty)
            {
                MessageBox.Show("Item not selected. Select Item!");
            }
            else
            {
                if (iMode == LineItemMode.Add)
                {
                    InvoiceItem lObjDummyLineItem = new InvoiceItem();
                    LoadDataToLineItemObj(lObjDummyLineItem);
                    lObjDummyInvoice.InvoiceItems.Add(lObjDummyLineItem);
                    LoadItemToLineItemsGrid(lObjDummyLineItem);
                    ClearItemFormPart();
                    LoadBillDetailsToForm();
                }
                else if (iMode == LineItemMode.UpdateOrDelete)
                {
                    LoadDataToLineItemObj(lObjDummyInvoice.InvoiceItems[mnSelectedRow]);
                    UpdateDataGridItem(mnSelectedRow);
                    ClearItemFormPart();
                    LoadBillDetailsToForm();
                    iMode = LineItemMode.Add;
                    buttonIAdd.Text = "Add";
                    buttonIDelete.Enabled = false;
                    buttonICancel.Enabled = false;
                }
            } 
        }

        private void buttonIDelete_Click(object sender, EventArgs e)       
        {
            if (mbSelected == true && iMode == LineItemMode.UpdateOrDelete)
            {
                if(mnMode == MasterMechUtil.OPMode.New)
                {
                    dataGridViewLineItems.Rows.RemoveAt(mnSelectedRow);
                    lObjDummyInvoice.InvoiceItems.RemoveAt(mnSelectedRow);
                    UpdateLineItemsSNo(mnSelectedRow);
                    ClearItemFormPart();
                    /*Below procedure only works when there are distinct items in line items, if same items are bought more than one once and any one is deleted, then always the one appearing first will be deleted not the one selected
                    foreach (InvoiceItem LineItem in lObjDummyInvoice.InvoiceItems)
                    {
                        if(LineItem.mnItemNo == Convert.ToInt32(textBoxItemNo.Text))
                        {
                            lObjDummyInvoice.InvoiceItems.Remove(LineItem);

                            UpdateLineItemsSNo(mnSelectedRow);
                            ClearItemFormPart();
                            break;
                        }
                    }*/
                }

                if (mnMode == MasterMechUtil.OPMode.Open)
                {
                    ExistingItemToDel.Add(lObjDummyInvoice.InvoiceItems[mnSelectedRow].mnInvoiceItemSNo);
                    dataGridViewLineItems.Rows.RemoveAt(mnSelectedRow);
                    lObjDummyInvoice.InvoiceItems.RemoveAt(mnSelectedRow);
                    UpdateLineItemsSNo(mnSelectedRow);
                    ClearItemFormPart();
                }
            }
            else
            {
                MessageBox.Show("Please Select LineItem row to delete.");
            }

            
        }

        private void buttonICancel_Click(object sender, EventArgs e)
        {
            ClearItemFormPart();
            iMode = LineItemMode.Add;
            buttonIAdd.Text = "Add";
            buttonIDelete.Enabled = false;
            buttonICancel.Enabled = false;
        }

        public void LoadVehicleDataToInvoiceObj()
        {
            lObjDummyInvoice.msVehicleRegNo = (textBoxRegNo.Text == String.Empty) ? null : textBoxRegNo.Text;
            lObjDummyInvoice.msVehicleModel = (textBoxModel.Text == String.Empty) ? null : textBoxModel.Text;
            lObjDummyInvoice.msChassisNo = (textBoxChassisNo.Text == String.Empty) ? null : textBoxChassisNo.Text;
            lObjDummyInvoice.msEngineNo = (textBoxEngineNo.Text == String.Empty) ? null : textBoxEngineNo.Text;
            if (textBoxMileage.Text == String.Empty)
            {
                lObjDummyInvoice.mnMileage = null;
            }
            else
            {
                lObjDummyInvoice.mnMileage = Convert.ToInt32(textBoxMileage.Text);
            }
            lObjDummyInvoice.msServiceType = (comboBoxServiceType.SelectedIndex == -1) ? null : Convert.ToString(comboBoxServiceType.SelectedItem);
            lObjDummyInvoice.msServiceAssoName = (textBoxSAName.Text == String.Empty) ? null : textBoxSAName.Text;
            lObjDummyInvoice.msServiceAssoMobNo = (textBoxSAMNo.Text == String.Empty) ? null : textBoxSAMNo.Text;
        }

        public void LoadBillDetailsToForm()
        {
            textBoxPTotal.Text = textBoxPCGST.Text = textBoxPSGST.Text = textBoxpigst.Text =
            textBoxLTotal.Text = textBoxLCGST.Text = textBoxLSGST.Text = textBoxLIGST.Text =
            textBoxTCGST.Text = textBoxTSGST.Text = textBoxTIGST.Text =
            textBoxTDiscount.Text = textBoxTTax.Text = textBoxTNAmount.Text = textBoxGTotal.Text = "0.0";

            for(int i = 0; i < dataGridViewLineItems.Rows.Count; i++)
            {
                if(Convert.ToString(dataGridViewLineItems.Rows[i].Cells[3].Value) == "PARTS")
                {
                    textBoxPTotal.Text = Convert.ToString(Convert.ToDouble(textBoxPTotal.Text) + Convert.ToDouble(dataGridViewLineItems.Rows[i].Cells[15].Value));
                    textBoxPCGST.Text = Convert.ToString(Convert.ToDouble(textBoxPCGST.Text) + Convert.ToDouble(dataGridViewLineItems.Rows[i].Cells[9].Value));
                    textBoxPSGST.Text = Convert.ToString(Convert.ToDouble(textBoxPSGST.Text) + Convert.ToDouble(dataGridViewLineItems.Rows[i].Cells[11].Value));
                    textBoxpigst.Text = Convert.ToString(Convert.ToDouble(textBoxpigst.Text) + Convert.ToDouble(dataGridViewLineItems.Rows[i].Cells[13].Value));
                }
                else if(Convert.ToString(dataGridViewLineItems.Rows[i].Cells[3].Value) == "SERVICES")
                {
                    textBoxLTotal.Text = Convert.ToString(Convert.ToDouble(textBoxLTotal.Text) + Convert.ToDouble(dataGridViewLineItems.Rows[i].Cells[15].Value));
                    textBoxLCGST.Text = Convert.ToString(Convert.ToDouble(textBoxLCGST.Text) + Convert.ToDouble(dataGridViewLineItems.Rows[i].Cells[9].Value));
                    textBoxLSGST.Text = Convert.ToString(Convert.ToDouble(textBoxLSGST.Text) + Convert.ToDouble(dataGridViewLineItems.Rows[i].Cells[11].Value));
                    textBoxLIGST.Text = Convert.ToString(Convert.ToDouble(textBoxLIGST.Text) + Convert.ToDouble(dataGridViewLineItems.Rows[i].Cells[13].Value));
                }
                textBoxTTax.Text = Convert.ToString(Convert.ToDouble(textBoxTTax.Text) + Convert.ToDouble(dataGridViewLineItems.Rows[i].Cells[14].Value));
                textBoxTDiscount.Text = Convert.ToString(Convert.ToDouble(textBoxTDiscount.Text) + Convert.ToDouble(dataGridViewLineItems.Rows[i].Cells[7].Value));
                textBoxTNAmount.Text = Convert.ToString(Convert.ToDouble(textBoxTNAmount.Text) + Convert.ToDouble(dataGridViewLineItems.Rows[i].Cells[16].Value));
                textBoxGTotal.Text = Convert.ToString(Convert.ToDouble(textBoxGTotal.Text) + Convert.ToDouble(dataGridViewLineItems.Rows[i].Cells[17].Value));
            }

            textBoxTCGST.Text = Convert.ToString(Convert.ToDouble(textBoxPCGST.Text) + Convert.ToDouble(textBoxLCGST.Text));
            textBoxTSGST.Text = Convert.ToString(Convert.ToDouble(textBoxPSGST.Text) + Convert.ToDouble(textBoxLSGST.Text));
            textBoxTIGST.Text = Convert.ToString(Convert.ToDouble(textBoxpigst.Text) + Convert.ToDouble(textBoxLIGST.Text));
        }

        public void LoadBillDetailToInvoiceObj()
        {
            if(textBoxPTotal.Text == String.Empty)
            {
                lObjDummyInvoice.mnPartsTotal = null;
            }
            else
            {
                lObjDummyInvoice.mnPartsTotal = Convert.ToDouble(textBoxPTotal.Text);
            }
            if (textBoxLTotal.Text == String.Empty)
            {
                lObjDummyInvoice.mnLabourTotal = null;
            }
            else
            {
                lObjDummyInvoice.mnLabourTotal = Convert.ToDouble(textBoxLTotal.Text);
            }


            if (textBoxPCGST.Text == String.Empty)
            {
                lObjDummyInvoice.mnPartsCGSTTotal = null;
            }
            else
            {
                lObjDummyInvoice.mnPartsCGSTTotal = Convert.ToDouble(textBoxPCGST.Text);
            }
            if (textBoxPSGST.Text == String.Empty)
            {
                lObjDummyInvoice.mnPartsSGSTTotal = null;
            }
            else
            {
                lObjDummyInvoice.mnPartsSGSTTotal = Convert.ToDouble(textBoxPSGST.Text);
            }
            if (textBoxpigst.Text == String.Empty)
            {
                lObjDummyInvoice.mnPartsIGSTTotal = null;
            }
            else
            {
                lObjDummyInvoice.mnPartsIGSTTotal = Convert.ToDouble(textBoxpigst.Text);
            }

            if (textBoxLCGST.Text == String.Empty)
            {
                lObjDummyInvoice.mnLabourCGSTTotal = null;
            }
            else
            {
                lObjDummyInvoice.mnLabourCGSTTotal = Convert.ToDouble(textBoxLCGST.Text);
            }
            if (textBoxLSGST.Text == String.Empty)
            {
                lObjDummyInvoice.mnLabourSGSTTotal = null;
            }
            else
            {
                lObjDummyInvoice.mnLabourSGSTTotal = Convert.ToDouble(textBoxLSGST.Text);
            }
            if (textBoxLIGST.Text == String.Empty)
            {
                lObjDummyInvoice.mnLabourIGSTTotal = null;
            }
            else
            {
                lObjDummyInvoice.mnLabourIGSTTotal = Convert.ToDouble(textBoxLIGST.Text);
            }

            if (textBoxTCGST.Text == String.Empty)
            {
                lObjDummyInvoice.mnTotalCGST = null;
            }
            else
            {
                lObjDummyInvoice.mnTotalCGST = Convert.ToDouble(textBoxTCGST.Text);
            }
            if (textBoxTSGST.Text == String.Empty)
            {
                lObjDummyInvoice.mnTotalSGST = null;
            }
            else
            {
                lObjDummyInvoice.mnTotalSGST = Convert.ToDouble(textBoxTSGST.Text);
            }
            if (textBoxTIGST.Text == String.Empty)
            {
                lObjDummyInvoice.mnTotalIGST = null;
            }
            else
            {
                lObjDummyInvoice.mnTotalIGST = Convert.ToDouble(textBoxTIGST.Text);
            }

            if (textBoxTTax.Text == String.Empty)
            {
                lObjDummyInvoice.mnTotalTax = null;
            }
            else
            {
                lObjDummyInvoice.mnTotalTax = Convert.ToDouble(textBoxTTax.Text);
            }

            if (textBoxTDiscount.Text == String.Empty)
            {
                lObjDummyInvoice.mnDiscountAmount = null;
            }
            else
            {
                lObjDummyInvoice.mnDiscountAmount = Convert.ToDouble(textBoxTDiscount.Text);
            }

            lObjDummyInvoice.mnTotalAmount = Convert.ToDouble(textBoxPTotal.Text) + Convert.ToDouble(textBoxLTotal.Text);

            if (textBoxTNAmount.Text == String.Empty)
            {
                lObjDummyInvoice.mnGrandTotal = null;
            }
            else
            {
                lObjDummyInvoice.mnGrandTotal = Convert.ToDouble(textBoxTNAmount.Text);
            }

            if(textBoxGTotal.Text == String.Empty)
            {
                lObjDummyInvoice.mnInvoiceTotal = null;
            }
            else
            {
                lObjDummyInvoice.mnInvoiceTotal = Convert.ToDouble(textBoxGTotal.Text);
            }

            lObjDummyInvoice.msInvoiceRemarks = (textBoxIRemarks.Text == String.Empty) ? null : textBoxIRemarks.Text;
        }

        private void buttonAction_Click(object sender, EventArgs e)
        {
            if(mnMode == MasterMechUtil.OPMode.New)
            {
                if (!ValidateCustomer())
                {
                    int lnError = mnErrors.Min();
                    switch (lnError)
                    {
                        case 0: textBoxFirstName.Focus(); break;
                        case 1: textBoxLastName.Focus(); break;
                        case 2: textBoxCustMNo.Focus(); break;
                        case 3: textBoxCustEID.Focus(); break;
                        case 4: comboBoxStatus.Focus(); break;
                        case 5: comboBoxType.Focus(); break;
                        case 6: textBoxCustPin.Focus(); break;
                        case 7: textBoxCustGSTNo.Focus(); break;
                    }
                    return;
                }
                else
                {
                    LoadDataToInvoiceCustObj();
                }
                if (lObjDummyInvoice.InvoiceItems.Count > 0)
                {
                    LoadVehicleDataToInvoiceObj();
                }
                else
                {
                    MessageBox.Show("Enter List Items in Invoice.");
                    return;
                }
                LoadBillDetailToInvoiceObj();
                if (lObjDummyInvoice.Save())
                {
                    MessageBox.Show("Invoice Saved Successfully.");
                    //PrintInvoiceForm lObjPrintInvoiceForm = new PrintInvoiceForm(Convert.ToInt32(textBoxInvoiceNo.Text));
                    //lObjPrintInvoiceForm.ShowDialog();
                    ClearInvoiceForm();
                    ClearInvoiceObjData();
                }
                else
                {
                    MessageBox.Show("Error! Unable to save Invoice.");
                }
            }
            else if (mnMode == MasterMechUtil.OPMode.Open)
            {
                if (textBoxInvoiceNo.Text == String.Empty)
                {
                    MessageBox.Show("Select appropriate Invoice to update.");
                }
                else
                {
                    if (!ValidateCustomer())
                    {
                        int lnError = mnErrors.Min();
                        switch (lnError)
                        {
                            case 0: textBoxFirstName.Focus(); break;
                            case 1: textBoxLastName.Focus(); break;
                            case 2: textBoxCustMNo.Focus(); break;
                            case 3: textBoxCustEID.Focus(); break;
                            case 4: comboBoxStatus.Focus(); break;
                            case 5: comboBoxType.Focus(); break;
                            case 6: textBoxCustPin.Focus(); break;
                            case 7: textBoxCustGSTNo.Focus(); break;
                        }
                        return;
                    }
                    else
                    {
                        LoadDataToInvoiceCustObj();
                    }
                    if (lObjDummyInvoice.InvoiceItems.Count > 0)
                    {
                        LoadVehicleDataToInvoiceObj();
                    }
                    else
                    {
                        MessageBox.Show("Enter List Items in Invoice.");
                        return;
                    }
                    LoadBillDetailToInvoiceObj();
                    if (lObjDummyInvoice.Save())
                    {
                        if(ExistingItemToDel.Count > 0)
                        {
                            foreach(int? x in ExistingItemToDel)
                            {
                                if(x != null)
                                {
                                    InvoiceItem lObjInvoiceItem = new InvoiceItem();
                                    lObjInvoiceItem.mnInvoiceItemSNo = x;
                                    lObjInvoiceItem.msDeletedBy = MasterMechUtil.sUserID;
                                    lObjInvoiceItem.Delete(MasterMechUtil.msConString, MasterMechUtil.sUserID);
                                }
                            }
                        }
                        MessageBox.Show("Invoice Updated Successfully.");
                        ClearInvoiceForm();
                        ClearInvoiceObjData();
                    }
                    else
                    {
                        MessageBox.Show("Error! Unable to update Invoice.");
                    }
                }
            }
            else if (mnMode == MasterMechUtil.OPMode.Delete)
            {
                if(textBoxInvoiceNo.Text == String.Empty)
                {
                    MessageBox.Show("Select appropriate Invoice to delete.");
                }
                else
                {
                    lObjDummyInvoice.mnInvoiceSNo = Convert.ToInt32(textBoxInvoiceNo.Text);
                    if (lObjDummyInvoice.Delete())
                    {
                        MessageBox.Show("Invoice Deleted Successfully.");
                        ClearInvoiceForm();
                        ClearInvoiceObjData();
                    }
                    else
                    {
                        MessageBox.Show("Error! Unable to delete Invoice.");
                    } 
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
            lnCnt = 1;
            ExistingItemToDel.Clear();
            mnErrors.Clear();
            ClearInvoiceObjData();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if(textBoxInvoiceNo.Text.Length == 0)
            {
                MessageBox.Show("Invoice not selected. Select appropriate Invoice to Print.");
            }
            else
            {
                PrintInvoiceForm lObjPrintInvoiceForm = new PrintInvoiceForm(Convert.ToInt32(textBoxInvoiceNo.Text));
                lObjPrintInvoiceForm.ShowDialog();
            }
            
        }

        public void LoadInvoicesToDataGrid(List<Invoice> iObjListInvoice, Invoice iObjInvoice)
        {
            InvoiceDataGridForm lObjInvoiceDataGridForm = new InvoiceDataGridForm();
            lObjInvoiceDataGridForm.noSelectMsg = "No Invoice selected. Select a Invoice row and click Select.";

            //Build the header
            lObjInvoiceDataGridForm.dataGridViewInvoice.ReadOnly = true;
            lObjInvoiceDataGridForm.dataGridViewInvoice.AllowUserToAddRows = false;
            lObjInvoiceDataGridForm.dataGridViewInvoice.ColumnCount = 21;
            lObjInvoiceDataGridForm.dataGridViewInvoice.Columns[0].Name = "S. No.";
            lObjInvoiceDataGridForm.dataGridViewInvoice.Columns[1].Name = "Invoice S.No.";
            lObjInvoiceDataGridForm.dataGridViewInvoice.Columns[2].Name = "Invoice Date";
            lObjInvoiceDataGridForm.dataGridViewInvoice.Columns[3].Name = "Status";
            lObjInvoiceDataGridForm.dataGridViewInvoice.Columns[4].Name = "Customer First Name";
            lObjInvoiceDataGridForm.dataGridViewInvoice.Columns[5].Name = "Customer Last Name";
            lObjInvoiceDataGridForm.dataGridViewInvoice.Columns[6].Name = "Customer Mobile No.";
            lObjInvoiceDataGridForm.dataGridViewInvoice.Columns[7].Name = "Customer Email";
            lObjInvoiceDataGridForm.dataGridViewInvoice.Columns[8].Name = "Customer City";
            lObjInvoiceDataGridForm.dataGridViewInvoice.Columns[9].Name = "Customer State";
            lObjInvoiceDataGridForm.dataGridViewInvoice.Columns[10].Name = "Vehicle Reg. No.";
            lObjInvoiceDataGridForm.dataGridViewInvoice.Columns[11].Name = "Vehicle Model";
            lObjInvoiceDataGridForm.dataGridViewInvoice.Columns[12].Name = "Service Type";
            lObjInvoiceDataGridForm.dataGridViewInvoice.Columns[13].Name = "Service Associate";
            lObjInvoiceDataGridForm.dataGridViewInvoice.Columns[14].Name = "Parts Total";
            lObjInvoiceDataGridForm.dataGridViewInvoice.Columns[15].Name = "Labour Total";
            lObjInvoiceDataGridForm.dataGridViewInvoice.Columns[16].Name = "Total Tax";
            lObjInvoiceDataGridForm.dataGridViewInvoice.Columns[17].Name = "Total Amount";
            lObjInvoiceDataGridForm.dataGridViewInvoice.Columns[18].Name = "Discount Amount";
            lObjInvoiceDataGridForm.dataGridViewInvoice.Columns[19].Name = "Gross Total";
            lObjInvoiceDataGridForm.dataGridViewInvoice.Columns[20].Name = "Invoice Total";

            int lnCount = 1;

            if(iObjListInvoice.Count == 0)
            {
                MessageBox.Show("No Invoice Found.");
                textBoxInvoiceSearchKey.Focus();
            }
            if(iObjListInvoice.Count == 1)
            {
                iObjInvoice.Load(Convert.ToInt32(iObjListInvoice[0].mnInvoiceSNo));
            }
            if(iObjListInvoice.Count > 1)
            {
                foreach(Invoice ObjInvoice in iObjListInvoice)
                {
                    lObjInvoiceDataGridForm.dataGridViewInvoice.Rows.Add(lnCount++, ObjInvoice.mnInvoiceSNo, ObjInvoice.mdInvoiceDate, ObjInvoice.msInvoiceStatus, ObjInvoice.InvoiceCustomer.msCustomerFName, ObjInvoice.InvoiceCustomer.msCustomerLName, ObjInvoice.InvoiceCustomer.msCustomerLName, ObjInvoice.InvoiceCustomer.msCustomerMNo, ObjInvoice.InvoiceCustomer.msCustomerEmail, ObjInvoice.InvoiceCustomer.msCustomerCity, ObjInvoice.InvoiceCustomer.msCustomerState, ObjInvoice.msVehicleRegNo, ObjInvoice.msVehicleModel, ObjInvoice.msServiceType, ObjInvoice.msServiceAssoName, ObjInvoice.mnPartsTotal, ObjInvoice.mnLabourTotal, ObjInvoice.mnTotalTax, ObjInvoice.mnTotalAmount, ObjInvoice.mnDiscountAmount, ObjInvoice.mnGrandTotal, ObjInvoice.mnInvoiceTotal);
                }

                lObjInvoiceDataGridForm.ShowDialog();
                int lnSelectedRow = lObjInvoiceDataGridForm.mnSelectedRow;
                if (lObjInvoiceDataGridForm.mbSelected)
                {
                    int lnInvoiceNo = Convert.ToInt32(lObjInvoiceDataGridForm.dataGridViewInvoice.Rows[lnSelectedRow].Cells[1].Value);
                    iObjInvoice.Load(lnInvoiceNo);
                }
            }
        }

        public void LoadVehicleBillToForm(Invoice iObjInvoice)
        {
            textBoxRegNo.Text = (iObjInvoice.msVehicleRegNo is null) ? String.Empty : iObjInvoice.msVehicleRegNo;
            textBoxModel.Text = (iObjInvoice.msVehicleModel is null) ? String.Empty : iObjInvoice.msVehicleModel;
            textBoxChassisNo.Text = (iObjInvoice.msChassisNo is null) ? String.Empty : iObjInvoice.msChassisNo;
            textBoxEngineNo.Text = (iObjInvoice.msEngineNo is null) ? String.Empty : iObjInvoice.msEngineNo;
            textBoxMileage.Text = (iObjInvoice.mnMileage is null) ? String.Empty : Convert.ToString(iObjInvoice.mnMileage);
            if(iObjInvoice.msServiceType is null)
            {
                comboBoxServiceType.SelectedIndex = -1;
            }
            else
            {
                comboBoxServiceType.SelectedItem = iObjInvoice.msServiceType;
            }
            textBoxSAName.Text = (iObjInvoice.msServiceAssoName is null) ? String.Empty : iObjInvoice.msServiceAssoName;
            textBoxSAMNo.Text = (iObjInvoice.msServiceAssoMobNo is null) ? String.Empty : iObjInvoice.msServiceAssoName;
            textBoxPTotal.Text = (iObjInvoice.mnPartsTotal is null) ? String.Empty : Convert.ToString(iObjInvoice.mnPartsTotal);
            textBoxPCGST.Text = (iObjInvoice.mnPartsCGSTTotal is null) ? String.Empty : Convert.ToString(iObjInvoice.mnPartsCGSTTotal);
            textBoxPSGST.Text = (iObjInvoice.mnPartsSGSTTotal is null) ? String.Empty : Convert.ToString(iObjInvoice.mnPartsSGSTTotal);
            textBoxpigst.Text = (iObjInvoice.mnPartsIGSTTotal is null) ? String.Empty : Convert.ToString(iObjInvoice.mnPartsIGSTTotal);
            textBoxLTotal.Text = (iObjInvoice.mnLabourTotal is null) ? String.Empty : Convert.ToString(iObjInvoice.mnLabourTotal);
            textBoxLCGST.Text = (iObjInvoice.mnLabourCGSTTotal is null) ? String.Empty : Convert.ToString(iObjInvoice.mnLabourCGSTTotal);
            textBoxLSGST.Text = (iObjInvoice.mnLabourSGSTTotal is null) ? String.Empty : Convert.ToString(iObjInvoice.mnLabourSGSTTotal);
            textBoxLIGST.Text = (iObjInvoice.mnLabourIGSTTotal is null) ? String.Empty : Convert.ToString(iObjInvoice.mnLabourIGSTTotal);
            textBoxTCGST.Text = (iObjInvoice.mnTotalCGST is null) ? String.Empty : Convert.ToString(iObjInvoice.mnTotalCGST);
            textBoxTSGST.Text = (iObjInvoice.mnTotalSGST is null) ? String.Empty : Convert.ToString(iObjInvoice.mnTotalSGST);
            textBoxTIGST.Text = (iObjInvoice.mnTotalIGST is null) ? String.Empty : Convert.ToString(iObjInvoice.mnTotalIGST);
            textBoxTTax.Text = (iObjInvoice.mnTotalTax is null) ? String.Empty : Convert.ToString(iObjInvoice.mnTotalTax);
            textBoxTDiscount.Text = (iObjInvoice.mnDiscountAmount is null) ? String.Empty : Convert.ToString(iObjInvoice.mnDiscountAmount);
            textBoxTNAmount.Text = (iObjInvoice.mnGrandTotal is null) ? String.Empty : Convert.ToString(iObjInvoice.mnGrandTotal);
            textBoxGTotal.Text = (iObjInvoice.mnInvoiceTotal is null) ? String.Empty : Convert.ToString(iObjInvoice.mnInvoiceTotal);
            textBoxIRemarks.Text = (iObjInvoice.msInvoiceRemarks is null) ? String.Empty : iObjInvoice.msInvoiceRemarks;
            textBoxInvoiceNo.Text = (iObjInvoice.mnInvoiceSNo is null) ? String.Empty : Convert.ToString(iObjInvoice.mnInvoiceSNo);
            textBoxInvoiceDate.Text = Convert.ToString(iObjInvoice.mdInvoiceDate);
            textBoxCreated.Text = (iObjInvoice.mdCreated is null) ? String.Empty : Convert.ToString(iObjInvoice.mdCreated);
            textBoxCreatedBy.Text = (iObjInvoice.msCreatedBy is null) ? String.Empty : iObjInvoice.msCreatedBy;
            textBoxModified.Text = (iObjInvoice.mdModified is null) ? String.Empty : Convert.ToString(iObjInvoice.mdModified);
            textBoxModifiedBy.Text = (iObjInvoice.msModifiedBy is null) ? String.Empty : iObjInvoice.msModifiedBy;
        }

        private void buttonInvoiceSearch_Click(object sender, EventArgs e)
        {
            if (textBoxInvoiceSearchKey.Text == String.Empty)
            {
                MessageBox.Show("Search Key is empty. Enter appropriate Mobile No. Key");
                textBoxInvoiceSearchKey.Focus();
            }
            else
            {
                lObjDummyInvoice.InvoiceItems.Clear();
                dataGridViewLineItems.Rows.Clear();
                lnCnt = 1;
                List<Invoice> lObjListInvoices = new List<Invoice>();
                string lsSearchKey = textBoxInvoiceSearchKey.Text;
                lObjDummyInvoice.SearchInvoices(lsSearchKey, lObjListInvoices);
                LoadInvoicesToDataGrid(lObjListInvoices, lObjDummyInvoice);
                LoadCustomerToForm(lObjDummyInvoice.InvoiceCustomer);
                foreach(InvoiceItem LineItem in lObjDummyInvoice.InvoiceItems)
                {
                     LineItem.Load(MasterMechUtil.msConString, MasterMechUtil.sUserID, Convert.ToInt32(LineItem.mnInvoiceItemSNo));
                    LoadItemToLineItemsGrid(LineItem);
                }
                LoadVehicleBillToForm(lObjDummyInvoice);
            }
        }

        private void buttonAInvoiceSearch_Click(object sender, EventArgs e)
        {
            lObjDummyInvoice.InvoiceItems.Clear();
            dataGridViewLineItems.Rows.Clear();
            lnCnt = 1;
            List<Invoice> lObjListInvoices = new List<Invoice>();
            InvoiceAdvanceSearchForm lObjAdvSearchForm = new InvoiceAdvanceSearchForm(lObjListInvoices);
            lObjAdvSearchForm.ShowDialog();
            LoadInvoicesToDataGrid(lObjListInvoices, lObjDummyInvoice);
            LoadCustomerToForm(lObjDummyInvoice.InvoiceCustomer);
            foreach (InvoiceItem LineItem in lObjDummyInvoice.InvoiceItems)
            {
                LineItem.Load(MasterMechUtil.msConString, MasterMechUtil.sUserID, Convert.ToInt32(LineItem.mnInvoiceItemSNo));
                LoadItemToLineItemsGrid(LineItem);
            }
            LoadVehicleBillToForm(lObjDummyInvoice);
        }
    }
}
