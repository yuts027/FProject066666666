using FProjectCamping.Models.EFModels;
using FProjectCamping.Models.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FProjectCamping.Models.ViewModels.Members
{
    public static class RegisterExts
    {
        public static Member ToEFModel(this RegisterVm vm)
        {
            var salt = HashUtility.GetSalt();
            var hashPassword=HashUtility.ToSHA256(vm.Password,salt);
            var confirmCode = Guid.NewGuid().ToString("N");

            return new Member
            {
                Id = vm.Id,
                Account = vm.Account,
                Password = hashPassword,
                Name = vm.Name,
                Email = vm.Email,
                PhoneNum = vm.PhoneNum,
                Birthday = vm.Birthday,
                Photo = null,
                Enabled = false,
                CreatedTime =DateTime.Now,
                IsConfirmed =false,
                ConfirmCode= confirmCode
            };
        }

    }
}