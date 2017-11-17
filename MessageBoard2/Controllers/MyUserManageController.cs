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
    public class MyUserManageController : Controller
    {
        public IMyUserService MyUserService { get; set; }
        public ActionResult Index() {
            return View();
        }

        public ActionResult GetUserDataGridList(int page = 1, int rows = 10, string KeyWord = "") {
            //为搜索拼接条件字符串
            string sql = "";
            if (KeyWord != "") {
                sql = "AND Username LIKE N'%" + KeyWord + "%'";
            }

            //得到数据总条数
            int total = MyUserService.GetUserCountBySql(sql);
            //分页查询
            SelectPageInfo info = new SelectPageInfo() {
                Min = rows * (page - 1),
                Count = rows,
                WhereSql = sql
            };
            IList<MyUser> users = MyUserService.GetUsersPageBySql(info);

            return Json(new { total=total, rows=users, page=page});
        }

        [HttpPost]
        public ActionResult AddUser(MyUser user) {
            bool result = MyUserService.CheckUsername(new MyUser() { Username = user.Username });
            if (result) {
                return Json(new { result = false, tip = "用户名已存在" });
            }
            MyUserService.AddUser(user);
            return Json(new { result = true, tip = "新增用户成功" });
        }

        [HttpPost]
        public ActionResult EditUser(MyUser user, string OldUsername) {
            //当名字改变时检查是否已存在同名用户
            if(OldUsername != user.Username) {
                bool result = MyUserService.CheckUsername(new MyUser() { Username = user.Username });
                if (result) {
                    return Json(new { result = false, tip = "用户名已存在" });
                }
            }
            MyUserService.ChangeUserInfoByAdmin(user);
            return Json(new { result = true, tip = "修改用户成功" });
        }

        [HttpPost]
        public ActionResult DeleteUser(MyUser user) {
            int count = MyUserService.DeleteUser(user);
            if(count > 0) {
                return Json(new { result = true, tip = "删除用户成功" });
            }else {
                return Json(new { result = false, tip = "由于未知原因, 删除用户失败" });
            }
        }
    }
}