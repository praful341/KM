using BLL.FunctionClasses.Transaction;
using BLL.PropertyClasses.Master;
using KM.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace KM.Controllers
{
    public class MemoController : Controller
    {
        // GET: Memo
        BLL.FunctionClasses.Master.FormMaster objForm = new BLL.FunctionClasses.Master.FormMaster();
        BLL.FunctionClasses.Master.AssortMaster objAssort = new BLL.FunctionClasses.Master.AssortMaster();
        BLL.FunctionClasses.Master.BrokerMaster objBroker = new BLL.FunctionClasses.Master.BrokerMaster();
        BLL.FunctionClasses.Master.PartyMaster objParty = new BLL.FunctionClasses.Master.PartyMaster();
        BLL.FunctionClasses.Master.SieveMaster objSieve = new BLL.FunctionClasses.Master.SieveMaster();
        BLL.FunctionClasses.Master.SubSieveMaster objSubSieve = new BLL.FunctionClasses.Master.SubSieveMaster();
        BLL.FunctionClasses.Master.DeliveryTypeMaster objDelivery = new BLL.FunctionClasses.Master.DeliveryTypeMaster();
        MemoInvoice objMemo = new MemoInvoice();
        public ActionResult MemoIssue()
        {
            List<Form_MasterProperty> FormDisplayNameList = new List<Form_MasterProperty>();
            FormDisplayNameList = (from DataRow dr in objForm.GetDataFormMaster().Rows
                                   select new Form_MasterProperty()
                                   {
                                       web_form_id = Convert.ToInt16(dr["web_form_id"]),
                                       display_name = dr["display_name"].ToString()
                                   }).ToList();

            ViewBag.FormDisplayNameList = new MultiSelectList(FormDisplayNameList, "web_form_id", "display_name");

            List<Assort_MasterProperty> AssortList = new List<Assort_MasterProperty>();
            AssortList = (from DataRow dr in objAssort.GetDataAssortMaster(1).Rows
                          select new Assort_MasterProperty()
                          {
                              assort_id = Convert.ToInt16(dr["assort_id"]),
                              assortname = dr["assort_name"].ToString()
                          }).ToList();

            ViewBag.AssortList = new MultiSelectList(AssortList, "assort_id", "assortname");

            List<Broker_MasterProperty> BrokerList = new List<Broker_MasterProperty>();
            BrokerList = (from DataRow dr in objBroker.GetDataBrokerMaster(1).Rows
                          select new Broker_MasterProperty()
                          {
                              broker_id = Convert.ToInt16(dr["broker_id"]),
                              broker_name = dr["broker_name"].ToString()
                          }).ToList();

            ViewBag.BrokerList = new MultiSelectList(BrokerList, "broker_id", "broker_name");

            List<Party_MasterProperty> PartyList = new List<Party_MasterProperty>();
            PartyList = (from DataRow dr in objParty.GetDataPartyMaster(1).Rows
                         select new Party_MasterProperty()
                         {
                             party_id = Convert.ToInt16(dr["party_id"]),
                             party_name = dr["party_name"].ToString()
                         }).ToList();

            ViewBag.PartyList = new MultiSelectList(PartyList, "party_id", "party_name");

            List<Sieve_MasterProperty> SieveList = new List<Sieve_MasterProperty>();
            SieveList = (from DataRow dr in objSieve.GetDataSieveMaster(1).Rows
                         select new Sieve_MasterProperty()
                         {
                             Sieve_Id = Convert.ToInt16(dr["sieve_id"]),
                             Sieve_Name = dr["Sieve_name"].ToString()
                         }).ToList();

            ViewBag.SieveList = new MultiSelectList(SieveList, "sieve_id", "sieve_name");

            List<SubSieve_MasterProperty> SubSieveList = new List<SubSieve_MasterProperty>();
            SubSieveList = (from DataRow dr in objSubSieve.GetDataSubSieveMaster(1).Rows
                            select new SubSieve_MasterProperty()
                            {
                                sub_sieve_id = Convert.ToInt16(dr["sub_sieve_id"]),
                                sub_sieve_name = dr["sub_sieve_name"].ToString()
                            }).ToList();

            ViewBag.SubSieveList = new MultiSelectList(SubSieveList, "sub_sieve_id", "sub_sieve_name");

            List<DeliveryTypeMasterProperty> DeliveryList = new List<DeliveryTypeMasterProperty>();
            DeliveryList = (from DataRow dr in objDelivery.GetData(1).Rows
                            select new DeliveryTypeMasterProperty()
                            {
                                delivery_type_id = Convert.ToInt16(dr["delivery_type_id"]),
                                delivery_type = dr["delivery_type"].ToString()
                            }).ToList();

            ViewBag.DeliveryList = new MultiSelectList(DeliveryList, "delivery_type_id", "delivery_type");

            return View();
        }

        public JsonResult GetOutstandingCarats()
        {
            Models.Employee_Master emp = new Models.Employee_Master();
            emp = SessionFacade.UserSession;
            DataTable dtOutstanding = objMemo.GetMemoData(emp.Company_Code, emp.Branch_Code, emp.Location_Code, emp.Department_Code, "0");
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(dtOutstanding);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult GetSubSieve(string Sieve_Id)
        {
            //DataTable dt = objSubSieve.SubSieve_GetData(1, Convert.ToInt32(Sieve_Id));
            DataTable dt = objSubSieve.GetDataSubSieveMaster();
            IEnumerable<SelectListItem> SubSieveList = (from DataRow dr in dt.Rows select new SelectListItem() { Value = dr["sub_sieve_id"].ToString(), Text = Convert.ToString(dr["sub_sieve_name"]) });
            var result = new SelectList(SubSieveList, "Value", "Text");
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetLatestPrice(string assort_id, string sieve_id)
        {
            string Rate = "0";
            Models.Employee_Master emp = new Models.Employee_Master();
            emp = SessionFacade.UserSession;
            Rate = objAssort.GetLatestPrice(Convert.ToInt32(assort_id == "" ? "0" : assort_id), Convert.ToInt32(sieve_id == "" ? "0" : sieve_id), emp.rate_type_id);
            return Json(new
            {
                success = true,
                rate = Rate
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GetOutstandingBalance(string party_id, string broker_id)
        {
            string Carats = "0";
            string Value = "0";
            Models.Employee_Master emp = new Models.Employee_Master();
            emp = SessionFacade.UserSession;
            //DataTable dtOutstanding = objMemo.GetMemoData(emp.Company_Code, emp.Branch_Code, emp.Location_Code, emp.Department_Code, "0", Convert.ToInt32(party_id == "" ? "0" : party_id), Convert.ToInt32(broker_id == "" ? "0" : broker_id));
            DataTable dtOutstanding = objMemo.GetMemoData(emp.Company_Code, emp.Branch_Code, emp.Location_Code, emp.Department_Code, "0");
            if (dtOutstanding.Rows.Count > 0)
            {
                Carats = dtOutstanding.Rows[0]["outstanding_carat"].ToString();
                Value = dtOutstanding.Rows[0]["outstanding_amount"].ToString();
            }
            if (Carats.Length == 0)
            {
                Carats = "0";
            }
            if (Value.Length == 0)
            {
                Value = "0";
            }
            return Json(new
            {
                success = true,
                carats = Carats,
                value = Value,
            }, JsonRequestBehavior.AllowGet);
        }
    }
}