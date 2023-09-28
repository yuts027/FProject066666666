using FProjectCampingBackend.Models.EFModels;
using FProjectCampingBackend.Models.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FProjectCampingBackend.Models.Repostories
{
	public class OrderRepository
	{
		private AppDbContext db; // Your DbContext 類別

		public OrderRepository(AppDbContext dbContext)
		{
			db = dbContext;
		}

		public IQueryable<Order> GetOrders(SearchParameterVm vm)
		{
			IQueryable<Order> parameter = db.Orders;

			if (!string.IsNullOrEmpty(vm.OrderNumber))
			{
				parameter = parameter.Where(x => x.OrderNumber.Contains(vm.OrderNumber)); // todo 訂單編號
			}
			if (!string.IsNullOrEmpty(vm.Name))
			{
				parameter = parameter.Where(x => x.Name.Contains(vm.Name));
			}

			if (vm.FirstTime != null)
			{
				parameter = parameter.Where(x => x.OrderTime >= vm.FirstTime);
			}

			if (vm.EndTime != null)
			{
				DateTime endDatePlusOneDay = vm.EndTime.Value.AddDays(1);

				parameter = parameter.Where(x => x.OrderTime <= endDatePlusOneDay);
			}

			if (vm.Status != null)
			{
				parameter = parameter.Where(x => x.Status == vm.Status);
			}

			return parameter;
		}
	}
}