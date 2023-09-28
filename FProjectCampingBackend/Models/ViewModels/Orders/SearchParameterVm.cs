using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FProjectCampingBackend.Models.ViewModels.Orders
{
	public class SearchParameterVm
	{
		public string OrderNumber { get; set; }
		public string Name { get; set; }

		public DateTime? FirstTime { get; set; }
		public DateTime? EndTime { get; set; }

		public int? Status { get; set; }
	}
}