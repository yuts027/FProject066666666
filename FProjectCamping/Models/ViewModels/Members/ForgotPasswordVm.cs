using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace FProjectCamping.Models.ViewModels.Members
{
    public class ForgotPasswordVm
	{
		[Display(Name = "帳號")]
		[Required(ErrorMessage ="{0} 必填")]
		[StringLength(50)]
		public string Account { get; set; }

		[Display(Name = "Email")]
		[Required(ErrorMessage = "{0} 必填")]
		[StringLength(256)]
		public string Email { get; set; }

	}
}