using FProjectCamping.Models.EFModels;
using FProjectCamping.Models.Infra;
using FProjectCamping.Models.ViewModels;
using FProjectCamping.Models.ViewModels.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace FProjectCamping.Models.Services
{
	public interface ILoginService
	{
		void ValidLogin(LoginVm vm);
		(string ReturnUrl, HttpCookie Cookie) ProcessLogin(LoginVm vm);
	}

	public class LoginService : ILoginService
	{
		public void ValidLogin(LoginVm vm)
		{
			var db = new AppDbContext();
			var member = db.Members.FirstOrDefault(p => p.Account == vm.Account);

			if (member == null)
			{
				throw new Exception("帳號或密碼有誤");
			}

			if (member.IsConfirmed == false)
			{
				throw new Exception("您尚未開通會員資格，請先收確認信，並點選信里的連結，完成驗證，才能登入本網站");
			}
			if (member.Enabled == true)
			{
				throw new Exception("您的帳號已被停權");
			}

			var salt = HashUtility.GetSalt();
			var hashPassword = HashUtility.ToSHA256(vm.Password, salt);

			if (string.Compare(member.Password, hashPassword, true) != 0)
			{
				throw new Exception("帳號或密碼有誤");
			}
		}

		public (string ReturnUrl, HttpCookie Cookie) ProcessLogin(LoginVm vm)
		{
			var rememberMe = vm.RememberMe;
			var account = vm.Account;
			var roles = string.Empty;

			var ticket =
				new FormsAuthenticationTicket(
					1,
					account,
					DateTime.Now,
					DateTime.Now.AddDays(10),
					rememberMe,
					roles,
					"/"
				);

			//加密
			var value = FormsAuthentication.Encrypt(ticket);

			var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, value);

			var url = FormsAuthentication.GetRedirectUrl(account, true);

			return (url, cookie);
		}
	}
}