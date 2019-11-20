using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCLogin.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LogIn(string usuario, string password)
        {
            if (usuario == "admin" && password == "admin")
            {
                FormsAuthentication.SetAuthCookie(usuario, false);
                return Json(1);
            }
            else
            {
                return Json(-1);
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

    }
}