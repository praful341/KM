using DLL;
using DLL.FunctionClasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace UPKeep_WebService
{
    /// <summary>
    /// Summary description for Client_Service
    /// </summary>
    [WebService(Namespace = "http://useupkeep.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Client_Service : System.Web.Services.WebService
    {
        SProc objSproc = new SProc();
        InterfaceLayer Ope = new InterfaceLayer();
        string ConnectionString_Global = ConfigurationManager.ConnectionStrings["KM_ConnectionString"].ConnectionString;
       
        [WebMethod]
        public DataTable Assessment_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Assessment Master");
            Request.CommandText = "Assessment_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable User_Right_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("User Rights Master");
            Request.CommandText = "User_Rights_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Sub_Assessment_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Sub Assessment Master");
            Request.CommandText = "Sub_Assessment_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        #region "Assesment Master"

        [WebMethod]
        public DataTable Assesment_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Assesment_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Assesment_Search_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = objSproc.Assessment_Master_Search_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public int Assesment_Master_Save(Assessment_Master_Property pclsProperty, string ConnectionString)
        {
            Request Request = new Request();
            DataTable dt = new DataTable();
            Request.AddParams("@Assessment_ID", pclsProperty.Assessment_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Module_ID", pclsProperty.Module_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Assessment_Name", pclsProperty.Assessment_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", pclsProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Remark", pclsProperty.Remarks, DbType.String, ParameterDirection.Input);
            Request.CommandText = objSproc.Assesment_Master_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        #endregion

      
    }
}
