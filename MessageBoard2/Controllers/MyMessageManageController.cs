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
    public class MyMessageManageController : Controller
    {
        public IMessageService MessageService { get; set; }
        public IReplyService ReplyService { get; set; }

        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult GetMessage(Message msg) {
            msg = MessageService.GetMessage(msg);
            return Json(msg);
        }

        [HttpPost]
        public ActionResult GetMessageDataGridList(int page = 1, int rows = 10, string KeyWord = "", string KeyWordType = "TitleOrContent") {
            //为搜索拼接条件字符串
            string sql = "";
            if (KeyWord != "") {
                if(KeyWordType == "TitleOrContent") {
                    sql = "AND (Title LIKE '%" + KeyWord + "%' OR Content LIKE '%" + KeyWord + "%')";
                }
                else if(KeyWordType == "Username") {
                    sql = "AND Username LIKE '%" + KeyWord + "%'";
                }
                
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
        public ActionResult SwitchMessageState(Message msg) {
            int count = MessageService.SwitchMessageState(msg);
            if (count > 0) {
                return Json(new { result = "Success", tip = "切换状态成功" });
            }
            else {
                return Json(new { result = "Fail", tip = "由于未知原因, 切换状态失败" });
            }
        }

        [HttpPost]
        public ActionResult ChangeMessage(Message msg) {
            int count = MessageService.ChangeMessage(msg);
            if (count > 0) {
                return Json(new { result = "Success", tip = "修改成功" });
            }
            else {
                return Json(new { result = "Fail", tip = "由于未知原因, 修改失败" });
            }
        }

        [HttpPost]
        public ActionResult DeleteMessage(Message msg) {
            int count = MessageService.DeleteMessage(msg);
            if (count > 0) {
                return Json(new { result = "Success", tip = "删除成功" });
            }
            else {
                return Json(new { result = "Fail", tip = "由于未知原因, 删除失败" });
            }
        }

        [HttpPost]
        public ActionResult AddReply(Reply reply) {
            reply.AdminName = (string)Session["AccountName"];
            int count = ReplyService.AddReply(reply);
            if (count > 0) {
                return Json(new { result = "Success", tip = "回复成功" });
            }
            else {
                return Json(new { result = "Fail", tip = "由于未知原因, 回复失败" });
            }
        }
    }
}