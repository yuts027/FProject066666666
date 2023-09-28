using FProjectCamping.Models.EFModels;
using FProjectCamping.Models.ViewModels.Carts;
using Microsoft.Ajax.Utilities;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace FProjectCamping.Models.Respositories
{
	public class CartRepository : BaseRepository<Cart>
	{
		private AppDbContext _db = new AppDbContext();

		/// <summary>
		/// 透過會員Key取得購物車資訊
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public Cart GetByMember(string account)
		{
			return _db.Carts.FirstOrDefault(x => x.MemberAccount == account);
		}

		public int AddNew(Cart cart)
		{
			_db.Carts.Add(cart);
			_db.SaveChanges();
			return cart.Id;
		}

		/// <summary>
		/// 清空指定 User 購物車
		/// </summary>
		/// <param name="account"></param>
		public void EmptyCart(string account)
		{
			var cart = _db.Carts.FirstOrDefault(c => c.MemberAccount == account);
			if (cart == null) return;

			_db.Carts.Remove(cart);
			_db.SaveChanges();
		}

		/// <summary>
		/// 更新總金額
		/// </summary>
		/// <param name="id"></param>
		/// <param name="totalPrice"></param>
		public void UpdateTotalPrice(int id, int totalPrice)
		{
			var cart = _db.Carts.FirstOrDefault(c => c.Id == id);
			if (cart == null) return;

			cart.TotalPrice = totalPrice;
			_db.SaveChanges();
		}
	}
}