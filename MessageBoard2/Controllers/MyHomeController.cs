using MessageBoard2.Models;
using MessageBoard2.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessageBoard2.Controllers
{
    public class MyHomeController : Controller
    {
        public IMessageService MessageService { get; set; }
        
        //主页
        public ActionResult Index()
        {
            return View();
        }

        //得到公开留言的分页数据
        [HttpPost]
        public ActionResult GetMessageDataGridList(int page = 1, int rows = 10, string KeyWord = "") {
            //为搜索拼接条件字符串
            string sql = " AND IsPublic=1";
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

        //得到某条公开留言的详细信息，包括回复
        [HttpPost]
        public ActionResult GetMessage(Message msg) {
            msg = MessageService.GetMessage(msg);
            if (msg.IsPublic) {
                return Json(msg);
            }else {
                return Json(new Message());
            }
            
        }
    }
}