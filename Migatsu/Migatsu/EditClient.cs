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
    public partial class EditClient : Form
    {
        GlobalVariables gd = new GlobalVariables();
        int companyID;
        string companyName;
        string companyAddress;
        string contactPerson;
        string contactNumber;
        DataTable dt;

        public EditClient()
        {
            InitializeComponent();
        }

        public EditClient(int ID, string comName, string comAddress, string conPerson, string conNumber)
        {
            InitializeComponent();
            try
            {
                companyID = ID;
                companyName = comName;
                companyAddress = comAddress;
                contactPerson = conPerson;
                contactNumber = conNumber;

                txtCompanyName.Text = companyName;
                txtAddress.Text = companyAddress;
                txtContactPerson.Text = contactPerson;
                txtContactNumber.Text = contactNumber;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public DataTable getDataTable
        {
            get
            {
                return dt;
            }
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
                    recordRow["ID"] = dr["ID"];
                    recordRow["Client_Name"] = dr["Client_Name"].ToString();
                    recordRow["Address"] = dr["Address"].ToString();
                    recordRow["Contact_Person"] = dr["Contact_Person"].ToString();
                    recordRow["Contact_Number"] = dr["Contact_Number"].ToString();
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
                                      "WHERE (Client_Name = @name AND ID  <> @comID)");

                gd.cmd = new SqlCommand(query, gd.CN);
                gd.cmd.Parameters.Add(new SqlParameter("@name", (object)txtCompanyName.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@comID", (object)companyID));
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

        public bool checkFields()
        {
            bool a = false;

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
                        updateSupplier();
                        a = true;
                    }
                }
            }
            else
            {
                toolTip1.Show("Please enter Client Name.", txtCompanyName);
            }
            return a;
        }

        public void updateSupplier()
        {
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();

                string qry = "UPDATE CLIENT " +
                             "SET Client_Name = @name, Address = @address, Contact_Person = @contactPerson, Contact_Number = @contactNumber " +
                             "WHERE ID = @comID";

                gd.cmd = new SqlCommand(qry, gd.CN);
                gd.cmd.Parameters.Add(new SqlParameter("@name", (object)txtCompanyName.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@address", (object)txtAddress.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@contactPerson", (object)txtContactPerson.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@contactNumber", (object)txtContactNumber.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@comID", (object)companyID));
                gd.cmd.ExecuteNonQuery();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkFields())
            {
                showRecords();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void txtContactPerson_Leave(object sender, EventArgs e)
        {
            TextInfo UsaTextInfo = new CultureInfo("en-US", false).TextInfo;
            string capitalized = UsaTextInfo.ToTitleCase(txtContactPerson.Text.Trim());
            txtContactPerson.Text = capitalized;
        }

        private void txtCompanyName_Enter(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void txtAddress_Enter(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void groupBox1_MouseHover(object sender, EventArgs e)
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

        private void EditClient_Leave(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void EditClient_LocationChanged(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void EditClient_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }
    }
}
