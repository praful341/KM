using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using KM.Models;
using KM.Utility;
using System;
using System.Data;
using System.Web.Mvc;

namespace KM.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        FormPermission objFormPermission = new FormPermission();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SavePermissionDetail(FormPermissionMasterModel FormPermissionMasterModel)
        {
            try
            {
                //string msg = "";
                Models.Employee_Master emp = new Models.Employee_Master();
                emp = SessionFacade.UserSession;
                FormPermissionMasterModel.user_id = emp.ID;
                FormPermissionMasterModel.entry_date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                FormPermissionMasterModel.entry_time = Convert.ToString(DateTime.Now.ToString("hh:mm:ss:fff tt"));
                objFormPermission.InsertPermissionMaster(FormPermissionMasterModel);
                //msg = "Form inserted successfully";
                return Json(new
                {
                    success = true,
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = true,
                    message = "Form saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetRoleData(int Id)
        {
            DataTable Dt = objFormPermission.GetAllRoleMasterData(Id);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Dt);
            int totalRecords = List.Count;
            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllRole(int Id = 0)
        {
            DataTable Dt = objFormPermission.GetAllRole(Id);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Dt);
            int totalRecords = List.Count;

            return Json(new
            {
                success = true,
                List
            }, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public JsonResult SaveRoleMaster(ConfigRole_MasterProperty ConfigRole_MasterProperty)
        //{
        //    try
        //    {
        //        string msg = "";
        //        int ROLEID = 0;
        //        Employee_Master emp = new Employee_Master();
        //        emp = SessionFacade.UserSession;
        //        if (ConfigRole_MasterProperty.role_id > 0)
        //        {
        //            ConfigRole_MasterProperty.enteredby = emp.ID;
        //            ConfigRole_MasterProperty.entereddate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        //            ConfigRole_MasterProperty.enteredtime = Convert.ToString(DateTime.Now.ToString("hh:mm:ss:fff tt"));
        //            objFormPermission.UpdateRoleMaster(ConfigRole_MasterProperty);
        //            msg = "Form updated successfully";
        //        }
        //        else
        //        {
        //            ConfigRole_MasterProperty.enteredby = emp.ID;
        //            ConfigRole_MasterProperty.entereddate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        //            ConfigRole_MasterProperty.enteredtime = Convert.ToString(DateTime.Now.ToString("hh:mm:ss:fff tt"));
        //            objFormPermission.InsertRoleMaster(ref ConfigRole_MasterProperty);
        //            ROLEID = ConfigRole_MasterProperty.role_id;
        //            msg = "Form inserted successfully";
        //        }
        //        return Json(new
        //        {
        //            success = true,
        //            message = msg,
        //            ROLEID = ROLEID,
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
        //        return Json(new
        //        {
        //            success = true,
        //            message = "Form saved failed"
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //[HttpPost]
        //public JsonResult DeleteRole(MasterReference.RoleMasterModel RoleMasterModel)
        //{
        //    try
        //    {
        //        string msg = "";
        //        Master.DeleteRoleMaster(RoleMasterModel);
        //        msg = "Data Delete Successfully";
        //        return Json(new
        //        {
        //            success = true,
        //            message = msg
        //        }, JsonRequestBehavior.AllowGet);

        //    }
        //    catch (Exception ex)
        //    {
        //        //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
        //        return Json(new
        //        {
        //            success = false
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}