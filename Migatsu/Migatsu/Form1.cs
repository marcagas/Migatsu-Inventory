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
    public partial class Form1 : Form
    {
        GlobalVariables gd = new GlobalVariables();
        public static int isMinimized = 0;
        public static int User_ID;
        SqlConnection conn;
        SqlCommand cmd;

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(int ID)
        {
            InitializeComponent();
            User_ID = ID;
        }

        public void getProfile()
        {
            gd.CN = new SqlConnection(gd.ConString);
            string qry = "SELECT dbo.PROFILE.First_Name, dbo.PROFILE.Middle_Name, dbo.PROFILE.Last_Name "+
                         "FROM dbo.PROFILE "+
                         "WHERE dbo.PROFILE.User_Account_ID = @id";
            gd.cmd = new SqlCommand(qry, gd.CN);
            gd.cmd.Parameters.Add(new SqlParameter("@id", (object)User_ID));

            SqlDataReader dr;

            try
            {
                gd.CN.Open();
                dr = gd.cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    gd.User_ID = User_ID;
                    gd.First_Name = dr["First_Name"].ToString();
                    gd.Middle_Name = dr["Middle_Name"].ToString();
                    gd.Last_Name = dr["Last_Name"].ToString();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
            gd.CN.Close();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewProduct ANP = null;

                if (IsFormAlreadyOpen(typeof(AddNewProduct)) == null)
                {
                    ANP = new AddNewProduct();
                    ANP.MdiParent = this;
                    ANP.Show();
                }
                else
                {
                    Form selectedForm = IsFormAlreadyOpen(typeof(AddNewProduct));
                    foreach (Form OpenForm in this.MdiChildren)
                    {
                        if (OpenForm == selectedForm)
                        {
                            if (selectedForm.WindowState == FormWindowState.Minimized)
                            {
                                selectedForm.WindowState = FormWindowState.Normal;
                            }
                            selectedForm.Select();
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public static Form IsFormAlreadyOpen(Type FormType)
        {
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.GetType() == FormType)
                    return OpenForm;
            }

            return null;
        }

        public static void miniMizeForms()
        {
            if (isMinimized == 0)
            {
                foreach (Form OpenForm in Application.OpenForms)
                {
                    if (OpenForm.WindowState == FormWindowState.Normal)
                    {
                        OpenForm.WindowState = FormWindowState.Minimized;
                    }
                }
                isMinimized = 1;
            }
            else
            {
                foreach (Form OpenForm in Application.OpenForms)
                {
                    if (OpenForm.WindowState == FormWindowState.Minimized)
                    {
                        OpenForm.WindowState = FormWindowState.Normal;
                    }
                }
                isMinimized = 0;
            }
        }
        
        private void unitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewUnit ARF = null;

                if (IsFormAlreadyOpen(typeof(AddNewUnit)) == null)
                {
                    ARF = new AddNewUnit();
                    ARF.MdiParent = this;
                    ARF.Show();
                }
                else
                {
                    Form selectedForm = IsFormAlreadyOpen(typeof(AddNewUnit));
                    foreach (Form OpenForm in this.MdiChildren)
                    {
                        if (OpenForm == selectedForm)
                        {
                            if (selectedForm.WindowState == FormWindowState.Minimized)
                            {
                                selectedForm.WindowState = FormWindowState.Normal;
                            }
                            selectedForm.Select();
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddCategoryForm ARF = null;

                if (IsFormAlreadyOpen(typeof(AddCategoryForm)) == null)
                {
                    ARF = new AddCategoryForm();
                    ARF.MdiParent = this;
                    ARF.Show();
                }
                else
                {
                    Form selectedForm = IsFormAlreadyOpen(typeof(AddCategoryForm));
                    foreach (Form OpenForm in this.MdiChildren)
                    {
                        if (OpenForm == selectedForm)
                        {
                            if (selectedForm.WindowState == FormWindowState.Minimized)
                            {
                                selectedForm.WindowState = FormWindowState.Normal;
                            }
                            selectedForm.Select();
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void subCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddSubCategoryForm ARF = null;

                if (IsFormAlreadyOpen(typeof(AddSubCategoryForm)) == null)
                {
                    ARF = new AddSubCategoryForm();
                    ARF.MdiParent = this;
                    ARF.Show();
                }
                else
                {
                    Form selectedForm = IsFormAlreadyOpen(typeof(AddSubCategoryForm));
                    foreach (Form OpenForm in this.MdiChildren)
                    {
                        if (OpenForm == selectedForm)
                        {
                            if (selectedForm.WindowState == FormWindowState.Minimized)
                            {
                                selectedForm.WindowState = FormWindowState.Normal;
                            }
                            selectedForm.Select();
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void sizeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewSize ARF = null;

                if (IsFormAlreadyOpen(typeof(AddNewSize)) == null)
                {
                    ARF = new AddNewSize();
                    ARF.MdiParent = this;
                    ARF.Show();
                }
                else
                {
                    Form selectedForm = IsFormAlreadyOpen(typeof(AddNewSize));
                    foreach (Form OpenForm in this.MdiChildren)
                    {
                        if (OpenForm == selectedForm)
                        {
                            if (selectedForm.WindowState == FormWindowState.Minimized)
                            {
                                selectedForm.WindowState = FormWindowState.Normal;
                            }
                            selectedForm.Select();
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void colorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewColor ARF = null;

                if (IsFormAlreadyOpen(typeof(AddNewColor)) == null)
                {
                    ARF = new AddNewColor();
                    ARF.MdiParent = this;
                    ARF.Show();
                }
                else
                {
                    Form selectedForm = IsFormAlreadyOpen(typeof(AddNewColor));
                    foreach (Form OpenForm in this.MdiChildren)
                    {
                        if (OpenForm == selectedForm)
                        {
                            if (selectedForm.WindowState == FormWindowState.Minimized)
                            {
                                selectedForm.WindowState = FormWindowState.Normal;
                            }
                            selectedForm.Select();
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void specialFeatureToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewSpecialFeature ARF = null;

                if (IsFormAlreadyOpen(typeof(AddNewSpecialFeature)) == null)
                {
                    ARF = new AddNewSpecialFeature();
                    ARF.MdiParent = this;
                    ARF.Show();
                }
                else
                {
                    Form selectedForm = IsFormAlreadyOpen(typeof(AddNewSpecialFeature));
                    foreach (Form OpenForm in this.MdiChildren)
                    {
                        if (OpenForm == selectedForm)
                        {
                            if (selectedForm.WindowState == FormWindowState.Minimized)
                            {
                                selectedForm.WindowState = FormWindowState.Normal;
                            }
                            selectedForm.Select();
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void warehouseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewWarehouse ARF = null;

                if (IsFormAlreadyOpen(typeof(AddNewWarehouse)) == null)
                {
                    ARF = new AddNewWarehouse();
                    ARF.MdiParent = this;
                    ARF.Show();
                }
                else
                {
                    Form selectedForm = IsFormAlreadyOpen(typeof(AddNewWarehouse));
                    foreach (Form OpenForm in this.MdiChildren)
                    {
                        if (OpenForm == selectedForm)
                        {
                            if (selectedForm.WindowState == FormWindowState.Minimized)
                            {
                                selectedForm.WindowState = FormWindowState.Normal;
                            }
                            selectedForm.Select();
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void masterFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                ProductMasterFile ARF = null;

                if (IsFormAlreadyOpen(typeof(ProductMasterFile)) == null)
                {
                    ARF = new ProductMasterFile();
                    ARF.MdiParent = this;
                    ARF.Show();
                }
                else
                {                    
                    Form selectedForm = IsFormAlreadyOpen(typeof(ProductMasterFile));
                    foreach (Form OpenForm in this.MdiChildren)
                    {
                        if (OpenForm == selectedForm)
                        {
                            if (selectedForm.WindowState == FormWindowState.Minimized)
                            {
                                selectedForm.WindowState = FormWindowState.Normal;
                            }
                            selectedForm.Select();
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void receiveInventoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                AddInventory ARF = null;

                if (IsFormAlreadyOpen(typeof(AddInventory)) == null)
                {
                    ARF = new AddInventory();
                    ARF.MdiParent = this;
                    ARF.Show();
                }
                else
                {
                    Form selectedForm = IsFormAlreadyOpen(typeof(AddInventory));
                    foreach (Form OpenForm in this.MdiChildren)
                    {
                        if (OpenForm == selectedForm)
                        {
                            if (selectedForm.WindowState == FormWindowState.Minimized)
                            {
                                selectedForm.WindowState = FormWindowState.Normal;
                            }
                            selectedForm.Select();
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddUserAccount ARF = null;

                if (IsFormAlreadyOpen(typeof(AddUserAccount)) == null)
                {
                    ARF = new AddUserAccount();
                    ARF.MdiParent = this;
                    ARF.Show();
                }
                else
                {
                    Form selectedForm = IsFormAlreadyOpen(typeof(AddUserAccount));
                    foreach (Form OpenForm in this.MdiChildren)
                    {
                        if (OpenForm == selectedForm)
                        {
                            if (selectedForm.WindowState == FormWindowState.Minimized)
                            {
                                selectedForm.WindowState = FormWindowState.Normal;
                            }
                            selectedForm.Select();
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            miniMizeForms();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int ans;
            ans = (int)MessageBox.Show("Are you sure you want Logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == 6)
            {
                //System.Environment.Exit(0);
                GlobalVariables.Login_Counter = true;
                Login log = new Login();
                this.Hide();
                log.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (User_ID <= 0)
            {
                System.Environment.Exit(0);
            }
            else
            {
                getProfile();
                toolStripLabelLogged.Text = gd.First_Name + " " + gd.Middle_Name.Substring(0, 1) + ". " + gd.Last_Name;
            }

            //check user privelege
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strSelect = "SELECT Is_Admin from USERACCOUNTS where ID=@userID";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("userID", (object)User_ID));
            if (Convert.ToBoolean(cmd.ExecuteScalar()) != true)
            {
                toolStripUsers.Visible = false;
                toolStripUserAccountDivider.Visible = false;
            }
            else
            {
                toolStripUsers.Visible = true;
                toolStripUserAccountDivider.Visible = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            int ans;
            ans = (int)MessageBox.Show("Are you sure you want exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == 6)
            {
                GlobalVariables.Login_Counter = true;
                System.Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void supplierToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewSupplier ARF = null;

                if (IsFormAlreadyOpen(typeof(AddNewSupplier)) == null)
                {
                    ARF = new AddNewSupplier();
                    ARF.MdiParent = this;
                    ARF.Show();
                }
                else
                {
                    Form selectedForm = IsFormAlreadyOpen(typeof(AddNewSupplier));
                    foreach (Form OpenForm in this.MdiChildren)
                    {
                        if (OpenForm == selectedForm)
                        {
                            if (selectedForm.WindowState == FormWindowState.Minimized)
                            {
                                selectedForm.WindowState = FormWindowState.Normal;
                            }
                            selectedForm.Select();
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewClient ARF = null;

                if (IsFormAlreadyOpen(typeof(AddNewClient)) == null)
                {
                    ARF = new AddNewClient();
                    ARF.MdiParent = this;
                    ARF.Show();
                }
                else
                {
                    Form selectedForm = IsFormAlreadyOpen(typeof(AddNewClient));
                    foreach (Form OpenForm in this.MdiChildren)
                    {
                        if (OpenForm == selectedForm)
                        {
                            if (selectedForm.WindowState == FormWindowState.Minimized)
                            {
                                selectedForm.WindowState = FormWindowState.Normal;
                            }
                            selectedForm.Select();
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            int ans;
            ans = (int)MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == 6)
            {
                System.Environment.Exit(0);
            }
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Profile ARF = null;

                if (IsFormAlreadyOpen(typeof(Profile)) == null)
                {
                    ARF = new Profile(User_ID);
                    ARF.MdiParent = this;
                    ARF.Show();
                }
                else
                {
                    Form selectedForm = IsFormAlreadyOpen(typeof(AddNewSupplier));
                    foreach (Form OpenForm in this.MdiChildren)
                    {
                        if (OpenForm == selectedForm)
                        {
                            if (selectedForm.WindowState == FormWindowState.Minimized)
                            {
                                selectedForm.WindowState = FormWindowState.Normal;
                            }
                            selectedForm.Select();
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void productsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                ProductInfoForm ARF = null;

                if (IsFormAlreadyOpen(typeof(ProductInfoForm)) == null)
                {
                    ARF = new ProductInfoForm();
                    ARF.MdiParent = this;
                    ARF.Show();
                }
                else
                {
                    Form selectedForm = IsFormAlreadyOpen(typeof(AddNewProduct));
                    foreach (Form OpenForm in this.MdiChildren)
                    {
                        if (OpenForm == selectedForm)
                        {
                            if (selectedForm.WindowState == FormWindowState.Minimized)
                            {
                                selectedForm.WindowState = FormWindowState.Normal;
                            }
                            selectedForm.Select();
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Users ARF = null;

                if (IsFormAlreadyOpen(typeof(Users)) == null)
                {
                    ARF = new Users();
                    ARF.MdiParent = this;
                    ARF.Show();
                }
                else
                {
                    Form selectedForm = IsFormAlreadyOpen(typeof(Users));
                    foreach (Form OpenForm in this.MdiChildren)
                    {
                        if (OpenForm == selectedForm)
                        {
                            if (selectedForm.WindowState == FormWindowState.Minimized)
                            {
                                selectedForm.WindowState = FormWindowState.Normal;
                            }
                            selectedForm.Select();
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void adjustmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AdjustmentForm ARF = null;

                if (IsFormAlreadyOpen(typeof(AdjustmentForm)) == null)
                {
                    ARF = new AdjustmentForm();
                    ARF.MdiParent = this;
                    ARF.Show();
                }
                else
                {
                    Form selectedForm = IsFormAlreadyOpen(typeof(AdjustmentForm));
                    foreach (Form OpenForm in this.MdiChildren)
                    {
                        if (OpenForm == selectedForm)
                        {
                            if (selectedForm.WindowState == FormWindowState.Minimized)
                            {
                                selectedForm.WindowState = FormWindowState.Normal;
                            }
                            selectedForm.Select();
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        public void openAnotherForm(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            try
            {
                AddInventory ARF = null;

                if (IsFormAlreadyOpen(typeof(AddInventory)) == null)
                {
                    ARF = new AddInventory();
                    ARF.MdiParent = fm;
                    ARF.Show();
                    MessageBox.Show("SUccess");
                }
                else
                {
                    Form selectedForm = IsFormAlreadyOpen(typeof(AddInventory));
                    foreach (Form OpenForm in fm.MdiChildren)
                    {
                        if (OpenForm == selectedForm)
                        {
                            if (selectedForm.WindowState == FormWindowState.Minimized)
                            {
                                selectedForm.WindowState = FormWindowState.Normal;
                            }
                            selectedForm.Select();
                        }
                    }
                }
                return;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void addNewClientOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewClientOrder ARF = null;

                if (IsFormAlreadyOpen(typeof(AddNewClientOrder)) == null)
                {
                    ARF = new AddNewClientOrder();
                    ARF.MdiParent = this;
                    ARF.Show();
                }
                else
                {
                    Form selectedForm = IsFormAlreadyOpen(typeof(AddNewClientOrder));
                    foreach (Form OpenForm in this.MdiChildren)
                    {
                        if (OpenForm == selectedForm)
                        {
                            if (selectedForm.WindowState == FormWindowState.Minimized)
                            {
                                selectedForm.WindowState = FormWindowState.Normal;
                            }
                            selectedForm.Select();
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }

        private void processClientOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessOrder ARF = null;

                if (IsFormAlreadyOpen(typeof(ProcessOrder)) == null)
                {
                    ARF = new ProcessOrder();
                    ARF.MdiParent = this;
                    ARF.Show();
                }
                else
                {
                    Form selectedForm = IsFormAlreadyOpen(typeof(ProcessOrder));
                    foreach (Form OpenForm in this.MdiChildren)
                    {
                        if (OpenForm == selectedForm)
                        {
                            if (selectedForm.WindowState == FormWindowState.Minimized)
                            {
                                selectedForm.WindowState = FormWindowState.Normal;
                            }
                            selectedForm.Select();
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.GetBaseException().ToString());
            }
        }
    }
}
