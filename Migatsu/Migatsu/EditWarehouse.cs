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
    public partial class EditWarehouse : Form
    {
        GlobalVariables gd = new GlobalVariables();
        int warehouseID;
        string warehouseName;
        string warehouseAddress;
        DataTable dt;

        public EditWarehouse()
        {
            InitializeComponent();
        }

        public EditWarehouse(int ID, string name, string address)
        {
            InitializeComponent();

            try
            {
                warehouseID = ID;
                warehouseName = name;
                warehouseAddress = address;
                textBox1.Text = warehouseName;
                textBox2.Text = warehouseAddress;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public bool checkIfWarehouseAlreadyExist(string unit)
        {
            bool isUnique = true;
            string query = "";
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();
                query = string.Format("SELECT * " +
                                      "FROM dbo.WAREHOUSE " +
                                      "WHERE (Warehouse_Name = @warehouse AND Warehouse_Address = @warehouseAddress AND ID <> @warehouseID)");

                gd.cmd = new SqlCommand(query, gd.CN);
                gd.cmd.Parameters.Add(new SqlParameter("@warehouse", (object)textBox1.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@warehouseAddress", (object)textBox2.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@warehouseID", (object)warehouseID));
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
            recordColumn.ColumnName = "Warehouse_Name";
            dtRecords.Columns.Add(recordColumn);

            recordColumn = new DataColumn();
            recordColumn.DataType = System.Type.GetType("System.String");
            recordColumn.ColumnName = "Warehouse_Address";
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
            string query = "SELECT * FROM dbo.WAREHOUSE";

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
                    recordRow["Warehouse_Name"] = dr["Warehouse_Name"].ToString();
                    recordRow["Warehouse_Address"] = dr["Warehouse_Address"].ToString();
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
                if (!checkIfWarehouseAlreadyExist(textBox1.Text.Trim()))
                {
                    toolTip2.Show("Warehouse already exists.", label4);
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    updateWarehouse();
                }
            }
            else
            {
                toolTip1.Show("Please enter Warehouse.", label4);
            }
            showRecords();
        }

        public void updateWarehouse()
        {
            SqlCommand cmd;
            SqlConnection conn;
            string query;

            try
            {
                conn = new SqlConnection(gd.ConString);
                conn.Open();

                query = "UPDATE WAREHOUSE set Warehouse_Name = @name, Warehouse_Address = @address WHERE ID = @warehouseID";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@name", (object)textBox1.Text.Trim()));
                cmd.Parameters.Add(new SqlParameter("@address", (object)textBox2.Text.Trim()));
                cmd.Parameters.Add(new SqlParameter("@warehouseID", (object)warehouseID));
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

        private void EditWarehouse_Leave(object sender, EventArgs e)
        {
            toolTip1.Hide(label5);
            toolTip2.Hide(label5);
        }

        private void EditWarehouse_LocationChanged(object sender, EventArgs e)
        {
            toolTip1.Hide(label5);
            toolTip2.Hide(label5);
        }

        private void EditWarehouse_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Hide(label5);
            toolTip2.Hide(label5);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            toolTip1.Hide(label5);
            toolTip2.Hide(label5);
        }

        private void textBox2_Enter(object sender, EventArgs e)
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
