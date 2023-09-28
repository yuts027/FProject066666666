using FProjectCamping.Models.EFModels;
using FProjectCamping.Models.ViewModels.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FProjectCamping.Controllers
{
    public class NewCartsController : ApiController
    {
        [HttpPost]

        public IHttpActionResult GetCartVm([FromBody] RenameVm vm)
        {
            //RenameVm vm = Newtonsoft.Json.JsonConvert.DeserializeObject<RenameVm>(json);
            var db = new AppDbContext();
            var cartItems = new CartItem
            {
				CartId = 9,
				RoomId = 6,
				CheckInDate = vm.StartDateTime,
				CheckOutDate = vm.EndDateTime,
				ExtraBed = true,
				ExtraBedPrice = 100,
				Days = 1,
				SubTotal = 100
			};


			db.CartItems.Add(cartItems);
			db.SaveChanges();
			return Ok();
		}
    }
}
