using FProjectCampingBackend.Models.EFModels;
using FProjectCampingBackend.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FProjectCampingBackend.Models.Services
{
	public class OrderService
	{
		public Order ConvertToOrder(OrderMemberNewVm orderMember)
		{
			if (orderMember == null)
			{
				return null;
			}

			return new Order
			{
				OrderNumber = orderMember.OrderNumber,
				OrderTime = orderMember.OrderTime,
				TotalPrice = orderMember.TotalPrice,
				Member = new Member
				{
					Account = orderMember.Account,
					Photo = orderMember.Photo
				}
			};
		}
		public SelectList GetStatusDropdownList()
		{
			var items = new List<SelectListItem>
		{
			new SelectListItem { Value = "", Text = "請選擇" },
			new SelectListItem { Value = "1", Text = "尚未付款" },
			new SelectListItem { Value = "2", Text = "付款完成" },
			new SelectListItem { Value = "3", Text = "付款失敗" },
			new SelectListItem { Value = "4", Text = "取消訂單" },
			new SelectListItem { Value = "5", Text = "完成訂單" }
		};
			return new SelectList(items, "Value", "Text");
		}
	}
}