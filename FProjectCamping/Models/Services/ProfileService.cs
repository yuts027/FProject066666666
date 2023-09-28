using FProjectCamping.Models.EFModels;
using FProjectCamping.Models.ViewModels;
using FProjectCamping.Models.ViewModels.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FProjectCamping.Models.Services
{
	public class ProfileService
	{

		public void UpdateProfile(EditProfileVm vm, string account)
		{
			var db=new AppDbContext();
			var memberInDb = db.Members.FirstOrDefault(p => p.Id == vm.Id);

			if (memberInDb.Account != account)
			{
				throw new Exception("您沒有權限修改別人資料");

			}

			memberInDb.Name = vm.Name;
			memberInDb.Email = vm.Email;
			memberInDb.PhoneNum = vm.PhoneNum;

			db.SaveChanges();

		}

		public EditProfileVm GetMemberProfile(string currentUserAccount)
		{
			var db = new AppDbContext();

			var member = db.Members.FirstOrDefault(p => p.Account == currentUserAccount);
			if (member == null)
			{
				throw new Exception("帳號不存在");
			}


			var vm = member.ToEditProfileVm();
			return vm;
		}

	}
}