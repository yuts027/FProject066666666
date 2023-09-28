using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace FProjectCamping.Models.ViewModels.Members
{
    public class EditPasswordVm
	{
		[Display(Name = "原始密碼")]
		[Required]
		[StringLength(70)]
		[DataType(DataType.Password)]
		public string OrgiginalPassword { get; set; }

		[Display(Name = "新密碼")]
		[Required]
		[StringLength(70)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "確認密碼")]
		[Required]
		[StringLength(70)]
		[Compare(nameof(Password))]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }
	}
}