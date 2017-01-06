using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace News.Controllers
{
    public class RequestDataController : Controller
    {
    
        public ActionResult AppUpTime()
        {
            System.Web.HttpContext.Current.Application.Lock();
            var timeUp=(DateTime)this.HttpContext.Application["TimeStart"];
            System.Web.HttpContext.Current.Application.UnLock();
            return PartialView("AppUpTime",(DateTime.Now-timeUp).Seconds.ToString());
        }

        public ActionResult RequestData()
        {
            return View("RequestData");
        }
    }
}