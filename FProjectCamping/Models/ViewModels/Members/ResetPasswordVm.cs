using FProjectCamping.Models.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace FProjectCamping.Models.ViewModels.Members
{
    public class ResetPasswordVm
	{
		[Display(Name = "密碼")]
		[Required(ErrorMessage = DAHelper.Required)]
		[StringLength(70, ErrorMessage = DAHelper.StringLength)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "確認密碼")]
		[Required(ErrorMessage = DAHelper.Required)]
		[StringLength(70, ErrorMessage = DAHelper.StringLength)]
		[Compare(nameof(Password), ErrorMessage = DAHelper.Compare)]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }
	}
}