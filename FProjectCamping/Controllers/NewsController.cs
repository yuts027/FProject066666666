using FProjectCamping.Models.EFModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using FProjectCamping.Models.Repositories;

namespace FProjectCamping.Controllers
{
    public class NewsController : Controller
    {
        private AppDbContext db = new AppDbContext();

		// GET: News
		public ActionResult Index(int page = 1, int pageSize = 8)
		{
			var repo = new NewsRepository(db);
            var newsList = repo.GetNew();
		
			var pagedNews = newsList.ToPagedList(page, pageSize);

			return View(pagedNews);
		}

		// GET: News/Details/5
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }
    }
}