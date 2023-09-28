using FProjectCampingBackend.Models.EFModels;
using FProjectCampingBackend.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FProjectCampingBackend.Models.Repostories
{
	public class RoomsRepository
	{

		private AppDbContext db; // Your DbContext 類別

		public RoomsRepository(AppDbContext dbContext)
		{
			db = dbContext;
		}
		public IQueryable<Room> GetRooms()
		{
			// 返回整個 db.Rooms 集合，不進行任何篩選
			IQueryable<Room> parameter = db.Rooms;

			return parameter;
		}


	}
}