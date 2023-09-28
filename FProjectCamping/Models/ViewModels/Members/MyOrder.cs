
using FProjectCamping.Models.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace FProjectCamping.Models.ViewModels.Members
{
	public class MyOrder
	{
		public int Id { get; set; }

		[Display(Name = "訂單編號")]
		public string OrderNumber { get; set; }

		[Display(Name = "訂單日期")]
		[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
		public DateTime OrderTime { get; set; }

		[Display(Name = "訂單狀態")]
		public string Status { get; set; }

		[Display(Name = "付款方式")]
		public string PaymentType { get; set; }

		public int PaymentTypeId { get; set; }

		[Display(Name = "總金額")]
		[DisplayFormat(DataFormatString = "{0:#,#}")]
		public int TotalPrice { get; set; }

		public List<OrderItems> OrderItems { get; set; }

		public bool AllowCancel { get; set; } = false; // 商碞未送出之前, 可以取消訂單
		public bool AllowModify { get; set; } = false;
	}
}