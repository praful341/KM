using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KM.Utility;

namespace KM.Controllers
{
    public class FormController : Controller
    {
        BLL.FunctionClasses.Master.FormMaster objForm = new BLL.FunctionClasses.Master.FormMaster();
        //GetDataFormMaster
        // GET: Form
        public ActionResult FormMaster()
        {
            //List<Form_Group_Master> FormGroupList = new List<Form_Group_Master>();
            //FormGroupList = (from DataRow dr in Master.GetFormGroup().Rows
            //                 select new Form_Group_Master()
            //                 {
            //                     ID = Convert.ToInt16(dr["ID"]),
            //                     TITLE = dr["TITLE"].ToString()
            //                 }).ToList();

            //ViewBag.GroupMasterList = new MultiSelectList(FormGroupList, "ID", "TITLE");

            List<Form_MasterProperty> FormDisplayNameList = new List<Form_MasterProperty>();
            FormDisplayNameList = (from DataRow dr in objForm.GetDataFormMaster().Rows
                                   select new Form_MasterProperty()
                                   {
                                       web_form_id = Convert.ToInt16(dr["web_form_id"]),
                                       display_name = dr["display_name"].ToString()
                                   }).ToList();

            ViewBag.FormDisplayNameList = new MultiSelectList(FormDisplayNameList, "web_form_id", "display_name");

            return View();
        }

        public JsonResult GetAllForm()
        {
            DataTable FormMaster = objForm.GetDataFormMaster();
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(FormMaster);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }
    }
}