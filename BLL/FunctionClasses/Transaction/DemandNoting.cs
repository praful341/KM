using BLL.PropertyClasses.Transaction;
using DLL;
using System;
using System.Data;


namespace BLL.FunctionClasses.Transaction
{
    public class DemandNoting
    {
        InterfaceLayer Ope = new InterfaceLayer();
        //BLL.Validation Val = new BLL.Validation();

        public Demand_Property Save(Demand_Property pClsProperty)
        {
            try
            {
                Request Request = new Request();

                Request.AddParams("@demand_id", pClsProperty.demand_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@demand_master_id", pClsProperty.demand_master_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@demand_no", pClsProperty.demand_No, DbType.String, ParameterDirection.Input);
                Request.AddParams("@demand_srno", pClsProperty.demand_srno, DbType.String, ParameterDirection.Input);
                Request.AddParams("@demand_date", pClsProperty.demand_date, DbType.Date, ParameterDirection.Input);
                Request.AddParams("@from_rate", pClsProperty.from_rate, DbType.Decimal, ParameterDirection.Input);
                Request.AddParams("@to_rate", pClsProperty.to_rate, DbType.Decimal, ParameterDirection.Input);
                Request.AddParams("@rough_shade_id", pClsProperty.rough_shade_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@company_id", pClsProperty.company_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@branch_id", pClsProperty.branch_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@location_id", pClsProperty.location_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@department_id", pClsProperty.department_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@party_id", pClsProperty.Party_Id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@broker_id", pClsProperty.Broker_Id, DbType.Int32, ParameterDirection.Input);

                Request.AddParams("@assort_id", pClsProperty.assort_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@sieve_id", pClsProperty.sieve_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@status", pClsProperty.Status, DbType.String, ParameterDirection.Input);
                //Request.AddParams("@sub_sieve_id", pClsProperty.sub_sieve_id, DbType.Int32, ParameterDirection.Input);
                //Request.AddParams("@pcs", pClsProperty.pcs, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@carat", pClsProperty.carat, DbType.Decimal, ParameterDirection.Input);
                Request.AddParams("@rate", pClsProperty.rate, DbType.Decimal, ParameterDirection.Input);
                Request.AddParams("@amount", pClsProperty.amount, DbType.Decimal, ParameterDirection.Input);
                Request.AddParams("@current_rate", pClsProperty.current_rate, DbType.Decimal, ParameterDirection.Input);
                Request.AddParams("@current_amount", pClsProperty.current_amount, DbType.Decimal, ParameterDirection.Input);

                //Request.AddParams("@quality", pClsProperty.quality, DbType.Int32, ParameterDirection.Input);

                //Request.AddParams("@demand_rate", pClsProperty.demand_rate, DbType.Decimal, ParameterDirection.Input);
                //Request.AddParams("@demand_amount", pClsProperty.demand_amount, DbType.Decimal, ParameterDirection.Input);

                Request.AddParams("@remarks", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
                Request.AddParams("@special_remarks", pClsProperty.Special_Remark, DbType.String, ParameterDirection.Input);
                Request.AddParams("@client_remarks", pClsProperty.Client_Remark, DbType.String, ParameterDirection.Input);
                Request.AddParams("@payment_remarks", pClsProperty.Payment_Remark, DbType.String, ParameterDirection.Input);
                Request.AddParams("@demand_deal_final", pClsProperty.demand_deal_final, DbType.Boolean, ParameterDirection.Input);
                Request.AddParams("@purity_id", pClsProperty.purity_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@cutting", pClsProperty.cutting, DbType.String, ParameterDirection.Input);
                Request.AddParams("@term_days", pClsProperty.term_days, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@currency_id", pClsProperty.currency_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@rate_type_id", pClsProperty.rate_type_id, DbType.Int32, ParameterDirection.Input);
                //Request.AddParams("@form_id", pClsProperty.form_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@user_id", pClsProperty.user_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@ip_address", pClsProperty.ip_address, DbType.String, ParameterDirection.Input);
                Request.AddParams("@entry_date", DateTime.Today.ToString("MM-dd-yyyy"), DbType.Date, ParameterDirection.Input);
                Request.AddParams("@entry_time", DateTime.Now.ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input);

                Request.AddParams("@follow", pClsProperty.Follow, DbType.String, ParameterDirection.Input);
                Request.AddParams("@mobileno", pClsProperty.MobileNo, DbType.String, ParameterDirection.Input);

                Request.CommandText = "TRN_Demand_Master_Save";
                Request.CommandType = CommandType.StoredProcedure;

                DataTable p_dtbMasterId = new DataTable();

                Ope.GetDataTable(Connection.DBKMConnectionString, Connection.Provider, p_dtbMasterId, Request);

                if (p_dtbMasterId != null)
                {
                    if (p_dtbMasterId.Rows.Count > 0)
                    {
                        pClsProperty.demand_srno = Convert.ToInt32(p_dtbMasterId.Rows[0][0]);
                        pClsProperty.demand_No = Convert.ToString(p_dtbMasterId.Rows[0][1]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pClsProperty;
        }
        public int Update(Demand_Property pClsProperty)
        {
            try
            {
                Request Request = new Request();

                Request.AddParams("@demand_no", pClsProperty.demand_No, DbType.String, ParameterDirection.Input);
                Request.AddParams("@MobileNo", pClsProperty.MobileNo, DbType.String, ParameterDirection.Input);
                Request.AddParams("@Follow", pClsProperty.Follow, DbType.String, ParameterDirection.Input);
                Request.AddParams("@Remark", pClsProperty.Remark, DbType.String, ParameterDirection.Input);
                Request.AddParams("@Special_Remark", pClsProperty.Special_Remark, DbType.String, ParameterDirection.Input);
                Request.AddParams("@Client_Remark", pClsProperty.Client_Remark, DbType.String, ParameterDirection.Input);
                Request.AddParams("@Payment_Remark", pClsProperty.Payment_Remark, DbType.String, ParameterDirection.Input);
                Request.AddParams("@status", pClsProperty.Status, DbType.String, ParameterDirection.Input);
                Request.AddParams("@demand_deal_final", pClsProperty.demand_deal_final, DbType.Boolean, ParameterDirection.Input);
                Request.AddParams("@user_id", pClsProperty.user_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@ip_address", pClsProperty.ip_address, DbType.String, ParameterDirection.Input);
                Request.AddParams("@entry_date", DateTime.Today.ToString("MM-dd-yyyy"), DbType.Date, ParameterDirection.Input);
                Request.AddParams("@entry_time", DateTime.Now.ToString("HH:mm:ss"), DbType.String, ParameterDirection.Input);

                Request.CommandText = "WEB_TRN_Demand_Status_Update";
                Request.CommandType = CommandType.StoredProcedure;
                return Ope.ExecuteNonQuery(Connection.DBKMConnectionString, Connection.Provider, Request);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return pClsProperty;
        }
        public DataTable GetData(string p_dtpFromDate, string p_dtpToDate)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = "TRN_Demand_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@From_Date", p_dtpFromDate, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@To_Date", p_dtpToDate, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("@company_id", GlobalDec.gEmployeeProperty.company_id, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("@branch_id", GlobalDec.gEmployeeProperty.branch_id, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("@location_id", GlobalDec.gEmployeeProperty.location_id, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("@department_id", GlobalDec.gEmployeeProperty.department_id, DbType.Int32, ParameterDirection.Input);

            Ope.GetDataTable(Connection.DBKMConnectionString, Connection.Provider, DTab, Request);
            return DTab;
        }
        public DataTable GetDemandList(Demand_Property pClsProperty)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = "WEB_TRN_Demand_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            //Request.AddParams("@From_Date", p_dtpFromDate, DbType.Int32, ParameterDirection.Input);
            //Request.AddParams("@To_Date", p_dtpToDate, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@company_id", pClsProperty.company_id, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@branch_id", pClsProperty.branch_id, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@location_id", pClsProperty.location_id, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@department_id", pClsProperty.department_id, DbType.Int32, ParameterDirection.Input);
            Ope.GetDataTable(Connection.DBKMConnectionString, Connection.Provider, DTab, Request);
            return DTab;
        }
        public DataTable GetDataDetails(Int64 p_numID)
        {
            DataTable DTab = new DataTable();
            try
            {
                Request Request = new Request();
                Request.CommandText = "TRN_Demand_GetDetailsData";
                Request.CommandType = CommandType.StoredProcedure;
                Request.AddParams("@demand_srno", p_numID, DbType.Int64, ParameterDirection.Input);

                Ope.GetDataTable(Connection.DBKMConnectionString, Connection.Provider, DTab, Request);
                return DTab;
            }
            catch (Exception ex)
            {
                return DTab;
            }
        }
        public Int64 FindMaxMemoMasterID()
        {
            Int64 DemandMasterID = 0;
            DemandMasterID = Ope.FindNewIDInt64(Connection.DBKMConnectionString, Connection.Provider, "TRN_Demand_Noting", "MAX(demand_master_id)", "");

            return DemandMasterID;
        }
        public DataTable GetRateWiseAssort(Demand_Property pClsProperty)
        {
            DataTable DTab = new DataTable();
            try
            {
                Request Request = new Request();
                Request.CommandText = "TRN_RateWiseAssort_GetData";
                Request.CommandType = CommandType.StoredProcedure;
                Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@from_rate", pClsProperty.from_rate, DbType.Decimal, ParameterDirection.Input);
                Request.AddParams("@to_rate", pClsProperty.to_rate, DbType.Decimal, ParameterDirection.Input);
                Request.AddParams("@color_id", pClsProperty.rough_shade_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@company_id", pClsProperty.company_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@branch_id", pClsProperty.branch_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@location_id", pClsProperty.location_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@department_id", pClsProperty.department_id, DbType.Int32, ParameterDirection.Input);

                Request.AddParams("@ratetype_id", pClsProperty.rate_type_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@sieve_id", pClsProperty.sieve_id, DbType.Int32, ParameterDirection.Input);
                Request.AddParams("@currency_id", pClsProperty.currency_id, DbType.Int32, ParameterDirection.Input);

                Ope.GetDataTable(Connection.DBKMConnectionString, Connection.Provider, DTab, Request);
                return DTab;
            }
            catch (Exception ex)
            {
                //BLL.General.ShowErrors(ex);
                return DTab;
            }
        }
        public DataTable CurrencyType()
        {
            InterfaceLayer Ope = new InterfaceLayer();
            DataTable DTab = new DataTable();
            Request Request = new Request();
            Request.CommandText = "MST_Currency_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@active", 1, DbType.Int32, ParameterDirection.Input);
            Ope.GetDataTable(Connection.DBKMConnectionString, Connection.Provider, DTab, Request);
            return DTab;
        }
        public string GetLetestPrice(Demand_Property pClsProperty)
        {
            Request Request = new Request();
            DataTable DTable = new DataTable();
            string p_numLetest_Price = string.Empty;
            Request.AddParams("@numassort_id", pClsProperty.assort_id, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@numsieve_id", pClsProperty.sieve_id, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@rate_type_id", 1, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "MST_Get_LetestPrice";
            Request.CommandType = CommandType.StoredProcedure;

            p_numLetest_Price = Ope.ExecuteScalar(Connection.DBKMConnectionString, Connection.Provider, Request);
            return p_numLetest_Price;
        }
        public DataTable GetDemandData(int Company_Code, int Branch_Code, int Location_Code, int Department_Code, string p_dtpFromDate, string p_dtpToDate, decimal p_FromRate, decimal p_ToRate)
        {
            DataTable DTab = new DataTable();
            Request Request = new Request();
            
            Request.CommandText = "TRN_Demand_GetData_Web";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@From_Date", p_dtpFromDate, DbType.String, ParameterDirection.Input);
            Request.AddParams("@To_Date", p_dtpToDate, DbType.String, ParameterDirection.Input);
            Request.AddParams("@From_Rate", p_FromRate, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("@To_Rate", p_ToRate, DbType.Decimal, ParameterDirection.Input);
            Request.AddParams("@company_id", Company_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@branch_id", Branch_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@location_id", Location_Code, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@department_id", Department_Code, DbType.Int32, ParameterDirection.Input);

            Ope.GetDataTable(Connection.DBKMConnectionString, Connection.Provider, DTab, Request);
            return DTab;
        }
    }
}
