using FProjectCamping.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FProjectCamping.Models.Respositories
{
	public class PaymentTypeRepository : BaseRepository<PaymentType>
	{
		private AppDbContext _db = new AppDbContext();

		public PaymentType GetTypeName(int typeCode)
		{
			return _db.PaymentTypes.FirstOrDefault(x => x.Id == typeCode && x.Enable);
		}

		public List<PaymentType> GetTypeName()
		{
			return _db.PaymentTypes.Where(x => x.Enable).ToList();
		}
	}
}