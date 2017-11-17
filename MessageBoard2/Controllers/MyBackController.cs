using MessageBoard2.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessageBoard2.Controllers
{
    [AdminFilter]
    public class MyBackController : Controller
    {
        //后台管理的主页
        public ActionResult Index()
        {
            return View();
        }
    }
}