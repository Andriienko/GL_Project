using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using News.Models;

namespace News.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Add(IEnumerable<NewsModel> news)
        {
            NewsMaker maker = new NewsMaker();
            if (news != null)
            {
                return Json(maker.AddNews(news), JsonRequestBehavior.AllowGet);
            }
            return RedirectToAction("GetNews");
        }
        public ActionResult GetNews()
        {
            NewsMaker maker=new NewsMaker();
            return Json(maker.GetNews(),JsonRequestBehavior.AllowGet);
        }
    }
}