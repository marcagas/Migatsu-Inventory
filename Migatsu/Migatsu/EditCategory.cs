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
    public partial class EditCategory : Form
    {
        GlobalVariables gd = new GlobalVariables();
        int categoryID;
        string categoryName;
        DataTable dt;

        public EditCategory()
        {
            InitializeComponent();
        }

        public EditCategory(int ID, string name)
        {
            InitializeComponent();
            try
            {
                categoryID = ID;
                categoryName = name;
                textBox1.Text = categoryName;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public bool checkIfCategoryAlreadyExist(string category)
        {
            bool isUnique = true;
            string query = "";
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();
                query = string.Format("SELECT Category_Name " +
                                      "FROM dbo.CATEGORY " +
                                      "WHERE (Category_Name = @categoryName AND ID <> @categoryID)");

                gd.cmd = new SqlCommand(query, gd.CN);
                gd.cmd.Parameters.Add(new SqlParameter("@categoryName", (object)textBox1.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@categoryID", (object)categoryID));
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

        public DataTable createCategoryDT()
        {
            DataTable dtRecords = new DataTable();
            DataColumn recordColumn = new DataColumn();

            recordColumn.DataType = System.Type.GetType("System.Int32");
            recordColumn.ColumnName = "ID";
            recordColumn.Unique = true;
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
            string query = "SELECT * FROM dbo.CATEGORY";

            try
            {
                conn = new SqlConnection(gd.ConString);
                conn.Open();

                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();

                DataTable dtRecords = createCategoryDT();
                DataRow recordRow = dtRecords.NewRow();
                int count = 0;
                while (dr.Read())
                {
                    recordRow = dtRecords.NewRow();
                    recordRow["ID"] = dr["ID"];
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                if (!checkIfCategoryAlreadyExist(textBox1.Text.Trim()))
                {
                    toolTip2.Show("Category name already exists.", textBox1);
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    updateCategory();
                }
            }
            else
            {
                toolTip1.Show("Please enter Category Name.", textBox1);
            }
            showRecords();
        }

        public void updateCategory()
        {
            SqlCommand cmd;
            SqlConnection conn;
            string query;

            try
            {
                conn = new SqlConnection(gd.ConString);
                conn.Open();

                query = "UPDATE CATEGORY set Category_Name=@categoryName WHERE ID = @categoryID";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@categoryName", (object)textBox1.Text.Trim()));
                cmd.Parameters.Add(new SqlParameter("@categoryID", (object)categoryID));
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

        private void EditCategory_LocationChanged(object sender, EventArgs e)
        {
            toolTip1.Hide(textBox1);
            toolTip2.Hide(textBox1);
        }

        private void EditCategory_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Hide(textBox1);
            toolTip2.Hide(textBox1);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            toolTip1.Hide(textBox1);
            toolTip2.Hide(textBox1);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
