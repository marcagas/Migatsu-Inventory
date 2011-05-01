using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Migatsu
{
    public partial class SupplierList : Form
    {
        GlobalVariables gd = new GlobalVariables();

        public SupplierList()
        {
            InitializeComponent();
        }

        private void SupplierList_Load(object sender, EventArgs e)
        {
            showRecords();
        }

        public DataTable createColorDT()
        {
            DataTable dtRecords = new DataTable();
            DataColumn recordColumn = new DataColumn();

            recordColumn.DataType = System.Type.GetType("System.Int32");
            recordColumn.ColumnName = "ID";
            recordColumn.Unique = true;
            dtRecords.Columns.Add(recordColumn);

            recordColumn = new DataColumn();
            recordColumn.DataType = System.Type.GetType("System.String");
            recordColumn.ColumnName = "Company_Name";
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
            string query = "SELECT * FROM dbo.SUPPLIER";

            try
            {
                conn = new SqlConnection(gd.ConString);
                conn.Open();

                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();

                DataTable dtRecords = createColorDT();
                DataRow recordRow = dtRecords.NewRow();
                int count = 0;
                while (dr.Read())
                {
                    recordRow = dtRecords.NewRow();
                    recordRow["ID"] = dr["ID"];
                    recordRow["Company_Name"] = dr["Company_Name"].ToString();
                    recordRow["Address"] = dr["Address"].ToString();
                    recordRow["Contact_Person"] = dr["Contact_Person"].ToString();
                    recordRow["Contact_Number"] = dr["Contact_Number"].ToString();
                    dtRecords.Rows.Add(recordRow);
                    count++;
                }
                dataGridView1.DataSource = dtRecords;
                toolStripStatusLabel1.Text = "Supplier/s: " + count.ToString();

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Company Name";
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

        public void showAddNewSupplierForm()
        {
            try
            {
                AddNewSupplier ARF = null;

                if (IsFormAlreadyOpen(typeof(AddNewSupplier)) == null)
                {
                    ARF = new AddNewSupplier();
                    ARF.MdiParent = this.MdiParent;
                    ARF.Show();
                }
                else
                {
                    Form selectedForm = IsFormAlreadyOpen(typeof(AddNewSupplier));
                    foreach (Form OpenForm in this.MdiChildren)
                    {
                        if (OpenForm == selectedForm)
                        {
                            if (selectedForm.WindowState == FormWindowState.Minimized)
                            {
                                selectedForm.WindowState = FormWindowState.Normal;
                            }
                            selectedForm.Select();
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public static Form IsFormAlreadyOpen(Type FormType)
        {
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.GetType() == FormType)
                    return OpenForm;
            }

            return null;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            showAddNewSupplierForm();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            showAddNewSupplierForm();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //int row;
            //try
            //{
            //    row = Convert.ToInt32(dataGridView1[0, Convert.ToInt32(dataGridView1.CurrentRow.Index)].Value);
            //    AddNewSupplier EC = new AddNewSupplier(Convert.ToInt32(dataGridView1[0, row - 1].Value), dataGridView1[1, row - 1].Value.ToString(), dataGridView1[2, row - 1].Value.ToString(), dataGridView1[3, row - 1].Value.ToString(), dataGridView1[4, row - 1].Value.ToString());
            //    if (EC.ShowDialog() == DialogResult.OK)
            //    {
            //        dataGridView1.DataSource = EC.getDataTable;
            //    }
            //}
            //catch (Exception x)
            //{
            //    MessageBox.Show(x.GetBaseException().ToString());
            //}
        }
    }
}
