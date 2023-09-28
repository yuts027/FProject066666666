
using FProjectCamping.Models.EFModels;
using FProjectCamping.Models.Services;
using FProjectCamping.Models.ViewModels.Carts;
using FProjectCamping.Models.ViewModels.Rooms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FProjectCamping.Controllers.Carts
{
	public class CartApiController : ApiController
    {
		[HttpPost]
		[Route("api/Cart/AddCartItem")]
		public IHttpActionResult AddCartItem([FromBody] CartItemsVm requestData)
		{
			var service = new CartService();
			string buyer = User.Identity.Name; // 购买者账号
			var result = service.AddToCart(buyer, requestData);

			// 将订单数量包含在响应中
			var response = new
			{
				Message = result.Message,
				Count = result.Count
			};

			return Ok(response);
		}
		[HttpGet]
		public IHttpActionResult GetOrderedRoomIds()
		{
			try
			{
				var db = new AppDbContext();

				// 获取已在 orderitem 中的 roomid 列表
				var orderedRoomIds = db.OrderItems.Select(oi => oi.RoomId).ToList();

				return Ok(orderedRoomIds);
			}
			catch (Exception ex)
			{
				return InternalServerError(ex);
			}
		}

		//[HttpPost]
		//[Route("api/Cart/AddCartItem")]
		//public IHttpActionResult AddCartItem([FromBody] CartItemRequestModel requestData)
		//{
		//    var param = new CartItemsVm() 
		//    {
		//        RoomId = requestData.roomId,
		//        CheckInDate = requestData.checkInDate,
		//        CheckOutDate = requestData.checkOutDate,
		//        ExtraBed = requestData.extraBed,
		//        ExtraBedPrice = requestData.extraBedPrice,
		//        Days = requestData.days,
		//        SubTotal = requestData.subtotal
		//    };

		//    var service = new CartService();
		//    string buyer = User.Identity.Name; // 買家帳號
		//    var result = service.AddToCart(buyer, param); //加入購物車

		//    return Ok(result);
		//}
	}
}