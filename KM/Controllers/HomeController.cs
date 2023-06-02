using BLL;
using KM.Models;
using KM.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace KM.Controllers
{
    public class HomeController : Controller
    {
        BLL.FunctionClasses.Master.EmployeeMaster objEmployee = new BLL.FunctionClasses.Master.EmployeeMaster();
        public ActionResult DashBoard()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CheckLogin(string UserName, string Password, bool IsRemind)
        {
            try
            {
                DataSet ds_Result = objEmployee.CheckLogin(UserName, Password);
                if (ds_Result.Tables.Count > 0)
                {
                    //if (ds_Result.Rows.Count > 0)
                    //{
                    //    User_Login_Master_Property objUserLogin = new User_Login_Master_Property();
                    //    objUserLogin.Login_ID = Convert.ToInt64(ds_Result.Rows[0]["Login_ID"].ToString());
                    //    objUserLogin.Client_ID = Convert.ToInt64(ds_Result.Rows[0]["Client_ID"].ToString());
                    //    objUserLogin.UserName = ds_Result.Rows[0]["UserName"].ToString();
                    //    objUserLogin.EmailID = ds_Result.Rows[0]["EmailID"].ToString();
                    //    objUserLogin.Mobile = Convert.ToInt64(ds_Result.Rows[0]["Mobile"].ToString());
                    //    //objUserLogin.Category_ID = Convert.ToInt64(ds_Result.Rows[0]["Category_ID"].ToString());
                    //    objUserLogin.User_Image = ds_Result.Rows[0]["User_Image"].ToString();
                    //    SessionDetails.UserSession = objUserLogin;
                    //    if (ds_Result.Rows.Count > 0)
                    //    {
                    //        return Json(new
                    //        {
                    //            success = true,
                    //            message = "Login done successfully",
                    //            redirect_controller = "Home",
                    //            redirect_action = "DashBoard"
                    //            //redirect_controller = dt_Employee.Rows[0]["Controller"].ToString(),
                    //            //redirect_action = dt_Employee.Rows[0]["Action"].ToString()
                    //        }, JsonRequestBehavior.AllowGet);
                    //    }
                    //    else
                    //    {
                    //        return Json(new
                    //        {
                    //            success = false,
                    //            message = "Username or Password is invalid"
                    //        }, JsonRequestBehavior.AllowGet);
                    //    }
                    //}
                    //else
                    //{
                    //    return Json(new
                    //    {
                    //        success = false,
                    //        message = "Username or Password is invalid"
                    //    }, JsonRequestBehavior.AllowGet);
                    //}
                    SessionFacade.IsPersistent = IsRemind;

                    DataTable dt_Employee = ds_Result.Tables[0];
                    DataTable dt_FormPermission = ds_Result.Tables[1];
                    if (dt_Employee.Rows.Count > 0)
                    {
                        //    DataTable dt_Settings = home_repository.GetData_Single_User_General_Preferences_Settings(Convert.ToInt32(dt_Employee.Rows[0]["EMPLOYEE_CODE"]));

                        Employee_Master employee_master = new Employee_Master();

                        employee_master.Company_Code = Convert.ToInt32(dt_Employee.Rows[0]["company_id"]);
                        employee_master.Branch_Code = Convert.ToInt32(dt_Employee.Rows[0]["branch_id"]);
                        employee_master.Location_Code = Convert.ToInt32(dt_Employee.Rows[0]["location_id"]);
                        employee_master.Department_Code = Convert.ToInt32(dt_Employee.Rows[0]["department_id"]);

                        employee_master.Company_Name = Convert.ToString(dt_Employee.Rows[0]["company_name"]);
                        employee_master.Branch_Name = Convert.ToString(dt_Employee.Rows[0]["branch_name"]);
                        employee_master.Location_Name = Convert.ToString(dt_Employee.Rows[0]["location_name"]);
                        employee_master.Department_Name = Convert.ToString(dt_Employee.Rows[0]["department_name"]);

                        employee_master.ID = Convert.ToInt32(dt_Employee.Rows[0]["user_id"]);
                        employee_master.UserName = Convert.ToString(dt_Employee.Rows[0]["user_name"]);
                        employee_master.user_type = Convert.ToString(dt_Employee.Rows[0]["user_type"]);
                        employee_master.Employee_ID = Convert.ToInt32(dt_Employee.Rows[0]["employee_id"]);
                        employee_master.Party_ID = Convert.ToInt32(dt_Employee.Rows[0]["party_id"]);
                        employee_master.RoleId = Convert.ToInt32(dt_Employee.Rows[0]["Role_id"]);

                        //if (dt_Settings.Rows.Count > 0)
                        //{
                        //    if (dt_Settings.Rows[0]["SHOW_ORDER_QTY_AND_DIFF"].ToString() == "")
                        //    {
                        //        employee_master.SHOW_ORDER_QTY_AND_DIFF = 0;
                        //    }
                        //    else
                        //    {
                        //        employee_master.SHOW_ORDER_QTY_AND_DIFF = Convert.ToInt32(dt_Settings.Rows[0]["SHOW_ORDER_QTY_AND_DIFF"].ToString());
                        //    }
                        //}


                        List<Form_Permission> form_permission_list = new List<Form_Permission>();

                        foreach (DataRow dr in dt_FormPermission.Rows)
                        {
                            Form_Permission form_permission = new Form_Permission();

                            form_permission.Controller = Convert.ToString(dr["controller"]);
                            form_permission.Action = Convert.ToString(dr["action"]);
                            form_permission.IsView = Convert.ToBoolean(dr["is_view"]);
                            form_permission.IsInsert = Convert.ToBoolean(dr["is_insert"]);
                            form_permission.IsUpdate = Convert.ToBoolean(dr["is_update"]);
                            form_permission.IsDelete = Convert.ToBoolean(dr["is_delete"]);
                            form_permission.IsEmail = Convert.ToBoolean(dr["is_email"]);
                            form_permission.IsPrint = Convert.ToBoolean(dr["is_print"]);

                            form_permission_list.Add(form_permission);
                        }

                        Global._IPAddress = GetIPAddress();
                        SessionFacade.MACAddr = Global.GetMACAddress();
                        SessionFacade.FormPermissionList = form_permission_list;
                        AdminMenuManager admin_menu_manager = new AdminMenuManager();
                        SessionFacade.MenuList = admin_menu_manager.GetSitemMenuItems(Convert.ToInt32(employee_master.RoleId));
                        DataTable p_DtbUserPreference = objEmployee.GetData_Single_User_General_Preferences_Settings(Convert.ToInt32(employee_master.ID));

                        if (p_DtbUserPreference.Rows.Count > 0)
                        {
                            DataRow DRow = p_DtbUserPreference.Rows[0];
                            employee_master.currency_id = Convert.ToInt32(DRow["currency_id"]);
                            employee_master.secondary_currency_id = Convert.ToInt32(DRow["secondary_currency_id"]);
                            employee_master.rate_type_id = Convert.ToInt32(DRow["rate_type_id"]);
                            employee_master.sale_rate_type_id = Convert.ToInt32(DRow["sale_rate_type_id"]);
                        }
                        SessionFacade.UserSession = employee_master;
                        objEmployee.Insert_Login_History(employee_master.ID, Request.UserHostAddress.ToString());//Request.UserHostAddress.ToString()
                        if (IsRemind)
                        {
                            //HttpCookie cookie = new HttpCookie(“YourAppLogin”);
                            //cookie.Values.Add(“username”, txtUsername.Text);
                            //cookie.Expires = DateTime.Now.AddDays(15);
                            //Response.Cookies.Add(cookie);
                        }
                        return Json(new
                        {
                            success = true,
                            message = "Login done successfully",
                            //redirect_controller = "Home",
                            //redirect_action = "DashBoard"
                            redirect_controller = dt_Employee.Rows[0]["Controller"].ToString(),
                            redirect_action = dt_Employee.Rows[0]["Action"].ToString()
                        }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new
                        {
                            success = false,
                            message = "Username or Password is invalid"
                        }, JsonRequestBehavior.AllowGet);
                    }
                }

                else
                {
                    return Json(new
                    {
                        success = false,
                        message = "Username or Password is invalid"
                    }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "Login failed"//, Error:-" + ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Home");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string GetIPAddress()
        {
            string ipaddress;
            ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                ipaddress = Request.ServerVariables["REMOTE_ADDR"];
            return ipaddress;
        }
    }
}