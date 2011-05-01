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
    public partial class Login : Form
    {
        GlobalVariables gd = new GlobalVariables();
        FilterFunctions filter = new FilterFunctions();

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            authenticate();
        }

        public void authenticate()
        {
            SqlConnection CN = new SqlConnection(gd.ConString);
            string qry = "SELECT * from USERACCOUNTS WHERE Username = @username AND Password = @password";
            SqlCommand SqlCom = new SqlCommand(qry, CN);
            SqlCom.Parameters.Add(new SqlParameter("@username", (object)txtUsername.Text.Trim()));
            SqlCom.Parameters.Add(new SqlParameter("@password", (object)gd.getMd5Hash(txtPassword.Text.Trim())));
            
            SqlDataReader dr;

            try
            {
                CN.Open();
                dr = SqlCom.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    GlobalVariables.User = txtUsername.Text.Trim();
                    GlobalVariables.profileID = filter.fetchProfileId(Convert.ToInt32(dr["ID"].ToString()));

                    if (checkIfFirstTimeLogin(Convert.ToInt32(dr["ID"])))
                    {                        
                        FirstTimeLogin p = new FirstTimeLogin(Convert.ToInt32(dr["ID"].ToString()));
                        p.Show();
                        this.Close();
                    }
                    else
                    {
                        Form1 f1 = new Form1(Convert.ToInt32(dr["ID"].ToString()));
                        f1.Show();
                        this.Close();
                    }

                }
                else
                {
                    toolTip1.Show("Invalid Username or Password.",label6);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public bool checkIfFirstTimeLogin(int ID)
        {
            bool isFirstTime = true;

            gd.CN = new SqlConnection(gd.ConString);
            string qry = "SELECT * from USERACCOUNTS WHERE ID = @id";
            gd.cmd = new SqlCommand(qry, gd.CN);
            gd.cmd.Parameters.Add(new SqlParameter("@id", (object)ID));

            SqlDataReader dr;

            try
            {
                gd.CN.Open();
                dr = gd.cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    if (Convert.ToBoolean(dr["Is_First_Time_Login"]))
                    {
                        isFirstTime = true;
                    }
                    else
                    {
                        isFirstTime = false;
                    }
                }
                else
                {
                    isFirstTime = false;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
            gd.CN.Close();
            return isFirstTime;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46 && e.KeyChar != 95)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsNumber(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46 && e.KeyChar != 95)
            //{
            //    e.Handled = true;
            //}
        }

        private void txtUsername_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Hide(label6);
        }

        private void txtPassword_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Hide(txtPassword);
        }

        private void Login_LocationChanged(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword fp = new ForgotPassword();
            fp.ShowDialog();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (GlobalVariables.Login_Counter == true)
            //{
            //    System.Environment.Exit(0);
            //}
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
