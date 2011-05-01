using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Migatsu
{
    public partial class AdjustmentForm : Form
    {
        string[] categoryList = new string[100];
        string[] subcategoryList = new string[100];
        string[] warehouseList = new string[100];

        FilterFunctions filter = new FilterFunctions();
        DefaultStatus status = new DefaultStatus();
        string strDefault = DefaultStatus.STR_DEFAULT;
        string[] transactionType = {"Damage Product", "Sample Product", "Transfer Product"};
        int productId = 0;
        int quantity = 0;
        int warehouseId = 0;
        string remarks = "";
        bool firstLoad = true;

        /*
         * Things to do:
         * 1. 
         * 2. 
         * 3. View Sample Transactions
         * 4. View Transfer Transactions
         * 5. View Damage Transactions
        */

        public AdjustmentForm()
        {
            InitializeComponent();
        }

        private void AdjustmentForm_Load(object sender, EventArgs e)
        {
            int i = 0;
            strDefault = strDefault;

            //add transactions
            comboBoxTransaction.Items.Add(strDefault);
            int transLength = transactionType.Length;
            for (i = 0; i < transLength; i++)
            {
                comboBoxTransaction.Items.Add(transactionType[i]);
            }
            comboBoxTransaction.SelectedItem = strDefault;

            //add warehouse
            comboBoxWarehouse.Items.Add(strDefault);
            comboBoxAssignWarehouse.Items.Add(strDefault);
            warehouseList = filter.fetchWarehouse();
            int warehouseLen = warehouseList.Length;
            for (i = 0; i < warehouseLen; i++)
            {
                comboBoxWarehouse.Items.Add(warehouseList[i]);
                comboBoxAssignWarehouse.Items.Add(warehouseList[i]);
            }
            comboBoxWarehouse.SelectedItem = strDefault;            
            comboBoxAssignWarehouse.SelectedItem = strDefault;

            comboBoxAssignWarehouse.Enabled = false;
            firstLoad = false;            
        }

        private void filterCategory()
        {
            categoryList = filter.selectCategory();
            if (categoryList != null)
            {
                //add data to combobox
                int catLength = categoryList.Length;
                for (int i = 0; i < catLength; i++)
                {
                    comboBoxTransaction.Items.Add(categoryList[i].ToString());
                }
            }
        }

        private void filterSubcategory()
        {
            if (subcategoryList != null)
            {
                int subLength = subcategoryList.Length;
                for (int i = 0; i < subLength; i++)
                {
                    comboBoxWarehouse.Items.Add(subcategoryList[i].ToString());
                }
            }
        }

        /*
         * display warehouses
         */
        private void displayWarehouse()
        {            
            warehouseList = filter.fetchWarehouse();         
            if (warehouseList != null)
            {
                int warehouseLen = warehouseList.Length;
                //add data to warehouse selection
                for (int i = 0; i < warehouseLen; i++)
                {
                    comboBoxAssignWarehouse.Items.Add(warehouseList[i].ToString());
                }
            }
        }

        private void textBoxQuantityToAdd_TextChanged(object sender, EventArgs e)
        {
            textBoxQuantityToAdd.Text = filter.validateIntegerInput(textBoxQuantityToAdd.Text.Trim());
            textBoxQuantityToAdd.SelectionStart = textBoxQuantityToAdd.Text.Length;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSearchProduct_Click(object sender, EventArgs e)
        {
            string[] productInformation;
            SearchProduct search = new SearchProduct();
            search.ShowDialog();
            if (GlobalVariables.productID != "" && GlobalVariables.productID != null)
            {
                //display product information
                productId = Convert.ToInt16(GlobalVariables.productID);
                GlobalVariables.productID = "";

                productInformation = filter.fetchProductInformation(productId);
                if (productInformation != null)
                {
                    textBoxProductName.Text = productInformation[1];
                    textBoxModel.Text = productInformation[2];
                    textBoxDescription.Text = productInformation[3];
                    textBoxBrand.Text = productInformation[4];
                    textBoxUnit.Text = productInformation[5];
                    textBoxSize.Text = productInformation[6];
                    textBoxColor.Text = productInformation[7];
                    textBoxCategory.Text = productInformation[8];
                    textBoxSubCategory.Text = productInformation[9];
                    textBoxSpecialFeature.Text = productInformation[10];
                    textBoxQuantityOnHand.Text = productInformation[11];

                    //display current quantity on warehouse
                    textBoxCurrentQuantity.Text = Convert.ToString(filter.fetchCurrentQuantityOnWarehouse(comboBoxWarehouse.SelectedItem.ToString(), productId));
                }
            }
            else
            {
                GlobalVariables.productID = "";
            }
        }

        private void comboBoxTransaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTransaction.SelectedItem == transactionType[2])
            {
                comboBoxAssignWarehouse.Enabled = true;
                if (firstLoad == false)
                {
                    toggleAssignWarehouse();                              
                }
            }
            else
            {
                comboBoxAssignWarehouse.Enabled = false;
                comboBoxAssignWarehouse.Items.Add(strDefault);
                textBoxQuantityOnWarehouse.Clear();
            }
        }

        private void toggleAssignWarehouse()
        {
            int len = 0,
                i = 0,
                j = 0;
            string[] filteredWarehouse;

            len = warehouseList.Length;
            filteredWarehouse = new string[len];

            for (i = 0; i < len; i++)
            {
                if (warehouseList[i].ToString() != comboBoxWarehouse.SelectedItem)
                {
                    filteredWarehouse[j] = warehouseList[i];
                    j++;
                }
            }

            len = filteredWarehouse.Length;
            //clear Assign warehouse combobox
            comboBoxAssignWarehouse.Items.Clear();
            comboBoxAssignWarehouse.Items.Add(strDefault);
            for (i = 0; i < len; i++)
            {
                if (filteredWarehouse[i] != null)
                {
                    comboBoxAssignWarehouse.Items.Add(filteredWarehouse[i].ToString());
                }
            }
            comboBoxAssignWarehouse.SelectedItem = strDefault;  
        }

        private void button2_Click(object sender, EventArgs e)
        {                    
            if (comboBoxTransaction.SelectedItem == strDefault)
            {
                MessageBox.Show("Choose the type of transaction.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboBoxWarehouse.SelectedItem == strDefault)
            {
                MessageBox.Show("Choose warehouse.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboBoxTransaction.SelectedItem == transactionType[2] && comboBoxAssignWarehouse.SelectedItem == strDefault)
            {
                MessageBox.Show("Assign a warehouse to transfer the product.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
            else if (productId == 0)
            {
                MessageBox.Show("Select a product.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBoxQuantityToAdd.Text.Trim() == "")
            {
                MessageBox.Show("Quantity is required.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToInt32(textBoxQuantityToAdd.Text.Trim()) == 0)
            {
                MessageBox.Show("Quantity is invalid.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                quantity = Convert.ToInt32(textBoxQuantityToAdd.Text.Trim());
                remarks = textBoxRemarks.Text.Trim();
                warehouseId = filter.fetchWarehouseId(comboBoxWarehouse.SelectedItem.ToString());
                bool result = false;

                //save the adjustment transaction
                if (comboBoxTransaction.SelectedItem == transactionType[0])
                {
                    result = insertDamageTransaction();
                }
                else if (comboBoxTransaction.SelectedItem == transactionType[1])
                {
                    result = insertSampleProductTransaction();
                }
                else if (comboBoxTransaction.SelectedItem == transactionType[2])
                {
                    //call transfer products function
                    result = insertTransferProductTransaction();
                }

                if (result != false)
                {
                    clearFields();
                }                
            }
        }

        /*
         * transfer products transaction
        */
        private bool insertTransferProductTransaction()
        {
            bool result = false;
            int toWarehouseId = filter.fetchWarehouseId(comboBoxAssignWarehouse.SelectedItem.ToString());

            result = filter.saveTransferOfProducts(productId, warehouseId, toWarehouseId, quantity, remarks);
            if (result == true)
            {
                toolTipSuccess.Show("Successfully recorded.", labelSuccess, 10000);
            }
            else
            {
                toolTipError.Show("An error occured, please try again.", labelError, 10000);
            }

            return result;
        }

        /*
         * This function calls sample product transaction
        */
        private bool insertSampleProductTransaction()
        {
            bool result = false;
            result = filter.deductSampleProducts(productId, warehouseId, quantity, GlobalVariables.profileID, remarks);
            if (result == true)
            {
                toolTipSuccess.Show("Successfully recorded.", labelSuccess, 10000);
            }
            else
            {
                toolTipError.Show("An error occured, please try again.", labelError, 10000);
            }
            return result;
        }


        /* deduct damaged products */
        private bool insertDamageTransaction()
        {
            bool result = false;
            result = filter.saveDamagedProducts(productId, quantity, remarks, GlobalVariables.profileID, warehouseId);
            if (result == true)
            {
                toolTipSuccess.Show("Successfully recorded.", labelSuccess, 10000);
            }
            else
            {
                toolTipError.Show("An error occured, please try again.", labelError,10000);
            }
            return result;
        }

        private void comboBoxAssignWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAssignWarehouse.SelectedItem != strDefault)
            {
                //display quantity of products in a particular warehouse
                textBoxQuantityOnWarehouse.Text = Convert.ToString(filter.fetchCurrentQuantityOnWarehouse(comboBoxAssignWarehouse.SelectedItem.ToString(), productId));
            }
            else
            {
                textBoxQuantityOnWarehouse.Text = "0";
            }
        }

        /*
         * reset all fields
        */ 
        private void clearFields()
        {
            comboBoxTransaction.SelectedItem = strDefault;
            comboBoxWarehouse.SelectedItem = strDefault;
            textBoxProductName.Clear();
            textBoxModel.Clear();
            textBoxBrand.Clear();
            textBoxSpecialFeature.Clear();
            textBoxDescription.Clear();
            textBoxUnit.Clear();
            textBoxSize.Clear();
            textBoxSubCategory.Clear();
            textBoxCategory.Clear();
            textBoxColor.Clear();
            textBoxQuantityOnHand.Clear();
            textBoxRemarks.Clear();
            textBoxQuantityToAdd.Clear();
            comboBoxAssignWarehouse.SelectedItem = strDefault;
            textBoxQuantityOnWarehouse.Clear();
            comboBoxTransaction.Focus();
            textBoxCurrentQuantity.Clear();
            productId = 0;
            quantity = 0;
            warehouseId = 0;
            remarks = "";
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void comboBoxWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxWarehouse.SelectedItem != strDefault && productId != 0)
            {
                textBoxCurrentQuantity.Text = Convert.ToString(filter.fetchCurrentQuantityOnWarehouse(comboBoxWarehouse.SelectedItem.ToString(), productId));
            }

            if (comboBoxTransaction.SelectedItem == transactionType[2])
            {
                comboBoxAssignWarehouse.Enabled = true;
                toggleAssignWarehouse();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.openAnotherForm(this, e);
        }
    }
}
