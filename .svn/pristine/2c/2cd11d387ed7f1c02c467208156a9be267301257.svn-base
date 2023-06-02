using BLL.FunctionClasses.Transaction;
using BLL.PropertyClasses.Master;
using BLL.PropertyClasses.Transaction;
using KM.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace KM.Controllers
{
    public class DemandController : Controller
    {
        // GET: Demand
        BLL.FunctionClasses.Master.AssortMaster objAssort = new BLL.FunctionClasses.Master.AssortMaster();
        BLL.FunctionClasses.Master.SieveMaster objSieve = new BLL.FunctionClasses.Master.SieveMaster();
        BLL.FunctionClasses.Master.BrokerMaster objBroker = new BLL.FunctionClasses.Master.BrokerMaster();
        BLL.FunctionClasses.Master.SubSieveMaster objSubSieve = new BLL.FunctionClasses.Master.SubSieveMaster();
        BLL.FunctionClasses.Master.PartyMaster objParty = new BLL.FunctionClasses.Master.PartyMaster();
        BLL.FunctionClasses.Master.ColorMaster objRoughShade = new BLL.FunctionClasses.Master.ColorMaster();
        BLL.FunctionClasses.Master.ClarityMaster objPurity = new BLL.FunctionClasses.Master.ClarityMaster();
        DemandNoting objDemandNoting = new DemandNoting();
        Models.Employee_Master emp = new Models.Employee_Master();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Demand()
        {
            Models.Employee_Master emp = new Models.Employee_Master();
            emp = SessionFacade.UserSession;

            if (emp == null)
            {
                return RedirectToAction("Login", "Home"); ;
            }
            else
            {
                List<Assort_MasterProperty> AssortDisplayNameList = new List<Assort_MasterProperty>();
                AssortDisplayNameList = (from DataRow dr in objAssort.GetDataAssortMaster().Rows
                                         select new Assort_MasterProperty()
                                         {
                                             assort_id = Convert.ToInt16(dr["assort_id"]),
                                             assortname = dr["assort_name"].ToString()
                                         }).ToList();

                ViewBag.AssortDisplayNameList = new MultiSelectList(AssortDisplayNameList, "assort_id", "assortname");

                List<Sieve_MasterProperty> SieveDisplayNameList = new List<Sieve_MasterProperty>();
                SieveDisplayNameList = (from DataRow dr in objSieve.GetDataSieveMaster().Rows
                                        select new Sieve_MasterProperty()
                                        {
                                            Sieve_Id = Convert.ToInt16(dr["sieve_id"]),
                                            Sieve_Name = dr["sieve_name"].ToString()
                                        }).ToList();

                ViewBag.SieveDisplayNameList = new MultiSelectList(SieveDisplayNameList, "Sieve_Id", "Sieve_Name");

                List<SubSieve_MasterProperty> SubSieveDisplayNameList = new List<SubSieve_MasterProperty>();
                SubSieveDisplayNameList = (from DataRow dr in objSubSieve.GetDataSubSieveMaster().Rows
                                           select new SubSieve_MasterProperty()
                                           {
                                               sub_sieve_id = Convert.ToInt16(dr["sub_sieve_id"]),
                                               sub_sieve_name = dr["sub_sieve_name"].ToString()
                                           }).ToList();

                ViewBag.SubSieveDisplayNameList = new MultiSelectList(SubSieveDisplayNameList, "sub_sieve_id", "sub_sieve_name");

                List<Party_MasterProperty> PartyDisplayNameList = new List<Party_MasterProperty>();
                PartyDisplayNameList = (from DataRow dr in objParty.GetDataPartyMaster(1, emp.Company_Code, emp.Branch_Code, emp.Location_Code, emp.Department_Code).Rows
                                        select new Party_MasterProperty()
                                        {
                                            party_id = Convert.ToInt16(dr["party_id"]),
                                            party_name = dr["party_name"].ToString()
                                        }).ToList();

                ViewBag.PartyDisplayNameList = new MultiSelectList(PartyDisplayNameList, "party_id", "party_name");

                List<Broker_MasterProperty> BrokerDisplayNameList = new List<Broker_MasterProperty>();
                BrokerDisplayNameList = (from DataRow dr in objBroker.GetDataBrokerMaster(1, emp.Company_Code, emp.Branch_Code, emp.Location_Code, emp.Department_Code).Rows
                                         select new Broker_MasterProperty()
                                         {
                                             broker_id = Convert.ToInt16(dr["broker_id"]),
                                             broker_name = dr["broker_name"].ToString()
                                         }).ToList();

                ViewBag.BrokerDisplayNameList = new MultiSelectList(BrokerDisplayNameList, "broker_id", "broker_name");

                List<Color_MasterProperty> RoughShadeDisplayNameList = new List<Color_MasterProperty>();
                RoughShadeDisplayNameList = (from DataRow dr in objRoughShade.GetColorData().Rows
                                             select new Color_MasterProperty()
                                             {
                                                 color_id = Convert.ToInt16(dr["color_id"]),
                                                 color_name = dr["color_name"].ToString()
                                             }).ToList();

                ViewBag.RoughShadeDisplayNameList = new MultiSelectList(RoughShadeDisplayNameList, "color_id", "color_name");


                DataTable m_dtbStatus = new DataTable();
                m_dtbStatus.Columns.Add("Status");
                m_dtbStatus.Rows.Add("Ok");
                m_dtbStatus.Rows.Add("Baki");
                List<Demand_Property> StatusNameList = new List<Demand_Property>();
                StatusNameList = (from DataRow dr in m_dtbStatus.Rows
                                  select new Demand_Property()
                                  {
                                      Status = dr["Status"].ToString()
                                  }).ToList();

                ViewBag.StatusNameList = new MultiSelectList(StatusNameList, "Status", "Status", new[] { "Pending" });

                DataTable m_dtbCutting = new DataTable();
                m_dtbCutting.Columns.Add("Cutting");
                m_dtbCutting.Rows.Add("EX");
                m_dtbCutting.Rows.Add("VG");
                m_dtbCutting.Rows.Add("Good");
                m_dtbCutting.Rows.Add("Single");
                List<Demand_Property> CuttingList = new List<Demand_Property>();
                CuttingList = (from DataRow dr in m_dtbCutting.Rows
                               select new Demand_Property()
                               {
                                   cutting = dr["Cutting"].ToString()
                               }).ToList();

                ViewBag.CuttingList = new MultiSelectList(CuttingList, "Cutting", "Cutting");

                List<Demand_Property> CurrencyTypeList = new List<Demand_Property>();
                Demand_Property objDemandProperty = new Demand_Property();
                CurrencyTypeList = (from DataRow dr in objDemandNoting.CurrencyType().Rows
                                        //CurrencyTypeList = (from DataRow dr in m_dtbCurrType.Rows
                                    select new Demand_Property()
                                    {
                                        currency_id = Convert.ToInt32(dr["currency_id"]),
                                        currency = dr["currency"].ToString()
                                    }).ToList();

                ViewBag.CurrencyTypeList = new MultiSelectList(CurrencyTypeList, "currency_id", "currency", new[] { emp.currency_id });

                DataTable m_dtbPurity = objPurity.GetData();
                m_dtbPurity.DefaultView.RowFilter = "purity_group = 'SALES' ";
                DataTable dtbdetail = m_dtbPurity.DefaultView.ToTable();
                List<Clarity_MasterProperty> PurityList = new List<Clarity_MasterProperty>();
                PurityList = (from DataRow dr in dtbdetail.Rows
                              select new Clarity_MasterProperty()
                              {
                                  purity_id = Convert.ToInt32(dr["purity_id"]),
                                  purity_name = dr["purity_name"].ToString()
                              }).ToList();

                ViewBag.PurityList = new MultiSelectList(PurityList, "purity_id", "purity_name");
                return View();
            }
        }

        [HttpPost]
        public JsonResult Demand_SaveForm(Demand_Property Demand_Property)
        {
            try
            {
                Models.Employee_Master emp = new Models.Employee_Master();
                emp = SessionFacade.UserSession;
                DemandNoting demandNoting = new DemandNoting();
                string msg = "";
                Int64 DmasterId = demandNoting.FindMaxMemoMasterID();
                Demand_Property.demand_master_id = Convert.ToInt16(DmasterId);
                Demand_Property.company_id = emp.Company_Code;
                Demand_Property.branch_id = emp.Branch_Code;
                Demand_Property.location_id = emp.Location_Code;
                Demand_Property.department_id = emp.Department_Code;
                Demand_Property.rate_type_id = emp.rate_type_id;
                Demand_Property.user_id = emp.ID;
                Demand_Property.ip_address = SessionFacade.gStrComputerIP;
                demandNoting.Save(Demand_Property);
                msg = "Sales Saved successfully";

                return Json(new
                {
                    success = true,
                    message = msg,
                    demand_no = Demand_Property.demand_No,
                    demand_srno = Demand_Property.demand_srno
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "Sales saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult RateWise_Assort(Demand_Property Demand_Property)
        {
            DataTable dtRateWiseAssort = new DataTable();
            DemandNoting demandNoting = new DemandNoting();

            Models.Employee_Master emp = new Models.Employee_Master();
            emp = SessionFacade.UserSession;

            Demand_Property.rate_type_id = emp.rate_type_id;

            dtRateWiseAssort = demandNoting.GetRateWiseAssort(Demand_Property);
            IEnumerable<SelectListItem> AssortList = (from DataRow dr in dtRateWiseAssort.Rows select new SelectListItem() { Value = dr["assort_id"].ToString(), Text = Convert.ToString(dr["assort_name"]) });
            var result = new SelectList(AssortList, "Value", "Text");
            //var result = new SelectList(clientlist, "Value", "Text");
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetLatestPrice(Demand_Property Demand_Property)
        {
            //DataTable dtRateWiseAssort = new DataTable();
            DemandNoting demandNoting = new DemandNoting();
            string rate = "0";
            rate = demandNoting.GetLetestPrice(Demand_Property);
            //IEnumerable<SelectListItem> AssortList = (from DataRow dr in dtRateWiseAssort.Rows select new SelectListItem() { Value = dr["assort_id"].ToString(), Text = Convert.ToString(dr["assort_name"]) });
            var result = rate;
            //var result = new SelectList(clientlist, "Value", "Text");
            return Json(new
            {
                success = true,
                result//message = msg
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DemandReport()
        {
            Models.Employee_Master emp = new Models.Employee_Master();
            emp = SessionFacade.UserSession;
            if (emp == null)
            {
                return RedirectToAction("Login", "Home"); ;
            }
            else
            {
                DataTable m_dtbStatus = new DataTable();
                m_dtbStatus.Columns.Add("Status");
                m_dtbStatus.Rows.Add("Ok");
                m_dtbStatus.Rows.Add("Baki");
                List<Demand_Property> StatusNameList = new List<Demand_Property>();
                StatusNameList = (from DataRow dr in m_dtbStatus.Rows
                                  select new Demand_Property()
                                  {
                                      Status = dr["Status"].ToString()
                                  }).ToList();
                ViewBag.StatusNameList = new MultiSelectList(StatusNameList, "Status", "Status");
                return View();
            }

        }
        [HttpPost]
        public JsonResult GetDemandReport(string fromDate, string toDate, string fromRate, string toRate)
        {
            decimal fRate = 0;
            decimal tRate = 0;
            if(fromRate == "" && toRate == "")
            {
                fRate = 0;
                tRate = 0;
            }
            else
            {
                fRate = Convert.ToDecimal(fromRate);
                tRate = Convert.ToDecimal(toRate);
            }
            Models.Employee_Master emp = new Models.Employee_Master();
            emp = SessionFacade.UserSession;
            DataTable Company_Master = objDemandNoting.GetDemandData(emp.Company_Code, emp.Branch_Code, emp.Location_Code, emp.Department_Code, fromDate, toDate, fRate, tRate);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Company_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult RateWise_Assort(Demand_Property Demand_Property)
        //{
        //    try
        //    {
        //        DataTable Dtab = new DataTable();
        //        DemandNoting demandNoting = new DemandNoting();

        //        //Dtab = demandNoting.GetRateWiseAssort(Demand_Property);
        //        List<Assort_MasterProperty> AssortDisplayNameList = new List<Assort_MasterProperty>();
        //        AssortDisplayNameList = (from DataRow dr in demandNoting.GetRateWiseAssort(Demand_Property).Rows
        //                                 select new Assort_MasterProperty()
        //                                 {
        //                                     assort_id = Convert.ToInt16(dr["assort_id"]),
        //                                     assortname = dr["assort_name"].ToString()
        //                                 }).ToList();
        //        ViewBag.AssortDisplayNameList = new MultiSelectList(AssortDisplayNameList, "assort_id", "assortname");

        //        if (AssortDisplayNameList != null)
        //        {
        //            return Json(new
        //            {
        //                success = true,
        //                message = msg,
        //                ViewBag.AssortDisplayNameList
        //            }, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json(new
        //            {
        //                success = false
        //            }, JsonRequestBehavior.AllowGet);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
        //        return Json(new
        //        {
        //            success = false,
        //            message = "Sales saved failed"
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        [HttpPost]
        public JsonResult PrintReport(string fromDate, string toDate)
        {
            string msg = "";
            decimal fromRate = 0;
            decimal toRate = 0;
            Models.Employee_Master emp = new Models.Employee_Master();
            emp = SessionFacade.UserSession;
            DataTable dtbReport = objDemandNoting.GetDemandData(emp.Company_Code, emp.Branch_Code, emp.Location_Code, emp.Department_Code, fromDate, toDate, fromRate, toRate);

            if (dtbReport.Rows.Count > 0)
            {
                System.Web.HttpContext.Current.Session["rptSource"] = dtbReport;
                System.Web.HttpContext.Current.Session["ReportName"] = "Report\\Shyam_Sales.rpt";
                return Json(new
                {
                    success = true,
                    //   message = msg
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    success = false,
                    message = "No Data Found!!!"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        #region DemandStatus
        public ActionResult DemandStatus()
        {
            Models.Employee_Master emp = new Models.Employee_Master();
            emp = SessionFacade.UserSession;
            if (emp == null)
            {
                return RedirectToAction("Login", "Home"); ;
            }
            else
            {
                DataTable m_dtbStatus = new DataTable();
                m_dtbStatus.Columns.Add("Status");
                m_dtbStatus.Rows.Add("Ok");
                m_dtbStatus.Rows.Add("Baki");
                List<Demand_Property> StatusNameList = new List<Demand_Property>();
                StatusNameList = (from DataRow dr in m_dtbStatus.Rows
                                  select new Demand_Property()
                                  {
                                      Status = dr["Status"].ToString()
                                  }).ToList();

                ViewBag.StatusNameList = new MultiSelectList(StatusNameList, "Status", "Status", new[] { "Pending" });

                return View();
            }
        }
        public JsonResult GetDemandList()
        {
            Demand_Property Demand_Property = new Demand_Property();
            Models.Employee_Master emp = new Models.Employee_Master();
            emp = SessionFacade.UserSession;
            Demand_Property.company_id = emp.Company_Code;
            Demand_Property.branch_id = emp.Branch_Code;
            Demand_Property.location_id = emp.Location_Code;
            Demand_Property.department_id = emp.Department_Code;
            DataTable DemandList = objDemandNoting.GetDemandList(Demand_Property);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(DemandList);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DemandStatusUpdate(Demand_Property Demand_Property)
        {
            try
            {
                Models.Employee_Master emp = new Models.Employee_Master();
                emp = SessionFacade.UserSession;
                Demand_Property objBroker = new Demand_Property();
                string msg = "";
                Demand_Property.user_id = emp.ID;
                Demand_Property.ip_address = SessionFacade.gStrComputerIP;
                objDemandNoting.Update(Demand_Property);
                msg = "Demand Status Update successfully";

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
                    message = "Demand Status saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}