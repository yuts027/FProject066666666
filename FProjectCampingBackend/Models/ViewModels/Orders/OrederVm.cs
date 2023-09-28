using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace FProjectCampingBackend.Models.ViewModels.Orders
{
	public class OrderVm
	{
		public int Id { get; set; }

		/// <summary>
		/// 訂單編號
		/// </summary>
		[Display(Name = "訂單編號")]
		public string OrderNumber { get; set; }

		/// <summary>
		/// 訂單日期
		/// </summary>
		[Display(Name = "訂單日期")]
		[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
		public DateTime OrderTime { get; set; }

		/// <summary>
		/// 付款方式
		/// </summary>
		[Display(Name = "付款方式")]
		public string PaymentType { get; set; }

		/// <summary>
		/// 金額
		/// </summary>
		[Display(Name = "金額")]
		[DisplayFormat(DataFormatString = "{0:#,#}")]
		public int Price { get; set; }

		/// <summary>
		/// 訂單狀態
		/// </summary>
		[Display(Name = "訂單狀態")]
		public string Status { get; set; }

		/// <summary>
		/// 會員姓名
		/// </summary>
		[Display(Name = "會員姓名")]
		public string Member { get; set; }

		/// <summary>
		/// 訂購人姓名
		/// </summary>
		[Display(Name = "訂購人姓名")]
		public string Name { get; set; }

		// <summary>
		/// 訂購人電子郵件
		/// </summary>
		[Display(Name = "訂購人電子郵件")]
		public string Email { get; set; }

		// <summary>
		/// 訂購人電話
		/// </summary>
		[Display(Name = "訂購人電話")]
		public string PhoneNum { get; set; }

		public List<OrderItemsVm> OrderItems { get; set; }
	}

}
public class OrderItemsVm
{
	/// <summary>
	/// 房型
	/// </summary>
	[Display(Name = "房型")]
	public string RoomType { get; set; }

	/// <summary>
	/// 房號
	/// </summary>
	[Display(Name = "房號")]
	public string RoomNum { get; set; }

	/// <summary>
	/// 入住日
	/// </summary>
	[Display(Name = "入住日")]
	public string CheckInDate { get; set; }

	/// <summary>
	/// 退房日
	/// </summary>
	[Display(Name = "退房日")]
	public string CheckOutDate { get; set; }

	/// <summary>
	/// 天數
	/// </summary>
	[Display(Name = "夜數")]
	public int Days { get; set; }

	/// <summary>
	/// 小計
	/// </summary>
	[Display(Name = "小計")]
	[DisplayFormat(DataFormatString = "{0:#,#}")]
	public int SubTotal { get; set; }
}