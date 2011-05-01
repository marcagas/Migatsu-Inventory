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
    public partial class AddNewWarehouse : Form
    {
        GlobalVariables gd = new GlobalVariables();

        public AddNewWarehouse()
        {
            InitializeComponent();
        }

        private void AddNewWarehouse_Load(object sender, EventArgs e)
        {
            showRecords();
        }

        public DataTable createWarehouseDT()
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

                DataTable dtRecords = createWarehouseDT();
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
                dataGridView1.DataSource = dtRecords;
                toolStripStatusLabel1.Text = "Warehouses: " + count.ToString();

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Name";
                dataGridView1.Columns[2].HeaderText = "Address";

                conn.Close();
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
                query = string.Format("SELECT * " +
                                      "FROM dbo.WAREHOUSE " +
                                      "WHERE (Warehouse_Name = @warehouse AND Warehouse_Address = @warehouseAddress)");

                gd.cmd = new SqlCommand(query, gd.CN);
                gd.cmd.Parameters.Add(new SqlParameter("@warehouse", (object)textBox1.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@warehouseAddress", (object)textBox2.Text.Trim()));
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

        public void saveNewWarehouse()
        {
            try
            {
                if (textBox1.Text.Trim() != "")
                {
                    if (checkIfCategoryAlreadyExist(textBox1.Text.Trim()))
                    {
                        if (textBox2.Text.Trim() != "")
                        {
                            gd.CN = new SqlConnection(gd.ConString);
                            gd.CN.Open();

                            string qry = "INSERT INTO WAREHOUSE" +
                                         "(Warehouse_Name, Warehouse_Address) " +
                                         "VALUES " +
                                         "(@warehouseName, @warehouseAddress)";

                            gd.cmd = new SqlCommand(qry, gd.CN);
                            gd.cmd.Parameters.Add(new SqlParameter("@warehouseName", (object)textBox1.Text.Trim()));
                            gd.cmd.Parameters.Add(new SqlParameter("@warehouseAddress", (object)textBox2.Text.Trim()));
                            gd.cmd.ExecuteNonQuery();

                            MessageBox.Show(this,
                                                   "New Warehouse has been saved.",
                                                   "Successful", MessageBoxButtons.OK,
                                                   MessageBoxIcon.Information,
                                                   MessageBoxDefaultButton.Button1,
                                                   0);
                        }
                        else
                        {
                            MessageBox.Show(this,
                                           "Please enter the Address of the warehouse.",
                                           "Warning", MessageBoxButtons.OK,
                                           MessageBoxIcon.Error,
                                           MessageBoxDefaultButton.Button1,
                                           0);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this,
                                           "Warehouse already exists.",
                                           "Warning", MessageBoxButtons.OK,
                                           MessageBoxIcon.Error,
                                           MessageBoxDefaultButton.Button1,
                                           0);
                    }
                    showRecords();
                }
                else
                {
                    MessageBox.Show(this,
                                           "Please enter the Warehouse name.",
                                           "Warning", MessageBoxButtons.OK,
                                           MessageBoxIcon.Error,
                                           MessageBoxDefaultButton.Button1,
                                           0);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveNewWarehouse();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int row;
            try
            {
                row = Convert.ToInt32(dataGridView1[0, Convert.ToInt32(dataGridView1.CurrentRow.Index)].Value);
                EditWarehouse EC = new EditWarehouse(Convert.ToInt32(dataGridView1[0, row - 1].Value), dataGridView1[1, row - 1].Value.ToString(), dataGridView1[2, row - 1].Value.ToString());
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
                EditWarehouse EC = new EditWarehouse(Convert.ToInt32(dataGridView1[0, row].Value), dataGridView1[1, row].Value.ToString(), dataGridView1[2, row].Value.ToString());
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

        private void textBox1_Leave(object sender, EventArgs e)
        {
            TextInfo UsaTextInfo = new CultureInfo("en-US", false).TextInfo;
            string capitalized = UsaTextInfo.ToTitleCase(textBox1.Text.Trim());
            textBox1.Text = capitalized;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
