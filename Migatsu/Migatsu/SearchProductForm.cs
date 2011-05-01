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
    public partial class SearchProductForm : Form
    {
        GlobalVariables gd = new GlobalVariables();
        public SearchProductForm()
        {
            InitializeComponent();
            
            populateUnit();
            toolStripComboBoxSearchBy.SelectedIndex = 0;
            populateCategory();
            
            populateSize();
            populateColor();
            populateSpecialFeatures();
            populateWarehouse();
            showRecords();
        }

        public DataTable createProductDetailDT()
        {
            DataTable dtRecords = new DataTable();
            DataColumn recordColumn = new DataColumn();

            recordColumn.DataType = System.Type.GetType("System.Int32");
            recordColumn.ColumnName = "ID";
            recordColumn.Unique = true;
            dtRecords.Columns.Add(recordColumn);

            recordColumn = new DataColumn();
            recordColumn.DataType = System.Type.GetType("System.String");
            recordColumn.ColumnName = "Product_Name";
            dtRecords.Columns.Add(recordColumn);

            recordColumn = new DataColumn();
            recordColumn.DataType = System.Type.GetType("System.String");
            recordColumn.ColumnName = "Model";
            dtRecords.Columns.Add(recordColumn);

            recordColumn = new DataColumn();
            recordColumn.DataType = System.Type.GetType("System.String");
            recordColumn.ColumnName = "Description";
            dtRecords.Columns.Add(recordColumn);

            recordColumn = new DataColumn();
            recordColumn.DataType = System.Type.GetType("System.String");
            recordColumn.ColumnName = "Brand";
            dtRecords.Columns.Add(recordColumn);

            recordColumn = new DataColumn();
            recordColumn.DataType = System.Type.GetType("System.String");
            recordColumn.ColumnName = "Unit";
            dtRecords.Columns.Add(recordColumn);

            recordColumn = new DataColumn();
            recordColumn.DataType = System.Type.GetType("System.String");
            recordColumn.ColumnName = "Size";
            dtRecords.Columns.Add(recordColumn);

            recordColumn = new DataColumn();
            recordColumn.DataType = System.Type.GetType("System.String");
            recordColumn.ColumnName = "Color";
            dtRecords.Columns.Add(recordColumn);

            recordColumn = new DataColumn();
            recordColumn.DataType = System.Type.GetType("System.String");
            recordColumn.ColumnName = "Category_Name";
            dtRecords.Columns.Add(recordColumn);

            recordColumn = new DataColumn();
            recordColumn.DataType = System.Type.GetType("System.String");
            recordColumn.ColumnName = "Sub_Category_Name";
            dtRecords.Columns.Add(recordColumn);

            recordColumn = new DataColumn();
            recordColumn.DataType = System.Type.GetType("System.String");
            recordColumn.ColumnName = "Special_Feature";
            dtRecords.Columns.Add(recordColumn);

            recordColumn = new DataColumn();
            recordColumn.DataType = System.Type.GetType("System.String");
            recordColumn.ColumnName = "Warehouse_Name";
            dtRecords.Columns.Add(recordColumn);

            DataColumn[] pkColumns = new DataColumn[1];
            pkColumns[0] = dtRecords.Columns["ID"];
            dtRecords.PrimaryKey = pkColumns;

            return dtRecords;
        }

        public void showRecords()
        {
            SqlDataReader dr;
            SqlCommand cmd;
            SqlConnection conn;
            string query = "SELECT * FROM View_Product_List where ";
            
            if (toolStripComboBoxSearchBy.SelectedIndex == 0)
            {
                query += "Product_Name like '%' +@productName+ '%' ";
            }

            if (toolStripComboBoxSearchBy.SelectedIndex == 1)
            {
                query += "Brand like '%' +@productName+ '%' ";
            }

            if (toolStripComboBoxSearchBy.SelectedIndex == 2)
            {
                query += "Model like '%' +@productName+ '%' ";
            }

            if (toolStripComboBoxSearchBy.SelectedIndex == 3)
            {
                query += "Description like '%' +@productName+ '%' ";
            }
            //----------------------------------------------------------------------------------------------------
            if (toolStripComboBoxCategory.SelectedIndex != 0)
            {
                query += " and Category_Name = @categoryName ";
            }
            if (toolStripComboBoxSubCategory.SelectedIndex != 0)
            {
                query += "and Sub_Category_Name = @subCategoryName ";
            }
            //----------------------------------------------------------------------------------------------------
            if (toolStripComboBoxUnit.SelectedIndex != 0)
            {
                query += " and Unit = @unit ";
            }
            if (toolStripComboBoxSize.SelectedIndex != 0)
            {
                query += " and Size = @size ";
            }
            if (toolStripComboBoxColor.SelectedIndex != 0)
            {
                query += " and Color = @color ";
            }
            if (toolStripComboBoxSpecialFeature.SelectedIndex != 0)
            {
                query += " and Special_Feature = @specialFeature ";
            }
            if (toolStripComboBoxWarehouse.SelectedIndex != 0)
            {
                query += " and Warehouse_Name = @warehouse ";
            }

            try
            {
                conn = new SqlConnection(gd.ConString);
                conn.Open();

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@productName", (object)toolStripTextBox1.Text.Trim()));
                if (toolStripComboBoxCategory.SelectedIndex != 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@categoryName", (object)toolStripComboBoxCategory.SelectedItem.ToString()));
                }
                if (toolStripComboBoxSubCategory.SelectedIndex != 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@subCategoryName", (object)toolStripComboBoxSubCategory.SelectedItem.ToString()));
                }
                //------------------------------------------------------------------------------------------------------
                if (toolStripComboBoxUnit.SelectedIndex != 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@unit", (object)toolStripComboBoxUnit.SelectedItem.ToString()));
                }
                if (toolStripComboBoxSize.SelectedIndex != 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@size", (object)toolStripComboBoxSize.SelectedItem.ToString()));
                }
                if (toolStripComboBoxColor.SelectedIndex != 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@color", (object)toolStripComboBoxColor.SelectedItem.ToString()));
                }
                if (toolStripComboBoxSpecialFeature.SelectedIndex != 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@specialFeature", (object)toolStripComboBoxSpecialFeature.SelectedItem.ToString()));
                }
                if (toolStripComboBoxWarehouse.SelectedIndex != 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@warehouse", (object)toolStripComboBoxWarehouse.SelectedItem.ToString()));
                }
                dr = cmd.ExecuteReader();

                DataTable dtRecords = createProductDetailDT();
                DataRow recordRow = dtRecords.NewRow();
                int count = 0;
                while (dr.Read())
                {
                    recordRow = dtRecords.NewRow();

                    recordRow["ID"] = dr["ID"];
                    recordRow["Product_Name"] = dr["Product_Name"].ToString();
                    recordRow["Model"] = dr["Model"].ToString();
                    recordRow["Description"] = dr["Description"].ToString();
                    recordRow["Brand"] = dr["Brand"].ToString();
                    recordRow["Unit"] = dr["Unit"].ToString();
                    recordRow["Size"] = dr["Size"].ToString();
                    recordRow["Color"] = dr["Color"].ToString();
                    recordRow["Category_Name"] = dr["Category_Name"].ToString();
                    recordRow["Sub_Category_Name"] = dr["Sub_Category_Name"].ToString();
                    recordRow["Special_Feature"] = dr["Special_Feature"].ToString();
                    recordRow["Warehouse_Name"] = dr["Warehouse_Name"].ToString();

                    dtRecords.Rows.Add(recordRow);
                    count++;
                }
                dataGridView1.DataSource = dtRecords;
                toolStripStatusLabel1.Text = "Record/s found: " + count.ToString();

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Product Name";
                dataGridView1.Columns[8].HeaderText = "Category";
                dataGridView1.Columns[9].HeaderText = "Sub Category";
                dataGridView1.Columns[10].HeaderText = "Special Feature";
                dataGridView1.Columns[11].HeaderText = "Warehouse";

                conn.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public void populateCategory()
        {
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();
                string qry = string.Format("SELECT Category_Name from CATEGORY");
                gd.cmd = new SqlCommand(qry, gd.CN);
                gd.dr = gd.cmd.ExecuteReader();
                toolStripComboBoxCategory.Items.Add("Select Category...");
                toolStripComboBoxCategory.SelectedIndex = 0;
                while (gd.dr.Read())
                {
                    toolStripComboBoxCategory.Items.Add(string.Format("{0}", gd.dr[0]));
                }
                gd.dr.Close();
                gd.CN.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public void populateSubCategory()
        {
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();
                string qry = string.Format("SELECT Sub_Category_Name from SUBCATEGORY Where Category_ID = @categoryID");
                gd.cmd = new SqlCommand(qry, gd.CN);
                gd.cmd.Parameters.Add(new SqlParameter("@categoryID", (object)getCategoryID()));
                gd.dr = gd.cmd.ExecuteReader();
                toolStripComboBoxSubCategory.Items.Clear();
                toolStripComboBoxSubCategory.Items.Add("Select Sub Category...");
                toolStripComboBoxSubCategory.SelectedIndex = 0;
                if (gd.dr.HasRows)
                {
                    toolStripComboBoxSubCategory.Enabled = true;
                    while (gd.dr.Read())
                    {
                        toolStripComboBoxSubCategory.Items.Add(string.Format("{0}", gd.dr[0]));
                    }
                }
                else
                {
                    toolStripComboBoxSubCategory.Enabled = false;
                    toolStripComboBoxSubCategory.Items.Clear();
                    toolStripComboBoxSubCategory.Items.Add("No available Sub Category...");
                    toolStripComboBoxSubCategory.SelectedIndex = 0;
                }

                gd.CN.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public void populateSize()
        {
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();
                string qry = string.Format("SELECT Size from SIZE");
                gd.cmd = new SqlCommand(qry, gd.CN);
                gd.dr = gd.cmd.ExecuteReader();
                toolStripComboBoxSize.Items.Clear();
                toolStripComboBoxSize.Items.Add("All");
                toolStripComboBoxSize.SelectedIndex = 0;
                while (gd.dr.Read())
                {
                    toolStripComboBoxSize.Items.Add(string.Format("{0}", gd.dr[0]));
                }
                gd.dr.Close();
                gd.CN.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public void populateColor()
        {
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();
                string qry = string.Format("SELECT Color from COLOR");
                gd.cmd = new SqlCommand(qry, gd.CN);
                gd.dr = gd.cmd.ExecuteReader();
                toolStripComboBoxColor.Items.Clear();
                toolStripComboBoxColor.Items.Add("All");
                toolStripComboBoxColor.SelectedIndex = 0;
                while (gd.dr.Read())
                {
                    toolStripComboBoxColor.Items.Add(string.Format("{0}", gd.dr[0]));
                }
                gd.dr.Close();
                gd.CN.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public void populateSpecialFeatures()
        {
            SqlDataReader dr;
            SqlCommand cmd;
            SqlConnection conn;
            string query = "SELECT Special_Feature FROM dbo.SPECIALFEATURE";

            try
            {
                conn = new SqlConnection(gd.ConString);
                conn.Open();
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                toolStripComboBoxSpecialFeature.Items.Clear();
                toolStripComboBoxSpecialFeature.Items.Add("All");
                toolStripComboBoxSpecialFeature.SelectedIndex = 0;
                while (dr.Read())
                {
                    toolStripComboBoxSpecialFeature.Items.Add(string.Format("{0}", dr[0]));
                }

                conn.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public void populateWarehouse()
        {
            SqlDataReader dr;
            SqlCommand cmd;
            SqlConnection conn;
            string query = "SELECT Warehouse_Name FROM dbo.WAREHOUSE";

            try
            {
                conn = new SqlConnection(gd.ConString);
                conn.Open();
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                toolStripComboBoxWarehouse.Items.Clear();
                toolStripComboBoxWarehouse.Items.Add("All");
                toolStripComboBoxWarehouse.SelectedIndex = 0;
                while (dr.Read())
                {
                    toolStripComboBoxWarehouse.Items.Add(string.Format("{0}", dr[0]));
                }

                conn.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public int getCategoryID()
        {
            SqlDataReader dr;
            SqlCommand cmd;
            SqlConnection conn;
            string ID = "";
            try
            {
                conn = new SqlConnection(gd.ConString);
                conn.Open();
                string query = string.Format("SELECT ID " +
                                      "FROM dbo.CATEGORY " +
                                      "WHERE (Category_Name = @categoryName)");

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@categoryName", (object)toolStripComboBoxCategory.SelectedItem));
                dr = cmd.ExecuteReader();
                dr.Read();

                ID = Convert.ToString(dr[0]);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
            return Convert.ToInt32(ID);
        }

        public void populateUnit()
        {
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();
                string qry = string.Format("SELECT Unit from UNIT");
                gd.cmd = new SqlCommand(qry, gd.CN);
                gd.dr = gd.cmd.ExecuteReader();
                toolStripComboBoxUnit.Items.Add("All");
                toolStripComboBoxUnit.SelectedIndex = 0;
                while (gd.dr.Read())
                {
                    toolStripComboBoxUnit.Items.Add(string.Format("{0}", gd.dr[0]));
                }
                gd.dr.Close();
                gd.CN.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void SearchProductForm_Load(object sender, EventArgs e)
        {
            //toolStripComboBoxSearchBy.SelectedIndex = 0;
            //populateCategory();
            //populateUnit();
            //populateSize();
            //populateColor();
            //populateSpecialFeatures();
            //populateWarehouse();
            //showRecords();
        }

        private void toolStripComboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBoxCategory.SelectedIndex != 0)
            {
                populateSubCategory();
            }
            else
            {
                toolStripComboBoxSubCategory.Items.Add("All");
                toolStripComboBoxSubCategory.SelectedIndex = 0;
                toolStripComboBoxSubCategory.Enabled = false;
            }
            showRecords();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            showRecords();
        }

        private void toolStripComboBoxSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            showRecords();
        }

        private void toolStripComboBoxSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            showRecords();
        }

        private void toolStripComboBoxUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            showRecords();
        }

        private void toolStripComboBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            showRecords();
        }

        private void toolStripComboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            showRecords();
        }

        private void toolStripComboBoxSpecialFeature_SelectedIndexChanged(object sender, EventArgs e)
        {
            showRecords();
        }

        private void toolStripComboBoxWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            showRecords();
        }
    }
}
