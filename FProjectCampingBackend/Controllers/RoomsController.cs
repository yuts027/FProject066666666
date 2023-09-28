using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FProjectCampingBackend.Models.EFModels;
using FProjectCampingBackend.Models.Repostories;
using FProjectCampingBackend.Models.Services;
using FProjectCampingBackend.Models.ViewModels;
using FProjectCampingBackend.Models.ViewModels.Orders;
using PagedList;

namespace FProjectCampingBackend.Controllers
{
    public class RoomsController : Controller
    {
		private AppDbContext db = new AppDbContext();
		private readonly DropdownListService _dropdownListService = new DropdownListService();

		// GET: Rooms
		public ActionResult Index(SearchParameterVm vm, int page = 1, int pageSize = 8)
		{
			//ViewData["RoomName"] = _dropdownListService.GetRoomNameDropdownList();


			IQueryable<Room> parameter = db.Rooms.Include(r => r.RoomType);

			var roomTypeNames = parameter.Select(room => room.RoomType.Name).ToList();



			var result = new List<RoomsVm>();
			foreach (var room in parameter)
			{
				var roomsVm = new RoomsVm()
				{
					Id = room.Id,
					RoomTypeName = room.RoomType.Name,
					RoomName = room.RoomName,
					WeekendPrice = room.WeekendPrice,
					WeekdayPrice = room.WeekdayPrice,
					Description = room.Description,
					Status = room.Status ? "可以" : "不可以",
					Stock = room.Stock,
					Photo = room.Photo
				};
				result.Add(roomsVm);
			}
			var pagedRooms = result.OrderBy(x => x.Id).ToPagedList(page, pageSize);
			return View(pagedRooms);

		}

		// GET: Rooms/Details/5
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: Rooms/Create
        public ActionResult Create()
        {
            ViewBag.RoomTypeId = new SelectList(db.RoomTypes, "Id", "Name");
            return View();
        }

        // POST: Rooms/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RoomTypeId,RoomName,Description,WeekendPrice,WeekdayPrice,Status,Stock")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoomTypeId = new SelectList(db.RoomTypes, "Id", "Name", room.RoomTypeId);
            return View(room);
        }

        // GET: Rooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomTypeId = new SelectList(db.RoomTypes, "Id", "Name", room.RoomTypeId);
            return View(room);
        }

        // POST: Rooms/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RoomTypeId,RoomName,Description,WeekendPrice,WeekdayPrice,Status,Stock,Photo")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoomTypeId = new SelectList(db.RoomTypes, "Id", "Name", room.RoomTypeId);
            return View(room);
        }

        // GET: Rooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
