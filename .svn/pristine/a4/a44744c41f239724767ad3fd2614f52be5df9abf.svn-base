using BLL.PropertyClasses.Master;
using KM.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Web;

namespace KM.Utility
{
    public static class SessionFacade
    {
        private const string LoggedInUser = "LoggedInUser";
        private const string FormPermissions = "FormPermissions";
        private const string MACAddr_ = "MACAddr";
        private const string Menu_List = "MenuList";
        public static bool IsPersistent { get; set; }
        public static Models.Employee_Master UserSession
        {
            get
            {
                Models.Employee_Master userAuth
                         = (Models.Employee_Master)HttpContext.Current.Session[LoggedInUser];

                return userAuth;
            }
            set
            {
                HttpContext.Current.Session[LoggedInUser] = value;
            }
        }
        public static BLL.PropertyClasses.Master.Employee_Master UserNewSession
        {
            get
            {
                BLL.PropertyClasses.Master.Employee_Master userMasterAuth
                         = (BLL.PropertyClasses.Master.Employee_Master)HttpContext.Current.Session[LoggedInUser];
                return userMasterAuth;
            }
            set
            {
                HttpContext.Current.Session[LoggedInUser] = value;
            }
        }
        public static List<Form_Permission> FormPermissionList
        {
            get
            {
                List<Form_Permission> list
                        = (List<Form_Permission>)HttpContext.Current.Session[FormPermissions];
                return list;
            }

            set
            {
                HttpContext.Current.Session[FormPermissions] = value;
            }
        }

        public static string MACAddr
        {
            get
            {
                string str
                          = (string)HttpContext.Current.Session[MACAddr_];
                return str;
            }
            set
            {
                HttpContext.Current.Session[MACAddr_] = value;
            }
        }

        public static List<Form_MasterProperty> MenuList
        {
            get
            {
                List<Form_MasterProperty> list
                         = (List<Form_MasterProperty>)HttpContext.Current.Session[Menu_List];
                return list;
            }

            set
            {
                HttpContext.Current.Session[Menu_List] = value;
            }
        }
        public static string gStrComputerIP
        {
            get
            {
                string strHostName = "";
                strHostName = System.Net.Dns.GetHostName();

                //IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
                //IPAddress[] addr = ipEntry.AddressList;

                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

                foreach (IPAddress a in localIPs)
                {
                    if (a.AddressFamily == AddressFamily.InterNetwork)
                    {
                        strHostName = a.ToString();
                    }
                }
                if (localIPs.Length == 0)
                {
                    return System.Environment.MachineName.ToString();
                }
                else
                {
                    return strHostName;
                }
            }
        }
    }
}