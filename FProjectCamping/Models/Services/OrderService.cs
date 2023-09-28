using FProjectCamping.Common;
using FProjectCamping.Models.EFModels;
using FProjectCamping.Models.Respositories;
using FProjectCamping.Models.ViewModels.Carts;
using FProjectCamping.Models.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using static FProjectCamping.MvcApplication;

namespace FProjectCamping.Models.Services
{
	public class OrderService
	{
		private readonly OrderRepository _orderRepository = new OrderRepository();
		private readonly PaymentTypeRepository _paymentTypeRepository = new PaymentTypeRepository();

		public int CreateOrder(string account, CartVm cart)
		{
			// todo : 拉到Repo
			var db = new AppDbContext();
			var memberId = db.Members.First(m => m.Account == account).Id;

			var order = new Order
			{
				MemberId = memberId,
				OrderNumber = GenerateOrderNumber(), // 產生唯一訂單
				Name = cart.ContactProfile.Name,
				PhoneNum = cart.ContactProfile.PhoneNum,
				Email = cart.ContactProfile.Email,
				OrderTime = DateTime.Now,
				Status = OrderStatusEnum.Wait.Int(),
				PaymentTypeId = cart.PaymentType,
				TotalPrice = cart.TotalPrice,
				Memo = cart.Memo
			};
			// 新增訂單明細
			foreach (var item in cart.Items)
			{
				var orderItem = new OrderItem
				{
					RoomId = item.RoomId,
					RoomName = item.RoomName,
					Days = item.Days,
					CheckInDate = Convert.ToDateTime(item.CheckInDate),
					CheckOutDate = Convert.ToDateTime(item.CheckOutDate),
					ExtraBed = item.ExtraBed,
					ExtraBedPrice = item.ExtraBedPrice,
					SubTotal = item.SubTotal,
				};
				order.OrderItems.Add(orderItem);
			}
			var newOrder = db.Orders.Add(order);
			db.SaveChanges();
			return newOrder.Id;
		}

		public PayOrderVm GetOrder(int orderId)
		{
			var order = _orderRepository.GetOrders(orderId);
			var vm = AutoMapperHelper.MapperObj.Map<PayOrderVm>(order);
			vm.PaymentType = _paymentTypeRepository.GetTypeName(order.PaymentTypeId).Name;
			vm.Status = vm.Status.StringToEnum<OrderStatusEnum>().GetAttribute<DisplayAttribute>().Name;
			vm.StatusEnum = order.Status;
			return vm;
		}

		// 產生一筆訂單 AA20230927001
		public string GenerateOrderNumber()
		{
			// 生成隨機的英文字母，前兩碼
			string orderPrefix = GenerateRandomLetters(2);

			// 取得今天日期，後面8碼
			string dateSuffix = GenerateDateSuffix();

			// 取得下一個訂單ID
			int nextOrderId = GetNextOrderId();

			// 生成訂單號碼
			string orderNumber = $"{orderPrefix}{dateSuffix}{nextOrderId:D3}";

			return orderNumber;
		}

		public void UpdateStatus(string orderNumber, OrderStatusEnum status)
		{
			_orderRepository.UpdateStatus(orderNumber, status.Int());
		}

		private string GenerateRandomLetters(int length)
		{
			Random random = new Random();
			const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			return new string(Enumerable.Repeat(letters, length)
				.Select(s => s[random.Next(s.Length)])
				.ToArray());
		}

		private string GenerateDateSuffix()
		{
			DateTime today = DateTime.Today;
			string dateSuffix = today.ToString("yyyyMMdd");
			return dateSuffix;
		}

		private int GetNextOrderId()
		{
			int nextOrderId = 1;

			// 使用LINQ查詢獲取order表中最新一筆ID，並取得下一個ID
			var maxOrderId = _orderRepository.GetLatestId();
			if (maxOrderId.HasValue)
			{
				nextOrderId = maxOrderId.Value + 1;
			}

			return nextOrderId;
		}
	}
}