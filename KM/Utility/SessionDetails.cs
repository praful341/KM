using BLL.PropertyClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KM.Utility
{
    public static class SessionDetails
    {
        private const string LoggedInUser = "LoggedInUser";
        private const string LoggedInClient = "LoggedInClient";
        public static User_Login_Master_Property UserSession
        {
            get
            {
                User_Login_Master_Property userAuth = (User_Login_Master_Property)HttpContext.Current.Session[LoggedInUser];
                return userAuth;
            }
            set
            {
                HttpContext.Current.Session[LoggedInUser] = value;
            }
        }
    }
}