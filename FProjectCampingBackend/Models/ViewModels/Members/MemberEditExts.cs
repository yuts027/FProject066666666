using FProjectCampingBackend.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FProjectCampingBackend.Models.ViewModels.Members
{
	public static class MemberEditExts
	{
		public static MemberEditVm ToMemberEditVm(this Member member)
		{
			if (member == null)
			{
				return null;
			}

			return new MemberEditVm
			{
				Id = member.Id,
				Name = member.Name,
				Account = member.Account,
				Photo = member.Photo,
				Email = member.Email,
                Birthday = member.Birthday,
                PhoneNum = member.PhoneNum,
				CreatedTime = member.CreatedTime,
				Enabled = member.Enabled,
				IsConfirmed = member.IsConfirmed,
                ConfirmCode = member.ConfirmCode,
            };
		}
	}
}