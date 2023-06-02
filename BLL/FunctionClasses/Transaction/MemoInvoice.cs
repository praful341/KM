using DLL;
using System;
using System.Data;

namespace BLL.FunctionClasses.Transaction
{
    public class MemoInvoice
    {
        InterfaceLayer Ope = new InterfaceLayer();
        public DataTable GetMemoData(int p_numCompany_id, int p_numBranch_id, int p_numLocation_id, int p_numDepartment_id, string p_memoNo)
        {
            DataTable DTab = new DataTable();
            try
            {

                Request Request = new Request();
                Request.CommandText = "WEB_TRN_OutStanding_Memo";
                Request.CommandType = CommandType.StoredProcedure;
                Request.AddParams("@Company_id", p_numCompany_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@Branch_id", p_numBranch_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@Location_id", p_numLocation_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@Department_id", p_numDepartment_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@memo_no", (object)p_memoNo ?? DBNull.Value, DbType.String, ParameterDirection.Input);
                Ope.GetDataTable(Connection.DBKMConnectionString, Connection.Provider, DTab, Request, DLL.GlobalDec.EnumTran.Continue, null);
                return DTab;
            }
            catch (Exception ex)
            {
                //BLL.General.ShowErrors(ex);
                return DTab;
            }
        }
    }
}
