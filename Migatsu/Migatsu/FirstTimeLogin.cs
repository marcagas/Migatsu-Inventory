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
    public partial class FirstTimeLogin : Form
    {
        public static int User_ID;
        GlobalVariables gd = new GlobalVariables();
        public FirstTimeLogin()
        {
            InitializeComponent();
        }

        public FirstTimeLogin(int ID)
        {
            InitializeComponent();
            User_ID = ID;
        }

        private void FirstTimeLogin_Load(object sender, EventArgs e)
        {
            if (User_ID <= 0)
            {
                this.Close();
            }
        }

        public bool checkFields()
        {
            bool isOk = true;
            if (txtPIN.Text.Trim() != "")
            {
                if (txtPIN.Text.Trim().Length == 4)
                {
                    if (txtPIN.Text.Trim() == txtConfirmPIN.Text.Trim())
                    {
                        if (txtFirstName.Text.Trim() != "")
                        {
                            if (txtLastName.Text.Trim() != "")
                            {
                                isOk = true;
                            }
                            else
                            {
                                isOk = false;
                                toolTip1.Show("Last Name is required", txtLastName);
                            }
                        }
                        else
                        {
                            isOk = false;
                            toolTip1.Show("First Name is required", txtFirstName);
                        }
                    }
                    else
                    {
                        isOk = false;
                        toolTip1.Show("Two PINs are not equal.", txtConfirmPIN);
                    }
                }
                else
                {
                    isOk = false;
                    toolTip1.Show("The PIN entered is too short.", txtPIN);
                }
            }
            else
            {
                isOk = false;
                toolTip1.Show("PIN is required", txtPIN);
            }
            return isOk;
        }

        public void savePINandUpdateIsFirstTimeLoginStatus()
        {
            string query = "";
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();
                query = string.Format("UPDATE USERACCOUNTS SET " +
                                      "Pin_Code = @pinCode, Is_First_Time_Login = @isFirstTimeLogin " +
                                      "WHERE (ID = @userID)");

                gd.cmd = new SqlCommand(query, gd.CN);
                gd.cmd.Parameters.Add(new SqlParameter("@pinCode", (object)gd.getMd5Hash(txtPIN.Text.Trim())));
                gd.cmd.Parameters.Add(new SqlParameter("@isFirstTimeLogin", (object)false));
                gd.cmd.Parameters.Add(new SqlParameter("@userID", (object)User_ID));
                gd.cmd.ExecuteNonQuery();

                gd.CN.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public void saveProfile()
        {
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();

                string qry = "INSERT INTO PROFILE" +
                             "(First_Name, Middle_Name, Last_Name, User_Account_ID) " +
                             "VALUES " +
                             "(@firstName, @middleName, @lastName, @userAccountID)";

                gd.cmd = new SqlCommand(qry, gd.CN);
                gd.cmd.Parameters.Add(new SqlParameter("@firstName", (object)txtFirstName.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@middleName", (object)txtMiddleName.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@lastName", (object)txtLastName.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@userAccountID", (object)User_ID));
                gd.cmd.ExecuteNonQuery(); 
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ok = checkFields();
            if (ok)
            {
                savePINandUpdateIsFirstTimeLoginStatus();
                saveProfile();

                Form1 f1 = new Form1(User_ID);
                f1.Show();
                this.Close();
            }
        }

        private void txtPIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtConfirmPIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtPIN_Enter(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void txtConfirmPIN_Enter(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void txtFirstName_Enter(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void txtMiddleName_Enter(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void txtLastName_Enter(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void FirstTimeLogin_Move(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void FirstTimeLogin_Leave(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void FirstTimeLogin_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void FirstTimeLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
