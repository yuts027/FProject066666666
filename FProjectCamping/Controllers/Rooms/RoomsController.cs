
using FProjectCamping.Models.EFModels;
using FProjectCamping.Models.ViewModels;
using FProjectCamping.Models.ViewModels.Rooms;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FProjectCamping.Controllers.Rooms
{
	public class RoomsController : Controller
	{
		// GET: Rooms
		public ActionResult Roomtype(int roomtypeid = 0, int selectedRoomTypeId = 0)
		{
			int roomTypeIdFromDatabase = 0; // 初始化为0，以防获取失败或不需要时的默认值
			if (selectedRoomTypeId != 0)
			{
				// 使用 selectedRoomTypeId 来执行特定操作
				var branches = GetRoomTypeVm(selectedRoomTypeId);
				ViewBag.hotrooms = branches;
			}
			else
			{
				// 使用 roomtypeid 参数来执行默认操作
				var branches = GetRoomTypeVm(roomtypeid);
				ViewBag.hotrooms = branches;


			}

			// 将 roomTypeIdFromDatabase 和 selectedRoomTypeId 传递给视图
			ViewBag.RoomTypeIdFromDatabase = roomTypeIdFromDatabase;
			ViewBag.SelectedRoomTypeId = selectedRoomTypeId;

			return View();
		}
		public List<RoomtypeVM> GetRoomTypeVm(int id = 0)
		{
			var db = new AppDbContext();
			IQueryable<RoomtypeVM> query = db.Rooms.Include("RoomType")
				.Select(c => new RoomtypeVM
				{
					RoomId = c.Id,
					RoomName = c.RoomName,
					WeekendPrice = c.WeekendPrice,
					WeekdayPrice = c.WeekdayPrice,
					RoomTypeName = c.RoomType.Name,
					RoomtypeId = c.RoomTypeId,
					Photo=c.Photo
				});

			if (id != 0)
			{
				query = query.Where(c => c.RoomtypeId == id);
			};

			var result = query.ToList();

			//foreach (var r in result)
			//{
			//	r.FileName = db.Photos.FirstOrDefault(c => c.RoomTypeId == r.Id);
			//}

			return result;
		}

		public ActionResult Forestarea()
		{
			return View();
		}
		public ActionResult RiversideDistrict()
		{
			return View();
		}

		public ActionResult RoomsPartial()
		{
			ViewBag.HotProducts = BranchroomPartial();
			return View();
		}

		private List<RoomtypeVM> BranchroomPartial()
		{
			var db = new AppDbContext();
			var branches = db.Rooms
				.Select(c => new RoomtypeVM
				{
					Id = c.Id,
					RoomName = c.RoomName,
					WeekendPrice = c.WeekendPrice,
					WeekdayPrice = c.WeekdayPrice,

				}).ToList();

			//foreach (var branch in branches)
			//{
			//	branch.FileName = db.Photos.FirstOrDefault(c => c.RoomTypeId == branch.Id);
			//}


			return branches;
		}
	}
}