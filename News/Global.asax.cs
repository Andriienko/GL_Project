using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using News.Infrastructure;
using News.Models;

namespace News
{
    public class MvcApplication : System.Web.HttpApplication
    {
       
        protected void Application_Start()
        {
            Application["TimeStart"] = DateTime.Now;
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ViewEngines.Engines.Add(new RequestDataViewEngine());
            ModelBinders.Binders.Add(typeof(UserModel),new DateBinder());
        }
    }
}
