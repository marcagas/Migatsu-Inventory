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
    public partial class SearchClientOrder : Form
    {
        GlobalVariables gd = new GlobalVariables();
        DefaultStatus status = new DefaultStatus();
        FilterFunctions filterFunc = new FilterFunctions();

        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;

        string strSelect,
               defaultSelect = DefaultStatus.STR_DEFAULT,
               result = "";

        public SearchClientOrder()
        {
            InitializeComponent();
        }

        private void SearchClientOrder_Load(object sender, EventArgs e)
        {
            // add search keywords
            comboBoxSearchBy.Items.Add(defaultSelect);
            comboBoxSearchBy.Items.Add(status.SALES_NUMBER);
            comboBoxSearchBy.Items.Add(status.COMPANY_NAME);

            comboBoxSearchBy.SelectedItem = defaultSelect;

            populateClientOrderList();
            displayStatus();
            unselectData();
            textBoxKeyword.Focus();
        }

        /*
         * display the number of total client orders
         */
        private void displayStatus()
        {
            int numClients = dataGridViewClientOrderList.RowCount;
            toolStripClientOrders.Text = status.TOTAL_CLIENT_ORDERS + Convert.ToString(numClients);
        }

        /*
         * populate the list of client orders in the grid view
         */
        private void populateClientOrderList()
        {
            dataGridViewClientOrderList.DataSource = filterFunc.fetchClientOrderList();
        }

        /*
         * unselect all data in the grid view 
         */
        private void unselectData() 
        {
            int numRow = dataGridViewClientOrderList.RowCount;
            for (int i = 0; i < numRow; i++)
            {
                dataGridViewClientOrderList[0, i].Selected = false;
            }
        }
    }
}
