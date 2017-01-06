using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace News.Controllers
{
    public class ImageController : Controller
    {
        private DirectoryInfo _dir;
        private FileInfo[] _files;

        public ImageController()
        {
            _dir = new DirectoryInfo(@"D:\Images");
            _files = _dir.GetFiles("*.jpg");
        }

        // GET: Home
        [HttpGet]
        public ActionResult Index(int id = 0)
        {
            ViewBag.CatalogSize = _files.Length;
            if (id < _files.Length && id >= 0)
            {
                ViewBag.Pointer = id;
            }
            else if (id < 0)
            {
                ViewBag.Pointer = id = 0;
            }
            else
            {
                ViewBag.Pointer = id = _files.Length - 1;
            }
            ViewData["Name"] = _files[id].Name.Replace(_files.Last().Extension, "");
            return View();
        }
        [HttpGet]
        public ActionResult RenderImage(int id)
        {
            byte[] image = System.IO.File.ReadAllBytes(_files[id].FullName);
            return File(image, "image/jpg");
        }
    }
}