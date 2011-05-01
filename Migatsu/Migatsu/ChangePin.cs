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
    public partial class ChangePin : Form
    {
        GlobalVariables gd = new GlobalVariables();
        SqlConnection conn;
        SqlCommand cmd;
        string userAccount;

        public ChangePin()
        {
            InitializeComponent();
        }

        private void ChangePin_Load(object sender, EventArgs e)
        {
            textCurrentPIN.Focus();
            userAccount = GlobalVariables.User;
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            int currentPIN;
            currentPIN = getCurrentPIN(userAccount, textCurrentPIN.Text.Trim());

            if (currentPIN <= 0)
            {
                toolTipErrorPin.Show("Invalid PIN", labelCurrentPIN);
            }
            else if (textNewPIN.Text.Trim() == "")
            {
                toolTipErrorPin.Show("Input your new PIN", labelNewPIN);
            }
            else if (textConfirmPIN.Text.Trim() != textNewPIN.Text.Trim())
            {
                toolTipErrorPin.Show("PIN does not match", labelConfirmPIN);
            }
            else
            {
                int userID;
                userID = getUserID(userAccount);
                updatePIN(userAccount, userID);
                buttonCancel.Text = "Close";
            }
        }

        public void updatePIN(string username, int userID)
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strUpdate = "UPDATE USERACCOUNTS set PIN_Code = @pin where ID = @userID";
            cmd = new SqlCommand(strUpdate, conn);
            cmd.Parameters.Add(new SqlParameter("pin", (object)gd.getMd5Hash(textNewPIN.Text.Trim())));
            cmd.Parameters.Add(new SqlParameter("userID", (object)userID));

            cmd.ExecuteNonQuery();
            toolTipSuccessPin.Show("Successfully updated PIN", labelUpdatePIN);
            conn.Close();

            return;
        }

        public int getCurrentPIN(string username, string inputPIN)
        {
            int currentPIN;
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strSelect = "SELECT count(*) from USERACCOUNTS where Username = @username and PIN_Code = @pin";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("username", (object)GlobalVariables.User));
            cmd.Parameters.Add(new SqlParameter("pin", (object)gd.getMd5Hash(inputPIN)));
            currentPIN = Convert.ToInt32(cmd.ExecuteScalar());

            return currentPIN;
        }

        public int getUserID(string username)
        {
            int userID;
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strSelect = "SELECT ID from USERACCOUNTS where Username = @username";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("username", (object)GlobalVariables.User));
            userID = Convert.ToInt16(cmd.ExecuteScalar());
            conn.Close();

            return userID;
        }

        private void textCurrentPIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textNewPIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textConfirmPIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void hideToolTip()
        {
            toolTipSuccessPin.Hide(labelUpdatePIN);
            toolTipErrorPin.Hide(labelNewPIN);
            toolTipErrorPin.Hide(labelConfirmPIN);
            toolTipErrorPin.Hide(labelCurrentPIN);
        }

        private void textCurrentPIN_MouseHover(object sender, EventArgs e)
        {
            hideToolTip();
        }

        private void textNewPIN_MouseHover(object sender, EventArgs e)
        {
            hideToolTip();
        }

        private void textConfirmPIN_MouseHover(object sender, EventArgs e)
        {
            hideToolTip();
        }
    }
}
