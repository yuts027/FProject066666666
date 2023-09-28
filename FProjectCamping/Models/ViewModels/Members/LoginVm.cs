using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace FProjectCamping.Models.ViewModels.Members
{
    public class LoginVm
	{
		[Display(Name = "帳號")]
		[Required]
		public string Account { get; set; }

		[Display(Name = "密碼")]
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "記住我")]
		public Boolean RememberMe { get; set; }
	}
}