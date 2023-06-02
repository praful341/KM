using BLL.PropertyClasses.Master;
using DLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.FunctionClasses.Master
{
    public class FormPermission
    {
        InterfaceLayer Ope = new InterfaceLayer();
        Request Request = new Request();
        public int InsertPermissionMaster(FormPermissionMasterModel FormPermissionMasterModel)
        {
            Request.AddParams("@web_form_id", FormPermissionMasterModel.web_form_id, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@role_id", FormPermissionMasterModel.role_id, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@is_view", FormPermissionMasterModel.is_view, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@is_insert", FormPermissionMasterModel.is_insert, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@is_update", FormPermissionMasterModel.is_update, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@is_delete", FormPermissionMasterModel.is_delete, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@is_print", FormPermissionMasterModel.is_print, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@is_email", FormPermissionMasterModel.is_email, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@active", FormPermissionMasterModel.active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@user_id", FormPermissionMasterModel.user_id, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@entry_date", FormPermissionMasterModel.entry_date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@entry_time", FormPermissionMasterModel.entry_time, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ip_address", FormPermissionMasterModel.ip_address, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@remarks", FormPermissionMasterModel.remarks, DbType.Date, ParameterDirection.Input);
            Request.CommandText = "WEB_MST_Form_Permission_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(Connection.DBKMConnectionString, Connection.Provider, Request);
        }

        public DataTable GetMenuWithRights(int RoleID)
        {
            DataTable dt = new DataTable();
            Request Request = new Request();
            Request.AddParams("role_id", RoleID, DbType.String, ParameterDirection.Input);

            Request.CommandText = "WEB_MST_Form_Permission_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(Connection.DBKMConnectionString, Connection.Provider, dt, Request);
            return dt;
        }

        public DataTable GetAllRoleMasterData(int IntID)
        {
            DataTable DT = new DataTable("Table");
            Request.AddParams("@role_id", IntID, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = "WEB_MST_Form_Role_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(Connection.DBKMConnectionString, Connection.Provider, DT, Request);
            return DT;
        }

        public DataTable GetAllRole(int ID)
        {
            DataTable DT = new DataTable("Table");
            Request.AddParams("ID_", ID, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = "WEB_MST_Form_Role_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(Connection.DBKMConnectionString, Connection.Provider, DT, Request);
            return DT;
        }

        //public ConfigRole_MasterProperty InsertRoleMaster(ref ConfigRole_MasterProperty RoleMasterModel)
        //{
        //    Request.AddParams("ROLE_NAME_", RoleMasterModel.role_name, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ACTIVE_", RoleMasterModel.active, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ENTRYBY_", RoleMasterModel.enteredby, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ENTRYDATE_", RoleMasterModel.entereddate, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("ENTRYTIME_", RoleMasterModel.enteredtime, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("OUT_ID_", RoleMasterModel.role_id, DbType.Int32, ParameterDirection.Output);
        //    Request.CommandText = "MST_Config_Role_Save";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    ArrayList AL = new ArrayList();
        //    AL = Ope.ExecuteNonQuery(Connection.DBKMConnectionString, Connection.Provider, Request);
        //    RoleMasterModel.role_id = Convert.ToInt32(AL[0]);
        //    return RoleMasterModel;
        //}

        //public int UpdateRoleMaster(RoleMasterModel RoleMasterModel)
        //{
        //    Request.AddParams("ID_", RoleMasterModel.ID, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ROLE_NAME_", RoleMasterModel.ROLE_NAME, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("ACTIVE_", RoleMasterModel.ACTIVE, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("UPDATEBY_", RoleMasterModel.UPDATE_BY, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("UPDATEDATE_", RoleMasterModel.UPDATE_DATE, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("UPDATETIME_", RoleMasterModel.UPDATE_TIME, DbType.String, ParameterDirection.Input);
        //    Request.CommandText = "WEB_FORM_ROLE_UPDATE";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(BLLFunctions.Decrypt(ConfigurationManager.ConnectionStrings["DBNivid"].ConnectionString, true), BLLFunctions.Decrypt(ConfigurationManager.ConnectionStrings["DBNivid"].ProviderName, true), Request);
        //}

        //public int DeleteRoleMaster(RoleMasterModel RoleMasterModel)
        //{
        //    Request.AddParams("ID_", RoleMasterModel.ID, DbType.Int32, ParameterDirection.Input);
        //    Request.CommandText = "WEB_FORM_ROLE_DELETE";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(BLLFunctions.Decrypt(ConfigurationManager.ConnectionStrings["DBNivid"].ConnectionString, true), BLLFunctions.Decrypt(ConfigurationManager.ConnectionStrings["DBNivid"].ProviderName, true), Request);
        //}
        //MST_Config_Role_Save
    }
}
