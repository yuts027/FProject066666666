
using FProjectCamping.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FProjectCamping.Models.Respositories
{
	public class RoomTypesRepository : BaseRepository<RoomType>
	{
		private AppDbContext _db = new AppDbContext();

		public List<RoomType> GetAll()
		{
			return _db.RoomTypes.ToList();
		}
	}
}