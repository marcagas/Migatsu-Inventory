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
    public partial class ProcessOrder : Form
    {

        GlobalVariables gd = new GlobalVariables();
        DefaultStatus status = new DefaultStatus();
        FilterFunctions filterFunc = new FilterFunctions();

        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;

        string defaultSelect = DefaultStatus.STR_DEFAULT,
               strSelect = "";

        bool productExist = false,
             formChanges = false;
        
        DataTable table; 

        public ProcessOrder()
        {
            InitializeComponent();
        }

        private void ProcessOrder_Load(object sender, EventArgs e)
        {
            buttonNew.Focus();
            populateWarehouse();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            if (formChanges == false)
            {
                textBoxDeliveryNumber.Text = filterFunc.populateDeliveryNumber();
                buttonNew.Enabled = false;
                enableComponents();
            }
            else
            {

            }
        }

        /*
         * Enable form components 
         */
        private void enableComponents()
        {
            buttonSearchOrder.Enabled = true;
            comboBoxWarehouse.Enabled = true;
            buttonAddToDeliveryList.Enabled = true;
            buttonSave.Enabled = true;             
        }

        /*
         * Disable form components
         */
        private void disableComponents()
        {
            buttonSearchOrder.Enabled = false;
            comboBoxWarehouse.Enabled = false;
            buttonAddToDeliveryList.Enabled = false;
            buttonSave.Enabled = false;            
        }

        private void clearFields()
        {

        }

        private void populateWarehouse()
        {
            string[] warehouseList;
            warehouseList = filterFunc.fetchWarehouse();

            //add default selected
            comboBoxWarehouse.Items.Add(defaultSelect);
            int warehouseLen = warehouseList.Length;
            for (int i = 0; i < warehouseLen; i++)
            {
                comboBoxWarehouse.Items.Add(warehouseList[i]);
            }
            comboBoxWarehouse.SelectedItem = defaultSelect;
        }

        private void buttonSearchOrder_Click(object sender, EventArgs e)
        {
            SearchClientOrder clientOrder = new SearchClientOrder();
            clientOrder.ShowDialog();
        }

        private void linkLabelClearList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
