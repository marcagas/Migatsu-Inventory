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
    public partial class AddCategoryForm : Form 
    {
        GlobalVariables gd = new GlobalVariables();
        DefaultStatus status = new DefaultStatus();

        public AddCategoryForm()
        {
            InitializeComponent();
        }

        private void AddCategoryForm_Load(object sender, EventArgs e)
        {
            showRecords();
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
            recordColumn.ColumnName = "Category_Name";
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
            string query = "SELECT * FROM dbo.CATEGORY";

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
                    recordRow["Category_Name"] = dr["Category_Name"].ToString();
                    dtRecords.Rows.Add(recordRow);
                    count++;
                }
                dataGridView1.DataSource = dtRecords;
                toolStripStatusLabel1.Text = "Categories: " + count.ToString();
                
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
                query = string.Format("SELECT Category_Name " +
                                      "FROM dbo.CATEGORY " +
                                      "WHERE (Category_Name = @categoryName)");

                gd.cmd = new SqlCommand(query, gd.CN);
                gd.cmd.Parameters.Add(new SqlParameter("@categoryName", (object)textBox1.Text.Trim()));
                gd.dr = gd.cmd.ExecuteReader();

                while (gd.dr.Read())
                {
                    if (gd.dr["Category_Name"].ToString().ToLower() == textBox1.Text.Trim().ToLower())
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

        private void saveToolStripSaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() != "")
                {
                    if (checkIfCategoryAlreadyExist(textBox1.Text.Trim()))
                    {
                        gd.CN = new SqlConnection(gd.ConString);
                        gd.CN.Open();

                        string qry = "INSERT INTO CATEGORY" +
                                     "(Category_Name) " +
                                     "VALUES " +
                                     "(@categoryName)";

                        gd.cmd = new SqlCommand(qry, gd.CN);
                        gd.cmd.Parameters.Add(new SqlParameter("@categoryName", (object)textBox1.Text.Trim()));
                        gd.cmd.ExecuteNonQuery();

                        MessageBox.Show(this,
                                               status.MSG_CATEGORY_SAVED,
                                               status.MSG_TITLE_SUCCESS, MessageBoxButtons.OK,
                                               MessageBoxIcon.Information,
                                               MessageBoxDefaultButton.Button1,
                                               0);
                    }
                    else
                    {
                        textBox1.SelectAll();
                        MessageBox.Show(this,
                                           status.MSG_CATEGORY_EXISTS,
                                           status.MSG_TITLE_WARNING, MessageBoxButtons.OK,
                                           MessageBoxIcon.Error,
                                           MessageBoxDefaultButton.Button1,
                                           0);
                    }
                    showRecords();
                }
                else
                {
                    MessageBox.Show(this,
                                           status.MSG_ENTER_CATEGORY,
                                           status.MSG_TITLE_WARNING, MessageBoxButtons.OK,
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

        public void saveNewCategory()
        {
            try
            {
                if (textBox1.Text.Trim() != "")
                {
                    if (checkIfCategoryAlreadyExist(textBox1.Text.Trim()))
                    {
                        gd.CN = new SqlConnection(gd.ConString);
                        gd.CN.Open();

                        string qry = "INSERT INTO CATEGORY" +
                                     "(Category_Name) " +
                                     "VALUES " +
                                     "(@categoryName)";

                        gd.cmd = new SqlCommand(qry, gd.CN);
                        gd.cmd.Parameters.Add(new SqlParameter("@categoryName", (object)textBox1.Text.Trim()));
                        gd.cmd.ExecuteNonQuery();

                        textBox1.Text = "";
                        toolTipSuccess.Show(status.MSG_CATEGORY_ADDED, btnSave);
                    }
                    else
                    {
                        toolTipError.Show(status.MSG_CATEGORY_EXISTS, textBox1);
                    }
                    showRecords();
                }
                else
                {
                    toolTipError.Show(status.MSG_ENTER_CATEGORY, textBox1);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveNewCategory();
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            TextInfo UsaTextInfo = new CultureInfo("en-US", false).TextInfo;
            string capitalized = UsaTextInfo.ToTitleCase(textBox1.Text.Trim());
            textBox1.Text = capitalized;
        }

        private void hideToolTip()
        {
            toolTipSuccess.Hide(btnSave);
            toolTipError.Hide(textBox1);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row;
            try
            {
                row = e.RowIndex;
                EditCategory EC = new EditCategory(Convert.ToInt32(dataGridView1[0, row].Value), dataGridView1[1, row].Value.ToString());
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
                EditCategory EC = new EditCategory(Convert.ToInt32(dataGridView1[0, row-1].Value), dataGridView1[1, row-1].Value.ToString());
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

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            hideToolTip();
        }

        private void labelInstruction1_MouseHover(object sender, EventArgs e)
        {
            hideToolTip();
        }

        private void linkLabel1_MouseHover(object sender, EventArgs e)
        {
            hideToolTip();
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            hideToolTip();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            hideToolTip();
        }

        private void dataGridView1_MouseHover(object sender, EventArgs e)
        {
            hideToolTip();
        }
    }
}
