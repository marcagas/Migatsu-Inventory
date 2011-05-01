using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Security.Cryptography;

namespace Migatsu
{
    public class GlobalVariables
    {
        public string ConString = @"Data Source=.;Initial Catalog=MIGATSUENTERPRISE;Integrated Security=SSPI";
        public SqlConnection CN;
        public SqlDataReader dr;
        public SqlCommand cmd;
        public string productName = "";

        public  int User_ID;
        public  string Username = "";
        public  string First_Name = "";
        public  string Middle_Name = "";
        public  string Last_Name = "";
        public  bool Is_Admin;
        public  bool Is_First_Time_Login;

        public static bool Login_Counter = false;   //for login logout purposes
        public static string User;                  //for update of password we need the username
        public static string productID = "";             //use for searching of product for receiving inventory;
        public static string supplierID = "";
        public static int profileID;
        public static string clientId = "";         

        public string getMd5Hash(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString().ToLower();
        }
    }
}
