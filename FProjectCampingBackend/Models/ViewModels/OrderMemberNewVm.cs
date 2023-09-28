using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FProjectCampingBackend.Models.ViewModels
{
	public class OrderMemberNewVm
	{
        public string OrderNumber { get; set; }
        public DateTime OrderTime { get; set; }
		public string Account { get; set; }
		public int TotalPrice { get; set; }
		public string Photo { get; set; }
	}
}