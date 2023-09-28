using FProjectCamping.Models.EFModels;
using FProjectCamping.Models.Infra;
using FProjectCamping.Models.Repositories;
using FProjectCamping.Models.ViewModels;
using FProjectCamping.Models.ViewModels.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FProjectCamping.Models.Services
{
	public class PasswordService
	{
		public void ProcessResentPassword(string account, string email, string urlTemeplate)
		{
			var db = new AppDbContext();
			var memberInDb = db.Members.FirstOrDefault(m => m.Account == account);

			if (memberInDb == null)
			{
				throw new Exception("帳號不存在");
			}
			if (string.Compare(email, memberInDb.Email, StringComparison.CurrentCultureIgnoreCase) != 0)
			{
				throw new Exception("您還沒有啟用本帳號,請先完成才能重設密碼");
			}
			if (memberInDb.IsConfirmed == false)
			{
				throw new Exception("帳號或 Email錯誤");
			}
			if (memberInDb.Enabled == true)
			{
				throw new Exception("您的帳號已被停權");
			}


			var confimCode = Guid.NewGuid().ToString();
			memberInDb.ConfirmCode = confimCode;
			db.SaveChanges();

			var url = string.Format(urlTemeplate, memberInDb.Id, confimCode);

			new EmailHelper().SenForgetPasswordEmail(url, memberInDb.Name, email);

		}


		public void ProcessResetPassword(int memberId, string confirmCode, ResetPasswordVm vm)
		{
			var db = new AppDbContext();

			var memberInDb = db.Members.FirstOrDefault(m => m.Id == memberId &&
														m.IsConfirmed == true &&
														m.ConfirmCode == confirmCode
														);
			
			if (memberInDb == null) return;
			bool isPasswordValid = new PasswordHelper().IsPasswordValid(vm.Password);
			if (!isPasswordValid)
			{
				throw new Exception("密碼不符合要求");
			}

			var salt = HashUtility.GetSalt();

			var hashedPassword = HashUtility.ToSHA256(vm.Password, salt);
			memberInDb.Password = hashedPassword;
			memberInDb.ConfirmCode = null;
			db.SaveChanges();
		}



		public void ChangePassword(EditPasswordVm vm, string account)
		{
			var db = new AppDbContext();
			var memberInDb = new MemberRepository(db).GetMemberByAccount(account);
			if (memberInDb == null)
			{
				throw new Exception("帳號不存在");
			}

			var salt = HashUtility.GetSalt();

			var hashedOriPassword = HashUtility.ToSHA256(vm.OrgiginalPassword, salt);
			if (string.Compare(memberInDb.Password, hashedOriPassword, true) != 0)
			{
				throw new Exception("原始密碼不正確");
			}

			bool isPasswordValid = new PasswordHelper().IsPasswordValid(vm.Password);

			if (!isPasswordValid)
			{
				throw new Exception("密碼不符合要求");
			}

			var hasedPassword = HashUtility.ToSHA256(vm.Password, salt);
			if (hashedOriPassword == hasedPassword)
			{
				throw new Exception("新密碼不可與原始密碼相同");
			}



			memberInDb.Password = hasedPassword;
			db.SaveChanges();

		}

	}
}