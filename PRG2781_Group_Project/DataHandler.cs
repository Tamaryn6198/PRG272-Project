using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace PRG2781_Group_Project
{
    internal class DataHandler
    {
        // details for connection string
        static string host = "TAMMYLAPTOP\\SQLEXPRESS";
        static string database = "BCdatabase";
        public static string connString = @"Data Source = " + host + "; Initial Catalog=" + database + ";Integrated Security=SSPI";

        // variables for connection and commands
        SqlConnection conn;
        SqlCommand cmd;
        SqlCommand cmd2;

        public DataHandler()
        {
            // Constructor
        }

        // Methods for Modules


        //-----------------------------------------------------------------------------------------------------------------------------------------------------//

        // Methods for Students


    }
}
