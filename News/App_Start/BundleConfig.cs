using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace News
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/*.css"));
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include("~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.unobtrusive-ajax.js"));
        }
    }
}