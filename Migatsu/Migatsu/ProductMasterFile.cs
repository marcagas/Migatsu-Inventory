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
    public partial class ProductMasterFile : Form
    {
        AutoCompleteStringCollection productNameCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection productBrandCollection = new AutoCompleteStringCollection();

        GlobalVariables gd = new GlobalVariables();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds;
        bool onLoad = true;

        public ProductMasterFile()
        {
            InitializeComponent();
        }

        private void ProductMasterFile_Load(object sender, EventArgs e)
        {
            //populate list
            populateTotalProductsList();
            populateWarehouse();
            populateSearchBy();            
        }

        private void populateWarehouse()
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strSelect = "SELECT Warehouse_Name from WAREHOUSE";
            cmd = new SqlCommand(strSelect, conn);
            dr = cmd.ExecuteReader();
            comboBoxWarehouse.Items.Add("Select...");
            comboBoxWarehouse.Items.Add("All");            
            if (dr.HasRows)
            {
                while(dr.Read())
                {
                    comboBoxWarehouse.Items.Add(dr["Warehouse_Name"].ToString());
                }
                dr.Close();
            }

            conn.Close();

            //select total products as default
            comboBoxWarehouse.SelectedIndex = 0;
        }

        private void populateSearchBy()
        {
            comboBoxSearchBy.Items.Add("Select...");
            comboBoxSearchBy.Items.Add("Product Name");
            comboBoxSearchBy.Items.Add("Product Brand");
            comboBoxSearchBy.SelectedIndex = 0;
        }

        private void populateTotalProductsList()
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strSelect = "SELECT [product id] as ID, Product_Name as [Product Name], Description, Brand, "+
                               "[quantity total] as Quantity from FINALVIEWWHOLEINVENTORY where IsArchived=0";
            cmd = new SqlCommand(strSelect, conn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet("ds");
            da.Fill(ds);
            ds.Tables[0].TableName = "table";
            dataGridViewProductList.DataSource = ds.Tables["table"];

            conn.Close();
            onLoad = false;
        }

        private void comboBoxWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateMasterFile();
        }

        private void populateMasterFile()
        {
            int selectedRow = 0;
            //select row that was selected previously
            //check if assigning of selected row was after the first load of productlist
            if (onLoad == false)
            {
                selectedRow = Convert.ToInt32(dataGridViewProductList.CurrentCell.RowIndex);
            }

            //check if total products will be displayed
            if (comboBoxWarehouse.SelectedIndex == 1)
            {
                populateTotalProductsList();
            }
            //if product list requested is by warehouse
            else if (comboBoxWarehouse.SelectedIndex != 0 && comboBoxWarehouse.SelectedIndex != 1)
            {
                populateProductListByWarehouse();
            }

            //select previous selected row
            if (onLoad == false)
            {
                dataGridViewProductList["Product Name", selectedRow].Selected = true;
            }
            displayNumberOfProducts();

            //hide first the ID col
            dataGridViewProductList.Columns["ID"].Visible = false;

        }

        private void populateAutoCompleteProductName()
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strSelect = "SELECT distinct(Product_Name) from PRODUCT where IsArchived=0";
            cmd = new SqlCommand(strSelect, conn);
            dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    productNameCollection.Add(dr[0].ToString());
                }
            }
            dr.Close();
            textBoxKeyword.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxKeyword.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBoxKeyword.AutoCompleteCustomSource = productNameCollection;
        }

        private void populateAutoCompleteProductBrand()
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strSelect = "SELECT distinct(Brand) from PRODUCT where IsArchived=0";
            cmd = new SqlCommand(strSelect, conn);
            dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    productNameCollection.Add(dr[0].ToString());
                }
            }
            dr.Close();
            textBoxKeyword.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxKeyword.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBoxKeyword.AutoCompleteCustomSource = productNameCollection;
        }

        private void displayNumberOfProducts()
        {
            int numberOfProducts = dataGridViewProductList.RowCount;
            toolStripProductStatus.Text = "Products: " + Convert.ToString(numberOfProducts);
            return;
        }

        private void populateProductListByWarehouse()
        {
            int warehouseID; //warehouse id
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strSelect = "SELECT ID FROM WAREHOUSE where Warehouse_Name=@warehouseName";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("warehouseName", (object)comboBoxWarehouse.SelectedItem.ToString()));

            warehouseID = Convert.ToInt32(cmd.ExecuteScalar());

            //populate product list of warehouse
            strSelect = "SELECT [product id] as ID, Product_Name as [Product Name], Description, Brand, " +
                        "[total quantity] as Quantity from FINALVIEWINVENTORY where IsArchived=0 and "+
                        "[warehouse id]=@warehouseID";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("warehouseID", (object)warehouseID));

            da = new SqlDataAdapter(cmd);
            ds = new DataSet("ds");
            da.Fill(ds);
            ds.Tables[0].TableName = "tableData";
            dataGridViewProductList.DataSource = ds.Tables["tableData"];

            conn.Close();
            onLoad = false;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            populateMasterFile();   
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //search product
            string prodCol;
            if (comboBoxSearchBy.SelectedIndex == 1)
            {
                prodCol = "Product Name";
                int rowCount = dataGridViewProductList.RowCount;
                for (int i = 0; i < rowCount; i++)
                {
                    if (dataGridViewProductList[prodCol, i].Value.ToString().ToLower() == textBoxKeyword.Text.Trim().ToLower())
                    {
                        dataGridViewProductList[prodCol, i].Selected = true;
                        dataGridViewProductList.CurrentCell.Selected = dataGridViewProductList[prodCol, i].Selected;
                        break;
                    }
                }
            }
            else if (comboBoxSearchBy.SelectedIndex == 2)
            {
                prodCol = "Brand";
                int rowCount = dataGridViewProductList.RowCount;
                for (int i = 0; i < rowCount; i++)
                {
                    if (dataGridViewProductList[prodCol, i].Value.ToString().ToLower() == textBoxKeyword.Text.Trim().ToLower())
                    {
                        dataGridViewProductList[prodCol, i].Selected = true;
                        dataGridViewProductList.CurrentCell.Selected = dataGridViewProductList[prodCol, i].Selected;
                    }
                }
            }
            else
            {
            }
        }

        private void comboBoxSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSearchBy.SelectedIndex == 1)
            {
                textBoxKeyword.AutoCompleteCustomSource.Clear();
                populateAutoCompleteProductName();
            }
            else if (comboBoxSearchBy.SelectedIndex == 2)
            {
                textBoxKeyword.AutoCompleteCustomSource.Clear();
                populateAutoCompleteProductBrand();
            }
            else
            {
                textBoxKeyword.AutoCompleteCustomSource.Clear();
            }
        }

        private void dataGridViewProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                //display product information
                conn = new SqlConnection(gd.ConString);
                conn.Open();

                string strSelect = "SELECT Product_Name, Model, Brand, Category_Name, Sub_Category_Name, " +
                                   "Description, Special_Feature, Unit, Size, Color, [quantity total] as Quantity from " +
                                   "FINALVIEWWHOLEINVENTORY where [product id]=@productID";
                cmd = new SqlCommand(strSelect, conn);
                cmd.Parameters.Add(new SqlParameter("productID", (object)Convert.ToInt32(dataGridViewProductList["ID", row].Value.ToString())));
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        textBoxProductName.Text = dr["Product_Name"].ToString();
                        textBoxModel.Text = dr["Model"].ToString();
                        textBoxBrand.Text = dr["Brand"].ToString();
                        textBoxCategory.Text = dr["Category_Name"].ToString();
                        textBoxSubCategory.Text = dr["Sub_Category_Name"].ToString();
                        textBoxDescription.Text = dr["Description"].ToString();
                        textBoxSpecialFeature.Text = dr["Special_Feature"].ToString();
                        textBoxUnit.Text = dr["Unit"].ToString();
                        textBoxSize.Text = dr["Size"].ToString();
                        textBoxColor.Text = dr["Color"].ToString();
                        textBoxQuantity.Text = dr["Quantity"].ToString();

                    }
                    dr.Close();
                }


                conn.Close();
            }
            catch (Exception x)
            {
            }
        }

    }
}
