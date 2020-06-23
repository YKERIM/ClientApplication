using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


   /*     public ActionResult LoginPage()
        {
            ViewBag.Message = "Veuillez vous connectez";

            return View();
        } */
    }
}