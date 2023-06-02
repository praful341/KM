using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.FunctionClasses.Master
{
    public class FormMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Request Request = new Request();
        public DataTable GetDataFormMaster()
        {
            DataTable DT = new DataTable("Table");
            Request.CommandText = "WEB_MST_Form_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(Connection.DBKMConnectionString, Connection.Provider, DT, Request);
            return DT;
        }

    }
}
