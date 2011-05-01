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
    public partial class AddNewClientOrder : Form
    {
        GlobalVariables gd = new GlobalVariables();
        DefaultStatus status = new DefaultStatus();
        FilterFunctions filterFunc = new FilterFunctions();
        DataTable table = new DataTable();
        int productId = 0;
        int clientId = 0,
            existingRow,
            dataColumns = 2;
        bool formChanges = false;                               /* detects if the user writes on something in the form */
        bool productExist = false;
        /*
         * To do list:
         * 1. View client order transactions
         * 
         */
        public AddNewClientOrder()
        {
            InitializeComponent();
        }

        private void AddNewClientOrder_Load(object sender, EventArgs e)
        {
            //display sales order number
            textBoxSalesOrderNumber.Text = filterFunc.populateSalesNumber();
            textBoxProductName.Focus();
            populateDataTable();
        }

        private void buttonSearchProduct_Click(object sender, EventArgs e)
        {
            string[] productInformation;
            SearchProduct searchProd = new SearchProduct();
            searchProd.ShowDialog();
            if (GlobalVariables.productID != "" && GlobalVariables.productID != null)
            {
                //display product information
                productId = Convert.ToInt16(GlobalVariables.productID);
                GlobalVariables.productID = "";

                productInformation = filterFunc.fetchProductInformation(productId);
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
                    textBoxCurrentQuantity.Text = productInformation[11];

                    formChanges = true;
                }
            }
        }

        private void buttonSearchClient_Click(object sender, EventArgs e)
        {
            string[] clientDetails = new string[3];
            SearchClient client = new SearchClient();
            client.ShowDialog();

            if (GlobalVariables.clientId != "" && GlobalVariables.clientId != null)
            {
                clientId = Convert.ToInt16(GlobalVariables.clientId);
                GlobalVariables.supplierID = "";

                /* get supplier name */
                clientDetails = filterFunc.fetchClientDetails(clientId);
                if (clientDetails != null)
                {
                    textBoxClient.Text = clientDetails[0];
                    textBoxContactPerson.Text = clientDetails[1];
                    textBoxDeliveryAddress.Text = clientDetails[2];

                    formChanges = true;
                }                
            }
            return;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (formChanges == true)
            {
                int ans;
                ans = (int)MessageBox.Show(status.MSG_UNSAVE_TRANSACTION, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == 6)
                {
                    this.Close();
                }
            }
            else
            {
                Close();
            }
        }

        private void buttonAddToList_Click(object sender, EventArgs e)
        {
            // check if product is null
            if (textBoxProductName.Text.Trim() == "")
            {
                MessageBox.Show(status.MSG_SELECT_PRODUCT, status.MSG_TITLE_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // check if quantity is null or 0
            else if (textBoxQuantityToAdd.Text.Trim() == "")
            {
                MessageBox.Show(status.MSG_ENTER_PROD_QUANTITY, status.MSG_TITLE_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToInt16(textBoxQuantityToAdd.Text.Trim()) == 0)
            {
                MessageBox.Show(status.MSG_INVALID_PROD_QUANTITY, status.MSG_TITLE_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //check if product was already entered
                int rowCount = dataGridViewProductList.RowCount;
                int prodId = 0;     //product id in datagridview
                productExist = false;

                for (int i = 0; i < rowCount; i++)
                {
                    if (productId == Convert.ToInt16(dataGridViewProductList[0, i].Value.ToString()))
                    {
                        productExist = true;
                        existingRow = dataGridViewProductList[0, i].RowIndex;
                        break;
                    }
                }

                if (productExist == true)
                {
                    dataGridViewProductList[status.COL_QUANTITY, existingRow].Value = Convert.ToString(Convert.ToInt16(dataGridViewProductList[status.COL_QUANTITY, existingRow].Value.ToString()) + Convert.ToInt16(textBoxQuantityToAdd.Text.Trim()));
                }
                else
                {
                    table.Rows.Add(productId, textBoxProductName.Text.Trim(), textBoxQuantityToAdd.Text.Trim(), textBoxModel.Text.Trim(), textBoxBrand.Text.Trim(), textBoxSpecialFeature.Text.Trim(), textBoxDescription.Text.Trim(), textBoxUnit.Text.Trim(), textBoxSize.Text.Trim(), textBoxColor.Text.Trim());
                }
                unselectProductList();
                displayNumProdSelected();
            }
            
        }

        private void textBoxQuantityToAdd_TextChanged(object sender, EventArgs e)
        {
            textBoxQuantityToAdd.Text = filterFunc.validateIntegerInput(textBoxQuantityToAdd.Text.Trim());
            textBoxQuantityToAdd.SelectionStart = textBoxQuantityToAdd.Text.Length;
        }

        private void linkLabelClearFields_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clearFields();
        }

        /*
         * clear the fields in the form
         */
        private void clearFields()
        {
            textBoxProductName.Clear();
            textBoxCurrentQuantity.Clear();
            textBoxModel.Clear();
            textBoxBrand.Clear();
            textBoxSpecialFeature.Clear();
            textBoxDescription.Clear();
            textBoxUnit.Clear();
            textBoxSize.Clear();
            textBoxSubCategory.Clear();
            textBoxCategory.Clear();
            textBoxColor.Clear();
            textBoxClient.Clear();
            textBoxContactPerson.Clear();
            textBoxDeliveryAddress.Clear();
            textBoxQuantityToAdd.Clear();

            //populate new sales number
            textBoxSalesOrderNumber.Text = filterFunc.populateSalesNumber();
            buttonSearchProduct.Focus();
            clientId = 0;
            productId = 0;
            formChanges = false;       
        }

        /*
         * populate the table for products
         */
        private void populateDataTable()
        {
            table = new DataTable();
            table.Columns.Add(status.COL_PROD_ID);
            table.Columns.Add(status.COL_PROD_NAME);
            table.Columns.Add(status.COL_QUANTITY);
            table.Columns.Add(status.COL_PROD_MODEL);
            table.Columns.Add(status.COL_PROD_BRAND);
            table.Columns.Add(status.COL_PROD_SPEC_FEATURE);
            table.Columns.Add(status.COL_PROD_DESCRIPTION);
            table.Columns.Add(status.COL_PROD_UNIT);
            table.Columns.Add(status.COL_PROD_SIZE);
            table.Columns.Add(status.COL_PROD_COLOR);

            //hide product ID column
            dataGridViewProductList.DataSource = table;
            dataGridViewProductList.Columns[status.COL_PROD_ID].Visible = false;
            displayNumProdSelected();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {            
            populateDataTable();
            displayNumProdSelected();
        }

        private void linkLabelRemoveAllData_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (formChanges == true)
            {
                int ans = 0;
                ans = (int)MessageBox.Show(status.MSG_REMOVE_ALL_DATA, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == 6)
                {
                    clearFields();
                    populateDataTable();
                    formChanges = false;
                }
            }
            else
            {
                clearFields();
                populateDataTable();               
            }
            
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int rowCount = dataGridViewProductList.RowCount;
            for (int i = 0; i < rowCount; i++)
            {
                if (dataGridViewProductList[0, i].Selected == true)
                {
                    dataGridViewProductList.Rows.RemoveAt(dataGridViewProductList.CurrentCell.RowIndex);
                    break;
                }
            }
            
        }

        /*
         * display number of products selected for order
         */
        private void displayNumProdSelected()
        {
            int numOfRows = dataGridViewProductList.RowCount;
            toolStripTotalProducts.Text = status.NUMBER_OF_PRODUCTS + Convert.ToString(numOfRows);
        }

        /*
         * this function unselects all data in the datagridview
         */
        private void unselectProductList()
        {
            int rowCount = dataGridViewProductList.RowCount;
            for (int i = 0; i < rowCount; i++)
            {
                dataGridViewProductList[status.COL_PROD_NAME, i].Selected = false;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int numOfProducts = dataGridViewProductList.RowCount;

            // no products were selected in the list
            if (numOfProducts <= 0)
            {
                MessageBox.Show(status.MSG_NO_PRODUCT_ORDERED, status.MSG_TITLE_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // check if no client was selected
            else if (textBoxClient.Text.Trim() == "")
            {
                MessageBox.Show(status.MSG_ENTER_CLIENT, status.MSG_TITLE_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // if sales number is none
            else if (textBoxSalesOrderNumber.Text.Trim() == "")
            {
                MessageBox.Show(status.MSG_ENTER_SALESNUMBER, status.MSG_TITLE_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int rows = dataGridViewProductList.RowCount;                
                string[] orderData = new string[6];            
                string[,] orderDetails = new string[rows, dataColumns];
                orderData[0] = textBoxSalesOrderNumber.Text.Trim();
                orderData[1] = textBoxContactPerson.Text.Trim();
                orderData[2] = Convert.ToString(clientId);
                orderData[3] = DateTime.Now.ToShortDateString();
                orderData[4] = Convert.ToString(GlobalVariables.profileID);
                orderData[5] = textBoxDeliveryAddress.Text.Trim();

                for (int i = 0; i < rows; i++)
                {
                    orderDetails[i, 0] = dataGridViewProductList[status.COL_PROD_ID, i].Value.ToString();
                    orderDetails[i, 1] = dataGridViewProductList[status.COL_QUANTITY, i].Value.ToString();
                }

                bool result = filterFunc.insertClientOrder(orderData, rows, orderDetails);
                if (result == true)
                {
                    MessageBox.Show(status.MSG_ORDER_SUCCESSFULLY_SAVED, status.MSG_TITLE_SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearFields();
                    populateDataTable();
                }
                else
                {
                    MessageBox.Show(status.MSG_INSERT_CLIENT_ORDER_ERROR, status.MSG_TITLE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }   
            }

        }
    }
}
