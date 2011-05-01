using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Migatsu
{   
    class FilterFunctions
    {
        GlobalVariables gd = new GlobalVariables();
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds;

        int i = 0;
        int drLen = 0;
        string table_warehouse = "WAREHOUSE";
        string table_category = "CATEGORY";
        string table_subcategory = "SUBCATEGORY";
        string column_categoryID = "Category_ID";
        string strSelect = "";
        string strInsert = "";
        
        /*
         * Transaction types:
         * 1 - purchase
         * 2 - sales
         * 3 - damage
         * 4 - sample
         * 5 - deduct transfer products
         * 6 - add transfer
        */
        int purchaseTransaction = 1,
            salesTransaction = 2,
            damageTransaction = 3,
            sampleTransaction = 4,
            deductTransaction = 5,
            addTransaction = 6;

        //product fields
        string _ID = "ID",
               _Product_Name = "Product_Name",
               _Model = "Model",
               _Description = "Description",
               _Brand = "Brand",
               _Unit = "Unit",
               _Size = "Size",
               _Color = "Color",
               _Category_Name = "Category_Name",
               _Sub_Category_Name = "Sub_Category_Name",
               _Special_Feature = "Special_Feature",
               _Quantity = "Quantity";

        //supplier and client fields
        string _Company_Name = "Company_Name",
               _Address = "Address",
               _Contact_Person = "Contact_Person";

        public string[] selectCategory()
        {
            string[] categoryList;
            
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            strSelect = "SELECT Category_Name from CATEGORY";
            cmd = new SqlCommand(strSelect, conn);

            dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                i = 0;                
                drLen = countNumOfRows(table_category, "", -1);
                categoryList = new string[drLen];
                while (dr.Read())
                {
                    categoryList[i] = dr["Category_Name"].ToString();
                    i++;
                }
                dr.Close();
            }
            else
            {
                categoryList = null;
            }
            conn.Close();
            return categoryList;
            
        }

        public string[] selectSubCategory(int categoryID)
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string[] subCategoryList = new string[100];

            strSelect = "SELECT Sub_Category_Name FROM SUBCATEGORY WHERE Category_ID=@categoryID";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("categoryID", (object)categoryID));
            dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                i = 0;
                drLen = countNumOfRows(table_subcategory, column_categoryID,categoryID);
                subCategoryList = new string[drLen];
                while (dr.Read())
                {
                    subCategoryList[i] = dr["Sub_Category_Name"].ToString();
                    i++;
                }
                dr.Close();
            }
            else
            {
                subCategoryList = null;
            }
            conn.Close();
            return subCategoryList;
        }

        public string[] fetchWarehouse()
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();
            string[] warehouseList;
            
            strSelect = "SELECT Warehouse_Name from WAREHOUSE";
            cmd = new SqlCommand(strSelect, conn);
            dr = cmd.ExecuteReader();            
            if (dr.HasRows == true)
            {
                i = 0;
                drLen = countNumOfRows(table_warehouse, "", -1);                
                warehouseList = new string[drLen];
                while (dr.Read())
                {                    
                    warehouseList[i] = dr["Warehouse_Name"].ToString();
                    i++;
                }
                dr.Close();
            }
            else
            {
                warehouseList = null;
            }
            conn.Close();
            return warehouseList;
        }

        private int countNumOfRows(string tableName, string columnName, int ID)
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            string strCount = "SELECT count(*) from " + tableName;
            if (ID >= 0 && columnName != null && columnName != "")
            {
                strCount += " where " + columnName + "=" + ID;
            }
            cmd = new SqlCommand(strCount, conn);
            int rowCount = Convert.ToInt16(cmd.ExecuteScalar());
                        
            return rowCount;
        }

        public int getCategoryID(string categoryName)
        {
            int categoryID;
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            strSelect = "SELECT ID FROM CATEGORY WHERE Category_Name = @categoryName";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("categoryName", (object)categoryName));
            categoryID = Convert.ToInt16(cmd.ExecuteScalar());
            
            conn.Close();
            return categoryID;
        }

        public string validateIntegerInput(string data)
        {
            string result = "";
            int strLen = data.Length;
            int parsedInt;

            for (int i = 0; i < strLen; i++)
            {
                if (int.TryParse(data[i].ToString(), out parsedInt))
                {
                    result += data[i].ToString();
                }
                else
                {
                    return result;
                }
            }
            return result;
        }

        public string[] fetchProductInformation(int productId)
        {
            string[] productInformation = new string[12];
            if (productId == null)
            {
                return productInformation = null;
            }
            else
            {
                //select product information
                conn = new SqlConnection(gd.ConString);
                conn.Open();

                strSelect = "SELECT [product id] as ID, Product_Name, Model, Description, Brand, Unit, Size, Color, " +
                            "Category_Name, Sub_Category_Name, Special_Feature, [quantity total] as Quantity FROM FINALVIEWWHOLEINVENTORY " +
                            "WHERE [product id] = @productID";
                cmd = new SqlCommand(strSelect, conn);
                cmd.Parameters.Add(new SqlParameter("productID", (object)productId));
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {                    
                    while (dr.Read())
                    {
                        productInformation[0] = dr[_ID].ToString();
                        productInformation[1] = dr[_Product_Name].ToString();
                        productInformation[2] = dr[_Model].ToString();
                        productInformation[3] = dr[_Description].ToString();
                        productInformation[4] = dr[_Brand].ToString();
                        productInformation[5] = dr[_Unit].ToString();
                        productInformation[6] = dr[_Size].ToString();
                        productInformation[7] = dr[_Color].ToString();
                        productInformation[8] = dr[_Category_Name].ToString();
                        productInformation[9] = dr[_Sub_Category_Name].ToString();
                        productInformation[10] = dr[_Special_Feature].ToString();
                        productInformation[11] = dr[_Quantity].ToString();
                    }
                    dr.Close();
                }
                conn.Close();
                return productInformation;
            }
            return productInformation = null;
        }

        public bool saveDamagedProducts(int prodId, int quantity, string remarks, int profileId, int warehouseId)
        {
            try
            {
                conn = new SqlConnection(gd.ConString);
                conn.Open();

                strInsert = "INSERT INTO DAMAGE(Product_ID, Quantity, Remarks, Profile_ID) values" +
                            "(@prodId, @quantity, @remarks, @profileId)";
                cmd = new SqlCommand(strInsert, conn);
                cmd.Parameters.Add(new SqlParameter("prodId", (object)prodId));
                cmd.Parameters.Add(new SqlParameter("quantity", (object)quantity));
                cmd.Parameters.Add(new SqlParameter("remarks", (object)remarks));
                cmd.Parameters.Add(new SqlParameter("profileId", (object)profileId));
                cmd.ExecuteNonQuery();

                //get damage_id from damage 
                strSelect = "SELECT Max(ID) FROM DAMAGE";
                cmd = new SqlCommand(strSelect, conn);
                int damageId = Convert.ToInt32(cmd.ExecuteScalar());

                //insert to inventory table
                strInsert = "INSERT INTO INVENTORY(Product_ID, Warehouse_ID, Quantity, Transaction_Type, Damage_ID, " +
                            "Profile_ID) VALUES(@prodId, @warehouseId, @quantity, @transactionType, @damageId, @profileId)";
                cmd = new SqlCommand(strInsert, conn);
                cmd.Parameters.Add(new SqlParameter("prodId", (object)prodId));
                cmd.Parameters.Add(new SqlParameter("warehouseId", (object)warehouseId));
                cmd.Parameters.Add(new SqlParameter("quantity", (object)quantity));
                cmd.Parameters.Add(new SqlParameter("transactionType", (object)damageTransaction));
                cmd.Parameters.Add(new SqlParameter("damageId", (object)damageId));
                cmd.Parameters.Add(new SqlParameter("profileId", (object)profileId));
                cmd.ExecuteNonQuery();

                conn.Close();
                return true;
            }
            catch(Exception x)
            {
                return false;
            }
        }

        /*
         *  This function fetches the ID of warehouse from the database          
        */
        public int fetchWarehouseId(string warehouse)
        {
            int warehouseId = 0;
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            strSelect = "SELECT ID FROM WAREHOUSE WHERE Warehouse_Name=@warehouse";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("warehouse", (object)warehouse));
            warehouseId = Convert.ToInt32(cmd.ExecuteScalar());

            conn.Close();
            return warehouseId;
        }

        /*
         *  Deducts sample products from Inventory 
        */
        public bool deductSampleProducts(int prodId, int warehouseId, int quantity, int profileId, string remarks)
        {
            try
            {
                conn = new SqlConnection(gd.ConString);
                conn.Open();

                strInsert = "INSERT INTO INVENTORY(Product_ID, Warehouse_ID, Quantity, Transaction_Type, Profile_ID, " +
                            "Date_Of_Transaction, Remarks) VALUES(@prodId, @warehouseId, @quantity, @transactionType, " +
                            "@profileId, @dateOfTransaction, @remarks)";
                cmd = new SqlCommand(strInsert, conn);
                cmd.Parameters.Add(new SqlParameter("prodId", (object)prodId));
                cmd.Parameters.Add(new SqlParameter("warehouseId", (object)warehouseId));
                cmd.Parameters.Add(new SqlParameter("quantity", (object)quantity));
                cmd.Parameters.Add(new SqlParameter("transactionType", (object)sampleTransaction));
                cmd.Parameters.Add(new SqlParameter("profileId", (object)profileId));
                cmd.Parameters.Add(new SqlParameter("dateOfTransaction", (object)DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("remarks", (object)remarks));
                cmd.ExecuteNonQuery();

                conn.Close();
                return true;
            }
            catch (Exception x)
            {
                return false;
            }           
        }

        /*
         * This function fetches the Profile ID of the user
        */
        public int fetchProfileId(int accountId)
        {
            int profileId = 0;
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            strSelect = "SELECT ID FROM PROFILE WHERE User_Account_ID = @accountId";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("accountId", (object)accountId));
            profileId = Convert.ToInt32(cmd.ExecuteScalar());

            return profileId;
        }

        /*
         * Fetch current quantity on warehouse
        */
        public int fetchCurrentQuantityOnWarehouse(string warehouse, int prodId)
        {
            int quantity = 0;
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            strSelect = "SELECT [total quantity] as Quantity FROM FINALVIEWINVENTORY WHERE [product id]=@prodId " +
                        "and Warehouse_Name=@warehouse";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("prodId", (object)prodId));
            cmd.Parameters.Add(new SqlParameter("warehouse", (object)warehouse));
            quantity = Convert.ToInt32(cmd.ExecuteScalar());

            conn.Close();
            return quantity;
        }

        /*
         * Inserts the transfer of products transaction in the database 
        */
        public bool saveTransferOfProducts(int prodId, int fromWarehouseId, int toWarehouseId, int quantity, string remarks)
        {
            try
            {
                conn = new SqlConnection(gd.ConString);
                conn.Open();

                //insert to inventory - deduct transaction
                strInsert = "INSERT INTO INVENTORY(Product_ID, Warehouse_ID, Quantity, Transaction_Type, " +
                            "Profile_ID, Date_Of_Transaction, Remarks) VALUES(@prodId, @warehouseId, @quantity, " +
                            "@transactionType, @profileId, @dateOfTransaction, @remarks)";
                cmd = new SqlCommand(strInsert, conn);
                cmd.Parameters.Add(new SqlParameter("prodId", (object)prodId));
                cmd.Parameters.Add(new SqlParameter("warehouseId", (object)fromWarehouseId));
                cmd.Parameters.Add(new SqlParameter("quantity", (object)quantity));
                cmd.Parameters.Add(new SqlParameter("transactionType", (object)deductTransaction));
                cmd.Parameters.Add(new SqlParameter("profileId", (object)GlobalVariables.profileID));
                cmd.Parameters.Add(new SqlParameter("dateOfTransaction", (object)DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("remarks", (object)remarks));
                cmd.ExecuteNonQuery();

                //insert to inventory - add transaction
                strInsert = "INSERT INTO INVENTORY(Product_ID, Warehouse_ID, Quantity, Transaction_Type, " +
                            "Profile_ID, Date_Of_Transaction, Remarks) VALUES(@prodId, @warehouseId, @quantity, " +
                            "@transactionType, @profileId, @dateOfTransaction, @remarks)";
                cmd = new SqlCommand(strInsert, conn);
                cmd.Parameters.Add(new SqlParameter("prodId", (object)prodId));
                cmd.Parameters.Add(new SqlParameter("warehouseId", (object)toWarehouseId));
                cmd.Parameters.Add(new SqlParameter("quantity", (object)quantity));
                cmd.Parameters.Add(new SqlParameter("transactionType", (object)addTransaction));
                cmd.Parameters.Add(new SqlParameter("profileId", (object)GlobalVariables.profileID));
                cmd.Parameters.Add(new SqlParameter("dateOfTransaction", (object)DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("remarks", (object)remarks));
                cmd.ExecuteNonQuery();

                conn.Close();
                return true;
            }
            catch (Exception x)
            {
                return false;
            }
        }

        /*
         * Select supplier information
         */
        public string[] fetchSupplierDetails(int supplierId)
        {
            string[] supplierDetails = new string[3];
            i = 0;
            conn = openDBConnection();
            strSelect = "SELECT Company_Name, Contact_Person, Address FROM SUPPLIER WHERE Supplier_ID = @supplierId";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("supplierId", (object)supplierId));
            dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    supplierDetails[0] = dr[_Company_Name].ToString();
                    supplierDetails[1] = dr[_Contact_Person].ToString();
                    supplierDetails[2] = dr[_Address].ToString();
                }
                dr.Close();
            }
            else
            {
                supplierDetails = null;
            }
            closeDBConnection();
            return supplierDetails;
        }

        /*
         * Opens the database and returns the connection
         */
        private SqlConnection openDBConnection()
        {
            conn = new SqlConnection(gd.ConString);
            conn.Open();

            return conn;
        }

        /*
         * close the database connection
         */ 
        private void closeDBConnection()
        {
            conn.Close();
        }

        /*
         * fetch client details
         */
        public string[] fetchClientDetails(int clientId)
        {
            string[] clientDetails = new string[3];

            conn = openDBConnection();

            strSelect = "SELECT Company_Name, Contact_Person, Address FROM CLIENT WHERE Client_ID=@clientId";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("clientId", (object)clientId));
            dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    clientDetails[0] = dr[_Company_Name].ToString();
                    clientDetails[1] = dr[_Contact_Person].ToString();
                    clientDetails[2] = dr[_Address].ToString();
                }
                dr.Close();
            }

            closeDBConnection();
            return clientDetails;
        }

        /*
         * select the list of clients
         */
        public object fetchClientList()
        {
            conn = openDBConnection();
            strSelect = "SELECT Client_ID, Company_Name as [Company], Contact_Person as [Contact Person], " +
                        "Address FROM CLIENT";
            cmd = new SqlCommand(strSelect, conn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet("ds");
            da.Fill(ds);
            ds.Tables[0].TableName = "table_data";
            
            closeDBConnection();
            return ds.Tables["table_data"];            
        }

        /* 
         * select the list of client orders
         */
        public object fetchClientOrderList()
        {
            conn = openDBConnection();
            strSelect = "SELECT Order_Number AS [Sales Order Number], Company_Name AS [Company Name], Representative, Date_Entered AS [Date Ordered] "+
                        "FROM [ORDER] AS o INNER JOIN CLIENT as c on c.Client_ID=o.Client_ID";
            cmd = new SqlCommand(strSelect, conn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet("ds");
            da.Fill(ds);
            ds.Tables[0].TableName = "table_data";

            closeDBConnection();
            return ds.Tables["table_data"];
        }

        /* 
         * select the list of clients base on criteria
         */
        public object filterClientList(string filter, string key)
        {
            conn = openDBConnection();
            if (filter.Contains("OR"))
            {
                strSelect = "SELECT Client_ID, Company_Name as [Company], Contact_Person as [Contact Person], " +
                    "Address FROM CLIENT WHERE " + (filter != null ? (filter.Substring(0, filter.IndexOf("OR"))) : "") +
                    " like '%" + (key != null ? key : "") + "%' OR " + (filter != null ? (filter.Substring(filter.IndexOf("OR") + 2)) : "") +
                    " like '%" + (key != null ? key : "") + "%'";
            }
            else
            {
                strSelect = "SELECT Client_ID, Company_Name as [Company], Contact_Person as [Contact Person], " +
                    "Address FROM CLIENT WHERE " + (filter != null ? filter : "") + " like '%" + (key != null ? key : "") + "%'";
            }
            cmd = new SqlCommand(strSelect, conn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet("ds");
            da.Fill(ds);
            ds.Tables[0].TableName = "table_data";
            
            closeDBConnection();
            return ds.Tables["table_data"];
        }

        /*
         * populate sales number
         */
        public string populateSalesNumber()
        {
            string salesNumber = "";

            conn = openDBConnection();
            strSelect = "SELECT count(*) FROM [ORDER]";
            cmd = new SqlCommand(strSelect, conn);
            int i = Convert.ToInt16(cmd.ExecuteScalar());
            i++;
            salesNumber = Convert.ToString(10000 + i);
            salesNumber = DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year + "-SO-" + salesNumber.Substring(1);

            closeDBConnection();
            return salesNumber;
        }

        /*
         * insert order data to database
         */
        public bool insertClientOrder(string[] orderData, int rows, string[,] orderDetails)
        {
           try
           {
                int pendingId = 0;

                if (orderData != null)
                {
                    conn = openDBConnection();  

                    // insert data to order table
                    strInsert = "INSERT INTO [ORDER](Order_Number, Representative, Client_ID, Date_Entered, " +
                                "Entered_BY, Delivery_Address) VALUES(@orderNumber, @representative, @clientId, " +
                                "@dateEntered, @enteredBy, @deliveryAddress)";

                    cmd = new SqlCommand(strInsert, conn);
                    cmd.Parameters.Add(new SqlParameter("orderNumber", (object)orderData[0]));
                    cmd.Parameters.Add(new SqlParameter("representative", (object)orderData[1]));
                    cmd.Parameters.Add(new SqlParameter("clientId", (object)orderData[2]));
                    cmd.Parameters.Add(new SqlParameter("dateEntered", (object)orderData[3]));
                    cmd.Parameters.Add(new SqlParameter("enteredBy", (object)orderData[4]));
                    cmd.Parameters.Add(new SqlParameter("deliveryAddress", (object)orderData[5]));

                    cmd.ExecuteNonQuery();

                    // insert data to pending tables2
                    strInsert = "INSERT INTO PENDING(Order_number) VALUES(@orderNumber)";
                    cmd = new SqlCommand(strInsert, conn);
                    cmd.Parameters.Add(new SqlParameter("orderNumber", (object)orderData[0]));
                    cmd.ExecuteNonQuery();

                    //get pendingId
                    pendingId = getPendingId(orderData[0]);
                    conn = openDBConnection();
                    int detailsLength = orderDetails.GetLength(0);
                    for (int i = 0; i < detailsLength; i++)
                    {
                        // insert to order details table and pending details
                        strInsert = "INSERT INTO ORDER_DETAILS(Order_Number, Product_ID, Quantity) values(@salesOrderNumber, " +
                                    "@productId, @quantity)";
                        cmd = new SqlCommand(strInsert, conn);
                        cmd.Parameters.Add(new SqlParameter("salesOrderNumber", (object)orderData[0]));
                        cmd.Parameters.Add(new SqlParameter("productId", (object)orderDetails[i, 0]));
                        cmd.Parameters.Add(new SqlParameter("quantity", (object)orderDetails[i, 1]));
                        cmd.ExecuteNonQuery();

                        strInsert = "INSERT INTO PENDING_DETAILS(Pending_ID, Product_ID, Quantity) values (@pendingID, " +
                                    "@productId, @quantity)";
                        cmd = new SqlCommand(strInsert, conn);
                        cmd.Parameters.Add(new SqlParameter("pendingId", (object)pendingId));
                        cmd.Parameters.Add(new SqlParameter("productId", (object)orderDetails[i, 0]));
                        cmd.Parameters.Add(new SqlParameter("quantity", (object)orderDetails[i, 1]));
                        cmd.ExecuteNonQuery();
                    }
                   

                    closeDBConnection();
                    return true;
                }
                else
                {
                    return false;
                }
           }
           catch (Exception x)
           {
                return false;
           }
        }

        /*
         * get the latest pending id 
         */
        public int getPendingId(string salesOrderNumber)
        {
            int pendingId = 0;
            conn = openDBConnection();

            strSelect = "SELECT ID FROM PENDING WHERE Order_Number=@salesOrderNumber";
            cmd = new SqlCommand(strSelect, conn);
            cmd.Parameters.Add(new SqlParameter("salesOrderNumber", (object)salesOrderNumber));
            pendingId = Convert.ToInt16(cmd.ExecuteScalar());

            closeDBConnection();

            return pendingId;
        }

        /*
         * populate delivery number
         */
        public string populateDeliveryNumber()
        {
            string deliveryNumber = "";

            conn = openDBConnection();
            strSelect = "SELECT COUNT(*) FROM DELIVERYRECEIPT";
            cmd = new SqlCommand(strSelect, conn);
            int i = Convert.ToInt16(cmd.ExecuteScalar());
            i++;
            deliveryNumber = Convert.ToString(10000 + i);
            deliveryNumber = DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year + "-DR" + deliveryNumber.Substring(1);

            closeDBConnection();
            return deliveryNumber;
        }

    }
}
