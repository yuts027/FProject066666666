using FProjectCampingBackend.Models.EFModels;
using FProjectCampingBackend.Models.Repostories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FProjectCampingBackend.Controllers
{
	public class HomeController : Controller
	{
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
		{
            string connectionString = "data source=.\\sql2022;initial catalog=FDB06;user id=sa5;password=sa5;MultipleActiveResultSets=True;App=EntityFramework\" providerName=\"System.Data.SqlClient"; 
            using (var dbConnection = new SqlConnection(connectionString))
            {
                var repo = new MemberRepository(dbConnection);
                var getmember = repo.GetLatestMembers();
				var getNewOrders = repo.GetNewOrders();
				ViewBag.NewOrders = getNewOrders;

				return View(getmember);
            }
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