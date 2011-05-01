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
    public partial class EditSubCategory : Form
    {
        GlobalVariables gd = new GlobalVariables();
        int subcategoryID;
        int categoryID;
        string subcategoryName;
        string categoryName;
        DataTable dt;

        public EditSubCategory()
        {
            InitializeComponent();
        }

        public EditSubCategory(int ID, int catID, string name, string nameCat)
        {
            InitializeComponent();
            try
            {
                subcategoryID = ID;
                categoryID = catID;
                subcategoryName = name;
                categoryName = nameCat;
                textBox1.Text = subcategoryName;
                textBox2.Text = categoryName;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public bool checkIfSubCategoryAlreadyExist(string unit)
        {
            bool isUnique = true;
            string query = "";
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();
                query = string.Format("SELECT Sub_Category_Name " +
                                      "FROM dbo.SUBCATEGORY " +
                                      "WHERE (Sub_Category_Name = @subcategoryName AND ID <> @subcategoryID)");

                gd.cmd = new SqlCommand(query, gd.CN);
                gd.cmd.Parameters.Add(new SqlParameter("@subcategoryName", (object)textBox1.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@subcategoryID", (object)subcategoryID));
                gd.dr = gd.cmd.ExecuteReader();

                if (gd.dr.HasRows)
                {
                    isUnique = false;
                }

                gd.CN.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
            return isUnique;
        }

        public DataTable getDataTable
        {
            get
            {
                return dt;
            }
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
                           "FROM dbo.CATEGORY INNER JOIN " +
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
                dt = dtRecords;
                conn.Close();
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
                gd.cmd.Parameters.Add(new SqlParameter("@categoryName", (object)textBox2.Text.Trim()));

                gd.dr = gd.cmd.ExecuteReader();

                while (gd.dr.Read())
                {
                    if (gd.dr["Category_Name"].ToString() == textBox2.Text.Trim())
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                if (!checkIfSubCategoryAlreadyExist(textBox1.Text.Trim()))
                {
                    toolTip2.Show("Sub Category already exists in this category.", label5);
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    updateSubcategory();
                }
            }
            else
            {
                toolTip1.Show("Please enter Sub Category.", label5);
            }
            showRecords();
        }

        public void updateSubcategory()
        {
            SqlCommand cmd;
            SqlConnection conn;
            string query;

            try
            {
                conn = new SqlConnection(gd.ConString);
                conn.Open();

                query = "UPDATE SUBCATEGORY set Sub_Category_Name = @subCat WHERE ID = @subCatID";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@subCat", (object)textBox1.Text.Trim()));
                cmd.Parameters.Add(new SqlParameter("@subCatID", (object)subcategoryID));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            TextInfo UsaTextInfo = new CultureInfo("en-US", false).TextInfo;
            string capitalized = UsaTextInfo.ToTitleCase(textBox1.Text.Trim());
            textBox1.Text = capitalized;
        }

        private void EditSubCategory_Leave(object sender, EventArgs e)
        {
            toolTip1.Hide(label5);
            toolTip2.Hide(label5);
        }

        private void EditSubCategory_LocationChanged(object sender, EventArgs e)
        {
            toolTip1.Hide(label5);
            toolTip2.Hide(label5);
        }

        private void EditSubCategory_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Hide(label5);
            toolTip2.Hide(label5);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            toolTip1.Hide(label5);
            toolTip2.Hide(label5);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
