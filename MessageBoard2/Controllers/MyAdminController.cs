﻿using MessageBoard2.Models;
using MessageBoard2.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessageBoard2.Controllers
{
    public class MyAdminController : Controller
    {
        public IAdminService AdminService { get; set; }

        public ActionResult Login(string message = "") {
            //已经登录时不能登录
            if (Session["AccountStatus"] != null && (MyAccountStatus)Session["AccountStatus"] == MyAccountStatus.Admin) {
                return RedirectToAction("Index", "MyBack");
            }
            ViewData["Message"] = message;  //设置提示信息
            return View("Login");
        }

        [HttpPost]
        public ActionResult DoLogin(Admin admin) {
            bool result = AdminService.CheckAdminPassword(admin);
            if (!result) {
                return RedirectToAction("Login", new { message = "用户名或密码错误，请重新登录！" });
            }
            else {
                //登录成功，信息写进Session
                Session["AccountStatus"] = MyAccountStatus.Admin;
                Session["AccountName"] = admin.AdminName;
                return RedirectToAction("Index", "MyBack");
            }
        }

        public ActionResult Logout() {
            //注销，修改Session中的信息
            Session["AccountStatus"] = MyAccountStatus.None;
            Session["AccountName"] = "";

            return RedirectToAction("Login", new { message = "注销成功" });
        }
    }
}