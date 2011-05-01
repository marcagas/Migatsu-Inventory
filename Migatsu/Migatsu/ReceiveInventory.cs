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
    public partial class ReceiveInventory : Form
    {
        GlobalVariables gd = new GlobalVariables();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        string strSelect;
        int productID;

        public ReceiveInventory()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SearchProduct spf = new SearchProduct();
            //spf.MdiParent = this.MdiParent;
            spf.ShowDialog();
            if (GlobalVariables.productID != "" && GlobalVariables.productID != null)
            {
                productID = Convert.ToInt16(GlobalVariables.productID);
                //display product information to the input boxes
                conn = new SqlConnection(gd.ConString);
                conn.Open();

                strSelect = "SELECT Product_Name, Model, Brand, Special_Feature, Description, Unit, Size, " +
                            "Color, Sub_Category_name, Category FROM View_Product_List where ID = @productID";
                cmd = new SqlCommand(strSelect, conn);
                cmd.Parameters.Add(new SqlParameter("productID", (object)productID));

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        
                    }
                    dr.Close();
                }
                        
                MessageBox.Show(Convert.ToString(productID));

                conn.Close();

                GlobalVariables.productID = "";
            }
            else
            {
                GlobalVariables.productID = "";
            }
        }

        private void ReceiveInventory_Load(object sender, EventArgs e)
        {
            Products ds = new Products();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
