using System;
using DLL;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.FunctionClasses.Master
{
    public class SubSieveMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Request Request = new Request();
        public DataTable GetDataSubSieveMaster(int active = 0)
        {
            DataTable DT = new DataTable("Table");
            Request.CommandText = "MST_Sub_Sieve_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@Active", active, DbType.Int32, ParameterDirection.Input);
            Ope.GetDataTable(Connection.DBKMConnectionString, Connection.Provider, DT, Request);
            return DT;
        }
    }
}
