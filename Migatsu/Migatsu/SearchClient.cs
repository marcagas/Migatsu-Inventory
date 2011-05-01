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
    public partial class SearchClient : Form
    {
        FilterFunctions filterFunc = new FilterFunctions();
        DefaultStatus status = new DefaultStatus();
        string clientId = "",
               defaultSelect = DefaultStatus.STR_DEFAULT;

        public SearchClient()
        {
            InitializeComponent();
        }

        private void SearchClient_Load(object sender, EventArgs e)
        {
            //add search keywords
            comboBoxSearchBy.Items.Add(defaultSelect);
            comboBoxSearchBy.Items.Add(status.COMPANY_NAME);
            comboBoxSearchBy.Items.Add(status.CONTACT_PERSON);

            comboBoxSearchBy.SelectedItem = defaultSelect;

            populateClientList();

            //hide supplier id
            dataGridViewClientList.Columns["Client_ID"].Visible = false;
            displayStatus();
            
            unselectData();
            textBoxKeyword.Focus();
        }

        /*
         * display the number of total clients
         */
        private void displayStatus()
        {
            int numClients = dataGridViewClientList.RowCount;
            toolStripTotalClients.Text = status.TOTAL_CLIENTS + Convert.ToString(numClients);
        }

        /*
         * populate the list of client in the grid view
         */
        private void populateClientList()
        {
            dataGridViewClientList.DataSource = filterFunc.fetchClientList();
            return;
        }

        /*
         * unselect all data in the grid view
         */
        private void unselectData()
        {
            int numRow = dataGridViewClientList.RowCount;
            for (int i = 0; i < numRow; i++)
            {
                dataGridViewClientList[0, i].Selected = false;
            }
            return;
        }

        private void filterClientLilst(string filter, string key)
        {
            dataGridViewClientList.DataSource = filterFunc.filterClientList(filter, key);
            unselectData();
            displayStatus();
        }

        private void comboBoxSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filterString = "";
            if (comboBoxSearchBy.SelectedItem != defaultSelect)
            {                
                if (comboBoxSearchBy.SelectedItem == status.COMPANY_NAME)
                {
                    filterString = status.DB_COMPANY_NAME;
                }
                else if (comboBoxSearchBy.SelectedItem == status.CONTACT_PERSON)
                {
                    filterString = status.DB_CONTACT_PERSON;
                }
                filterClientLilst(filterString, textBoxKeyword.Text.Trim());
            }
        }

        private void textBoxKeyword_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxSearchBy.SelectedItem == defaultSelect)
            {
                filterClientLilst(status.DB_COMPANY_NAME + " OR " + status.DB_CONTACT_PERSON, textBoxKeyword.Text.Trim());
            }
            else
            {
                if (comboBoxSearchBy.SelectedItem == status.COMPANY_NAME)
                {
                    filterClientLilst(status.DB_COMPANY_NAME, textBoxKeyword.Text.Trim());
                }
                else if (comboBoxSearchBy.SelectedItem == status.CONTACT_PERSON)
                {
                    filterClientLilst(status.DB_CONTACT_PERSON, textBoxKeyword.Text.Trim());
                }
                
            }
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            if (clientId != "" && clientId != null)
            {
                GlobalVariables.clientId = clientId;
                this.Close();
            }
            else
            {
                MessageBox.Show(status.MSG_SELECT_CLIENT, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridViewClientList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                clientId = dataGridViewClientList[status.DB_SUPPLIER_ID, row].Value.ToString();
            }
            catch (Exception x)
            {
                clientId = "";
            }
            
        }


    }
}
