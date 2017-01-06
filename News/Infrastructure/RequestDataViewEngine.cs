using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Infrastructure
{
    public class RequestDataViewEngine : IViewEngine
    {
        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            return new ViewEngineResult(new string[]
            { "No view (Request Data View Engine)" });
        }

        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            if (viewName == "RequestData")
            {
                return new ViewEngineResult(new RequestDataView(), this);
            }
            else
            {
                return new ViewEngineResult(new string[]
                { "No view (Request Data View Engine)" });
            }
        }

        public void ReleaseView(ControllerContext controllerContext, IView view)
        {

        }
    }
}