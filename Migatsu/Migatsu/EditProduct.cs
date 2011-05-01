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
    public partial class EditProduct : Form
    {
        int productNumber;
        int unitID,
            sizeID,
            colorID,
            specialFeatureID,
            categoryID,
            subCategoryID;

        GlobalVariables gd = new GlobalVariables();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        
        public EditProduct(string prodID)
        {
            productNumber = Convert.ToInt32(prodID);
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditProduct_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(Convert.ToString(productNumber));           

            //populate product info list
            populateCategory();
            populateSpecialFeatures();
            populateUnit();
            populateColor();
            populateSize();

            //populate product information
            productInfo();
            textBoxProductName.Focus();
        }

        private void populateCategory()
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

        private void populateSubCategory()
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

        private void populateUnit()
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

        private void populateSize()
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

        private void populateColor()
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

        private void populateSpecialFeatures()
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
                radioListBoxSpecialFeature.Items.Clear();
                while (dr.Read())
                {
                    radioListBoxSpecialFeature.Items.Add(dr["Special_Feature"].ToString());
                }

                conn.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private int getCategoryID()
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

        private string getSubCategoryID()
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

        private string getUnitID()
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

        private string getSizeID()
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

        private string getColorID()
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

        private string getSpecialFeatureID()
        {
            SqlDataReader dr;
            SqlCommand cmd;
            SqlConnection conn;
            try
            {
                if (radioListBoxSpecialFeature.Items.Count > 0)
                {
                    conn = new SqlConnection(gd.ConString);
                    conn.Open();
                    string query = string.Format("SELECT ID " +
                                          "FROM dbo.SPECIALFEATURE " +
                                          "WHERE (Special_Feature = @specialFeatureName)");

                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.Add(new SqlParameter("@specialFeatureName", (object)radioListBoxSpecialFeature.SelectedItem));
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

        private void productInfo()
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strSelect = "SELECT Product_Name, Model, Description, Brand, " +
                               "Unit_ID, Size_ID, Color_ID, Category_ID, Sub_Category_ID, Special_Feature_ID " +
                               "FROM PRODUCT where ID = @productID";

            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("productID", (object)Convert.ToInt32(productNumber)));
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    textBoxProductName.Text = dr[0].ToString();
                    textBoxModel.Text = dr[1].ToString();
                    textBoxDescription.Text = dr[2].ToString();
                    textBoxBrand.Text = dr[3].ToString();
                    if (dr[4].ToString() != null && dr[4].ToString() != "")
                    {
                        unitID = Convert.ToInt32(dr[4].ToString());
                        selectUnit(unitID);
                    }
                    if (dr[5].ToString() != null && dr[5].ToString() != "")
                    {
                        sizeID = Convert.ToInt32(dr[5].ToString());
                        selectSize(sizeID);
                    }
                    if (dr[6].ToString() != null && dr[6].ToString() != "")
                    {
                        colorID = Convert.ToInt32(dr[6].ToString());
                        selectColor(colorID);
                    }
                    if (dr[7].ToString() != null && dr[7].ToString() != "")
                    {
                        categoryID = Convert.ToInt32(dr[7].ToString());
                        selectCategory(categoryID);
                    }
                    if (dr[8].ToString() != null && dr[8].ToString() != "")
                    {
                        subCategoryID = Convert.ToInt32(dr[8].ToString());
                        selectSubCategory(subCategoryID);
                    }
                    if (dr[9].ToString() != null && dr[9].ToString() != "")
                    {
                        specialFeatureID = Convert.ToInt32(dr[9].ToString());
                        selectSpecialFeature(specialFeatureID);
                    }                    
                }                
            }
            dr.Close();
            conn.Close();
        }

        private void selectUnit(int ID)
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strSelect = "SELECT Unit from UNIT where ID = @unitID";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("unitID", (object)ID));

            comboBoxUnit.SelectedItem = Convert.ToString(cmd.ExecuteScalar());
            conn.Close();
            return;
        }

        private void selectSize(int ID)
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strSelect = "SELECT Size from SIZE where ID = @sizeID";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("sizeID", (object)ID));

            comboBoxSize.SelectedItem = Convert.ToString(cmd.ExecuteScalar());
            conn.Close();
            return;
        }

        private void selectColor(int ID)
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strSelect = "SELECT Color from COLOR where ID=@colorID";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("colorID", (object)ID));

            comboBoxColor.SelectedItem = Convert.ToString(cmd.ExecuteScalar());
            conn.Close();
            return;
        }

        private void selectCategory(int ID)
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strSelect = "SELECT Category_Name from Category where ID=@categoryID";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("categoryID", (object)ID));

            comboBoxCategory.SelectedItem = Convert.ToString(cmd.ExecuteScalar());
            conn.Close();
            return;
        }

        private void selectSubCategory(int ID)
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strSelect = "SELECT Sub_Category_Name from SUBCATEGORY where ID=@subCategoryID";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("subCategoryID", (object)ID));

            comboBoxSubCategory.SelectedItem = Convert.ToString(cmd.ExecuteScalar());
            conn.Close();
            return;
        }

        private void selectSpecialFeature(int ID)
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strSelect = "SELECT Special_Feature from SPECIALFEATURE where ID=@specialFeatureID";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("specialFeatureID", (object)ID));

            radioListBoxSpecialFeature.SelectedItem = Convert.ToString(cmd.ExecuteScalar());
            conn.Close();
            return;
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

        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            uncheckSpecialFeatures();
        }

        private void uncheckSpecialFeatures()
        {
            radioListBoxSpecialFeature.ClearSelected();
            populateSpecialFeatures();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            populateCategory();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            populateUnit();
            populateSize();
            populateColor();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //update product information
            updateProduct();            
        }

        private void updateProduct()
        {
            if (textBoxProductName.Text.Trim() == "")
            {
                MessageBox.Show(this, "Please enter a Product Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
            }
            else if (comboBoxCategory.SelectedIndex == 0)
            {
                MessageBox.Show(this, "Please select a Category for this particular product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, 0);
            }
            else
            {
                if (checkIfProductAlreadyExists())
                {
                    conn = new SqlConnection(gd.ConString);
                    conn.Open();

                    string strUpdate = "UPDATE Product set Product_Name = @productName,"+
                                       "Model=@model, Brand=@brand, Description=@description,"+
                                       "Category_ID=@categoryID";

                    if (comboBoxSubCategory.SelectedIndex != 0)
                    {
                        strUpdate += ", Sub_Category_ID=@subCategoryID";
                    }
                    if (comboBoxUnit.SelectedIndex != 0)
                    {
                        strUpdate += ", Unit_ID=@unitID";
                    }
                    if (comboBoxSize.SelectedIndex != 0)
                    {
                        strUpdate += ",Size_ID=@sizeID";
                    }
                    if (comboBoxColor.SelectedIndex != 0)
                    {
                        strUpdate += ",Color_ID=@colorID";
                    }
                    if (checkSpecialFeature())
                    {
                        strUpdate +=", Special_Feature_ID=@specialFeatureID";
                    }
                    strUpdate += " where ID=@productID";

                    cmd = new SqlCommand(strUpdate, conn);
                    cmd.Parameters.Add(new SqlParameter("productName", (object)textBoxProductName.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("model", (object)textBoxModel.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("brand", (object)textBoxBrand.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("description", (object)textBoxDescription.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("categoryID", (object)getCategoryID()));
                    cmd.Parameters.Add(new SqlParameter("productID", (object)productNumber));

                    if (comboBoxCategory.SelectedIndex != 0)
                    {
                        cmd.Parameters.Add(new SqlParameter("subCategoryID", (object)getSubCategoryID()));                                                                     
                    }
                    if (comboBoxUnit.SelectedIndex != 0)
                    {
                        cmd.Parameters.Add(new SqlParameter("unitID", (object)getUnitID()));
                    }                                      
                    if (comboBoxSize.SelectedIndex != 0)
                    {
                        cmd.Parameters.Add(new SqlParameter("sizeID", (object)getSizeID()));
                    }
                    if (comboBoxColor.SelectedIndex != 0)
                    {
                        cmd.Parameters.Add(new SqlParameter("colorID", (object)getColorID()));
                    }
                    if (checkSpecialFeature())
                    {
                        cmd.Parameters.Add(new SqlParameter("specialFeatureID", (object)getSpecialFeatureID()));
                    }
                    cmd.ExecuteNonQuery();

                    MessageBox.Show(this,
                                                   "Product has been modified.",
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
            
        }

        private bool checkSpecialFeature()
        {
            bool specialFeatureSelected = true;
           
            if (radioListBoxSpecialFeature.SelectedItem == null)
            {                
                return specialFeatureSelected = false;
            }
            return specialFeatureSelected;
        }

        private bool checkIfProductAlreadyExists()
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
                             "Category_ID = @categoryID AND "+
                             "ID != @productID ";

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
                if (checkSpecialFeature())
                {
                    qry += "AND Special_Feature_ID = @specialFeature ";
                }
                gd.cmd = new SqlCommand(qry, gd.CN);
                gd.cmd.Parameters.Add(new SqlParameter("@productName", (object)textBoxProductName.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@model", (object)textBoxModel.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@brand", (object)textBoxBrand.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@description", (object)textBoxDescription.Text.Trim()));
                gd.cmd.Parameters.Add(new SqlParameter("@categoryID", (object)getCategoryID()));
                gd.cmd.Parameters.Add(new SqlParameter("@productID", (object)productNumber));

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
                if (checkSpecialFeature())
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

        private void buttonAddToArchive_Click(object sender, EventArgs e)
        {
            if (buttonAddToArchive.Text == "Add To Archive")
            {
                int ans;
                ans = (int)MessageBox.Show("Are you sure you want to archive \n this product?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == 6)
                {
                    conn = new SqlConnection(gd.ConString);
                    conn.Open();

                    string strUpdate = "UPDATE Product set IsArchived=1 where ID=@productID";
                    cmd = new SqlCommand(strUpdate, conn);
                    cmd.Parameters.Add(new SqlParameter("productID", (object)productNumber));
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Product was put into archived.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    buttonAddToArchive.Text = "Remove from archive";
                    conn.Close();
                }
            }
            else
            {
                int ans;
                ans = (int)MessageBox.Show("Are you sure you want to remove this \n product from the archive?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ans == 6)
                {
                    conn = new SqlConnection(gd.ConString);
                    conn.Open();

                    string strUpdate = "UPDATE Product set IsArchived=0 where ID=@productID";
                    cmd = new SqlCommand(strUpdate, conn);
                    cmd.Parameters.Add(new SqlParameter("productID", (object)productNumber));
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Product was successfully removed from archive.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    buttonAddToArchive.Text = "Add To Archive";
                    conn.Close();
                }
            }
        }
    }
}
