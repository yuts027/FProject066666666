using FProjectCamping.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FProjectCamping.Models.Repositories
{
	public class NewsRepository
	{
		private AppDbContext db;
		public NewsRepository(AppDbContext dbContext)
		{
			db = dbContext;
		}
		public List<News> GetNew()
		{
			var newsList = db.News
				.OrderByDescending(newsItem => newsItem.CreatedTime)
				.ToList();

			return newsList;
		}
	}
}