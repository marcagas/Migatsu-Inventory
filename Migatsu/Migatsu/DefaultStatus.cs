using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Migatsu
{
    class DefaultStatus
    {
        /*
         * Default string values
         */ 
        public static string STR_DEFAULT = "Select...";
        public string COMPANY_NAME = "Company Name";
        public string CONTACT_PERSON = "Contact Person";
        public string SALES_NUMBER = "Sales Order Number";

        /*
         * datagridview toolstrip status
         */
        public string TOTAL_CLIENTS = "Total Clients: ";
        public string TOTAL_SUPPLIERS = "Total Suppliers: ";
        public string NUMBER_OF_PRODUCTS = "Number of Products Selected: ";
        public string TOTAL_CLIENT_ORDERS = "Total Client Orders: ";


        /*
         * Messages in messageboxes
         */
        //INFO
        public string MSG_UNSAVE_TRANSACTION = "Do you want to close this form without \n saving this transaction?",
                      MSG_PRODUCT_SUCCESSFULLY_SAVED = "Product was successfully saved.",
                      MSG_PRODUCTS_SUCCESSFULLY_SAVED = "Products were successfully saved.",
                      MSG_ORDER_SUCCESSFULLY_SAVED = "Client order successfully saved.",
                      MSG_CATEGORY_SAVED = "New category has been saved.",
                      MSG_CATEGORY_ADDED = "New category has been added.",
                      MSG_COLOR_SAVED = "New Color has been saved.",
                      MSG_UNSAVE_DATA = "Do you want to close this form without \n saving the changes you've made?";

        //WARNING
        public string MSG_SELECT_CLIENT = "Select a client from the list.",
                      MSG_SELECT_PROD_TO_ADD = "Select the product to add to inventory.",
                      MSG_ENTER_PROD_QUANTITY = "Enter product quantity.",
                      MSG_INVALID_PROD_QUANTITY = "Invalid product quantity.",
                      MSG_SELECT_WAREHOUSE_TO_KEEP = "Select the warehouse where the product will be kept.",
                      MSG_SELECT_SUPPLIER = "Select supplier.",
                      MSG_SELECT_PRODUCT = "Select a product.",
                      MSG_ENTER_PURCHASEORDERNUM = "Enter purchase order number for reference.",
                      MSG_ENTER_CLIENT = "Enter a client.",
                      MSG_ENTER_SALESNUMBER = "Enter sales order number.",
                      MSG_NO_PRODUCT_ORDERED = "No products ordered.",
                      MSG_INSERT_CLIENT_ORDER_ERROR = "An error occured, please try again \n or contact your administrator",
                      MSG_CATEGORY_EXISTS = "Category name already exists.",
                      MSG_ENTER_CATEGORY = "Please enter a category name",
                      MSG_COLOR_EXISTS = "Color already exists.",
                      MSG_ENTER_COLOR = "Please enter color";
        

        //QUESTION
        public string MSG_REMOVE_ALL_DATA = "Are you sure you want to remove all data in this form?";

        //ERROR
        public string MSG_NO_PRODUCT_ENTERED = "No product was entered in the list.";


        /*
         * Messages Title in messageboxes
         */
        public string MSG_TITLE_WARNING = "Warning",
                      MSG_TITLE_ERROR = "Error",
                      MSG_TITLE_SUCCESS = "Success";
        

        /*
         * database fields
         */
        public string DB_COMPANY_NAME = "Company_Name",     // field for name of client and supplier
                      DB_CONTACT_PERSON = "Contact_Person", // field for contact person of company
                      DB_SUPPLIER_ID = "Client_ID";         // field for clientid


        /*
         * Standard column names in datagridviews
         */
        public string COL_PROD_NAME = "Product Name",    // column name for product name
                      COL_PROD_ID = "Product Id",        // column name for product id
                      COL_QUANTITY = "Quantity",         // column name for quantity of products
                      COL_WAREHOUSE = "Warehouse",       // column name for warehouses
                      COL_PROD_MODEL = "Model",          // column name for product model
                      COL_PROD_BRAND = "Brand",          // column name for product brand
                      COL_PROD_SPEC_FEATURE = "Special Feature", // column name for product special feature
                      COL_PROD_DESCRIPTION = "Description",      // column name for product description
                      COL_PROD_UNIT = "Unit",            // column name for product unit
                      COL_PROD_SIZE = "Size",            // column name for product size
                      COL_PROD_COLOR = "Color";          // column name for product color
        
    }
}
