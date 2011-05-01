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
    public partial class AddNewSize : Form
    {
        GlobalVariables gd = new GlobalVariables();

        public AddNewSize()
        {
            InitializeComponent();
        }

        private void AddNewSize_Load(object sender, EventArgs e)
        {
            showRecords();
        }

        public DataTable createSizeDT()
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

                DataTable dtRecords = createSizeDT();
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
                dataGridView1.DataSource = dtRecords;
                toolStripStatusLabel1.Text = "Sizes: " + count.ToString();

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "";

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
                query = string.Format("SELECT Size " +
                                      "FROM dbo.SIZE " +
                                      "WHERE (Size = @size)");

                gd.cmd = new SqlCommand(query, gd.CN);
                gd.cmd.Parameters.Add(new SqlParameter("@size", (object)textBox1.Text.Trim()));
                gd.dr = gd.cmd.ExecuteReader();

                while (gd.dr.Read())
                {
                    if (gd.dr["size"].ToString().ToLower() == textBox1.Text.Trim().ToLower())
                    {
                        isUnique = false;
                    }
                }
                gd.CN.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
            return isUnique;
        }

        public void saveNewSize()
        {
            try
            {
                if (textBox1.Text.Trim() != "")
                {
                    if (checkIfCategoryAlreadyExist(textBox1.Text.Trim()))
                    {
                        gd.CN = new SqlConnection(gd.ConString);
                        gd.CN.Open();

                        string qry = "INSERT INTO SIZE" +
                                     "(Size) " +
                                     "VALUES " +
                                     "(@size)";

                        gd.cmd = new SqlCommand(qry, gd.CN);
                        gd.cmd.Parameters.Add(new SqlParameter("@size", (object)textBox1.Text.Trim()));
                        gd.cmd.ExecuteNonQuery();

                        MessageBox.Show(this,
                                               "New Size has been saved.",
                                               "Successful", MessageBoxButtons.OK,
                                               MessageBoxIcon.Information,
                                               MessageBoxDefaultButton.Button1,
                                               0);
                    }
                    else
                    {
                        MessageBox.Show(this,
                                           "Size already exists.",
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
                                           "Please enter Size.",
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
            saveNewSize();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row;
            try
            {
                row = e.RowIndex;
                EditSize EC = new EditSize(Convert.ToInt32(dataGridView1[0, row].Value), dataGridView1[1, row].Value.ToString());
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int row;
            try
            {
                row = Convert.ToInt32(dataGridView1[0, Convert.ToInt32(dataGridView1.CurrentRow.Index)].Value);
                EditSize EC = new EditSize(Convert.ToInt32(dataGridView1[0, row - 1].Value), dataGridView1[1, row - 1].Value.ToString());
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
