using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace FProjectCamping.Models.ViewModels.Members
{
    public class EditProfileVm
	{
		public int Id { get; set; }

		[Display(Name = "姓名")]
		[Required]
		[StringLength(30)]
		public string Name { get; set; }

		[Required]
		[StringLength(256)]
		[EmailAddress]
		public string Email { get; set; }

		[Display(Name = "手機")]
		[Required]
		[StringLength(10)]
		public string PhoneNum { get; set; }

		[Display(Name = "生日")]
		[DataType(DataType.Date)]
        [ReadOnly(true)] 
        public DateTime? Birthday { get; set; }
	}
}