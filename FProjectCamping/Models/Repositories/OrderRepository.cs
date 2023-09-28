using FProjectCamping.Models.EFModels;
using FProjectCamping.Models.ViewModels.Members;
using FProjectCamping.Models.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FProjectCamping.Models.Respositories
{
	public class OrderRepository
	{
		private AppDbContext _db = new AppDbContext();
		private static List<MyOrder> _orders = new List<MyOrder>();

		public List<Order> GetOrders(string account)
		{
			var memberInDb = _db.Members.FirstOrDefault(p => p.Account == account);
			var orders = _db.Orders.Where(x => x.MemberId == memberInDb.Id)
								.OrderByDescending(x => x.OrderTime)
								.ToList();
			return orders;
		}

		public Order GetOrders(int orderId)
		{
			return _db.Orders.FirstOrDefault(x => x.Id == orderId);
		}

		public int? GetLatestId()
		{
			return _db.Orders.Select(o => (int?)o.Id).Max();
		}

		public void UpdateStatus(string orderNumber, int status)
		{
			var order = _db.Orders.FirstOrDefault(x => x.OrderNumber == orderNumber);

			if (order != null)
			{
				order.Status = status;
				_db.SaveChanges();
			}
		}
	}
}