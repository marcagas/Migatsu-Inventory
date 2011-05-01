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
    public partial class SearchProduct : Form
    {
        GlobalVariables gd = new GlobalVariables();
        SqlDataReader dr;
        SqlCommand cmd;
        SqlConnection conn;
        DataSet ds;
        SqlDataAdapter da;
        string defaultSelect = "Select...";
        string strSelect = "";
        bool onload = false;
        string productID = "";
        string searchProdName = "Product Name",
               searchModel = "Model",
               searchBrand = "Brand",
               searchDescription = "Description";

        public SearchProduct()
        {
            InitializeComponent();
        }

        private void SearchProduct_Load(object sender, EventArgs e)
        {
            populateProductList();
            populateCategory();
            populateSpecialFeature();
            populateUnit();
            populateSize();
            populateColor();
            unselectData();

            //by default set subcategory 
            comboBoxSubCategory.Items.Add("Select category...");
            comboBoxSubCategory.Enabled = false;
            comboBoxSubCategory.SelectedIndex = 0;

            comboBoxSearchBy.Items.Add(searchProdName);
            comboBoxSearchBy.Items.Add(searchModel);
            comboBoxSearchBy.Items.Add(searchBrand);
            comboBoxSearchBy.Items.Add(searchDescription);
            comboBoxSearchBy.SelectedIndex = 0;

            onload = true;           
        }

        private void unselectData()
        {
            int numRows = dataGridViewProductList.RowCount;
            for (int i = 0; i < numRows; i++)
            {
                dataGridViewProductList["Product Name", i].Selected = false;
            }

            toolStripStatusLabelProducts.Text = "Products: " + Convert.ToString(numRows);
        }

        private void populateColor()
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            strSelect = "SELECT Color from COLOR";
            cmd = new SqlCommand(strSelect, conn);
            dr = cmd.ExecuteReader();

            comboBoxColor.Items.Add(defaultSelect);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    comboBoxColor.Items.Add(dr["Color"].ToString());
                }
                dr.Close();
            }

            comboBoxColor.SelectedIndex = 0;

            conn.Close();
        }

        private void populateSize()
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            strSelect = "SELECT Size from SIZE";
            cmd = new SqlCommand(strSelect, conn);
            dr = cmd.ExecuteReader();

            //add default select
            comboBoxSize.Items.Add(defaultSelect);

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    comboBoxSize.Items.Add(dr["Size"].ToString());
                }
                dr.Close();
            }
            comboBoxSize.SelectedIndex = 0;
            conn.Close();
        }

        private void populateUnit()
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            strSelect = "SELECT Unit from UNIT";
            cmd = new SqlCommand(strSelect, conn);
            
            //add default "Select..."
            comboBoxUnit.Items.Add(defaultSelect);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    comboBoxUnit.Items.Add(dr["Unit"].ToString());
                }
                dr.Close();
            }
            comboBoxUnit.SelectedIndex = 0;
            conn.Close();
        }

        private void populateSpecialFeature()
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            strSelect = "SELECT Special_Feature from SPECIALFEATURE";
            cmd = new SqlCommand(strSelect, conn);

            //add "Select...";
            comboBoxSpecialFeature.Items.Add(defaultSelect);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    comboBoxSpecialFeature.Items.Add(dr["Special_Feature"].ToString());
                }
                dr.Close();
            }
            comboBoxSpecialFeature.SelectedIndex = 0;

            conn.Close();
        }

        private void populateSubCategory()
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            strSelect = "SELECT Sub_Category_Name from SUBCATEGORY where Category_ID = @categoryID;";
            SqlCommand scmd = new SqlCommand(strSelect, conn);
            scmd.Parameters.Add(new SqlParameter("categoryID", (object)getCategoryID()));
            dr = scmd.ExecuteReader();
            comboBoxSubCategory.Items.Clear();         
            
            //add to subcategory "Select..."
            comboBoxSubCategory.Items.Add(defaultSelect);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    comboBoxSubCategory.Items.Add(dr["Sub_Category_Name"].ToString());
                }
                dr.Close();
                
            }
            comboBoxSubCategory.SelectedIndex = 0;
            comboBoxSubCategory.Enabled = true;
            conn.Close();            
            return;
        }

        private int getCategoryID()
        {
            int categoryID;

            strSelect = "SELECT ID from CATEGORY where Category_Name = @categoryName";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("categoryName", (object)comboBoxCategory.SelectedItem));
            categoryID = Convert.ToInt32(cmd.ExecuteScalar());
 
            return categoryID;           
            
        }

        private void populateCategory()
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            strSelect = "SELECT Category_Name from CATEGORY";
            cmd = new SqlCommand(strSelect, conn);
            comboBoxCategory.Items.Add(defaultSelect);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    comboBoxCategory.Items.Add(dr["Category_Name"].ToString());
                }
                dr.Close();
            }

            //default selected item is 'Select...'
            comboBoxCategory.SelectedIndex = 0;

        }

        private void populateProductList()
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();
        
            //select product info from database
            strSelect = "SELECT ID, Product_Name as \"Product Name\", Model as Model, Description as Description, " +
                               "Brand as Brand, Size as Size, Unit as Unit, Color as Color, category_name as Category, sub_category_name "+
                               "as \"Sub Category\", Special_feature as \"Special Feature\" from view_product_list";
            cmd = new SqlCommand(strSelect, conn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet("ds");
            da.Fill(ds);
            ds.Tables[0].TableName = "tableData";
            dataGridViewProductList.DataSource = ds.Tables["tableData"];
            
            conn.Close();

            //hide product ID column from datagridview
            dataGridViewProductList.Columns["ID"].Visible = false;
            dataGridViewProductList.AllowUserToOrderColumns = false;
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCategory.SelectedItem.ToString() != defaultSelect)
            {
                populateSubCategory();
            }
            else
            {
                comboBoxSubCategory.Enabled = false;
                comboBoxSubCategory.Items.Clear();
                comboBoxSubCategory.Items.Add("Select category...");
                comboBoxSubCategory.SelectedIndex = 0;
            }
            if (onload == true)
            {
                filterProductList();
            }
        }

        private bool needsFilter()
        {
            if(comboBoxSearchBy.SelectedItem != defaultSelect)
            {
                return true;
            }
            else if(comboBoxCategory.SelectedItem != defaultSelect)
            {
                return true;
            }
            else if (comboBoxSubCategory.SelectedItem != defaultSelect)
            {
                return true;
            }
            else if (comboBoxSpecialFeature.SelectedItem != defaultSelect)
            {
                return true;
            }
            else if (comboBoxUnit.SelectedItem != defaultSelect)
            {
                return true;
            }
            else if (comboBoxSize.SelectedItem != defaultSelect)
            {
                return true;
            }
            else if (comboBoxColor.SelectedItem != defaultSelect)
            {
                return true;
            }
            else
            {
                return false;
            }
            return false;
        }

        private void filterProductList()
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            try
            {
                string strSelect;
                
                strSelect = string.Format("select id as ID, product_name as \"Product Name\", model as Model, "+
                            "description as Description, brand as Brand, unit as Unit, color as Color, category_name "+
                            "as Category, sub_category_name as \"Sub Category\", Special_feature as \"Special Feature\" "+
                            "from view_product_list where ");

                //filter for search by
                if (comboBoxSearchBy.SelectedItem == searchProdName)
                {
                    strSelect += "Product_name like '%" + textBoxKeyword.Text + "%'";
                }

                if (comboBoxSearchBy.SelectedItem == searchBrand)
                {
                    strSelect += "Brand like '%" + textBoxKeyword.Text + "%'";
                }

                if (comboBoxSearchBy.SelectedItem == searchModel)
                {
                    strSelect += "model like '%" + textBoxKeyword.Text + "%'";
                }

                if (comboBoxSearchBy.SelectedItem == searchDescription)
                {
                    strSelect += "description like '%" + textBoxKeyword.Text + "%'";
                }

                //MessageBox.Show(strSelect);

                //filter for category
                if (comboBoxCategory.SelectedIndex != 0)
                {
                    strSelect += " and category_name = '" + comboBoxCategory.SelectedItem + "'";
                }

                if (comboBoxSubCategory.SelectedIndex != 0)
                {
                    strSelect += " and sub_category_name= '" + comboBoxSubCategory.SelectedItem + "'";
                }

                //filter for unit
                if (comboBoxUnit.SelectedIndex != 0)
                {
                    strSelect += " and unit = '" + comboBoxUnit.SelectedItem + "'";
                }

                //filter for size
                if (comboBoxSize.SelectedIndex != 0)
                {
                    strSelect += " and size = '" + comboBoxSize.SelectedItem + "'";
                }

                //filter for color
                if (comboBoxColor.SelectedIndex != 0)
                {
                    strSelect += " and color = '" + comboBoxColor.SelectedItem + "'";
                }

                //filter for special feature
                if (comboBoxSpecialFeature.SelectedIndex != 0)
                {
                    strSelect += " and special_feature = '" + comboBoxSpecialFeature.SelectedItem + "'";
                }

                cmd = new SqlCommand(strSelect, conn);

                da = new SqlDataAdapter(cmd);
                ds = new DataSet("ds");
                da.Fill(ds);
                ds.Tables[0].TableName = "table_mirror";
                dataGridViewProductList.DataSource = ds.Tables["table_mirror"];

                //hide product ID column from datagridview
                dataGridViewProductList.Columns["ID"].Visible = false;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
            dataGridViewProductList.AllowUserToOrderColumns = false;
            unselectData();
            conn.Close();

            //set productID to empty string

        }

        private void textBoxKeyword_TextChanged(object sender, EventArgs e)
        {
            if (onload == true)
            {
                filterProductList();
            }
        }

        private void comboBoxSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (onload == true)
            {
                filterProductList();
            }
        }

        private void comboBoxSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (onload == true)
            {
                filterProductList();
            }
        }

        private void comboBoxSpecialFeature_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (onload == true)
            {
                filterProductList();
            }
        }

        private void comboBoxUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (onload == true)
            {
                filterProductList();
            }
        }

        private void comboBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (onload == true)
            {
                filterProductList();
            }
        }

        private void comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (onload == true)
            {
                filterProductList();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (productID != "" && productID != null)
            {
                if (dataGridViewProductList.SelectedCells.Count > 0)
                {
                    GlobalVariables.productID = productID;
                }
                Close();
            }
            else
            {
                MessageBox.Show("Select a product in the list.", "Note!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridViewProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row;
                row = e.RowIndex;
                productID = dataGridViewProductList["ID", row].Value.ToString();
            }
            catch (Exception)
            {
                populateProductList();
            }
        }
    }
}
