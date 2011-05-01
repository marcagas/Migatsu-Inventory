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
    public partial class AddInventory : Form
    {
        GlobalVariables gd = new GlobalVariables();
        DefaultStatus status = new DefaultStatus();
        FilterFunctions filterFunc = new FilterFunctions();

        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        
        string strSelect,
               defaultSelect = DefaultStatus.STR_DEFAULT,
               result = "";

        int productID = 0,
            supplierID = 0,
            profileId = 0,
            existingRow;

        bool productExist = false,
             formChanges = false;
        DataTable table;               

        public AddInventory()
        {
            InitializeComponent();
        }

        private void AddInventory_Load(object sender, EventArgs e)
        {
            populateWarehouse();
            populateProductList();
            displayProductStatus();
            profileId = GlobalVariables.profileID;
            defaultSelect =  DefaultStatus.STR_DEFAULT;
        }

        private void populateWarehouse()
        {
            string[] warehouseList;
            warehouseList = filterFunc.fetchWarehouse();
            
            //add default selected
            comboBoxWarehouse.Items.Add(defaultSelect);
            int warehouseLen = warehouseList.Length;
            for (int i = 0; i < warehouseLen; i++)
            {
                comboBoxWarehouse.Items.Add(warehouseList[i]);
            }
            comboBoxWarehouse.SelectedItem = defaultSelect;

            /*
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            strSelect = "SELECT Warehouse_Name FROM WAREHOUSE";
            cmd = new SqlCommand(strSelect, conn);
            dr = cmd.ExecuteReader();

            //add default warehouse
            comboBoxWarehouse.Items.Add(defaultSelect);

            if(dr.HasRows)
            {
                while (dr.Read())
                {
                    comboBoxWarehouse.Items.Add(dr["Warehouse_Name"].ToString());
                }
                dr.Close();
            }

            //select default warehouse
            comboBoxWarehouse.SelectedItem = "Select...";

            conn.Close();*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SearchProduct spf = new SearchProduct();
            //spf.MdiParent = this.MdiParent;
            spf.ShowDialog();
            if (GlobalVariables.productID != "" && GlobalVariables.productID != null)
            {
                productID = Convert.ToInt16(GlobalVariables.productID);
                GlobalVariables.productID = "";
                //display product information to the input boxes
                conn = new SqlConnection(gd.ConString);
                conn.Open();

                strSelect = "SELECT Product_Name, Model, Brand, Special_Feature, Description, Unit, Size, " +
                            "Color, Sub_Category_Name, Category_Name FROM View_Product_List where ID = @productID";
                cmd = new SqlCommand(strSelect, conn);
                cmd.Parameters.Add(new SqlParameter("productID", (object)productID));

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBoxProductName.Text = dr["Product_Name"].ToString();
                        textBoxModel.Text = dr["Model"].ToString();
                        textBoxBrand.Text = dr["Brand"].ToString();
                        textBoxSpecialFeature.Text = dr["Special_Feature"].ToString();
                        textBoxDescription.Text = dr["Description"].ToString();
                        textBoxUnit.Text = dr["Unit"].ToString();
                        textBoxSize.Text = dr["Size"].ToString();
                        textBoxColor.Text = dr["Color"].ToString();
                        textBoxSubCategory.Text = dr["Sub_Category_Name"].ToString();
                        textBoxCategory.Text = dr["Category_Name"].ToString();
                        formChanges = true;
                    }
                    dr.Close();
                }

                conn.Close();                
            }
            else
            {
                GlobalVariables.productID = "";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (formChanges == true)
            {
                int ans;
                ans = (int)MessageBox.Show(status.MSG_UNSAVE_TRANSACTION, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == 6)
                {
                    Close();
                }
            }
            else
            {
                Close();
            }
        }

        private void linkLabelRemoveAllData_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int ans;
            ans = (int)MessageBox.Show(status.MSG_REMOVE_ALL_DATA, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == 6)
            {
                clearFields();
                populateProductList();
            }
        }

        private void linkLabelClearFields_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clearFields();
        }

        private void clearFields()
        {
            textBoxProductName.Clear();
            textBoxModel.Clear();
            textBoxBrand.Clear();
            textBoxSpecialFeature.Clear();
            textBoxDescription.Clear();
            textBoxUnit.Clear();
            textBoxSize.Clear();
            textBoxColor.Clear();
            textBoxSubCategory.Clear();
            textBoxCategory.Clear();
            textBoxSupplier.Clear();
            textBoxPurchaseOrderNumber.Clear();
            textBoxQuantityToAdd.Clear();

            comboBoxWarehouse.SelectedItem = defaultSelect;
            buttonSearchProduct.Focus();
        }

        private void populateProductList()
        {
            table = new DataTable();
            table.Columns.Add(status.COL_PROD_ID);
            table.Columns.Add(status.COL_PROD_NAME);
            table.Columns.Add(status.COL_QUANTITY);
            table.Columns.Add(status.COL_WAREHOUSE);
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
        }

        private void linkLabelClearList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            populateProductList();
            displayProductStatus();
        }

        private void displayProductStatus()
        {
            int rowCount = dataGridViewProductList.RowCount;
            toolStripProductStatus.Text = status.NUMBER_OF_PRODUCTS + Convert.ToString(rowCount);
        }

        private void buttonSearchSupplier_Click(object sender, EventArgs e)
        {
            SearchSupplier supplier = new SearchSupplier();
            supplier.ShowDialog();
            if (GlobalVariables.supplierID != "" && GlobalVariables.supplierID != null)
            {
                supplierID = Convert.ToInt16(GlobalVariables.supplierID);

                string[] supplierDetails = filterFunc.fetchSupplierDetails(supplierID);
                if (supplierDetails != null)
                {
                    textBoxSupplier.Text = supplierDetails[0];
                    formChanges = true;
                }
                /*
                //select supplier info name
                conn = new SqlConnection(gd.ConString);
                conn.Open();

                strSelect = "SELECT Company_Name from SUPPLIER where Supplier_ID = @supplierID";
                cmd = new SqlCommand(strSelect, conn);
                cmd.Parameters.Add(new SqlParameter("supplierID", (object)supplierID));
                textBoxSupplier.Text = Convert.ToString(cmd.ExecuteScalar());*/
                
                GlobalVariables.supplierID = "";
            }
            else
            {
                GlobalVariables.supplierID = "";
            }
        }

        private void textBoxQuantityToAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
                e.Handled = true;
             */            
        }

        private void textBoxQuantityToAdd_TextChanged(object sender, EventArgs e)
        {
            textBoxQuantityToAdd.Text = filterFunc.validateIntegerInput(textBoxQuantityToAdd.Text.Trim());
            textBoxQuantityToAdd.SelectionStart = textBoxQuantityToAdd.Text.Length;            
        }

        private void buttonAddToList_Click(object sender, EventArgs e)
        {
            if (textBoxProductName.Text.Trim() == "")
            {
                MessageBox.Show(status.MSG_SELECT_PROD_TO_ADD, status.MSG_TITLE_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBoxQuantityToAdd.Text.Trim() == "")
            {
                MessageBox.Show(status.MSG_ENTER_PROD_QUANTITY, status.MSG_TITLE_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToInt16(textBoxQuantityToAdd.Text.Trim()) <= 0)
            {
                MessageBox.Show(status.MSG_INVALID_PROD_QUANTITY, status.MSG_TITLE_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboBoxWarehouse.SelectedItem == defaultSelect)
            {
                MessageBox.Show(status.MSG_SELECT_WAREHOUSE_TO_KEEP, status.MSG_TITLE_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //check if product was already entered
                int rowCount = dataGridViewProductList.RowCount;
                productExist = false;

                for (int i = 0; i < rowCount; i++)
                {
                    if (productID == Convert.ToInt16(dataGridViewProductList[0, i].Value.ToString()))
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
                    table.Rows.Add(productID, textBoxProductName.Text.Trim(), textBoxQuantityToAdd.Text.Trim(), comboBoxWarehouse.SelectedItem.ToString().Trim(), textBoxModel.Text.Trim(), textBoxBrand.Text.Trim(), textBoxSpecialFeature.Text.Trim(), textBoxDescription.Text.Trim(), textBoxUnit.Text.Trim(), textBoxSize.Text.Trim(), textBoxColor.Text.Trim());
                }
                unselectProductList();
                displayProductStatus();
            }
        }

        private void unselectProductList()
        {
            int rowCount = dataGridViewProductList.RowCount;
            for (int i = 0; i < rowCount; i++)
            {
                dataGridViewProductList[status.COL_PROD_NAME, i].Selected = false;
            }
        }

        private void linkLabelDeleteSelectedItem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

            //unselect data
            unselectProductList();
            displayProductStatus();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                //insert products to inventory
                conn = new SqlConnection(gd.ConString);
                conn.Open();

                int rowCount = dataGridViewProductList.RowCount;
                if (rowCount == 0)
                {
                    MessageBox.Show(status.MSG_NO_PRODUCT_ENTERED, status.MSG_TITLE_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBoxSupplier.Text.Trim() == "")
                {
                    MessageBox.Show(status.MSG_SELECT_SUPPLIER, status.MSG_TITLE_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBoxPurchaseOrderNumber.Text.Trim() == "")
                {
                    MessageBox.Show(status.MSG_ENTER_PURCHASEORDERNUM, status.MSG_TITLE_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    for (int i = 0; i < rowCount; i++)
                    {
                        string strInsert = "INSERT INTO INVENTORY (Product_ID, Warehouse_ID, Quantity, Transaction_Type, " +
                                           "Supplier_ID, Purchase_Order_Number, Profile_ID, Date_Of_Transaction) values(@productId, @warehouseID, " +
                                           "@quantity, @transactionType, @supplierID, @purchaseOrderNumber, @profileID, @dateOfTransaction)";
                        SqlCommand insertCmd = new SqlCommand(strInsert, conn);
                        insertCmd.Parameters.Add(new SqlParameter("productID", (object)Convert.ToInt16(dataGridViewProductList[0, i].Value.ToString())));
                        insertCmd.Parameters.Add(new SqlParameter("warehouseID", (object)getWarehouseID(dataGridViewProductList["Warehouse", i].Value.ToString())));
                        insertCmd.Parameters.Add(new SqlParameter("quantity", (object)Convert.ToInt32(dataGridViewProductList["Quantity", i].Value.ToString())));
                        insertCmd.Parameters.Add(new SqlParameter("transactionType", (object)1));
                        insertCmd.Parameters.Add(new SqlParameter("supplierID", (object)supplierID));
                        insertCmd.Parameters.Add(new SqlParameter("purchaseOrderNumber", (object)textBoxPurchaseOrderNumber.Text.Trim()));
                        insertCmd.Parameters.Add(new SqlParameter("profileID", (object)profileId));
                        insertCmd.Parameters.Add(new SqlParameter("dateOfTransaction", (object)DateTime.Now));

                        insertCmd.ExecuteNonQuery();
                    }

                    if (rowCount == 1)
                    {
                        MessageBox.Show(status.MSG_PRODUCT_SUCCESSFULLY_SAVED, status.MSG_TITLE_SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(status.MSG_PRODUCTS_SUCCESSFULLY_SAVED, status.MSG_TITLE_SUCCESS, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    clearFields();
                    populateProductList();
                    formChanges = false;
                }

                conn.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private int getWarehouseID(string warehouse)
        {
            
            int warehouseId = 0;
            warehouseId = filterFunc.fetchWarehouseId(warehouse);
            /*
            strSelect = "SELECT ID from WAREHOUSE where Warehouse_Name = @warehouseName";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("warehouseName", (object)warehouse));
            warehouseID = Convert.ToInt16(cmd.ExecuteScalar());
            */
            return warehouseId;
        }
    }
}
