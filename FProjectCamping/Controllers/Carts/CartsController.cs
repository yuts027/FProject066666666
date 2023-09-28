using FProjectCamping.Models.Services;
using FProjectCamping.Models.ViewModels.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;

namespace FProjectCamping.Controllers.Carts
{
	public class CartsController : Controller
	{
		private readonly Models.Services.ProfileService _profileService = new Models.Services.ProfileService();
		private readonly CartService _cartService = new CartService();

		[Authorize]
		public ActionResult Cart()
		{
			// 登入者
			var account = User.Identity.Name;
			var model = _cartService.Get(account);

			return View(model);
		}

		[Authorize]
		[HttpPost]
		public ActionResult Cart(CartVm vm)
		{
			if (vm.Items == null)
			{
				ViewBag.ShowSweetAlert = true;
				return View(vm);
			}

			_cartService.Update(vm);

			return RedirectToAction("OrderInfo");
		}

		[Authorize]
		public ActionResult OrderInfo()
		{
			var account = User.Identity.Name;
			var cart = _cartService.Get(account);

			// 預設帶入 訂房人資料
			cart.ContactProfile = _profileService.GetMemberProfile(account);
			return View(cart);
		}

		[Authorize]
		[HttpPost]
		public ActionResult OrderInfo(CartVm vm)
		{
			if (!ModelState.IsValid) return View(vm);

			// 檢查購物車要有項目 才能後續動作 todo: 給前端錯誤訊息
			if (!vm.Items.Any()) { return View(vm); }

			var account = User.Identity.Name;
			var cart = _cartService.GetOrCreateCart(account);
			cart.AllowCheckout = cart.Items.Any();

			if (cart.AllowCheckout == false)
			{
				ModelState.AddModelError("", "購物車是空的,無法進行結帳");
				return View(vm);
			}

			foreach (var item in cart.Items)
			{
				item.RoomName = vm.Items.FirstOrDefault(x => x.Id == item.Id).RoomName;
			}
			cart.ContactProfile = vm.ContactProfile;
			cart.Memo = vm.Memo;
			cart.PaymentType = vm.PaymentType;

			var orderId = _cartService.ProcessCheckout(account, cart);
			return RedirectToAction("Pay", "Orders", new { orderId = orderId }); // 轉導到 Orders/Pay 並帶入參數: orderId
		}

		/// <summary>
		/// 將 CartItem加入購物車
		/// </summary>
		/// <param name="vm"></param>
		/// <returns></returns>
		[Authorize]
		[HttpPost]
		public string AddItem(CartItemsVm vm)
		{
			string buyer = User.Identity.Name; // 買家帳號
			var result = _cartService.AddToCart(buyer, vm); // 加入購物車

			// 返回 AddToCartResult 中的消息字符串
			return result.Message;
		}

		//[Authorize]
		//public ActionResult Checkout()
		//{
		//	var buyer = User.Identity.Name;
		//	var cart = _cartService.GetOrCreateCart(buyer);

		//	if (cart.AllowCheckout == false) ViewBag.ErrorMessage = "購物車是空的,無法進行結帳";

		//	return View();
		//}

		//[Authorize]
		//[HttpPost]
		//public ActionResult Checkout(CheckoutVm vm)
		//{
		//	if (!ModelState.IsValid) return View(vm);

		//	var cartService = _cartService;

		//	var buyer = User.Identity.Name;
		//	var cart = cartService.GetOrCreateCart(buyer);

		//	if (cart.AllowCheckout == false)
		//	{
		//		ModelState.AddModelError("", "購物車是空的,無法進行結帳");
		//		return View(vm);
		//	}

		//	//cartService.ProcessCheckout(buyer, cart, vm);
		//	return View("ConfirmCheckout");
		//}

		public ActionResult DeleteCartItem(int cartItemId)
		{
			_cartService.DeleteCartItem(cartItemId);
			return new EmptyResult();
		}
	}
}