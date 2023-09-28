using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FProjectCamping.Models.ViewModels.Carts
{
    public class CartItemRequestModel
	{
		public int roomId { get; set; }
		public int cartId { get; set; }
		public DateTime checkInDate { get; set; }
		public DateTime checkOutDate { get; set; }
		public bool extraBed { get; set; }
		public int extraBedPrice { get; set; }
		public int days { get; set; }

		public int subtotal { get; set; }




	}

}