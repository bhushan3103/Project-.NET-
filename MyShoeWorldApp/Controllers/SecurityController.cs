using MyShoeWorldApp.Dal;
using MyShoeWorldApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShoeWorldApp.Controllers
{
    public class SecurityController : Controller
    {
        private readonly UserDal _userDal;

        public SecurityController(UserDal userDal)
        {
            _userDal = userDal;
        }

        // GET: Security
        public ActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(User user)
        {
            if (ModelState.IsValid)
            {
                user.Role = "Customer";
                int result = _userDal.RegisterNewUser(user);
                if (result>0)
                {
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                User existingUser = _userDal.CheckCredentials(user);
                Session["Role"] = existingUser.Role;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Security");
        }
    }
}