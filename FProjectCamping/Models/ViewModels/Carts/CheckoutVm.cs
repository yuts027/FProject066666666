using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FProjectCamping.Models.ViewModels.Carts
{
	public class CheckoutVm
	{
		[Display(Name = "訂購人姓名")]
		[Required]
		[MaxLength(30)]
		public string Name { get; set; }

		[Display(Name = "手機")]
		[Required]
		[MaxLength(10)]
		public string PhoneNum { get; set; }

		[Display(Name = "電子郵件")]
		[Required]
		public string Email { get; set; }

		[Display(Name = "支付方式")]
		[Required]
		public string PaymnetType { get; set; }

		[Display(Name = "優惠卷")]
		public string Coupon { get; set; }
	}
}