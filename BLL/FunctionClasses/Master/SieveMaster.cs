using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.FunctionClasses.Master
{
    public class SieveMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Request Request = new Request();
        public DataTable GetDataSieveMaster(int active = 0)
        {
            DataTable DT = new DataTable("Table");
            Request.CommandText = "MST_Sieve_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@Active", active, DbType.Int32, ParameterDirection.Input);
            Ope.GetDataTable(Connection.DBKMConnectionString, Connection.Provider, DT, Request);
            return DT;
        }
    }
}
