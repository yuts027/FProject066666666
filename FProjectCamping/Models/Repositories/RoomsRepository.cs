using FProjectCamping.Models.EFModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FProjectCamping.Models.Respositories
{
	public class RoomsRepository : BaseRepository<Room>
	{
		private AppDbContext _db = new AppDbContext();

		public List<Room> GetAll()
		{
			return _db.Rooms.ToList();
		}
	}
}