using DLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.FunctionClasses.Master
{
    public class EmployeeMaster
    {
        InterfaceLayer Ope = new InterfaceLayer();
        public DataSet CheckLogin(string UserName, string Password)
        {
            DataSet ds = new DataSet();
            Request Request = new Request();
            Request.AddParams("@UserName", UserName, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Password", Connection.Encrypt(Password, true), DbType.String, ParameterDirection.Input);

            Request.CommandText = "Check_Login_Web";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataSet(Connection.DBKMConnectionString, Connection.Provider, ds, "Login", Request);
            if (ds == null)
            {
                return new DataSet();
            }
            else
            {
                return ds;
            }
        }

        public DataTable GetData_Single_User_General_Preferences_Settings(int user_id)
        {
            DataTable DtPreView = new DataTable();
            Request Request = new Request();
            Request.CommandType = CommandType.StoredProcedure;
            Request.CommandText = "MST_User_Preference_GetData";
            Request.AddParams("@user_id", user_id, DbType.Int32);

            Ope.GetDataTable(Connection.DBKMConnectionString, Connection.Provider, DtPreView, Request);
            return DtPreView;
        }

        public void Insert_Login_History(Int64 UserId, string LoginIpAddress)
        {
            Request Request = new Request();
            Request.AddParams("@login_history_id", 0, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@history_type", "Web Login", DbType.String, ParameterDirection.Input);
            Request.AddParams("@login_date", DateTime.Now, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@login_time", DateTime.Now, DbType.Time, ParameterDirection.Input);
            Request.AddParams("@user_id", UserId, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ip_address", LoginIpAddress, DbType.String, ParameterDirection.Input);

            Request.CommandText = "MST_Config_Login_History_Save";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.ExecuteNonQuery(Connection.DBKMConnectionString, Connection.Provider, Request);
        }
    }
}
