using DLL;
using System.Data;

namespace BLL.FunctionClasses.Master
{

    public class AssortMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Request Request = new Request();
        public DataTable GetDataAssortMaster(int active = 0)
        {
            DataTable DT = new DataTable("Table");
            Request.CommandText = "MST_Assort_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@Active", active, DbType.Int32, ParameterDirection.Input);
            Ope.GetDataTable(Connection.DBKMConnectionString, Connection.Provider, DT, Request);
            return DT;
        }

        public string GetLatestPrice(int p_numAssort_ID, int p_numSieve_ID, int p_rateTypeId)
        {
            Request Request = new Request();
            DataTable DTable = new DataTable();
            string p_numLetest_Price = string.Empty;
            Request.AddParams("@numassort_id", p_numAssort_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@numsieve_id", p_numSieve_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@rate_type_id", p_rateTypeId, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "MST_Get_LetestPrice";
            Request.CommandType = CommandType.StoredProcedure;

            p_numLetest_Price = Ope.ExecuteScalar(Connection.DBKMConnectionString, Connection.Provider, Request);
            return p_numLetest_Price;
        }
        
    }
}
