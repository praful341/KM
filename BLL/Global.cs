using System;
using System.Net.NetworkInformation;

namespace BLL
{
    public static class Global
    {
        public static string _IPAddress;
        public static string IPAddress
        {
            get { return _IPAddress; }
            set { _IPAddress = value; }
        }

        public static void initGlobalConn()
        {
            //Connection.DBKMConnectionString = Connection.Decrypt(ConfigurationManager.ConnectionStrings["DBKMConnectionString"].ConnectionString, true);
            //Connection.DBKMConnectionString = "Data Source=192.168.1.112;Initial Catalog=DERP;User ID=sa;Password=admin@123";
            //Connection.DBKMConnectionString = "Data Source=192.168.1.112;Initial Catalog=DERP_SALES_31072020;User ID=sa;Password=admin@123";
            Connection.DBKMConnectionString = "Data Source=SQL5054.site4now.net,1433;Initial Catalog=DB_A4B382_DERP;User Id=DB_A4B382_DERP_admin;Password=admin@123;";
            Connection.Provider = "System.Data.SqlClient";
            //Connection.Provider = "sqloledb";
            //string dycrypt = "sqloledb";
            string dycrypt = "System.Data.SqlClient";
            string encrypt = Connection.Encrypt(dycrypt, true);
            dycrypt = Connection.Decrypt(encrypt, true);

        }

        public static string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }
    }
}
