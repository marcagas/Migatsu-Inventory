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
    public partial class SearchSupplier : Form
    {
        GlobalVariables gd = new GlobalVariables();
        SqlConnection conn;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter da;
        string defaultSelect = "Select...";
        string companyName = "Company Name",
               contactPerson = "Contact person";
        string supplierID;

        public SearchSupplier()
        {
            InitializeComponent();
        }

        private void SearchSupplier_Load(object sender, EventArgs e)
        {
            //add data for search..
            comboBoxSearchBy.Items.Add(defaultSelect);
            comboBoxSearchBy.Items.Add(companyName);
            comboBoxSearchBy.Items.Add(contactPerson);
            
            //select default 
            comboBoxSearchBy.SelectedItem = defaultSelect;

            populateSupplierList();
            unselectSuppliers();
        }

        private void unselectSuppliers()
        {
            int rowCount = dataGridViewSupplierList.RowCount;
            for (int i = 0; i < rowCount; i++)
            {
                dataGridViewSupplierList["Company", i].Selected = false;
            }
        }

        private void populateSupplierList()
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strSelect = "SELECT Supplier_ID, Company_Name as [Company], Contact_Person as [Contact Person], " +
                               "Address FROM SUPPLIER";
            cmd = new SqlCommand(strSelect, conn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet("ds");
            da.Fill(ds);
            ds.Tables[0].TableName = "tableData";
            dataGridViewSupplierList.DataSource = ds.Tables["tableData"];

            conn.Close();

            displaySupplierStatus();

            //hide supplier_ID
            dataGridViewSupplierList.Columns["Supplier_ID"].Visible = false;
        }

        private void comboBoxSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSearchBy.SelectedItem != defaultSelect)
            {
                filterSupplierList();
            }
            else
            {
                populateSupplierList();
            }
        }

        private void filterSupplierList()
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strSelect = "SELECT Supplier_ID, Company_Name as [Company], Contact_Person as [Contact Person]," +
                               "Address from SUPPLIER where ";

            if (comboBoxSearchBy.SelectedItem == companyName)
            {
                strSelect += "Company_Name like '%" + textBoxKeyword.Text + "%'";
            }
            else if (comboBoxSearchBy.SelectedItem == contactPerson)
            {
                strSelect += "Contact_Person like '%" + textBoxKeyword.Text + "%'";
            }
            cmd = new SqlCommand(strSelect, conn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet("ds");
            da.Fill(ds);
            ds.Tables[0].TableName = "tableData";
            dataGridViewSupplierList.DataSource = ds.Tables["tableData"];

            //hide supplier_id
            dataGridViewSupplierList.Columns["Supplier_ID"].Visible = false;
            unselectSuppliers();
            displaySupplierStatus();
            conn.Close();
        }

        private void displaySupplierStatus()
        {
            int rowCount = dataGridViewSupplierList.RowCount;
            statusStripSuppliers.Text = "Suppliers: " + Convert.ToString(rowCount);
        }

        private void textBoxKeyword_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxSearchBy.SelectedItem != defaultSelect)
            {
                filterSupplierList();
            }
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            if (supplierID != "" && supplierID != null)
            {
                GlobalVariables.supplierID = supplierID;
                Close();
            }
            else
            {
                MessageBox.Show("Select a supplier from the list.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridViewSupplierList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row;
                row = e.RowIndex;
                supplierID = dataGridViewSupplierList["Supplier_ID", row].Value.ToString();
            }
            catch (Exception x)
            {

            }
        }
        
    }
}
