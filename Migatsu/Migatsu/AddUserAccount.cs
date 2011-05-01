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
    public partial class AddUserAccount : Form
    {
        AutoCompleteStringCollection userFullName = new AutoCompleteStringCollection();
        GlobalVariables gd = new GlobalVariables();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        string userCol = "Full Name";
        string idCol = "ID";
        string userStatus = "Users: ";
        string userPrivelegeCol = "User Privelege";
        
        public AddUserAccount()
        {
            InitializeComponent();
        }

        public bool checkFields()
        {
            bool fieldsOk = true;
            if (txtUsername.Text.Trim() != "")
            {
                if (txtUsername.Text.Trim().Length < 4)
                {
                    fieldsOk = false;
                    toolTip1.Show("Username is too short, must be at least 4 characters length.", txtUsername);
                }
                else
                {
                    if (txtPassword.Text.Trim() != "")
                    {
                        if (txtPassword.Text.Trim().Length < 5)
                        {
                            fieldsOk = false;
                            toolTip1.Show("Password too short, must be at least 5 characters in length.", txtPassword);
                        }
                        else
                        {
                            if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
                            {
                                fieldsOk = false;
                                toolTip1.Show("Passwords did not match.", txtConfirmPassword);
                            }
                            else
                            {
                                if (radioButton1.Checked == false && radioButton2.Checked == false)
                                {
                                    fieldsOk = false;
                                    toolTip1.Show("Please select an account type.", radioButton1);
                                }
                                else
                                {
                                    if (!checkIfUsernameIsUnique())
                                    {
                                        fieldsOk = false;
                                        toolTip1.Show("Username already exist.\nPlease try other one.", txtUsername);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        fieldsOk = false;
                        toolTip1.Show("No Password.", txtPassword);
                    }
                }
            }
            else
            {
                fieldsOk = false;
                toolTip1.Show("No Username.", txtUsername);
            }
            return fieldsOk;
        }

        public bool getAccountType()
        {
            bool isAdmin = false;

            if (radioButton2.Checked == true)
            {
                isAdmin = true;
            }
            return isAdmin;
        }

        public bool checkIfUsernameIsUnique()
        {
            bool isUnique = true;

            string query = "";
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();
                query = string.Format("SELECT Username " +
                                      "FROM dbo.USERACCOUNTS WHERE Username = @username");

                gd.cmd = new SqlCommand(query, gd.CN);
                gd.cmd.Parameters.Add(new SqlParameter("@username", (object)txtUsername.Text.Trim()));
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

        public void saveNewUserAccount()
        {
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();

                string qry = "INSERT INTO USERACCOUNTS" +
                             "(Username, Password, Is_First_Time_Login, Is_Admin) " +
                             "VALUES " +
                             "(@username, @password, @isFirstTimeLogin, @isAdmin)";

                gd.cmd = new SqlCommand(qry, gd.CN);
                gd.cmd.Parameters.Add(new SqlParameter("@username", (object)txtUsername.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@password", (object)gd.getMd5Hash(txtPassword.Text.Trim())));
                gd.cmd.Parameters.Add(new SqlParameter("@isFirstTimeLogin", (object)true));
                gd.cmd.Parameters.Add(new SqlParameter("@isAdmin", (object)getAccountType()));
                gd.cmd.ExecuteNonQuery();

                MessageBox.Show(this,
                                       "New Account has been saved.",
                                       "Successful", MessageBoxButtons.OK,
                                       MessageBoxIcon.Information,
                                       MessageBoxDefaultButton.Button1,
                                       0);

                populateAutoCompleteSearch();
                populateUserList();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkFields())
            {
                saveNewUserAccount();
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46 && e.KeyChar != 95)
            {
                e.Handled = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46 && e.KeyChar != 95)
            {
                e.Handled = true;
            }
        }

        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46 && e.KeyChar != 95)
            {
                e.Handled = true;
            }
        }

        private void AddUserAccount_LocationChanged(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void txtConfirmPassword_Enter(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddUserAccount_Load(object sender, EventArgs e)
        {
            populateUserList();
            populateAutoCompleteSearch();

            dataGridViewUserList.Columns[idCol].Visible = false;
        }

        private void populateUserList()
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strSelect = "select u.ID, First_Name + ' ' + substring(Middle_Name,1,1) + '. ' + Last_Name as [Full Name], Username as "+
                               "[User Account], case IS_Admin when 1 then 'Administrator' else 'Standard User' end as [User Privelege] "+
                               "FROM PROFILE as p inner join USERACCOUNTS as u on p.User_Account_ID = u.ID where u.Is_Active=1";

            cmd = new SqlCommand(strSelect, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet("ds");
            da.Fill(ds);
            ds.Tables[0].TableName = "table_mirror";
            dataGridViewUserList.DataSource = ds.Tables["table_mirror"];

            int userCount = dataGridViewUserList.RowCount;
            toolStripNumberOfUsers.Text = userStatus + userCount.ToString();

            conn.Close();
        }

        private void populateAutoCompleteSearch()
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strSelect = "SELECT First_Name + ' ' + substring(Middle_Name,1,1) + '. ' + Last_Name from PROFILE "+
                               "as P inner join USERACCOUNTS as u on u.ID = p.User_Account_ID where u.Is_Active=1";
            cmd = new SqlCommand(strSelect, conn);
            dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    userFullName.Add(dr[0].ToString());
                }
            }
            dr.Close();
            textBoxSearchUser.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxSearchUser.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBoxSearchUser.AutoCompleteCustomSource = userFullName;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            int rowCount = dataGridViewUserList.RowCount;
            for (int i = 0; i < rowCount; i++)
            {
                if (dataGridViewUserList[userCol, i].Value.ToString().ToLower() == textBoxSearchUser.Text.Trim().ToLower())
                {
                    dataGridViewUserList[userCol, i].Selected = true;
                    dataGridViewUserList.CurrentCell.Selected = dataGridViewUserList[userCol, i].Selected;
                    break;
                }
            }
        }

        private void linkLabelEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            editUser();
        }

        private void editUser()
        {
            int row = Convert.ToInt32(dataGridViewUserList.CurrentCell.RowIndex);
            if (row != null)
            {
                string accountID = dataGridViewUserList[0, row].Value.ToString();
                string privelege = dataGridViewUserList[userPrivelegeCol, row].Value.ToString();
                string name = dataGridViewUserList[userCol, row].Value.ToString();

                EditUserAccount ep = new EditUserAccount(accountID, privelege, name);
                ep.ShowDialog();
            }
            populateUserList();
            try
            {
                dataGridViewUserList[1, row].Selected = true;
            }
            catch (Exception x)
            {

            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            populateUserList();
            populateAutoCompleteSearch();
        }

        private void dataGridViewUserList_DoubleClick(object sender, EventArgs e)
        {
            editUser();
        }
    }
    
}
