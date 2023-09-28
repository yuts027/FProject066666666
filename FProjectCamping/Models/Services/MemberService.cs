using FProjectCamping.Models.EFModels;
using FProjectCamping.Models.Infra;
using FProjectCamping.Models.ViewModels;
using FProjectCamping.Models.ViewModels.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace FProjectCamping.Models.Services
{
	public class MemberService
	{
		public void RegisterMember(RegisterVm vm, string urlTemeplate)
		{
			var db = new AppDbContext();
			var errors = new List<string>();


			var memberInDb = db.Members.FirstOrDefault(p => p.Account == vm.Account);
			//判斷密碼
			bool isPasswordValid = new PasswordHelper().IsPasswordValid(vm.Password);

			if (memberInDb != null)
			{
				errors.Add("帳號已存在");
			}

			if (!IsAccountValid(vm.Account))
			{
				errors.Add("帳號不能是中文");
			}

			if (!isPasswordValid)
			{
				errors.Add("密碼不符合要求");
			}

			if (errors.Count > 0)
			{
				throw new Exception(string.Join("; ", errors));
			}

			var member = vm.ToEFModel();


			db.Members.Add(member);
			db.SaveChanges();


			var url = string.Format(urlTemeplate, member.Id, member.ConfirmCode);

			new EmailHelper().SendConfirmRegisterEmail(url, member.Name, member.Email);
		}


		//帳號限制中文字

		public bool IsAccountValid(string account)
		{
			string pattern = @"^[^\u4e00-\u9fa5]+$";
			return Regex.IsMatch(account, pattern);
		}
	}
}