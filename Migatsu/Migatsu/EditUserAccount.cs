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
    public partial class EditUserAccount : Form
    {
        GlobalVariables gd = new GlobalVariables();
        SqlConnection conn;
        SqlCommand cmd;
        int userID;
        string userPrivelege;
        string userFullName;
        string admin = "Administrator";
        string standardUser = "Standard User";
        int isAdmin = 0;
        string active = "Activate";
        string inactive = "Deactivate";

        public EditUserAccount(string ID, string prev, string name)
        {
            userID = Convert.ToInt32(ID);
            userPrivelege = prev;
            userFullName = name;
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditUserAccount_Load(object sender, EventArgs e)
        {
            labelUserPrivelege.Text = userPrivelege;
            labelUserName.Text = userFullName;

            if (userPrivelege == admin)
            {
                radioButtonAdministrator.Checked = true;
            }
            else
            {
                radioButtonAdministrator.Checked = false;
            }

            if (userPrivelege == standardUser)
            {
                radioButtonStandardUser.Checked = true;
            }
            else
            {
                radioButtonStandardUser.Checked = false;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int ans;
            ans = (int)MessageBox.Show("Are you sure you want to change the \n user privelege of " + userFullName + "?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == 6)
            {
                //update user privelege 
                conn = new SqlConnection(gd.ConString);
                conn.Open();

                string strUpdate = "UPDATE USERACCOUNTS set Is_Admin=@isAdmin where ID=@userID";
                cmd = new SqlCommand(strUpdate, conn);
                cmd.Parameters.Add(new SqlParameter("isAdmin", (object)isAdmin));
                cmd.Parameters.Add(new SqlParameter("userID", (object)userID));
                cmd.ExecuteNonQuery();

                //MessageBox.Show("User Privelege has been modified.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                toolTip1.Show("User privelege has been modified.", labelDeactivate);

                conn.Close();
            }
        }

        private void radioButtonStandardUser_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonStandardUser.Checked == true)
            {
                isAdmin = 0;
            }
            else
            {
                isAdmin = 1;
            }
        }

        private void radioButtonAdministrator_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAdministrator.Checked == true)
            {
                isAdmin = 1;
            }
            else
            {
                isAdmin = 0;
            }
        }

        private void buttonDeactivate_Click(object sender, EventArgs e)
        {
            if (buttonDeactivate.Text == inactive)
            {
                int ans;
                ans = (int)MessageBox.Show("Are you sure you want \n to deactivate this account?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == 6)
                {
                    conn = new SqlConnection(gd.ConString);
                    conn.Open();

                    string strUpdate = "UPDATE USERACCOUNTS set Is_Active=0 where ID=@userID";
                    cmd = new SqlCommand(strUpdate, conn);
                    cmd.Parameters.Add(new SqlParameter("userID", (object)userID));
                    cmd.ExecuteNonQuery();

                    toolTip1.Show("Account has been deactivated.", labelDeactivate);
                    buttonDeactivate.Text = active;
                }
            }
            else
            {
                int ans;
                ans = (int)MessageBox.Show("Are you sure you want \n to activate this account?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == 6)
                {
                    conn = new SqlConnection(gd.ConString);
                    conn.Open();

                    string strUpdate = "UPDATE USERACCOUNTS set Is_Active=1 where ID=@userID";
                    cmd = new SqlCommand(strUpdate, conn);
                    cmd.Parameters.Add(new SqlParameter("userID", (object)userID));
                    cmd.ExecuteNonQuery();

                    toolTip1.Show("Account has been activated.", labelDeactivate);
                    buttonDeactivate.Text = inactive;
                }
            }
        }
    }
}
