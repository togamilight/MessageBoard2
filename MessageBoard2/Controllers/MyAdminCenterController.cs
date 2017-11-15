using MessageBoard2.Filters;
using MessageBoard2.Models;
using MessageBoard2.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessageBoard2.Controllers
{
    [AdminFilter]
    public class MyAdminCenterController : Controller
    {
        public IAdminService AdminService { get; set; }

        public ActionResult ChangeAdminInfo(string message = "") {
            ViewData["Message"] = message;
            return View("ChangeAdminInfo");
        }

        [HttpPost]
        public ActionResult ChangeAdminPassword(string oldPassword, string newPassword) {
            string adminName = (string)Session["AccountName"];
            Admin admin = new Admin() { AdminName = adminName, Password = oldPassword };
            //确认原密码正确性
            if (AdminService.CheckAdminPassword(admin)) {
                admin.Password = newPassword;
                AdminService.ChangeAdminPassword(admin);
                return Json(new { Tip = "修改密码成功" });
            }
            else {
                return Json(new { Tip = "原密码错误，修改密码失败" });
            }
        }

        //注册页面
        public ActionResult SignUp(string message = "") {
            ViewData["Message"] = message;
            return View("SignUp");
        }

        [HttpPost]
        public ActionResult CheckAdminName(string AdminName) {
            bool result = AdminService.CheckAdminName(new Admin() { AdminName = AdminName});
            return Json(new { isUnique = !result });
        }

        [HttpPost]
        public ActionResult DoSignUp(Admin admin) {
            AdminService.AddAdmin(admin);
            return RedirectToAction("SignUp", new { message = "注册成功!" });
        }
    }
}