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
    public partial class AddNewClient : Form
    {
        GlobalVariables gd = new GlobalVariables();

        public AddNewClient()
        {
            InitializeComponent();
        }

        public bool checkIfSupplierAlreadyExists()
        {
            bool isUnique = true;
            string query = "";
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();
                query = string.Format("SELECT Client_Name " +
                                      "FROM dbo.CLIENT " +
                                      "WHERE (Client_Name = @name)");

                gd.cmd = new SqlCommand(query, gd.CN);
                gd.cmd.Parameters.Add(new SqlParameter("@name", (object)txtCompanyName.Text.Trim()));
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

        public void checkFields()
        {
            if (txtCompanyName.Text.Trim() != "")
            {
                if (!checkIfSupplierAlreadyExists())
                {
                    MessageBox.Show(this,
                                       "Client already exists.",
                                       "Warning", MessageBoxButtons.OK,
                                       MessageBoxIcon.Warning,
                                       MessageBoxDefaultButton.Button1,
                                       0);
                }
                else
                {
                    if (txtContactNumber.Text.Trim() == "")
                    {
                        toolTip1.Show("Please enter Contact Number.", txtContactNumber);
                    }
                    else
                    {
                        saveSupplier();

                        MessageBox.Show(this,
                                       "Client has been saved.",
                                       "Successful", MessageBoxButtons.OK,
                                       MessageBoxIcon.Information,
                                       MessageBoxDefaultButton.Button1,
                                       0);
                        showRecords();
                        clearFields();
                    }
                }
            }
            else
            {
                toolTip1.Show("Please enter Client Name.", txtCompanyName);
            }
        }

        public void clearFields()
        {
            txtCompanyName.Text = "";
            txtAddress.Text = "";
            txtContactPerson.Text = "";
            txtContactNumber.Text = "";
        }

        public void saveSupplier()
        {
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();

                string qry = "INSERT INTO CLIENT" +
                             "(Client_Name, Address, Contact_Person, Contact_Number) " +
                             "VALUES " +
                             "(@Client_Name, @Address, @Contact_Person, @Contact_Number)";

                gd.cmd = new SqlCommand(qry, gd.CN);
                gd.cmd.Parameters.Add(new SqlParameter("@Client_Name", (object)txtCompanyName.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@Address", (object)txtAddress.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@Contact_Person", (object)txtContactPerson.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@Contact_Number", (object)txtContactNumber.Text.Trim()));
                gd.cmd.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkFields();
        }

        private void AddNewClient_Load(object sender, EventArgs e)
        {
            showRecords();
        }

        public DataTable createSupplierDT()
        {
            DataTable dtRecords = new DataTable();
            DataColumn recordColumn = new DataColumn();

            recordColumn.DataType = System.Type.GetType("System.Int32");
            recordColumn.ColumnName = "ID";
            recordColumn.Unique = true;
            dtRecords.Columns.Add(recordColumn);

            recordColumn = new DataColumn();
            recordColumn.DataType = System.Type.GetType("System.String");
            recordColumn.ColumnName = "Client_Name";
            dtRecords.Columns.Add(recordColumn);

            recordColumn = new DataColumn();
            recordColumn.DataType = System.Type.GetType("System.String");
            recordColumn.ColumnName = "Address";
            dtRecords.Columns.Add(recordColumn);

            recordColumn = new DataColumn();
            recordColumn.DataType = System.Type.GetType("System.String");
            recordColumn.ColumnName = "Contact_Person";
            dtRecords.Columns.Add(recordColumn);

            recordColumn = new DataColumn();
            recordColumn.DataType = System.Type.GetType("System.String");
            recordColumn.ColumnName = "Contact_Number";
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
            string query = "SELECT * FROM dbo.CLIENT";

            try
            {
                conn = new SqlConnection(gd.ConString);
                conn.Open();

                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();

                DataTable dtRecords = createSupplierDT();
                DataRow recordRow = dtRecords.NewRow();
                int count = 0;
                while (dr.Read())
                {
                    recordRow = dtRecords.NewRow();
                    recordRow["ID"] = dr["Client_ID"];
                    recordRow["Client_Name"] = dr["Company_Name"].ToString();
                    recordRow["Address"] = dr["Address"].ToString();
                    recordRow["Contact_Person"] = dr["Contact_Person"].ToString();
                    recordRow["Contact_Number"] = dr["Contact_Number"].ToString();
                    dtRecords.Rows.Add(recordRow);
                    count++;
                }
                dataGridView1.DataSource = dtRecords;
                toolStripStatusLabel1.Text = "Clients: " + count.ToString();

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Client Name";
                dataGridView1.Columns[2].HeaderText = "Address";
                dataGridView1.Columns[3].HeaderText = "Contact Person/s";
                dataGridView1.Columns[4].HeaderText = "Contact Number/s";

                conn.Close();
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
                EditClient EC = new EditClient(Convert.ToInt32(dataGridView1[0, row - 1].Value), dataGridView1[1, row - 1].Value.ToString(), dataGridView1[2, row - 1].Value.ToString(), dataGridView1[3, row - 1].Value.ToString(), dataGridView1[4, row - 1].Value.ToString());
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

        private void AddNewClient_Leave(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void AddNewClient_LocationChanged(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void AddNewClient_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void txtCompanyName_Enter(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void txtAddress_Enter(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void txtContactPerson_Enter(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void txtContactNumber_Enter(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void groupBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void txtContactPerson_Leave(object sender, EventArgs e)
        {
            TextInfo UsaTextInfo = new CultureInfo("en-US", false).TextInfo;
            string capitalized = UsaTextInfo.ToTitleCase(txtContactPerson.Text.Trim());
            txtContactPerson.Text = capitalized;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row;
            try
            {
                row = e.RowIndex;
                EditClient EC = new EditClient(Convert.ToInt32(dataGridView1[0, row].Value), dataGridView1[1, row].Value.ToString(), dataGridView1[2, row].Value.ToString(), dataGridView1[3, row].Value.ToString(), dataGridView1[4, row].Value.ToString());
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
