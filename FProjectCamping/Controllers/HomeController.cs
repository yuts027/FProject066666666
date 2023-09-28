using FProjectCamping.Models.EFModels;
using FProjectCamping.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace FProjectCamping.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            var db = new AppDbContext();
            var repo = new NewsRepository(db);
			var newsList = repo.GetNew();

			return View(newsList);
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