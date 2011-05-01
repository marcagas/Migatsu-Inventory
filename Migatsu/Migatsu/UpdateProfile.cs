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
    public partial class UpdateProfile : Form
    {
        GlobalVariables gd = new GlobalVariables();
        SqlConnection conn;
        SqlCommand cmd;

        public UpdateProfile()
        {
            InitializeComponent();
        }

        private void UpdateProfile_Load(object sender, EventArgs e)
        {
            txtFirstName.Focus();
            fillUpNames(GlobalVariables.User);
        }

        public void fillUpNames(string username)
        {
            SqlDataReader dr;
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strSelect = "SELECT First_Name, Middle_Name, Last_Name from PROFILE as P INNER JOIN USERACCOUNTS as U " +
                                "on P.User_Account_ID = U.ID where U.Username = @username";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("username", (object)username));
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtFirstName.Text = dr[0].ToString();
                txtMiddleName.Text = dr[1].ToString();
                txtLastName.Text = dr[2].ToString();
            }
            dr.Close();
            conn.Close();

            return;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text.Trim() == "")
            {
                toolTipUpdateProfile.Show("Required field", labelFirstName);
            }
            else if (txtMiddleName.Text.Trim() == "")
            {
                toolTipUpdateProfile.Show("Required field", labelMiddleName);
            }
            else if (txtLastName.Text.Trim() == "")
            {
                toolTipUpdateProfile.Show("Required field", labelLastName);
            }
            else
            {
                updatePassword(GlobalVariables.User, txtFirstName.Text.Trim(), txtMiddleName.Text.Trim(), txtLastName.Text.Trim());
                buttonCancel.Text = "Close";
            }
           
        }

        public void updatePassword(string username, string firstName, string middleName, string lastName)
        {
            //get profile ID
            int profileID = getProfileID(username);
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strUpdate = "UPDATE PROFILE set First_Name=@firstName, Middle_Name=@middleName, Last_Name =" +
                                "@lastName where ID = @profileID ";
            cmd = new SqlCommand(strUpdate, conn);
            cmd.Parameters.Add(new SqlParameter("firstName", (object)txtFirstName.Text.Trim()));
            cmd.Parameters.Add(new SqlParameter("lastName", (object)txtLastName.Text.Trim()));
            cmd.Parameters.Add(new SqlParameter("middleName", (object)txtMiddleName.Text.Trim()));
            cmd.Parameters.Add(new SqlParameter("profileID", (object)profileID));

            cmd.ExecuteNonQuery();
            toolTipSuccess.Show("Update Successful", labelUpdateProfile);
            conn.Close();
            return;
        }

        public int getProfileID(string username)
        {
            int profileID;
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strSelect = "SELECT P.ID from PROFILE as P INNER JOIN USERACCOUNTS as U on " +
                                "P.User_Account_ID = U.ID where U.Username = @username";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("username", (object)username));
            profileID = Convert.ToInt16(cmd.ExecuteScalar());
            conn.Close();

            return profileID;
        }

        public void hideToolTips()
        {
            toolTipSuccess.Hide(this);
            toolTipUpdateProfile.Hide(this);            
        }

        private void txtFirstName_MouseHover(object sender, EventArgs e)
        {
            hideToolTips();
        }

        private void txtMiddleName_MouseHover(object sender, EventArgs e)
        {
            hideToolTips();
        }

        private void txtLastName_MouseHover(object sender, EventArgs e)
        {
            hideToolTips();
        }
    }
}
