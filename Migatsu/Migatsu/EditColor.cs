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
    public partial class EditColor : Form
    {
        GlobalVariables gd = new GlobalVariables();
        int colorID;
        string colorName;
        DataTable dt;

        public EditColor()
        {
            InitializeComponent();
        }

        public EditColor(int ID, string name)
        {
            InitializeComponent();

            try
            {
                colorID = ID;
                colorName = name;
                textBox1.Text = colorName;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public bool checkIfColorAlreadyExist(string color)
        {
            bool isUnique = true;
            string query = "";
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();
                query = string.Format("SELECT Color " +
                                      "FROM dbo.COLOR " +
                                      "WHERE (Color = @color AND ID <> @colorID)");

                gd.cmd = new SqlCommand(query, gd.CN);
                gd.cmd.Parameters.Add(new SqlParameter("@color", (object)textBox1.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@colorID", (object)colorID));
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
            recordColumn.ColumnName = "Color";
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
            string query = "SELECT * FROM dbo.COLOR";

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
                    recordRow["Color"] = dr["Color"].ToString();
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
                if (!checkIfColorAlreadyExist(textBox1.Text.Trim()))
                {
                    toolTip2.Show("Color already exists.", textBox1);
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    updateColor();
                }
            }
            else
            {
                toolTip1.Show("Please enter Color.", textBox1);
            }
            showRecords();
        }

        public void updateColor()
        {
            SqlCommand cmd;
            SqlConnection conn;
            string query;

            try
            {
                conn = new SqlConnection(gd.ConString);
                conn.Open();

                query = "UPDATE COLOR set Color = @color WHERE ID = @colorID";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@color", (object)textBox1.Text.Trim()));
                cmd.Parameters.Add(new SqlParameter("@colorID", (object)colorID));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
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

        private void textBox1_Leave(object sender, EventArgs e)
        {
            TextInfo UsaTextInfo = new CultureInfo("en-US", false).TextInfo;
            string capitalized = UsaTextInfo.ToTitleCase(textBox1.Text.Trim());
            textBox1.Text = capitalized;
        }

        private void EditColor_Leave(object sender, EventArgs e)
        {
            toolTip1.Hide(textBox1);
            toolTip2.Hide(textBox1);
        }

        private void EditColor_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Hide(textBox1);
            toolTip2.Hide(textBox1);
        }

        private void EditColor_LocationChanged(object sender, EventArgs e)
        {
            toolTip1.Hide(textBox1);
            toolTip2.Hide(textBox1);
        }

        private void textBox1_Enter_1(object sender, EventArgs e)
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
