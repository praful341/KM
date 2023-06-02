using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace KM.Utility
{
    public class AdminMenuManager
    {
        public List<Form_MasterProperty> GetSitemMenuItems(int RoleID)
        {
            FormPermission objFormMaster = new FormPermission();
            DataTable dataTable = objFormMaster.GetMenuWithRights(RoleID);
            List<Form_MasterProperty> MenuList = DataRowToObject.CreateListFromTable<Form_MasterProperty>(dataTable);
            return MenuList;
        }
    }
}