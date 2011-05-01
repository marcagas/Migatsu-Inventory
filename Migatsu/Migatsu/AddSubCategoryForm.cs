using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace Migatsu
{
    public partial class AddSubCategoryForm : Form
    {
        GlobalVariables gd = new GlobalVariables();

        public AddSubCategoryForm()
        {
            InitializeComponent();
        }

        private void AddSubCategoryForm_Load(object sender, EventArgs e)
        {
            populateCategory();
            showRecords();
            textBox1.Enabled = false;
        }

        public DataTable createSubCategoryDT()
        {
            DataTable dtRecords = new DataTable();
            DataColumn recordColumn = new DataColumn();

            recordColumn.DataType = System.Type.GetType("System.Int32");
            recordColumn.ColumnName = "ID";
            recordColumn.Unique = true;
            dtRecords.Columns.Add(recordColumn);

            recordColumn = new DataColumn();
            recordColumn.DataType = System.Type.GetType("System.String");
            recordColumn.ColumnName = "Expr1";
            dtRecords.Columns.Add(recordColumn);

            recordColumn = new DataColumn();
            recordColumn.DataType = System.Type.GetType("System.String");
            recordColumn.ColumnName = "Sub_Category_Name";
            dtRecords.Columns.Add(recordColumn);

            recordColumn = new DataColumn();
            recordColumn.DataType = System.Type.GetType("System.String");
            recordColumn.ColumnName = "Category_Name";
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
            string query = "SELECT dbo.SUBCATEGORY.ID, dbo.CATEGORY.ID AS Expr1, dbo.SUBCATEGORY.Sub_Category_Name, dbo.CATEGORY.Category_Name " +
                           "FROM dbo.CATEGORY INNER JOIN "+
                           "dbo.SUBCATEGORY ON dbo.CATEGORY.ID = dbo.SUBCATEGORY.Category_ID";

            try
            {
                conn = new SqlConnection(gd.ConString);
                conn.Open();

                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();

                DataTable dtRecords = createSubCategoryDT();
                DataRow recordRow = dtRecords.NewRow();
                int count = 0;
                while (dr.Read())
                {
                    recordRow = dtRecords.NewRow();
                    recordRow["ID"] = dr["ID"];
                    recordRow["Expr1"] = dr["Expr1"];
                    recordRow["Sub_Category_Name"] = dr["Sub_Category_Name"].ToString();
                    recordRow["Category_Name"] = dr["Category_Name"].ToString();
                    dtRecords.Rows.Add(recordRow);
                    count++;
                }
                dataGridView1.DataSource = dtRecords;
                toolStripStatusLabel1.Text = "Sub Categories: " + count.ToString();

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "Sub Category";
                dataGridView1.Columns[3].HeaderText = "Category";

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

                string qry = string.Format("SELECT Category_Name FROM dbo.CATEGORY");
                gd.cmd = new SqlCommand(qry, gd.CN);
                gd.dr = gd.cmd.ExecuteReader();
                comboBox1.Items.Clear();
                comboBox1.Items.Add("Select...");
                comboBox1.SelectedIndex = 0;
                while (gd.dr.Read())
                {
                    comboBox1.Items.Add(string.Format("{0}", gd.dr[0]));
                }
                gd.dr.Close();
                gd.CN.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public int getCategoryID()
        {
            int categoryID = 0;
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();

                string qry = string.Format("SELECT ID, Category_Name FROM dbo.CATEGORY where Category_Name = @categoryName");
                gd.cmd = new SqlCommand(qry, gd.CN);
                gd.cmd.Parameters.Add(new SqlParameter("@categoryName", (object)comboBox1.SelectedItem));
                
                gd.dr = gd.cmd.ExecuteReader();
                
                while (gd.dr.Read())
                {
                    if (gd.dr["Category_Name"].ToString() == comboBox1.SelectedItem.ToString())
                    {
                        categoryID = Convert.ToInt32(gd.dr["ID"]);
                    }
                }
                gd.CN.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
            return categoryID;
        }

        public bool checkIfSubcategoryAlreadyExists()
        {
            SqlDataReader dr;
            SqlCommand cmd;
            SqlConnection conn;

            bool isUnique = true;
            string query = "";
            try
            {
                conn = new SqlConnection(gd.ConString);
                conn.Open();
                query = string.Format("SELECT Sub_Category_Name, Category_ID " +
                                      "FROM dbo.SUBCATEGORY " +
                                      "WHERE (Sub_Category_Name = @subcategoryName AND Category_ID = @categoryID)");

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@subcategoryName", (object)textBox1.Text.Trim()));
                cmd.Parameters.Add(new SqlParameter("@categoryID", (object)getCategoryID()));
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    isUnique = false;
                }

                conn.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
            return isUnique;
        }

        public void saveNewSubCategory()
        {
            int x = getCategoryID();
            if (x == 0)
            {
                MessageBox.Show(this,
                                               "Please select first a Category.",
                                               "Error", MessageBoxButtons.OK,
                                               MessageBoxIcon.Error,
                                               MessageBoxDefaultButton.Button1,
                                               0);
            }
            else
            {
                if (textBox1.Text.Trim() == "")
                {
                    MessageBox.Show(this,
                                               "Please enter Sub Category Name.",
                                               "Error", MessageBoxButtons.OK,
                                               MessageBoxIcon.Error,
                                               MessageBoxDefaultButton.Button1,
                                               0);
                }
                else
                {
                    if (!checkIfSubcategoryAlreadyExists())
                    {
                        MessageBox.Show(this,
                                               "Sub Category already exists in this category.",
                                               "Error", MessageBoxButtons.OK,
                                               MessageBoxIcon.Error,
                                               MessageBoxDefaultButton.Button1,
                                               0);
                    }
                    else
                    {
                        try
                        {
                            gd.CN = new SqlConnection(gd.ConString);
                            gd.CN.Open();

                            string qry = "INSERT INTO SUBCATEGORY" +
                                         "(Category_ID, Sub_Category_Name) " +
                                         "VALUES " +
                                         "(@categoryID, @subCategoryName)";

                            gd.cmd = new SqlCommand(qry, gd.CN);
                            gd.cmd.Parameters.Add(new SqlParameter("@categoryID", (object)x));
                            gd.cmd.Parameters.Add(new SqlParameter("@subCategoryName", (object)textBox1.Text.Trim()));
                            gd.cmd.ExecuteNonQuery();

                            showRecords();

                            MessageBox.Show(this,
                                                   "New Sub Category has been saved.",
                                                   "Successful", MessageBoxButtons.OK,
                                                   MessageBoxIcon.Information,
                                                   MessageBoxDefaultButton.Button1,
                                                   0);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.GetBaseException().ToString());
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveNewSubCategory();
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != 0)
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            TextInfo UsaTextInfo = new CultureInfo("en-US", false).TextInfo;
            string capitalized = UsaTextInfo.ToTitleCase(textBox1.Text.Trim());
            textBox1.Text = capitalized;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int row;
            try
            {
                row = Convert.ToInt32(dataGridView1[0, Convert.ToInt32(dataGridView1.CurrentRow.Index)].Value);
                EditSubCategory EC = new EditSubCategory(Convert.ToInt32(dataGridView1[0, row - 1].Value), Convert.ToInt32(dataGridView1[1, row - 1].Value), dataGridView1[2, row - 1].Value.ToString(), dataGridView1[3, row - 1].Value.ToString());
                if (EC.ShowDialog() == DialogResult.OK)
                {
                    dataGridView1.DataSource = EC.getDataTable;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row;
            try
            {
                row = e.RowIndex;
                EditSubCategory EC = new EditSubCategory(Convert.ToInt32(dataGridView1[0, row].Value), Convert.ToInt32(dataGridView1[1, row].Value), dataGridView1[2, row].Value.ToString(), dataGridView1[3, row].Value.ToString());
                if (EC.ShowDialog() == DialogResult.OK)
                {
                    dataGridView1.DataSource = EC.getDataTable;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
