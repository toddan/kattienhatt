using kattienhatt.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kattienhatt.Controllers
{
    public class HomeController : Controller
    {
        private KattienhattDbContext db = new KattienhattDbContext();

        public ActionResult Index()
        {
            var users = db.Users.ToList();

            return View(users);
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