using FProjectCamping.Models.ViewModels.Members;
using System.Collections.Generic;
using System.Linq;

namespace FProjectCamping.Models.ViewModels.Carts
{
	public class CartVm
	{
		public int Id { get; set; }

		public string MemberAccount { get; set; }

		public List<CartItemsVm> Items { get; set; }

		//public int TotalPrice => Items.Sum(x => x.SubTotal);

		public int TotalPrice { get; set; }

		public bool AllowCheckout { get; set; } // 至少要有一筆明細資料才可以結帳

		public EditProfileVm ContactProfile { get; set; }

		public string Coupon { get; set; }

		public int PaymentType { get; set; }

		public string Memo { get; set; }
	}
}