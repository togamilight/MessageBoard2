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
    [UserFilter]
    public class MyUserCenterController : Controller
    {
        public IMyUserService MyUserService { get; set; }
        public ActionResult ChangeUserInfo(string message = "") {
            ViewData["Message"] = message;
            return View("ChangeUserInfo");
        }

        [HttpPost]
        public ActionResult GetUserInfo() {
            MyUser user = new MyUser() { Username = (string)Session["AccountName"] };
            user = MyUserService.GetUserInfo(user);
            return Json(user);
        }

        [HttpPost]
        public ActionResult ChangeUserInfo(MyUser user) {
            user.Username = (string)Session["AccountName"];
            int count = MyUserService.ChangeUserInfo(user);
            if(count > 0) {
                return Json(new { Tip="修改信息成功"});
            }
            return Json(new { Tip = "由于未知原因，修改信息失败" });
        }

        [HttpPost]
        public ActionResult ChangeUserPassword(string oldPassword, string newPassword) {
            string username = (string)Session["AccountName"];
            MyUser user = new MyUser() { Username = username, Password = oldPassword };
            //确认原密码正确性
            if (MyUserService.CheckUserPassword(user)) {
                user.Password = newPassword;
                MyUserService.ChangeUserPassword(user);
                return Json(new { Tip="修改密码成功"});
            }
            else {
                return Json(new { Tip = "原密码错误，修改密码失败" });
            }
        }
    }
}