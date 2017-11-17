using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessageBoard2.Controllers
{
    public class MyErrorController : Controller
    {
        //拦截无效路径
        public ActionResult Index()
        {
            Exception e = new Exception("无效的路径（无效的Action或Controller）");
            HandleErrorInfo eInfo = new HandleErrorInfo(e, "Unknown", "Unknown");
            return View("Error", eInfo);
        }
    }
}