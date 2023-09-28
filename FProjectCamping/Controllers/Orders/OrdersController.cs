using FProjectCamping.Common;
using FProjectCamping.Models.Services;
using FProjectCamping.Models.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FProjectCamping.Controllers
{
	public class OrdersController : Controller
	{
		private readonly OrderService _orderService = new OrderService();

		// GET: Orders
		public ActionResult Index()
		{
			return View();
		}

		[Authorize]
		public ActionResult Pay(int orderId)
		{
			var model = _orderService.GetOrder(orderId);

			if (model.StatusEnum == OrderStatusEnum.Payment.Int())
			{
				return RedirectToAction("PaySuccessed");
			}

			return View(model);
		}

		[Authorize]
		public ActionResult PaySuccessed(int orderId)
		{
			var model = _orderService.GetOrder(orderId);

			return View(model);
		}

		[HttpPost]
		public void CallBack(CallbackReq req)
		{
			// 付款成功
			if (req.IsSuccessed)
			{
				_orderService.UpdateStatus(req.OrderNumber, OrderStatusEnum.Payment);
			}
			else // 例外狀況: 付款失敗
			{
				_orderService.UpdateStatus(req.OrderNumber, OrderStatusEnum.Failed);
			}
		}
	}
}