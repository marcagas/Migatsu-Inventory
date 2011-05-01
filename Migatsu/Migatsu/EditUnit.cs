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
    public partial class EditUnit : Form
    {
        GlobalVariables gd = new GlobalVariables();
        int unitID;
        string unitName;
        DataTable dt;

        public EditUnit()
        {
            InitializeComponent();
        }

        public EditUnit(int ID, string name)
        {
            InitializeComponent();
            try
            {
                unitID = ID;
                unitName = name;
                textBox1.Text = unitName;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public bool checkIfUnitAlreadyExist(string unit)
        {
            bool isUnique = true;
            string query = "";
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();
                query = string.Format("SELECT Unit " +
                                      "FROM dbo.UNIT " +
                                      "WHERE (Unit = @unit AND ID <> @unitID)");

                gd.cmd = new SqlCommand(query, gd.CN);
                gd.cmd.Parameters.Add(new SqlParameter("@unit", (object)textBox1.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@unitID", (object)unitID));
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
            recordColumn.ColumnName = "Unit";
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
            string query = "SELECT * FROM dbo.UNIT";

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
                    recordRow["Unit"] = dr["Unit"].ToString();
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

        private void textBox1_Leave(object sender, EventArgs e)
        {
            TextInfo UsaTextInfo = new CultureInfo("en-US", false).TextInfo;
            string capitalized = UsaTextInfo.ToTitleCase(textBox1.Text.Trim());
            textBox1.Text = capitalized;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                if (!checkIfUnitAlreadyExist(textBox1.Text.Trim()))
                {
                    toolTip2.Show("Unit already exists.", label4);
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    updateUnit();
                }
            }
            else
            {
                toolTip1.Show("Please enter Unit.", label4);
            }
            showRecords();
        }

        public void updateUnit()
        {
            SqlCommand cmd;
            SqlConnection conn;
            string query;

            try
            {
                conn = new SqlConnection(gd.ConString);
                conn.Open();

                query = "UPDATE UNIT set Unit = @unit WHERE ID = @unitID";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@unit", (object)textBox1.Text.Trim()));
                cmd.Parameters.Add(new SqlParameter("@unitID", (object)unitID));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void EditUnit_Leave(object sender, EventArgs e)
        {
            toolTip1.Hide(label4);
            toolTip2.Hide(label4);
        }

        private void EditUnit_LocationChanged(object sender, EventArgs e)
        {
            toolTip1.Hide(label4);
            toolTip2.Hide(label4);
        }

        private void EditUnit_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Hide(label4);
            toolTip2.Hide(label4);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            toolTip1.Hide(label4);
            toolTip2.Hide(label4);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
