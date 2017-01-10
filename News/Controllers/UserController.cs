using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using News.Models;

namespace News.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUsers()
        {
            return Json(GetAllUsersHelper(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserModel userModel)
        {
            if (userModel.ConfirmPassword != userModel.Password)
                ModelState.AddModelError(String.Empty, "Password not match with confirm password!");
            
            if (ModelState.IsValid)
            {
                userModel.UserId=UsersDB.GetAllUsers().Count();
                UsersDB.AddUser(userModel);
                ViewBag.RegistrationState = "Registration successful!";
            }
            return View(userModel);
        }

        private IEnumerable<UserModel> GetAllUsersHelper()
        {
            return UsersDB.GetAllUsers();
        }

        public ActionResult Sort(string by)
        {
            return Json(GetSortedUsersHelper(by), JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<UserModel> GetSortedUsersHelper(string by)
        {
            var allUsers = UsersDB.GetAllUsers();
            if (by == "First Name")
                return allUsers.OrderBy(x => x.FirstName);
            if (by == "Last Name")
                return allUsers.OrderBy(x => x.LastName);
            if (by == "Email")
                return allUsers.OrderBy(x => x.Email);
            return allUsers.OrderBy(x => x.UserId);
        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                var user = UsersDB.GetAllUsers().FirstOrDefault(x => x.UserId == id);
                if (user != null)
                {
                    ViewBag.IsRegistered = true;
                    return PartialView(user);
                }
            }
            ViewBag.EditingState = "User not found!";
            return PartialView();
        }
        [HttpPost]
        public ActionResult Details(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = UsersDB.GetAllUsers().FirstOrDefault(x => x.UserId == userModel.UserId);
                if (user != null)
                {
                    user.FirstName = userModel.FirstName;
                    user.LastName = userModel.LastName;
                    user.Email = userModel.Email;
                    user.Password = userModel.Password;
                    user.ConfirmPassword = userModel.ConfirmPassword;
                    ViewBag.EditingState = "Saved!";
                }
                else
                {
                    ViewBag.EditingState = "User not found!";
                }
            }
            return Json(GetSortedUsersHelper(""), JsonRequestBehavior.AllowGet);
        }
    }

}