using FProjectCamping.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FProjectCamping.Models.ViewModels.Members
{
    public static class MemberExts
	{
		public static EditProfileVm ToEditProfileVm(this Member member)
		{
			return new EditProfileVm
			{
				Id = member.Id,
				Email = member.Email,
				Name = member.Name,
				PhoneNum = member.PhoneNum,
				Birthday = member.Birthday
			};
		}
	}
}