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
    public partial class UpdatePassword : Form
    {
        GlobalVariables gd = new GlobalVariables();
        SqlConnection conn;
        SqlCommand cmd;
        int userID;

        public UpdatePassword()
        {
            InitializeComponent();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            //Get password
            int oldPassword;
            oldPassword = Convert.ToInt16(getOldPassword((GlobalVariables.User), textOldPassword.Text.Trim()));

            if (oldPassword <= 0)
            {
                toolTipOldPassword.Show("Incorrect password", labelOldPassword);
                textOldPassword.Focus();
            }

            else if (textNewPassword.Text.Trim() == "")
            {
                toolTipNewPassword.Show("Enter a valid password", labelNewPassword);
                textNewPassword.Focus();
            }

            else if (textConfirmPassword.Text.Trim() != textNewPassword.Text.Trim())
            {
                toolTipConfirmPassword.Show("Password does not match", labelConfirmPassword);
                textConfirmPassword.Focus();
            }
            else
            {
                userID = getUserID(GlobalVariables.User);
                updatePassword(userID);
                button1.Text = "Close";
            }
        }

        public int getOldPassword(string username, string currentPassword)
        {
            int oldPassword;
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strSelect = "SELECT count(*) from USERACCOUNTS where Username = @username and password = @password";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("username", (object)GlobalVariables.User));
            cmd.Parameters.Add(new SqlParameter("password", (object)gd.getMd5Hash(currentPassword)));
            oldPassword = Convert.ToInt16(cmd.ExecuteScalar());

            return oldPassword;
        }

        public int getUserID(string username)
        {
            int userKey;    //term for userid
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strSelect = "SELECT ID from USERACCOUNTS where Username = @username";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("username", (object)GlobalVariables.User));
            userKey = Convert.ToInt16(cmd.ExecuteScalar());
            conn.Close();

            return userKey;
        }

        public void updatePassword(int userKey)
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strUpdate = "UPDATE USERACCOUNTS set Password = @password where ID = @userID";
            cmd = new SqlCommand(strUpdate, conn);
            cmd.Parameters.Add(new SqlParameter("password", (object)gd.getMd5Hash(textNewPassword.Text.Trim())));
            cmd.Parameters.Add(new SqlParameter("userID", (object)userKey));

            cmd.ExecuteNonQuery();
            toolTipUpdate.Show("Successfully update password", labelUpdatePassword);
            conn.Close();

            return;
        }

        public void hideToolTips()
        {
            toolTipOldPassword.Hide(labelOldPassword);
            toolTipNewPassword.Hide(labelNewPassword);
            toolTipConfirmPassword.Hide(labelConfirmPassword);
            toolTipUpdate.Hide(labelUpdatePassword);
        }

        private void UpdatePassword_Load(object sender, EventArgs e)
        {
            textNewPassword.Focus();
        }

        private void textOldPassword_MouseHover(object sender, EventArgs e)
        {
            this.hideToolTips();
        }

        private void textNewPassword_MouseHover(object sender, EventArgs e)
        {
            this.hideToolTips();
        }

        private void textConfirmPassword_MouseHover(object sender, EventArgs e)
        {
            this.hideToolTips();
        }

        private void buttonChange_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
