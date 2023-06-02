using DLL;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class DeliveryTypeMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();


        public DataTable GetData(int active = 0)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = "MST_Delivery_Type_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@Active", active, DbType.Int32, ParameterDirection.Input);
            Ope.GetDataTable(Connection.DBKMConnectionString, Connection.Provider, DTab, Request);
            return DTab;
        }
    }
}
