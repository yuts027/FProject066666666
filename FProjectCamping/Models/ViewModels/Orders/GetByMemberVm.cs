using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace FProjectCamping.Models.ViewModels.Orders
{
	public class GetByMemberVm
	{
		public int DisplayNumber { get; set; }

		/// <summary>
		/// 訂單編號
		/// </summary>
		[Display(Name = "訂單編號")]
		public string OrderNumber { get; set; }

		/// <summary>
		/// 訂單日期
		/// </summary>
		[Display(Name = "訂單日期")]
		public string OrderTime { get; set; }

		/// <summary>
		/// 付款方式
		/// </summary>
		[Display(Name = "付款方式")]
		public string PaymentType { get; set; }

		/// <summary>
		/// 金額
		/// </summary>
		[Display(Name = "金額")]
		public int Price { get; set; }

		/// <summary>
		/// 訂單狀態
		/// </summary>
		[Display(Name = "訂單狀態")]
		public string Status { get; set; }

		public List<OrderItems> OrderItems { get; set; }
	}
}