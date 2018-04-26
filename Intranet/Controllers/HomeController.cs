using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intranet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Zona = 1;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Zona = 2;
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Zona = 3;

            return View();
        }

        public ActionResult User1()
        {
            ViewBag.Message = "Usuario 1";
            ViewBag.Zona = 41;

            return View();
        }

        public ActionResult User2()
        {
            ViewBag.Message = "Usuario 2";
            ViewBag.Zona = 42;

            return View();
        }
    }
}