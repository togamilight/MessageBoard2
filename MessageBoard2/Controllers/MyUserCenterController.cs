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
        public IMessageService MessageService { get; set; }

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
                return Json(new { result = true, tip="修改信息成功"});
            }
            return Json(new { result = false, tip = "由于未知原因，修改信息失败" });
        }

        [HttpPost]
        public ActionResult ChangeUserPassword(string oldPassword, string newPassword) {
            string username = (string)Session["AccountName"];
            MyUser user = new MyUser() { Username = username, Password = oldPassword };
            //确认原密码正确性
            if (MyUserService.CheckUserPassword(user)) {
                user.Password = newPassword;
                MyUserService.ChangeUserPassword(user);
                return Json(new { result = true, tip="修改密码成功"});
            }
            else {
                return Json(new { result = false, tip = "原密码错误，修改密码失败" });
            }
        }

        public ActionResult MessageManage() {
            return View();
        }

        [HttpPost]
        public ActionResult GetMessageDataGridList(int page = 1, int rows = 10, string KeyWord = "") {
            //为搜索拼接条件字符串
            string sql = " AND Username=N'" + (string)Session["AccountName"] + "'";
            if (KeyWord != "") {
                    sql += " AND (Title LIKE N'%" + KeyWord + "%' OR Content LIKE N'%" + KeyWord + "%')";
            }
            //得到数据总条数
            int total = MessageService.GetMessageCountBySql(sql);
            //分页查询
            SelectPageInfo info = new SelectPageInfo() {
                Min = rows * (page - 1),
                Count = rows,
                WhereSql = sql
            };
            IList<Message> msgs = MessageService.GetMessagesPageBySql(info);

            return Json(new { total = total, rows = msgs, page = page });
        }

        [HttpPost]
        public ActionResult AddMessage(Message msg) {
            msg.Username = (string)Session["AccountName"];
            int id = MessageService.AddMessage(msg);
            if(id != 0) {
                return Json(new { result = true, tip = "发表留言成功" });
            }else {
                return Json(new { result = false, tip = "由于未知原因，发表留言失败" });
            }
        }

        [HttpPost]
        public ActionResult GetMessage(Message msg) {
            msg = MessageService.GetMessage(msg);
            if(msg.NewReply > 0) {
                //已查看新回复，更新新回复数
                MessageService.ClearNewReply(msg);
            }
            return Json(msg);
        }

        [HttpPost]
        public ActionResult ChangeMessage(Message msg) {
            //以防万一
            if (msg.IsPublic) {
                return Json(new { result = false , tip = "无法修改已公开留言" });
            }
            int count = MessageService.ChangeMessage(msg);
            if (count > 0) {
                return Json(new { result = true, tip = "修改成功" });
            }
            else {
                return Json(new { result = false, tip = "由于未知原因, 修改失败" });
            }
        }

        [HttpPost]
        public ActionResult DeleteMessage(Message msg) {
            //以防万一
            if (msg.IsPublic) {
                return Json(new { result = false, tip = "无法删除已公开留言" });
            }
            int count = MessageService.DeleteMessage(msg);
            if (count > 0) {
                return Json(new { result = true, tip = "删除成功" });
            }
            else {
                return Json(new { result = false, tip = "由于未知原因, 删除失败" });
            }
        }
    }
}