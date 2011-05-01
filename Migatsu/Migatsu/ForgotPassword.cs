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
    public partial class ForgotPassword : Form
    {
        GlobalVariables gd = new GlobalVariables();
        SqlConnection conn;
        SqlCommand cmd;

        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkUserAndPin(textUserName.Text.Trim(), textPinCode.Text.Trim());
        }

        public void checkUserAndPin(string username, string pincode)
        {
            SqlConnection CN = new SqlConnection(gd.ConString);
            string strSelect = "SELECT Password from USERACCOUNTS WHERE Username = @username AND PIN_Code = @pinCode";
            SqlCommand cmd = new SqlCommand(strSelect,CN);
            cmd.Parameters.Add(new SqlParameter("@username", (object)username));
            cmd.Parameters.Add(new SqlParameter("@pinCode", (object)gd.getMd5Hash(pincode)));
            SqlDataReader dr;
            try
            {
                CN.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    string generatedPassword = (Convert.ToString(dr["Password"])).Substring(1, 6);
                    //generatedPassword = generatedPassword;
                    string hashedPassword = gd.getMd5Hash(generatedPassword);
                    int userID;
                    userID = Convert.ToInt16(getUserID(textUserName.Text.Trim(), textPinCode.Text.Trim()));
                    updatePassword(userID, hashedPassword);
                    MessageBox.Show("Your new password is: " + generatedPassword);                    
                }
                else
                {
                    
                }
                CN.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public void updatePassword(int userID, string password)
        {
          
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            //update query
            string strUpdatePassword = "Update USERACCOUNTS set password = @password where ID = @userID";
            cmd = new SqlCommand(strUpdatePassword, conn);
            cmd.Parameters.Add(new SqlParameter("userID", (object)userID));
            cmd.Parameters.Add(new SqlParameter("password", (object)password));
            cmd.ExecuteNonQuery();
            conn.Close();
            return;      
        }

        public int getUserID(string username, string pinCode)
        {
            int userID;
            conn = new SqlConnection(gd.ConString);
            conn.Open();
            string strSelectUserID = "Select ID from USERACCOUNTS where Username = @username and PIN_Code = @pinCode";
            cmd = new SqlCommand(strSelectUserID, conn);
            pinCode = gd.getMd5Hash(pinCode);
            cmd.Parameters.Add(new SqlParameter("username", (object)username));
            cmd.Parameters.Add(new SqlParameter("pinCode", (object)pinCode));

            userID = Convert.ToInt16(cmd.ExecuteScalar());
            conn.Close();
            return userID;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
