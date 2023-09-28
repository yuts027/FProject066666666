using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace FProjectCampingBackend.Models.ViewModels.Members
{
	public class MemberEditVm
	{
		[Display(Name = "編號")]
		public int Id { get; set; }

		[Display(Name = "帳號")]
		[Required]
		[StringLength(50)]
		public string Account { get; set; }

		[Display(Name = "姓名")]
		[Required]
		[StringLength(30)]
		public string Name { get; set; }

		[Required]
		[StringLength(256)]
		public string Email { get; set; }
        [Display(Name = "生日")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        // 创建一个只读属性，返回格式化后的生日字符串
        public string FormattedBirthday => Birthday.ToString("yyyy/MM/dd");


        [Display(Name = "電話")]
		[Required]
		[StringLength(10)]
		public string PhoneNum { get; set; }

		[Display(Name = "是否停權")]
		public bool Enabled { get; set; }

		[Display(Name = "照片")]
		[StringLength(1000)]
		public string Photo { get; set; }

		[Display(Name = "建立時間")]
		public DateTime CreatedTime { get; set; }

		[Display(Name = "是否驗證")]
		public bool? IsConfirmed { get; set; }
		[Display(Name = "是否驗證")]
		public string IsConfirmedDisplayName =>
	IsConfirmed.HasValue
		? (IsConfirmed.Value ? "是" : "否")
		: "未確認";
        [Display(Name = "驗證碼")]
        [StringLength(50)]
        public string ConfirmCode { get; set; }

    }
}