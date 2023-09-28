using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace FProjectCamping.Models.ViewModels.Carts
{
	public class CartItemsVm
	{
		/// <summary>
		/// 購物車明細ID
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// 房號Key
		/// </summary>
		public int RoomId { get; set; }

		/// <summary>
		/// 房型Key
		/// </summary>
		public string RoomTypeId { get; set; }

		/// <summary>
		/// 房型
		/// </summary>
		[Display(Name = "房型")]
		public string RoomName { get; set; }

		/// <summary>
		/// 房號
		/// </summary>
		[Display(Name = "房號")]
		public string RoomNum { get; set; }

		/// <summary>
		/// 入住日
		/// </summary>
		[Display(Name = "入住日")]
		[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
		public DateTime CheckInDate { get; set; }

		/// <summary>
		/// 退房日
		/// </summary>
		[Display(Name = "退房日")]
		[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
		public DateTime CheckOutDate { get; set; }

		/// <summary>
		/// 夜數
		/// </summary>
		[Display(Name = "夜數")]
		public int Days { get; set; }

		/// <summary>
		/// 單價
		/// </summary>
		[Display(Name = "單價")]
		[DisplayFormat(DataFormatString = "{0:#,#}")]
		public int RoomPrice { get; set; }

		/// <summary>
		/// 是否加床
		/// </summary>
		[Display(Name = "是否加床")]
		public bool ExtraBed { get; set; }

		/// <summary>
		/// 加床金額,有加床才有值
		/// </summary>
		[Display(Name = "加床金額")]
		public int ExtraBedPrice { get; set; }

		/// <summary>
		/// 此房號加床的金額
		/// </summary>
		public int ExtraPrice { get; set; }

		/// <summary>
		/// 金額
		/// </summary>
		[Display(Name = "金額")]
		public int SubTotal { get; set; }
	}
}