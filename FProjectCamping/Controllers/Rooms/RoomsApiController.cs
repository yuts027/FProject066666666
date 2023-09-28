using FProjectCamping.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;

namespace FProjectCamping.Controllers.Rooms
{
    public class RoomsApiController : ApiController
    {
		[HttpGet]
		public IHttpActionResult GetRoomType()
		{
			var db = new AppDbContext();

			var products = db.RoomTypes.Select(r => new
			{

				value = r.Id,
				name = r.Name

			});

			return Json(products);
		}

	}


}
