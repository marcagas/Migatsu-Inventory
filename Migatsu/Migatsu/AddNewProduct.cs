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
    public partial class AddNewProduct : Form
    {
        GlobalVariables gd = new GlobalVariables();

        public AddNewProduct()
        {
            InitializeComponent();
        }

        private void AddNewProduct_Load(object sender, EventArgs e)
        {
            populateSpecialFeatures();
            populateCategory();
            populateUnit();
            populateSize();
            populateColor();
        }

        public void populateCategory()
        {
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();
                string qry = string.Format("SELECT Category_Name from CATEGORY");
                gd.cmd = new SqlCommand(qry, gd.CN);
                gd.dr = gd.cmd.ExecuteReader();
                comboBoxCategory.Items.Clear();
                comboBoxCategory.Items.Add("Select...");
                comboBoxCategory.SelectedIndex = 0;
                while (gd.dr.Read())
                {
                    comboBoxCategory.Items.Add(string.Format("{0}", gd.dr[0]));
                }
                gd.dr.Close();
                gd.CN.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public void populateSubCategory()
        {
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();
                string qry = string.Format("SELECT Sub_Category_Name from SUBCATEGORY Where Category_ID = @categoryID");
                gd.cmd = new SqlCommand(qry, gd.CN);
                gd.cmd.Parameters.Add(new SqlParameter("@categoryID", (object)getCategoryID()));
                gd.dr = gd.cmd.ExecuteReader();
                comboBoxSubCategory.Items.Clear();
                comboBoxSubCategory.Items.Add("Select...");
                comboBoxSubCategory.SelectedIndex = 0;
                if (gd.dr.HasRows)
                {
                    comboBoxSubCategory.Enabled = true;
                    while (gd.dr.Read())
                    {
                        comboBoxSubCategory.Items.Add(string.Format("{0}", gd.dr[0]));
                    }
                }
                else
                {
                    comboBoxSubCategory.Enabled = false;
                    comboBoxSubCategory.Items.Clear();
                    comboBoxSubCategory.Items.Add("No available Sub Category...");
                    comboBoxSubCategory.SelectedIndex = 0;
                }

                gd.CN.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public void populateUnit()
        {
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();
                string qry = string.Format("SELECT Unit from UNIT");
                gd.cmd = new SqlCommand(qry, gd.CN);
                gd.dr = gd.cmd.ExecuteReader();
                comboBoxUnit.Items.Clear();
                comboBoxUnit.Items.Add("Select...");
                comboBoxUnit.SelectedIndex = 0;
                while (gd.dr.Read())
                {
                    comboBoxUnit.Items.Add(string.Format("{0}", gd.dr[0]));
                }
                gd.dr.Close();
                gd.CN.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public void populateSize()
        {
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();
                string qry = string.Format("SELECT Size from SIZE");
                gd.cmd = new SqlCommand(qry, gd.CN);
                gd.dr = gd.cmd.ExecuteReader();
                comboBoxSize.Items.Clear();
                comboBoxSize.Items.Add("Select...");
                comboBoxSize.SelectedIndex = 0;
                while (gd.dr.Read())
                {
                    comboBoxSize.Items.Add(string.Format("{0}", gd.dr[0]));
                }
                gd.dr.Close();
                gd.CN.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public void populateColor()
        {
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();
                string qry = string.Format("SELECT Color from COLOR");
                gd.cmd = new SqlCommand(qry, gd.CN);
                gd.dr = gd.cmd.ExecuteReader();
                comboBoxColor.Items.Clear();
                comboBoxColor.Items.Add("Select...");
                comboBoxColor.SelectedIndex = 0;
                while (gd.dr.Read())
                {
                    comboBoxColor.Items.Add(string.Format("{0}", gd.dr[0]));
                }
                gd.dr.Close();
                gd.CN.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public void populateSpecialFeatures()
        {
            SqlDataReader dr;
            SqlCommand cmd;
            SqlConnection conn;
            string query = "SELECT * FROM dbo.SPECIALFEATURE";

            try
            {
                conn = new SqlConnection(gd.ConString);
                conn.Open();
                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();
                radioListBox1.Items.Clear();
                while (dr.Read())
                {
                   radioListBox1.Items.Add(dr["Special_Feature"].ToString());
                }

                conn.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public int getCategoryID()
        {
            SqlDataReader dr;
            SqlCommand cmd;
            SqlConnection conn;
            string ID = "";
            try
            {
                conn = new SqlConnection(gd.ConString);
                conn.Open();
                string query = string.Format("SELECT ID " +
                                      "FROM dbo.CATEGORY " +
                                      "WHERE (Category_Name = @categoryName)");

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@categoryName", (object)comboBoxCategory.SelectedItem));
                dr = cmd.ExecuteReader();
                dr.Read();
                
                ID = Convert.ToString(dr[0]);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
            return Convert.ToInt32(ID);
        }

        public string getSubCategoryID()
        {
            SqlDataReader dr;
            SqlCommand cmd;
            SqlConnection conn;
            try
            {
                if (comboBoxSubCategory.SelectedIndex != 0)
                {
                    conn = new SqlConnection(gd.ConString);
                    conn.Open();
                    string query = string.Format("SELECT ID " +
                                          "FROM dbo.SUBCATEGORY " +
                                          "WHERE (Sub_Category_Name = @subCategoryName)");

                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add(new SqlParameter("@subCategoryName", (object)comboBoxSubCategory.SelectedItem));
                    dr = cmd.ExecuteReader();
                    dr.Read();

                    return Convert.ToString(dr[0]);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
            return "";
        }

        public string getUnitID()
        {
            SqlDataReader dr;
            SqlCommand cmd;
            SqlConnection conn;
            try
            {
                if (comboBoxUnit.SelectedIndex != 0)
                {
                    conn = new SqlConnection(gd.ConString);
                    conn.Open();
                    string query = string.Format("SELECT ID " +
                                          "FROM dbo.UNIT " +
                                          "WHERE (Unit = @unit)");

                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add(new SqlParameter("@unit", (object)comboBoxUnit.SelectedItem));
                    dr = cmd.ExecuteReader();
                    dr.Read();

                    return Convert.ToString(dr[0]);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
            return "";
        }

        public string getSizeID()
        {
            SqlDataReader dr;
            SqlCommand cmd;
            SqlConnection conn;
            try
            {
                if (comboBoxSize.SelectedIndex != 0)
                {
                    conn = new SqlConnection(gd.ConString);
                    conn.Open();
                    string query = string.Format("SELECT ID " +
                                          "FROM dbo.SIZE " +
                                          "WHERE (Size = @size)");

                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add(new SqlParameter("@size", (object)comboBoxSize.SelectedItem));
                    dr = cmd.ExecuteReader();
                    dr.Read();

                    return Convert.ToString(dr[0]);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
            return "";
        }

        public string getColorID()
        {
            SqlDataReader dr;
            SqlCommand cmd;
            SqlConnection conn;
            try
            {
                if (comboBoxColor.SelectedIndex != 0)
                {
                    conn = new SqlConnection(gd.ConString);
                    conn.Open();
                    string query = string.Format("SELECT ID " +
                                          "FROM dbo.COLOR " +
                                          "WHERE (Color = @color)");

                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add(new SqlParameter("@color", (object)comboBoxColor.SelectedItem));
                    dr = cmd.ExecuteReader();
                    dr.Read();

                    return Convert.ToString(dr[0]);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
            return "";
        }

        public string getSpecialFeatureID()
        {
            SqlDataReader dr;
            SqlCommand cmd;
            SqlConnection conn;
            try
            {
                if (radioListBox1.Items.Count > 0)
                {
                    conn = new SqlConnection(gd.ConString);
                    conn.Open();
                    string query = string.Format("SELECT ID " +
                                          "FROM dbo.SPECIALFEATURE " +
                                          "WHERE (Special_Feature = @specialFeatureName)");

                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add(new SqlParameter("@specialFeatureName", (object)radioListBox1.SelectedItem));
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    return Convert.ToString(dr["ID"]);
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
            return "";
        }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCategory.SelectedIndex != 0)
            {
                populateSubCategory();
            }
            else
            {
                comboBoxSubCategory.Items.Clear();
                comboBoxSubCategory.Items.Add("Please select first a Category...");
                comboBoxSubCategory.SelectedIndex = 0;
                comboBoxSubCategory.Enabled = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            unCheckRadioListItems();
        }

        public void unCheckRadioListItems()
        {
            int itemCount = radioListBox1.Items.Count;
            try
            {
                if (itemCount != 0)
                {
                    radioListBox1.SetSelected(getCheckedItem(), false);
                }
            }
            catch
            {
            }
            populateSpecialFeatures();
        }

        public bool ifTheresCheckedRadioButton()
        {
            bool result = true;
            int x = getCheckedItem();
            if (x < 0)
            {
                result = false;
                return false;
            }
            return result;
        }

        //-------------------------------------------------------------------------------//

        public bool checkIfProductAlreadyExists()
        {
            bool isUnique = true;
            try
            {
                gd.CN = new SqlConnection(gd.ConString);
                gd.CN.Open();

                string qry = "SELECT * from PRODUCT where " +
                             "Product_Name = @productName AND " +
                             "Model = @model AND " +
                             "Brand = @brand AND " +
                             "Description = @description AND " +
                             "Category_ID = @categoryID ";

                if (comboBoxSubCategory.SelectedIndex != 0)
                {
                    qry += "AND Sub_Category_ID = @subCategoryID ";
                }
                if (comboBoxUnit.SelectedIndex != 0)
                {
                    qry += "AND Unit_ID = @unitID ";
                }
                if (comboBoxSize.SelectedIndex != 0)
                {
                    qry += "AND Size_ID = @sizeID ";
                }
                if (comboBoxColor.SelectedIndex != 0)
                {
                    qry += "AND Color_ID = @colorID ";
                }
                if (ifTheresCheckedRadioButton())
                {
                    qry += "AND Special_Feature_ID = @specialFeature ";
                }
                gd.cmd = new SqlCommand(qry, gd.CN);
                gd.cmd.Parameters.Add(new SqlParameter("@productName", (object)textBoxProductName.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@model", (object)textBoxModel.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@brand", (object)textBoxBrand.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@description", (object)textBoxDescription.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@categoryID", (object)getCategoryID()));

                if (comboBoxSubCategory.SelectedIndex != 0)
                {
                    gd.cmd.Parameters.Add(new SqlParameter("@subCategoryID", (object)getSubCategoryID()));
                }
                if (comboBoxUnit.SelectedIndex != 0)
                {
                    gd.cmd.Parameters.Add(new SqlParameter("@unitID", (object)getUnitID()));
                }
                if (comboBoxSize.SelectedIndex != 0)
                {
                    gd.cmd.Parameters.Add(new SqlParameter("@sizeID", (object)getSizeID()));
                }
                if (comboBoxColor.SelectedIndex != 0)
                {
                    gd.cmd.Parameters.Add(new SqlParameter("@colorID", (object)getColorID()));
                }
                if (ifTheresCheckedRadioButton())
                {
                    gd.cmd.Parameters.Add(new SqlParameter("@specialFeature", (object)getSpecialFeatureID()));
                }

                SqlDataReader dr;
                
                dr = gd.cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    isUnique = false;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
            return isUnique;
        }

        public void saveNewProduct()
        {
            if (textBoxProductName.Text.Trim() == "")
            {
                MessageBox.Show(this,
                                           "Please enter a Product Name.",
                                           "Error", MessageBoxButtons.OK,
                                           MessageBoxIcon.Error,
                                           MessageBoxDefaultButton.Button1,
                                           0);
            }
            else
            {
                if (comboBoxCategory.SelectedIndex == 0)
                {
                    MessageBox.Show(this,
                                           "Please select a Category for this particular product.",
                                           "Error", MessageBoxButtons.OK,
                                           MessageBoxIcon.Error,
                                           MessageBoxDefaultButton.Button1,
                                           0);
                }
                else
                {
                    try
                    {
                        if (checkIfProductAlreadyExists())
                        {
                            gd.CN = new SqlConnection(gd.ConString);
                            gd.CN.Open();

                            string qry = "INSERT INTO PRODUCT" +
                                         "(Product_Name, " +
                                         "Model, " +
                                         "Brand, " +
                                         "Description, " +
                                         "Category_ID";

                            if (comboBoxSubCategory.SelectedIndex != 0)
                            {
                                qry += ", Sub_Category_ID";
                            }
                            if (comboBoxUnit.SelectedIndex != 0)
                            {
                                qry += ", Unit_ID";
                            }
                            if (comboBoxSize.SelectedIndex != 0)
                            {
                                qry += ", Size_ID";
                            }
                            if (comboBoxColor.SelectedIndex != 0)
                            {
                                qry += ", Color_ID";
                            }
                            if (ifTheresCheckedRadioButton())
                            {
                                qry += ", Special_Feature_ID";
                            }
                            qry += "" +
                            ") VALUES " +
                            "(@productName, " +
                            "@model, " +
                            "@brand, " +
                            "@description, " +
                            "@categoryID";

                            if (comboBoxSubCategory.SelectedIndex != 0)
                            {
                                qry += ", @subCategoryID";
                            }
                            if (comboBoxUnit.SelectedIndex != 0)
                            {
                                qry += ", @unitID";
                            }
                            if (comboBoxSize.SelectedIndex != 0)
                            {
                                qry += ", @sizeID";
                            }
                            if (comboBoxColor.SelectedIndex != 0)
                            {
                                qry += ", @colorID";
                            }
                            if (ifTheresCheckedRadioButton())
                            {
                                qry += ", @specialFeature";
                            }
                            qry += ")";

                            gd.cmd = new SqlCommand(qry, gd.CN);
                            gd.cmd.Parameters.Add(new SqlParameter("@productName", (object)textBoxProductName.Text.Trim()));
                            gd.cmd.Parameters.Add(new SqlParameter("@model", (object)textBoxModel.Text.Trim()));
                            gd.cmd.Parameters.Add(new SqlParameter("@brand", (object)textBoxBrand.Text.Trim()));
                            gd.cmd.Parameters.Add(new SqlParameter("@description", (object)textBoxDescription.Text.Trim()));
                            gd.cmd.Parameters.Add(new SqlParameter("@categoryID", (object)getCategoryID()));

                            if (comboBoxSubCategory.SelectedIndex != 0)
                            {
                                gd.cmd.Parameters.Add(new SqlParameter("@subCategoryID", (object)getSubCategoryID()));
                            }
                            if (comboBoxUnit.SelectedIndex != 0)
                            {
                                gd.cmd.Parameters.Add(new SqlParameter("@unitID", (object)getUnitID()));
                            }
                            if (comboBoxSize.SelectedIndex != 0)
                            {
                                gd.cmd.Parameters.Add(new SqlParameter("@sizeID", (object)getSizeID()));
                            }
                            if (comboBoxColor.SelectedIndex != 0)
                            {
                                gd.cmd.Parameters.Add(new SqlParameter("@colorID", (object)getColorID()));
                            }
                            if (ifTheresCheckedRadioButton())
                            {
                                gd.cmd.Parameters.Add(new SqlParameter("@specialFeature", (object)getSpecialFeatureID()));
                            }

                            gd.cmd.ExecuteNonQuery();

                            MessageBox.Show(this,
                                                   "New Product has been saved.",
                                                   "Successful", MessageBoxButtons.OK,
                                                   MessageBoxIcon.Information,
                                                   MessageBoxDefaultButton.Button1,
                                                   0);
                        }
                        else
                        {
                            MessageBox.Show(this,
                                                   "Product already exists.",
                                                   "Error", MessageBoxButtons.OK,
                                                   MessageBoxIcon.Error,
                                                   MessageBoxDefaultButton.Button1,
                                                   0);
                        }
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show(x.GetBaseException().ToString());
                    }
                }
            }
        }
        public void clearFields()
        {
            textBoxProductName.Text = "";
            textBoxBrand.Text = "";
            textBoxDescription.Text = "";
            textBoxModel.Text = "";
            unCheckRadioListItems();
            populateSpecialFeatures();
            populateCategory();
            populateUnit();
            populateSize();
            populateColor();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (comboBoxUnit.SelectedIndex == 0)
            {
                MessageBox.Show(getUnitID().ToString());
            }
        }

        public int getCheckedItem()
        {
            int itemCount = radioListBox1.Items.Count;
            if (itemCount != 0)
            {
               return radioListBox1.SelectedIndex;
            }
            return -1;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            populateCategory();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            populateUnit();
            populateSize();
            populateColor();
        }

        private void saveToolStripButton1_Click(object sender, EventArgs e)
        {
            saveNewProduct();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveNewProduct();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            clearFields();
        }
    }
}
