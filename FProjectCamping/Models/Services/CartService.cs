using FProjectCamping.Models.EFModels;
using FProjectCamping.Models.Respositories;
using FProjectCamping.Models.ViewModels.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using static FProjectCamping.MvcApplication;

namespace FProjectCamping.Models.Services
{
	public class CartService
	{
		public CartVm Get(string account)
		{
			var vm = new CartVm();
			var cartRepo = new CartRepository();
			var cartItemRepo = new CartItemsRepository();

			var cart = cartRepo.GetByMember(account);

			var cartItem = cartItemRepo.Get(cart.Id);

			// 房型資料 TODO:也許後續改Join
			var roomTypes = new RoomTypesRepository().GetAll();
			var rooms = new RoomsRepository().GetAll();

			vm = AutoMapperHelper.MapperObj.Map<CartVm>(cart);
			vm.Items = AutoMapperHelper.MapperObj.Map<List<CartItemsVm>>(cartItem);

			foreach (var item in vm.Items)
			{
				var (roomName, roomTypeName, roomPrice, extraPrice) = GetRoomTypeName(roomTypes, rooms, item.RoomId);
				item.RoomName = roomTypeName;
				item.RoomNum = roomName;
				item.RoomPrice = roomPrice;
				item.ExtraPrice = extraPrice;
			}

			return vm;
		}

		public AddToCartResult AddToCart(string buyer, CartItemsVm vm)
		{
			AddToCartResult result = new AddToCartResult();

			// 取得目前購物車主檔,若沒有就立即新增一筆並傳回
			CartVm cart = GetOrCreateCart(buyer);

			// 檢查是否有加入重複的明細檔，有的話，阻擋加入
			if (cart != null && !this.IsRepeat(cart, vm))
			{
				var entity = AutoMapperHelper.MapperObj.Map<CartItem>(vm);
				entity.CartId = cart.Id;

				//加入購物車,若明細不存在就新增一筆
				new CartItemsRepository().AddCartItem(entity);
				result.Message = "加入購物車~";

				// 获取订单数量
				int orderCount = CalculateOrderCount(buyer);
				result.Count = orderCount; // 将订单数量设置到 AddToCartResult 对象中
			}
			else
			{
				result.Message = "不可新增重複的項目";
			}

			return result;
		}

		public int CalculateOrderCount(string buyer)
		{
			using (var dbContext = new AppDbContext())
			{
				int orderCount = dbContext.CartItems
					.Where(cartItem => cartItem.Cart.MemberAccount == buyer) 
					.Count();

				return orderCount;
			}
		}


		public class AddToCartResult
		{
			public string Message { get; set; }
			public int Count { get; set; }
		}

		/// <summary>
		/// 取得目前購物車主檔,若沒有就立即新增一筆並傳回
		/// </summary>
		/// <param name="buyer"></param>
		/// <returns></returns>
		public CartVm GetOrCreateCart(string buyer)
		{
			var cartRepo = new CartRepository();
			var cart = cartRepo.GetByMember(buyer);

			// 沒有購物車紀錄，立即新增一筆並傳回
			if (cart == null)
			{
				cart = new Cart { MemberAccount = buyer };
				var id = cartRepo.AddNew(cart);

				return new CartVm
				{
					Id = id,
					MemberAccount = cart.MemberAccount,
					Items = new List<CartItemsVm>()
				};
			}

			// 傳回目前購物車主檔/明細檔紀錄

			return new CartVm
			{
				Id = cart.Id,
				MemberAccount = cart.MemberAccount,
				TotalPrice = cart.TotalPrice,
				Items = AutoMapperHelper.MapperObj.Map<List<CartItemsVm>>(cart.CartItems),
			};
		}

		public void DeleteCartItem(int cartItemId)
		{
			new CartItemsRepository().Delete(cartItemId);
		}

		public int ProcessCheckout(string account, CartVm cart)
		{
			// 建立訂單主檔明細檔
			var id = new OrderService().CreateOrder(account, cart);

			// 清空購物車
			new CartRepository().EmptyCart(account);

			return id;
		}

		/// <summary>
		/// 更新 CartItems 與 TotalPrice
		/// </summary>
		/// <param name="vm"></param>
		public void Update(CartVm vm)
		{
			new CartItemsRepository().UpdateExtraBed(vm);
			new CartRepository().UpdateTotalPrice(vm.Id, vm.TotalPrice);
		}

		/// <summary>
		/// 比較欲新增的明細檔是否重複
		/// </summary>
		/// <param name="cartVm"></param>
		/// <param name="vm"></param>
		/// <returns></returns>
		private bool IsRepeat(CartVm cartVm, CartItemsVm vm)
		{
			// 檢查邏輯: 只要涵蓋到入住日與退房日 都被視為重複
			DateTime vmCheckInDate = Convert.ToDateTime(vm.CheckInDate).Date;
			DateTime vmCheckOutDate = Convert.ToDateTime(vm.CheckOutDate).Date;

			return cartVm.Items.Any(item =>
			{
				DateTime itemCheckInDate = Convert.ToDateTime(item.CheckInDate).Date;
				DateTime itemCheckOutDate = Convert.ToDateTime(item.CheckOutDate).Date;

				return item.RoomId == vm.RoomId &&
					   itemCheckInDate <= vmCheckOutDate &&
					   itemCheckOutDate >= vmCheckInDate;
			});
		}

		private (string roomName, string roomTypeName, int roomPrice, int extraPrice) GetRoomTypeName(List<RoomType> roomTypes, List<Room> rooms, int roomId)
		{
			var room = rooms.FirstOrDefault(x => x.Id == roomId);

			if (room == null) throw new Exception($"未設定 RoomId : {roomId} 的對應資料");

			// TODO 取金額要依假日調整
			return (room.RoomName,
					roomTypes.FirstOrDefault(x => x.Id == room.RoomTypeId).Name,
					room.WeekdayPrice,
					Convert.ToInt32(roomTypes.FirstOrDefault(x => x.Id == room.RoomTypeId).ExtraBedPrice));
		}
	}
}