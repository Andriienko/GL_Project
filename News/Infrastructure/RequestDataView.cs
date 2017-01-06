using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Infrastructure
{
    public class RequestDataView : IView
    {
        public void Render(ViewContext viewContext, TextWriter writer)
        {
            
            writer.WriteLine("<a style='margin-left:800px; font-size:25px;' href='"+"http://localhost:55545/Home/Index"+"'>Home</a>");
            Write(writer, "<h3>---Request Headers---</h3>");
            foreach (string key in viewContext.HttpContext.Request.Headers.Keys)
            {
                Write(writer, "Key: {0}, Value: {1}",
                    key, viewContext.HttpContext.Request.Headers[key]);
            }
            Write(writer, "<h3>---Post Data---</h3>");
            foreach (string key in viewContext.HttpContext.Request.Form.Keys)
            {
                Write(writer, "Key: {0}, Value: {1}", key,
                    viewContext.HttpContext.Request.Form[key]);
            }
            Write(writer, "<h3>---Cookies---</h3>");
            foreach (string key in viewContext.HttpContext.Request.Cookies.Keys)
            {
                Write(writer, "Key: {0}, Value: {1}", key,
                    viewContext.HttpContext.Request.Cookies[key]);
            }
            Write(writer, "<h3>---Query parameters---</h3>");
            foreach (string key in viewContext.HttpContext.Request.Params.Keys)
            {
                Write(writer, "Key: {0}, Value: {1}", key,
                    viewContext.HttpContext.Request.Params[key]);
            }
        }

        private void Write(TextWriter writer, string template, params object[] values)
        {
            writer.Write(string.Format(template, values) + "<p/>");
        }
    }
}