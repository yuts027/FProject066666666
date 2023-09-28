using FProjectCamping.Common;
using FProjectCampingBackend.Models.EFModels;
using FProjectCampingBackend.Models.Repostories;
using FProjectCampingBackend.Models.Services;
using FProjectCampingBackend.Models.ViewModels.Orders;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FProjectCampingBackend.Controllers
{
	public class OrdersController : Controller
	{
		private AppDbContext db = new AppDbContext();
		private readonly OrderService _OrderService = new OrderService();

		// GET: Orders

		public ActionResult Index(SearchParameterVm vm, int page = 1, int pageSize = 15)
		{
			ViewData["Status"] = _OrderService.GetStatusDropdownList();
			var repo = new OrderRepository(db);
			IQueryable<Order> parameter = repo.GetOrders(vm);

			// 遍歷資料庫中的訂單，並將其轉換為 ViewModel
			var result = new List<OrderVm>();
			foreach (var order in parameter)
			{
				var orderVm = new OrderVm()
				{
					Id = order.Id,
					OrderNumber = order.OrderNumber,
					OrderTime = order.OrderTime,
					PaymentType = order.PaymentType.Name,
					Price = order.TotalPrice,
					Status = order.Status.IntToEnum<OrderStatusEnum>().GetAttribute<DisplayAttribute>().Name,
					Member = order.Member.Name,
					Name = order.Name,
					Email = order.Email,
					PhoneNum = order.PhoneNum
				};
				result.Add(orderVm);
			}

			// 使用ToPagedList進行分頁
			var pagedOrders = result.OrderByDescending(x => x.OrderTime).ToPagedList(page, pageSize);

			return View(pagedOrders);
		}

		// GET: Orders/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Order order = db.Orders.Find(id);
			if (order == null)
			{
				return HttpNotFound();
			}
			var result = new List<OrderItemsVm>();
			foreach (var item in order.OrderItems)
			{
				var orderItemsVm = new OrderItemsVm
				{
					RoomType = item.Room.RoomType.Name,
					RoomNum = item.Room.RoomName,
					CheckInDate = item.CheckInDate.ToShortDateString(),
					CheckOutDate = item.CheckOutDate.ToShortDateString(),
					Days = item.Days,
					SubTotal = item.SubTotal
				};
				result.Add(orderItemsVm);
			}
			return View(result);
		}

		// GET: Orders/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Order orders = db.Orders.Find(id);
			if (orders == null)
			{
				return HttpNotFound();
			}
			return View(orders);
		}

		// POST: Orders/Edit/5
		// 若要免於大量指派 (overposting) 攻擊，請啟用您要繫結的特定屬性，
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,MemberId,OrderTime,Status,PaymentTypeId,TotalPrice")] Order order)
		{
			if (ModelState.IsValid)
			{
				db.Entry(order).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.MemberId = new SelectList(db.Members, "Id", "Account", order.MemberId);
			ViewBag.PaymentTypeId = new SelectList(db.PaymentTypes, "Id", "Name", order.PaymentTypeId);
			return View(order);
		}

		// GET: Orders/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Order order = db.Orders.Find(id);
			if (order == null)
			{
				return HttpNotFound();
			}
			return View(order);
		}

		// POST: Orders/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Order order = db.Orders.Find(id);
			db.Orders.Remove(order);
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