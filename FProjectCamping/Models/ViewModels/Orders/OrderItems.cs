using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FProjectCamping.Models.ViewModels.Orders
{
	public class OrderItems
	{
		/// <summary>
		/// 房型
		/// </summary>
		[Display(Name = "房型")]
		public string RoomId { get; set; }

		/// <summary>
		/// 房號
		/// </summary>
		[Display(Name = "房號")]
		public string RoomName { get; set; }

		/// <summary>
		/// 入住日
		/// </summary>
		[Display(Name = "入住日")]
		[DisplayFormat(DataFormatString = "{yyyy/MM/dd}")]
		public DateTime CheckInDate { get; set; }

		/// <summary>
		/// 退房日
		/// </summary>
		[Display(Name = "退房日")]
		[DisplayFormat(DataFormatString = "{yyyy/MM/dd}")]
		public DateTime CheckOutDate { get; set; }

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
}