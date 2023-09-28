using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FProjectCamping.Models.Infra;

namespace FProjectCamping.Models.ViewModels.Members
{
    public class RegisterVm
    {
        public int Id { get; set; }

        [Display(Name="帳號")]
        [Required]
        [StringLength(50)]
        public string Account { get; set; }

        [Display(Name = "密碼")]
        [Required]
        [StringLength(70)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "確認密碼")]
        [Required]
        [StringLength(70)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

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
        [Required]
        [DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = DAHelper.yyyyMMdd)]
		public DateTime Birthday { get; set; }

    }
}