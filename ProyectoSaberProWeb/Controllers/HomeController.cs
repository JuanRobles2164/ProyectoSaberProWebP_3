using ProyectoSaberProWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoSaberProWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            //Si no encuenta algún usuario, redirije al registro
            if (db.Users.ToList().Count == 0)
            {
                return RedirectToAction("Register", "Account");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}