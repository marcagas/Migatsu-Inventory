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
    public partial class AddNewColor : Form
    {
        GlobalVariables gd = new GlobalVariables();
        DefaultStatus status = new DefaultStatus();
        bool formChanges = false;

        public AddNewColor()
        {
            InitializeComponent();
        }

        private void AddNewColor_Load(object sender, EventArgs e)
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

                DataTable dtRecords = createColorDT();
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
                dataGridView1.DataSource = dtRecords;
                toolStripStatusLabel1.Text = "Colors: " + count.ToString();

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
                query = string.Format("SELECT Color " +
                                      "FROM dbo.COLOR " +
                                      "WHERE (Color = @color)");

                gd.cmd = new SqlCommand(query, gd.CN);
                gd.cmd.Parameters.Add(new SqlParameter("@color", (object)textBoxColor.Text.Trim()));
                gd.dr = gd.cmd.ExecuteReader();

                while (gd.dr.Read())
                {
                    if (gd.dr["color"].ToString().ToLower() == textBoxColor.Text.Trim().ToLower())
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
                if (textBoxColor.Text.Trim() != "")
                {
                    if (checkIfCategoryAlreadyExist(textBoxColor.Text.Trim()))
                    {
                        gd.CN = new SqlConnection(gd.ConString);
                        gd.CN.Open();

                        string qry = "INSERT INTO COLOR" +
                                     "(Color) " +
                                     "VALUES " +
                                     "(@color)";

                        gd.cmd = new SqlCommand(qry, gd.CN);
                        gd.cmd.Parameters.Add(new SqlParameter("@color", (object)textBoxColor.Text.Trim()));
                        gd.cmd.ExecuteNonQuery();

                        MessageBox.Show(this,
                                               "New Color has been saved.",
                                               "Successful", MessageBoxButtons.OK,
                                               MessageBoxIcon.Information,
                                               MessageBoxDefaultButton.Button1,
                                               0);
                    }
                    else
                    {
                        MessageBox.Show(this,
                                           "Color already exists.",
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
                                           "Please enter Color.",
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

        public void saveNewColor()
        {
            try
            {
                if (textBoxColor.Text.Trim() != "")
                {
                    if (checkIfCategoryAlreadyExist(textBoxColor.Text.Trim()))
                    {
                        gd.CN = new SqlConnection(gd.ConString);
                        gd.CN.Open();

                        string qry = "INSERT INTO COLOR" +
                                     "(Color) " +
                                     "VALUES " +
                                     "(@color)";

                        gd.cmd = new SqlCommand(qry, gd.CN);
                        gd.cmd.Parameters.Add(new SqlParameter("@color", (object)textBoxColor.Text.Trim()));
                        gd.cmd.ExecuteNonQuery();

                        textBoxColor.Text = "";
                        toolTipSuccess.Show(status.MSG_COLOR_SAVED, textBoxColor);
                        formChanges = false;
                        /*MessageBox.Show(this,
                                               "New Color has been saved.",
                                               "Successful", MessageBoxButtons.OK,
                                               MessageBoxIcon.Information,
                                               MessageBoxDefaultButton.Button1,
                                               0);*/
                    }
                    else
                    {
                        toolTipError.Show(status.MSG_COLOR_EXISTS, textBoxColor);
                        /*
                        MessageBox.Show(this,
                                           "Color already exists.",
                                           "Warning", MessageBoxButtons.OK,
                                           MessageBoxIcon.Error,
                                           MessageBoxDefaultButton.Button1,
                                           0);*/
                    }
                    showRecords();
                }
                else
                {
                    toolTipError.Show(status.MSG_ENTER_COLOR, textBoxColor);
                    /*
                    MessageBox.Show(this,
                                           "Please enter Color.",
                                           "Warning", MessageBoxButtons.OK,
                                           MessageBoxIcon.Error,
                                           MessageBoxDefaultButton.Button1,
                                           0);*/
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveNewColor();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row;
            try
            {
                row = e.RowIndex;
                EditColor EC = new EditColor(Convert.ToInt32(dataGridView1[0, row].Value), dataGridView1[1, row].Value.ToString());
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
                EditColor EC = new EditColor(Convert.ToInt32(dataGridView1[0, row - 1].Value), dataGridView1[1, row - 1].Value.ToString());
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
            string capitalized = UsaTextInfo.ToTitleCase(textBoxColor.Text.Trim());
            textBoxColor.Text = capitalized;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (formChanges == true)
            {
                int ans;
                ans = (int)MessageBox.Show(status.MSG_UNSAVE_DATA, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == 6)
                {
                    hideToolTip();
                    this.Close();                    
                }
            }
            else
            {
                hideToolTip();
                Close();                
            }            
            
        }

        private void hideToolTip()
        {
            toolTipSuccess.Hide(btnSave);
            toolTipError.Hide(textBoxColor);
        }

        private void textBoxCategory_TextChanged(object sender, EventArgs e)
        {
            hideToolTip();
            if (textBoxColor.Text != "")
            {
                formChanges = true;
            }
            else
            {
                formChanges = false;
            }
        }

        private void textBoxColor_MouseHover(object sender, EventArgs e)
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

    }
}