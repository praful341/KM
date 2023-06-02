using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using KM.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace KM.Controllers
{
    public class MasterController : Controller
    {
        BLL.FunctionClasses.Master.PartyMaster objParty = new BLL.FunctionClasses.Master.PartyMaster();
        BLL.FunctionClasses.Master.AssortMaster objAssort = new BLL.FunctionClasses.Master.AssortMaster();
        BLL.FunctionClasses.Master.SieveMaster objSieve = new BLL.FunctionClasses.Master.SieveMaster();
        BLL.FunctionClasses.Master.BrokerMaster objBroker = new BLL.FunctionClasses.Master.BrokerMaster();
        BLL.FunctionClasses.Master.SubSieveMaster objSubSieve = new BLL.FunctionClasses.Master.SubSieveMaster();
        BLL.FunctionClasses.Master.ColorMaster objRoughShade = new BLL.FunctionClasses.Master.ColorMaster();
        BLL.FunctionClasses.Master.ClarityMaster objPurity = new BLL.FunctionClasses.Master.ClarityMaster();

        // GET: Master
        public ActionResult Index()
        {
            return View();
        }

        #region PartyMaster
        public ActionResult PartyMaster()
        {
            Models.Employee_Master emp = new Models.Employee_Master();
            emp = SessionFacade.UserSession;
            if (emp == null)
            {
                return RedirectToAction("Login", "Home"); ;
            }
            else
            {
                DataTable m_dtbPartyType = new DataTable();
                m_dtbPartyType.Columns.Add("party_type");
                m_dtbPartyType.Rows.Add("OUTSIDE");
                m_dtbPartyType.Rows.Add("INHOUSE");
                List<Party_MasterProperty> PartyTypeList = new List<Party_MasterProperty>();
                PartyTypeList = (from DataRow dr in m_dtbPartyType.Rows
                                 select new Party_MasterProperty()
                                 {
                                     party_type = dr["party_type"].ToString()
                                 }).ToList();

                ViewBag.PartyTypeList = new MultiSelectList(PartyTypeList, "party_type", "party_type");

                return View();
            }
        }
        public JsonResult GetParty()
        {

            Models.Employee_Master emp = new Models.Employee_Master();
            emp = SessionFacade.UserSession;
            DataTable Party_Master = objParty.GetDataPartyMaster(1, emp.Company_Code, emp.Branch_Code, emp.Location_Code, emp.Department_Code);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Party_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Party_SaveForm(Party_MasterProperty Party_Property)
        {
            try
            {
                Models.Employee_Master emp = new Models.Employee_Master();
                emp = SessionFacade.UserSession;
                PartyMaster objParty = new PartyMaster();
                string msg = "";
                Party_Property.company_id = emp.Company_Code;
                Party_Property.branch_id = emp.Branch_Code;
                Party_Property.location_id = emp.Location_Code;
                Party_Property.department_id = emp.Department_Code;
                Party_Property.user_id = emp.ID;
                Party_Property.ip_address = SessionFacade.gStrComputerIP;
                objParty.Save(Party_Property);
                msg = "Party Saved successfully";

                return Json(new
                {
                    success = true,
                    message = msg
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "Party saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult Party_UpdateForm(Party_MasterProperty Party_Property)
        {
            try
            {
                Models.Employee_Master emp = new Models.Employee_Master();
                emp = SessionFacade.UserSession;
                PartyMaster objParty = new PartyMaster();
                string msg = "";
                Party_Property.company_id = emp.Company_Code;
                Party_Property.branch_id = emp.Branch_Code;
                Party_Property.location_id = emp.Location_Code;
                Party_Property.department_id = emp.Department_Code;
                Party_Property.user_id = emp.ID;
                Party_Property.ip_address = SessionFacade.gStrComputerIP;
                objParty.Save(Party_Property);
                msg = "Party Update successfully";

                return Json(new
                {
                    success = true,
                    message = msg
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "Party saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        #region BrokerMaster
        public ActionResult BrokerMaster()
        {
            Models.Employee_Master emp = new Models.Employee_Master();
            emp = SessionFacade.UserSession;
            if (emp == null)
            {
                return RedirectToAction("Login", "Home"); ;
            }
            else
            {
                DataTable m_dtbBrokerType = new DataTable();
                m_dtbBrokerType.Columns.Add("broker_type");
                m_dtbBrokerType.Rows.Add("OUTSIDE");
                m_dtbBrokerType.Rows.Add("INHOUSE");
                List<Broker_MasterProperty> BrokerTypeList = new List<Broker_MasterProperty>();
                BrokerTypeList = (from DataRow dr in m_dtbBrokerType.Rows
                                  select new Broker_MasterProperty()
                                  {
                                      broker_type = dr["broker_type"].ToString()
                                  }).ToList();

                ViewBag.BrokerTypeList = new MultiSelectList(BrokerTypeList, "broker_type", "broker_type");

                return View();
            }
        }
        public JsonResult GetBroker()
        {

            Models.Employee_Master emp = new Models.Employee_Master();
            emp = SessionFacade.UserSession;

            DataTable Broker_Master = objBroker.GetDataBrokerMaster(1, emp.Company_Code, emp.Branch_Code, emp.Location_Code, emp.Department_Code);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Broker_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Broker_SaveForm(Broker_MasterProperty Broker_Property)
        {
            try
            {
                Models.Employee_Master emp = new Models.Employee_Master();
                emp = SessionFacade.UserSession;
                BrokerMaster objBroker = new BrokerMaster();

                string msg = "";

                Broker_Property.company_id = emp.Company_Code;
                Broker_Property.branch_id = emp.Branch_Code;
                Broker_Property.location_id = emp.Location_Code;
                Broker_Property.department_id = emp.Department_Code;

                Broker_Property.user_id = emp.ID;
                Broker_Property.ip_address = SessionFacade.gStrComputerIP;
                objBroker.Save(Broker_Property);
                msg = "Broker Saved successfully";

                return Json(new
                {
                    success = true,
                    message = msg
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "Broker saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult Broker_UpdateForm(Broker_MasterProperty Broker_Property)
        {
            try
            {
                Models.Employee_Master emp = new Models.Employee_Master();
                emp = SessionFacade.UserSession;
                BrokerMaster objBroker = new BrokerMaster();

                string msg = "";

                Broker_Property.company_id = emp.Company_Code;
                Broker_Property.branch_id = emp.Branch_Code;
                Broker_Property.location_id = emp.Location_Code;
                Broker_Property.department_id = emp.Department_Code;

                Broker_Property.user_id = emp.ID;
                Broker_Property.ip_address = SessionFacade.gStrComputerIP;
                objBroker.Save(Broker_Property);
                msg = "Broker Update successfully";

                return Json(new
                {
                    success = true,
                    message = msg
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "Broker saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}