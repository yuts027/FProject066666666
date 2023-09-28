using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using FProjectCampingBackend.Models.ViewModels;
using FProjectCampingBackend.Models.EFModels;
using Dapper;
using FProjectCampingBackend.Models.Services;
using FProjectCampingBackend.Models.ViewModels.Members;

namespace FProjectCampingBackend.Models.Repostories
{
    public class MemberRepository
    {
        private AppDbContext db;


        public MemberRepository(AppDbContext dbContext)
        {
            db = dbContext;
        }
        private readonly IDbConnection _dbConnection;

        public MemberRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }


        public IQueryable<Member> GetMembers(MemberSearchCriteria vm)
        {
            IQueryable<Member> query = db.Members;

            if (!string.IsNullOrEmpty(vm.Name))
            {
                query = query.Where(m => m.Name.Contains(vm.Name));
            }

            if (!string.IsNullOrEmpty(vm.Account))
            {
                query = query.Where(m => m.Account.Contains(vm.Account));
            }

            if (vm.FirstTime != null)
            {
                query = query.Where(m => m.CreatedTime >= vm.FirstTime);
            }

            if (vm.EndTime != null)
            {
                DateTime endDatePlusOneDay = vm.EndTime.Value.AddDays(1);

                query = query.Where(m => m.CreatedTime <= endDatePlusOneDay);
            }

            if (vm.Enabled != null)
            {
                query = query.Where(m => m.Enabled == vm.Enabled);
            }
            if (vm.IsConfirmed != null)
            {
                query = query.Where(m => m.IsConfirmed == vm.IsConfirmed);
            }


            return query;
        }

        public List<Member> GetLatestMembers()
        {
            string sql = "SELECT TOP 5 * FROM Members ORDER BY CreatedTime DESC";
            return _dbConnection.Query<Member>(sql).ToList();
        }


        public List<OrderMemberNewVm> GetNewOrders()
        {
            string sql = @"SELECT TOP 5 o.OrderNumber,o.OrderTime, m.Account,o.TotalPrice ,m.Photo
FROM Orders o 
INNER JOIN Members m ON o.MemberId = m.Id
ORDER BY o.OrderTime DESC";
            var orderMemberNewVms = _dbConnection.Query<OrderMemberNewVm>(sql).ToList();
            var orderService = new OrderService();
            var orders = orderMemberNewVms.Select(orderService.ConvertToOrder).ToList();


            return _dbConnection.Query<OrderMemberNewVm>(sql).ToList();
        }

    }
}