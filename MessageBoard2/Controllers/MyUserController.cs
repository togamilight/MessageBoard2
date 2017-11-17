using MessageBoard2.Models;
using MessageBoard2.Service;
using MessageBoard2.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessageBoard2.Controllers
{
    public class MyUserController : Controller
    {
        public IMyUserService MyUserService { get; set; }

        //得到头部分部页面，包含已登录用户的信息，新回复数
        public ActionResult GetUserHeader() {
            MyUser user = new MyUser();
            if (Session["AccountStatus"] != null && (MyAccountStatus)Session["AccountStatus"] == MyAccountStatus.User) {
                string userName = (string)Session["AccountName"];
                user.Username = userName;
                user = MyUserService.GetUserInfo(user);
            }
            return PartialView("UserHeader", user);
        }

        //注册页面
        public ActionResult SignUp() {
            //已经登录时不能注册
            if (Session["AccountStatus"] != null && (MyAccountStatus)Session["AccountStatus"] == MyAccountStatus.User) {
                return RedirectToAction("Index", "MyHome");
            }
            return View("SignUp");
        }

        //确认用户名是否重复
        [HttpPost]
        public ActionResult CheckUsername(string Username) {
            bool result = MyUserService.CheckUsername(new MyUser() { Username = Username});
            return Json(new { isUnique = !result });
        }

        //用户注册
        [HttpPost]
        public ActionResult DoSignUp(MyUser user) {
            MyUserService.AddUser(user);
            return RedirectToAction("Login", new { message = "注册成功，请登录" });
        }

        //登录页面
        public ActionResult Login(string message = "") {
            //已经登录时不能登录
            if (Session["AccountStatus"] != null && (MyAccountStatus)Session["AccountStatus"] == MyAccountStatus.User) {
                return RedirectToAction("Index", "MyHome");
            }
            ViewData["Message"] = message;  //设置提示信息
            return View("Login");
        }

        //用户登录
        [HttpPost]
        public ActionResult DoLogin(MyUser user) {
            bool result = MyUserService.CheckUserPassword(user);
            if (!result) {
                return RedirectToAction("Login", new { message = "用户名或密码错误，请重新登录！" });
            }
            else {
                //登录成功，信息写进Session
                Session["AccountStatus"] = MyAccountStatus.User;
                Session["AccountName"] = user.Username;
                return RedirectToAction("Index", "MyHome");
            }
        }

        //注销
        public ActionResult Logout() {
            //注销，修改Session中的信息
            Session["AccountStatus"] = MyAccountStatus.None;
            Session["AccountName"] = "";

            return RedirectToAction("Login", new { message = "注销成功" });
        }
    }
}