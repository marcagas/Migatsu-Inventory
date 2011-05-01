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
    public partial class Profile : Form
    {
        GlobalVariables gd = new GlobalVariables();
        SqlConnection conn;
        SqlCommand cmd;

        int userID;
        public Profile(int ID)
        {
            userID = ID;
            InitializeComponent();
        }

        public Profile()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePassword cp = new ChangePassword();
            cp.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UpdateProfile up = new UpdateProfile();
            up.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePin cp = new ChangePin();
            cp.ShowDialog();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            //set user name
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strSelect = "select First_Name + ' ' + substring(Middle_Name,1,1) + '. ' + Last_Name, "+
                                "case IS_Admin when 1 then 'Administrator' else 'Standard User' end " +
                               "FROM PROFILE as p inner join USERACCOUNTS as u on p.User_Account_ID = u.ID "+
                               "where u.ID=@userID and Is_Active=1";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("userID", (object)userID));
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    labelUserName.Text = dr[0].ToString();
                    labelUserPrivelege.Text = dr[1].ToString();
                }
            }
            dr.Close();
            conn.Close();
        }        
    }
}
