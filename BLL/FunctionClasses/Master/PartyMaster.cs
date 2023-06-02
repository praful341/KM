using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class PartyMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Request Request = new Request();
        Employee_Master employee_master = new Employee_Master();
        public int Save(Party_MasterProperty pClsProperty)
        {
            try
            {
                Request Request = new Request();

                Request.AddParams("@party_id", pClsProperty.party_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@party_name", pClsProperty.party_name.ToUpper(), DbType.String, ParameterDirection.Input);
                Request.AddParams("@party_type", pClsProperty.party_type.ToUpper(), DbType.String, ParameterDirection.Input);
                Request.AddParams("@active", pClsProperty.active, DbType.Boolean, ParameterDirection.Input);
                Request.AddParams("@user_id", pClsProperty.user_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@ip_address", pClsProperty.ip_address, DbType.String, ParameterDirection.Input);
                Request.AddParams("@entry_date", DateTime.Today.ToString("MM-dd-yyyy"), DbType.Date, ParameterDirection.Input);
                Request.AddParams("@entry_time", DateTime.Now.ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input);

                Request.AddParams("@company_id", pClsProperty.company_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@branch_id", pClsProperty.branch_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@location_id", pClsProperty.location_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@department_id", pClsProperty.department_id, DbType.Int32, ParameterDirection.Input);

                Request.CommandText = "MST_Party_Save";
                Request.CommandType = CommandType.StoredProcedure;
                return Ope.ExecuteNonQuery(Connection.DBKMConnectionString, Connection.Provider, Request);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable GetDataPartyMaster(int active = 0, int numCompanyCode = 0, int numBranchCode = 0, int numLocationCode = 0, int numDepartmentCode = 0)
        {
            DataTable DT = new DataTable("Table");
            Request.CommandText = "MST_Party_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@Active", active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@company_id", numCompanyCode, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@location_id", numLocationCode, DbType.Int32, ParameterDirection.Input);
            Ope.GetDataTable(Connection.DBKMConnectionString, Connection.Provider, DT, Request);
            return DT;
        }
    }
}
