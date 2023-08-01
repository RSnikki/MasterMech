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
    public partial class ItemForm : Form
    {
        public MasterMechLib.MasterMechUtil.OPMode mnMode;
        public List<int> mnErrorControls = new List<int>();
        public ItemForm()
        {
            InitializeComponent();
        }

        public ItemForm(MasterMechLib.MasterMechUtil.OPMode inMode)
        {
            mnMode = inMode;
            InitializeComponent();
        }

        private void ItemForm_Load(object sender, EventArgs e)
        {
            switch (mnMode)
            {
                case MasterMechLib.MasterMechUtil.OPMode.New:
                    labelItemSearch.Visible = false;
                    textBoxSearchKey.Visible = false;
                    buttonSearch.Visible = false;
                    buttonAction.Text = "Save";
                    break;
                case MasterMechLib.MasterMechUtil.OPMode.Open:
                    labelItemSearch.Visible = true;
                    textBoxSearchKey.Visible = true;
                    buttonSearch.Visible = true;
                    buttonAction.Text = "Save";
                    break;
                case MasterMechLib.MasterMechUtil.OPMode.Delete:
                    labelItemSearch.Visible = true;
                    textBoxSearchKey.Visible = true;
                    buttonSearch.Visible = true;
                    buttonAction.Text = "Delete";
                    break;
            }
            LoadCBType();
            LoadCBCategory();
            LoadCBStatus();
        }

        public void LoadCBType()
        {
            Item.GetItemType();
            foreach(string x in Item.itemType)
            {
                comboBoxItemType.Items.Add(x);
            }
        }

        public void LoadCBCategory()
        {
            Item.GetItemCategory();
            foreach (string x in Item.itemCategories)
            {
                comboBoxItemCategory.Items.Add(x);
            }
        }

        public void LoadCBStatus()
        {
            Item.GetItemStatus();
            foreach (string x in Item.itemStatus)
            {
                comboBoxStatus.Items.Add(x);
            }
        }

        public bool ValidateEntry()
        {
            bool lbValid = true;
            mnErrorControls.Clear();
            if(textBoxItemDesc.Text.Length == 0)
            {
                labelItemDescError.Visible = true;
                mnErrorControls.Add(0);
                
            }
            if(comboBoxItemType.SelectedIndex == -1)
            {
                labelTypeError.Visible = true;
                mnErrorControls.Add(1);
                
            }
            if(comboBoxItemCategory.SelectedIndex == -1)
            {
                labelCategoryError.Visible = true;
                mnErrorControls.Add(2);
                
            }
            if (textBoxItemPrice.Text.Length == 0)
            {
                labelPriceError.Visible = true;
                mnErrorControls.Add(3);
                
            }
            if (textBoxUOM.Text.Length == 0)
            {
                labelUOMError.Visible = true;
                mnErrorControls.Add(4);
            }
            if(comboBoxStatus.SelectedIndex == -1)
            {
                labelStatusError.Visible = true;
                mnErrorControls.Add(5);
            }

            if(mnErrorControls.Count > 0)
            {
                lbValid = false; ;
            }
            return lbValid;
        }

        private void buttonAction_Click(object sender, EventArgs e)
        {
            bool lbMode;
            if(mnMode == MasterMechLib.MasterMechUtil.OPMode.New)
            {
                lbMode = true;
                if (!ValidateEntry())
                {
                    if (mnErrorControls.Count > 0)
                    {
                        int lnFirstControl = mnErrorControls.Min();
                        switch (lnFirstControl)
                        {
                            case 0: textBoxItemDesc.Focus(); break;
                            case 1: comboBoxItemType.Focus(); break;
                            case 2: comboBoxItemCategory.Focus(); break;
                            case 3: textBoxItemPrice.Focus(); break;
                            case 4: textBoxUOM.Focus(); break;
                            case 5: comboBoxStatus.Focus();break;
                        }

                    }
                    return;
                }
                else
                {
                    SaveItem(lbMode);
                }
                
            }
            else if(mnMode == MasterMechLib.MasterMechUtil.OPMode.Open)
            {
                lbMode = false;
                if(textBoxItemNo.Text.Length > 0)
                {
                    if (!ValidateEntry())
                    {
                        if (mnErrorControls.Count > 0)
                        {
                            int lnFirstControl = mnErrorControls.Min();
                            switch (lnFirstControl)
                            {
                                case 0: textBoxItemDesc.Focus(); break;
                                case 1: comboBoxItemType.Focus(); break;
                                case 2: comboBoxItemCategory.Focus(); break;
                                case 3: textBoxItemPrice.Focus(); break;
                                case 4: textBoxUOM.Focus(); break;
                                case 5: comboBoxStatus.Focus(); break;
                            }

                        }
                        return;
                    }
                    else
                    {
                        SaveItem(lbMode);
                    }
                }
                else
                {
                    MessageBox.Show("Select the Item to update.");
                }
                
            }
            else if(mnMode == MasterMechLib.MasterMechUtil.OPMode.Delete)
            {
                DeleteItem();
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if(textBoxSearchKey.Text.Length == 0)
            {
                labelSearchKeyError.Visible = true;
            }
            else
            {
                SearchItems();
            }
        }

        public void SearchItems()
        {
            Item lObjDummyItem = new Item();
            List<Item> lObjListItems = new List<Item>();
            string lsSearchKey = textBoxSearchKey.Text;

            lObjDummyItem.SearchItems(MasterMechUtil.msConString, lsSearchKey, lObjListItems);

            ItemDataGridForm lObjUDGForm = new ItemDataGridForm();
            lObjUDGForm.noSelectMsg = "No User Selected. Select a user row and then click select.";

            //Build the header
            lObjUDGForm.dataGridItemView.ReadOnly = true;
            lObjUDGForm.dataGridItemView.AllowUserToAddRows = false;
            lObjUDGForm.dataGridItemView.ColumnCount = 19;
            lObjUDGForm.dataGridItemView.Columns[0].Name = "S. No.";
            lObjUDGForm.dataGridItemView.Columns[1].Name = "ItemNo";
            lObjUDGForm.dataGridItemView.Columns[2].Name = "ItemDesc";
            lObjUDGForm.dataGridItemView.Columns[3].Name = "ItemType";
            lObjUDGForm.dataGridItemView.Columns[4].Name = "ItemCategory";
            lObjUDGForm.dataGridItemView.Columns[5].Name = "ItemPrice";
            lObjUDGForm.dataGridItemView.Columns[6].Name = "ItemUOM";
            lObjUDGForm.dataGridItemView.Columns[7].Name = "ItemStatus";
            lObjUDGForm.dataGridItemView.Columns[8].Name = "CGSTRate";
            lObjUDGForm.dataGridItemView.Columns[9].Name = "SGSTRate";
            lObjUDGForm.dataGridItemView.Columns[10].Name = "IGSTRate";
            lObjUDGForm.dataGridItemView.Columns[11].Name = "UPCCode";
            lObjUDGForm.dataGridItemView.Columns[12].Name = "HSNCode";
            lObjUDGForm.dataGridItemView.Columns[13].Name = "SACCode";
            lObjUDGForm.dataGridItemView.Columns[14].Name = "QuantityInHand";
            lObjUDGForm.dataGridItemView.Columns[15].Name = "NoOfParts";
            lObjUDGForm.dataGridItemView.Columns[16].Name = "ReOrderQty";
            lObjUDGForm.dataGridItemView.Columns[17].Name = "ReOrderLevel";
            lObjUDGForm.dataGridItemView.Columns[18].Name = "ItemRemarks";


            int lnCnt = 1;

            if (lObjListItems.Count == 0)
            {
                MessageBox.Show("No Item Found!");
                this.textBoxSearchKey.Focus();
                return;
            }
            else if (lObjListItems.Count == 1)
            {
                lObjDummyItem.Load(MasterMechUtil.msConString, lObjListItems[0].mnItemNo);
                FormDataLoad(lObjDummyItem);

            }
            else if (lObjListItems.Count > 1)
            {
                foreach (Item ItemSelected in lObjListItems)
                {
                    lObjUDGForm.dataGridItemView.Rows.Add(lnCnt++, ItemSelected.mnItemNo, ItemSelected.msItemDesc, ItemSelected.msItemType, ItemSelected.msItemCategory, ItemSelected.mnItemPrice, ItemSelected.msUOM, ItemSelected.msStatus, ItemSelected.mnCGST, ItemSelected.mnSGST, ItemSelected.mnIGST, ItemSelected.msUPC, ItemSelected.msHSN, ItemSelected.msSAC, ItemSelected.msRemarks, ItemSelected.mnQuantityInHand, ItemSelected.mnNoOfParts, ItemSelected.mnReOrderQty, ItemSelected.mnReOrderLevel, ItemSelected.msRemarks);

                }
                lObjUDGForm.ShowDialog();
                int lnSelectedRow = lObjUDGForm.mnSelectedRow;
                int lnItemNo = Convert.ToInt32(lObjUDGForm.dataGridItemView.Rows[lnSelectedRow].Cells[1].Value);
                if (lObjUDGForm.mbSelected)
                {
                    if (lObjDummyItem.Load(MasterMechUtil.msConString, lnItemNo))
                    {
                        FormDataLoad(lObjDummyItem);
                    }
                }
                else
                {
                    this.textBoxSearchKey.Focus();
                }
            }
        }

        public void FormDataLoad(Item iObjDummyItem)
        {
            textBoxItemNo.Text = Convert.ToString(iObjDummyItem.mnItemNo);
            textBoxItemDesc.Text = iObjDummyItem.msItemDesc;
            comboBoxItemType.SelectedItem = iObjDummyItem.msItemType;
            comboBoxItemCategory.SelectedItem = iObjDummyItem.msItemCategory;
            textBoxItemPrice.Text = Convert.ToString(iObjDummyItem.mnItemPrice);
            textBoxUOM.Text = iObjDummyItem.msUOM;
            comboBoxStatus.SelectedItem = iObjDummyItem.msStatus;
            if(iObjDummyItem.mnCGST is null)
            {
                textBoxCGST.Text = string.Empty;
            }
            else
            {
                textBoxCGST.Text = Convert.ToString(iObjDummyItem.mnCGST);
            }
            if (iObjDummyItem.mnSGST is null)
            {
                textBoxSGST.Text = string.Empty;
            }
            else
            {
                textBoxSGST.Text = Convert.ToString(iObjDummyItem.mnSGST);
            }
            if (iObjDummyItem.mnIGST is null)
            {
                textBoxIGST.Text = string.Empty;
            }
            else
            {
                textBoxIGST.Text = Convert.ToString(iObjDummyItem.mnIGST);
            }
            if (iObjDummyItem.msUPC is null)
            {
                textBoxUPC.Text = string.Empty;
            }
            else
            {
                textBoxUPC.Text = iObjDummyItem.msUPC;
            }
            if (iObjDummyItem.msHSN is null)
            {
                textBoxHSN.Text = string.Empty;
            }
            else
            {
                textBoxHSN.Text = iObjDummyItem.msHSN;
            }
            if (iObjDummyItem.msSAC is null)
            {
                textBoxSAC.Text = string.Empty;
            }
            else
            {
                textBoxSAC.Text = iObjDummyItem.msSAC;
            }
            if (iObjDummyItem.mnQuantityInHand is null)
            {
                textBoxQtyHand.Text = string.Empty;
            }
            else
            {
                textBoxQtyHand.Text = Convert.ToString(iObjDummyItem.mnQuantityInHand);
            }
            if (iObjDummyItem.mnNoOfParts is null)
            {
                textBoxNoParts.Text = string.Empty;
            }
            else
            {
                textBoxNoParts.Text = Convert.ToString(iObjDummyItem.mnNoOfParts);
            }
            if (iObjDummyItem.mnReOrderQty is null)
            {
                textBoxReorderQty.Text = string.Empty;
            }
            else
            {
                textBoxReorderQty.Text = Convert.ToString(iObjDummyItem.mnReOrderQty);
            }

            if (iObjDummyItem.mnReOrderLevel is null)
            {
                textBoxReorderLevel.Text = string.Empty;
            }
            else
            {
                textBoxReorderLevel.Text = Convert.ToString(iObjDummyItem.mnReOrderLevel);
            }
            if (iObjDummyItem.msRemarks is null)
            {
                textBoxRemarks.Text = string.Empty;
            }
            else
            {
                textBoxRemarks.Text = iObjDummyItem.msRemarks;
            }
            if (iObjDummyItem.mdCreated is null)
            {
                textBoxCreated.Text = string.Empty;
            }
            else
            {
                textBoxCreated.Text = Convert.ToString(iObjDummyItem.mdCreated);
            }
            if (iObjDummyItem.msCreatedBy is null)
            {
                textBoxCreatedBy.Text = string.Empty;
            }
            else
            {
                textBoxCreatedBy.Text = iObjDummyItem.msCreatedBy;
            }
            if (iObjDummyItem.mdModified is null)
            {
                textBoxModified.Text = string.Empty;
            }
            else
            {
                textBoxModified.Text = Convert.ToString(iObjDummyItem.mdModified);
            }
            if (iObjDummyItem.msModifiedBy is null)
            {
                textBoxModifiedBy.Text = string.Empty;
            }
            else
            {
                textBoxModifiedBy.Text = iObjDummyItem.msModifiedBy;
            }
        }

        public void SaveItem(bool ibMode)
        {

            string lsItemDesc = textBoxItemDesc.Text;
            string lsItemType = Convert.ToString(comboBoxItemType.SelectedItem);
            string lsItemCategory = Convert.ToString(comboBoxItemCategory.SelectedItem);
            Double ItemPrice = Convert.ToDouble(textBoxItemPrice.Text);
            string lsUOM = textBoxUOM.Text;
            string lsStatus = Convert.ToString(comboBoxStatus.SelectedItem);

            Item lObjDummyItem = new Item(lsItemDesc, lsItemType, lsItemCategory, ItemPrice, lsUOM, lsStatus);

            lObjDummyItem.mnCGST = Convert.ToDouble(textBoxCGST.Text.Equals(String.Empty)? null : textBoxCGST.Text);
            lObjDummyItem.mnSGST = Convert.ToDouble(textBoxSGST.Text.Equals(String.Empty)? null : textBoxSGST.Text);
            lObjDummyItem.mnIGST = Convert.ToDouble(textBoxIGST.Text.Equals(String.Empty)? null : textBoxIGST.Text);
            lObjDummyItem.msUPC = textBoxUPC.Text.Equals(String.Empty)? null : textBoxUPC.Text;
            lObjDummyItem.msHSN = textBoxHSN.Text.Equals(String.Empty)? null : textBoxHSN.Text;
            lObjDummyItem.msSAC = textBoxSAC.Text.Equals(String.Empty)? null : textBoxSAC.Text;
            lObjDummyItem.mnQuantityInHand = Convert.ToDouble(textBoxQtyHand.Text.Equals(string.Empty)? null : textBoxQtyHand.Text);
            lObjDummyItem.mnNoOfParts = Convert.ToInt32(textBoxNoParts.Text.Equals(string.Empty)? null : textBoxNoParts.Text);
            lObjDummyItem.mnReOrderQty = Convert.ToDouble(textBoxReorderQty.Text.Equals(string.Empty)? null : textBoxReorderQty.Text);
            lObjDummyItem.mnReOrderLevel = Convert.ToDouble(textBoxReorderLevel.Text.Equals(string.Empty)? null : textBoxReorderLevel.Text);
            lObjDummyItem.msRemarks = textBoxRemarks.Text.Equals(string.Empty)? null : textBoxRemarks.Text;

            if (ibMode)
            {
                if(lObjDummyItem.Save(MasterMechUtil.msConString, MasterMechUtil.sUserID, ibMode))
                {
                    MessageBox.Show("New Item added successfully.");
                }
                else
                {
                    MessageBox.Show("Unable to add new item.");
                }
            }
            else
            {
                lObjDummyItem.mnItemNo = Convert.ToInt32(textBoxItemNo.Text);
                if (lObjDummyItem.Save(MasterMechUtil.msConString, MasterMechUtil.sUserID, ibMode))
                {
                    MessageBox.Show("Item detais updated successfully.");
                }
                else
                {
                    MessageBox.Show("Unable to update item details.");
                }
            }
        }

        public void DeleteItem()
        {
            
            if (textBoxItemNo.Text.Length != 0)
            {
                Item lObjDummyItem = new Item();
                lObjDummyItem.mnItemNo = Convert.ToInt32(textBoxItemNo.Text);
                if (lObjDummyItem.Delete(MasterMechUtil.msConString, MasterMechUtil.sUserID))
                {
                    MessageBox.Show("Item Successfully deleted!");
                }
                else
                {
                    MessageBox.Show("Item not deleted or not available to delete.");
                }
            }
            else
            {
                MessageBox.Show("Select the item to delete.");
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxSearchKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelSearchKeyError.Visible = false;
        }

        private void textBoxItemDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelItemDescError.Visible = false;
        }

        private void comboBoxItemType_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelTypeError.Visible = false;
        }

        private void comboBoxItemCategory_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelCategoryError.Visible = false;
        }

        private void textBoxItemPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelPriceError.Visible = false;
        }

        private void textBoxUOM_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelUOMError.Visible = false;
        }

        private void comboBoxStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            labelStatusError.Visible = false;
        }

        public void LoadDataToGrid(List<Item> lObjItemList, Item lObjDummyItem)
        {
            ItemDataGridForm lObjUDGForm = new ItemDataGridForm();
            lObjUDGForm.noSelectMsg = "No User Selected. Select a user row and then click select.";

            //Build the header
            lObjUDGForm.dataGridItemView.ReadOnly = true;
            lObjUDGForm.dataGridItemView.AllowUserToAddRows = false;
            lObjUDGForm.dataGridItemView.ColumnCount = 19;
            lObjUDGForm.dataGridItemView.Columns[0].Name = "S. No.";
            lObjUDGForm.dataGridItemView.Columns[1].Name = "ItemNo";
            lObjUDGForm.dataGridItemView.Columns[2].Name = "ItemDesc";
            lObjUDGForm.dataGridItemView.Columns[3].Name = "ItemType";
            lObjUDGForm.dataGridItemView.Columns[4].Name = "ItemCategory";
            lObjUDGForm.dataGridItemView.Columns[5].Name = "ItemPrice";
            lObjUDGForm.dataGridItemView.Columns[6].Name = "ItemUOM";
            lObjUDGForm.dataGridItemView.Columns[7].Name = "ItemStatus";
            lObjUDGForm.dataGridItemView.Columns[8].Name = "CGSTRate";
            lObjUDGForm.dataGridItemView.Columns[9].Name = "SGSTRate";
            lObjUDGForm.dataGridItemView.Columns[10].Name = "IGSTRate";
            lObjUDGForm.dataGridItemView.Columns[11].Name = "UPCCode";
            lObjUDGForm.dataGridItemView.Columns[12].Name = "HSNCode";
            lObjUDGForm.dataGridItemView.Columns[13].Name = "SACCode";
            lObjUDGForm.dataGridItemView.Columns[14].Name = "QuantityInHand";
            lObjUDGForm.dataGridItemView.Columns[15].Name = "NoOfParts";
            lObjUDGForm.dataGridItemView.Columns[16].Name = "ReOrderQty";
            lObjUDGForm.dataGridItemView.Columns[17].Name = "ReOrderLevel";
            lObjUDGForm.dataGridItemView.Columns[18].Name = "ItemRemarks";


            int lnCnt = 1;

            if (lObjItemList.Count == 0)
            {
                MessageBox.Show("No Item Found!");
                this.textBoxSearchKey.Focus();
                return;
            }
            else if (lObjItemList.Count == 1)
            {
                lObjDummyItem.Load(MasterMechUtil.msConString, lObjItemList[0].mnItemNo);
                FormDataLoad(lObjDummyItem);

            }
            else if (lObjItemList.Count > 1)
            {
                foreach (Item ItemSelected in lObjItemList)
                {
                    lObjUDGForm.dataGridItemView.Rows.Add(lnCnt++, ItemSelected.mnItemNo, ItemSelected.msItemDesc, ItemSelected.msItemType, ItemSelected.msItemCategory, ItemSelected.mnItemPrice, ItemSelected.msUOM, ItemSelected.msStatus, ItemSelected.mnCGST, ItemSelected.mnSGST, ItemSelected.mnIGST, ItemSelected.msUPC, ItemSelected.msHSN, ItemSelected.msSAC, ItemSelected.msRemarks, ItemSelected.mnQuantityInHand, ItemSelected.mnNoOfParts, ItemSelected.mnReOrderQty, ItemSelected.mnReOrderLevel, ItemSelected.msRemarks);

                }
                lObjUDGForm.ShowDialog();
                int lnSelectedRow = lObjUDGForm.mnSelectedRow;
                int lnItemNo = Convert.ToInt32(lObjUDGForm.dataGridItemView.Rows[lnSelectedRow].Cells[1].Value);
                if (lObjUDGForm.mbSelected)
                {
                    lObjDummyItem.Load(MasterMechUtil.msConString, lnItemNo);  
                }
            }
        }

        private void comboBoxItemType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            labelTypeError.Visible = false;
        }

        private void comboBoxItemCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            labelCategoryError.Visible = false;
        }

        private void comboBoxStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            labelStatusError.Visible = false;
        }

        private void textBoxItemDesc_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxItemDesc.Text.Length == 0)
            {
                labelItemDescError.Visible = true;
                e.Cancel = false;
            }
        }

        private void comboBoxItemType_Validating(object sender, CancelEventArgs e)
        {
            if (comboBoxItemType.SelectedIndex == -1)
            {
                labelTypeError.Visible = true;
                e.Cancel = false;

            }
        }

        private void comboBoxItemCategory_Validating(object sender, CancelEventArgs e)
        {
            if (comboBoxItemCategory.SelectedIndex == -1)
            {
                labelCategoryError.Visible = true;
                e.Cancel = false;

            }
        }

        private void textBoxItemPrice_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxItemPrice.Text.Length == 0)
            {
                labelPriceError.Visible = true;
                e.Cancel = false;

            }
        }

        private void textBoxUOM_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxUOM.Text.Length == 0)
            {
                labelUOMError.Visible = true;
                e.Cancel = false;
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
    }
}
  