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
    public partial class EditSize : Form
    {
        GlobalVariables gd = new GlobalVariables();
        int sizeID;
        string sizeName;
        DataTable dt;

        public EditSize()
        {
            InitializeComponent();
        }

        public EditSize(int ID, string name)
        {
            InitializeComponent();

            try
            {
                sizeID = ID;
                sizeName = name;
                textBox1.Text = sizeName;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public bool checkIfSizeAlreadyExist(string size)
        {
            bool isUnique = true;
            string query = "";
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();
                query = string.Format("SELECT Size " +
                                      "FROM dbo.SIZE " +
                                      "WHERE (Size = @size AND ID <> @sizeID)");

                gd.cmd = new SqlCommand(query, gd.CN);
                gd.cmd.Parameters.Add(new SqlParameter("@size", (object)textBox1.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@sizeID", (object)sizeID));
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
            recordColumn.ColumnName = "Size";
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
            string query = "SELECT * FROM dbo.SIZE";

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
                    recordRow["Size"] = dr["Size"].ToString();
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
                if (!checkIfSizeAlreadyExist(textBox1.Text.Trim()))
                {
                    toolTip2.Show("Size already exists.", textBox1);
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    updateSize();
                }
            }
            else
            {
                toolTip1.Show("Please enter Size.", textBox1);
            }
            showRecords();
        }

        public void updateSize()
        {
            SqlCommand cmd;
            SqlConnection conn;
            string query;

            try
            {
                conn = new SqlConnection(gd.ConString);
                conn.Open();

                query = "UPDATE SIZE set Size = @size WHERE ID = @sizeID";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@size", (object)textBox1.Text.Trim()));
                cmd.Parameters.Add(new SqlParameter("@sizeID", (object)sizeID));
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

        private void EditSize_Leave(object sender, EventArgs e)
        {
            toolTip1.Hide(textBox1);
            toolTip2.Hide(textBox1);
        }

        private void EditSize_LocationChanged(object sender, EventArgs e)
        {
            toolTip1.Hide(textBox1);
            toolTip2.Hide(textBox1);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            toolTip1.Hide(textBox1);
            toolTip2.Hide(textBox1);
        }

        private void EditSize_MouseHover(object sender, EventArgs e)
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
