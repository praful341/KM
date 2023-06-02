using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Master
{
    public class BrokerMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Request Request = new Request();
        public int Save(Broker_MasterProperty pClsProperty)
        {
            try
            {
                Request Request = new Request();

                Request.AddParams("@broker_id", pClsProperty.broker_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@broker_name", pClsProperty.broker_name.ToUpper(), DbType.String, ParameterDirection.Input);
                Request.AddParams("@broker_type", pClsProperty.broker_type.ToUpper(), DbType.String, ParameterDirection.Input);
                Request.AddParams("@brokerage", pClsProperty.brokerage, DbType.Decimal, ParameterDirection.Input);
                Request.AddParams("@active", pClsProperty.active, DbType.Boolean, ParameterDirection.Input);
                Request.AddParams("@user_id", pClsProperty.user_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@ip_address", pClsProperty.ip_address, DbType.String, ParameterDirection.Input);
                Request.AddParams("@entry_date", DateTime.Today.ToString("MM-dd-yyyy"), DbType.Date, ParameterDirection.Input);
                Request.AddParams("@entry_time", DateTime.Now.ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input);

                Request.AddParams("@company_id", pClsProperty.company_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@branch_id", pClsProperty.branch_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@location_id", pClsProperty.location_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@department_id", pClsProperty.department_id, DbType.Int32, ParameterDirection.Input);

                Request.CommandText = "MST_Broker_Save";
                Request.CommandType = CommandType.StoredProcedure;
                return Ope.ExecuteNonQuery(Connection.DBKMConnectionString, Connection.Provider, Request);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable GetDataBrokerMaster(int active = 0, int numCompanyID = 0, int numBranchID = 0, int numLocationID = 0, int numDepartmentID = 0)
        {
            DataTable DT = new DataTable("Table");
            Request.CommandText = "MST_Broker_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@Active", active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@company_id", numCompanyID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@branch_id", numBranchID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@location_id", numLocationID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@department_id", numDepartmentID, DbType.Int32, ParameterDirection.Input);

            Ope.GetDataTable(Connection.DBKMConnectionString, Connection.Provider, DT, Request);
            return DT;
        }
    }
}
