using FProjectCamping.Models.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FProjectCamping.Models.Repositories
{
    public class MemberRepository
    {
        private readonly AppDbContext _db;

        public MemberRepository(AppDbContext dbContext)
        {
            _db = dbContext;
        }

        public Member GetUnconfirmedMember(int memberId, string confirmCode)
        {
            return _db.Members.FirstOrDefault(p => p.Id == memberId && p.ConfirmCode == confirmCode && p.IsConfirmed == false);
        }

        public void ConfirmMember(Member member)
        {
            member.IsConfirmed = true;
            member.ConfirmCode = null;
            _db.SaveChanges();
        }
		public Member GetMemberByAccount(string account)
		{
			return _db.Members.FirstOrDefault(p => p.Account == account);
		}
	}
}