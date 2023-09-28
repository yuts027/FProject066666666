using FProjectCampingBackend.Models.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FProjectCampingBackend.Models.ViewModels
{
	public class RoomsVm
	{
		public int Id { get; set; }
		/// <summary>
		/// 訂單編號
		/// </summary>
		[Display(Name = "房型名稱")]
		public string RoomName { get; set; }

		/// <summary>
		/// 訂單日期
		/// </summary>
		[Display(Name = "平日價格")]
        [DisplayFormat(DataFormatString = "{0:#,#}")]
        public int WeekendPrice { get; set; }


		/// <summary>
		/// 付款方式
		/// </summary>
		[Display(Name = "假日價格")]
        [DisplayFormat(DataFormatString = "{0:#,#}")]
        public int WeekdayPrice { get; set; }

		/// <summary>
		/// 金額
		/// </summary>
		[Display(Name = "描述")]

		public string Description { get; set; }

		[Display(Name = "是否能預定")]

		public string Status { get; set; }

		[Display(Name = "庫存")]
		public int Stock { get; set; }

		[Display(Name = "房型照片")]
		public string Photo { get; set; }

        //public RoomType RoomType { get; set; }
        [Display(Name = "營區房型")]
        public string RoomTypeName { get; set; }


    }
}

