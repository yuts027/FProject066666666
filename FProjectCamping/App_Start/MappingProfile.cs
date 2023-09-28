using AutoMapper;
using FProjectCamping.Models.EFModels;
using FProjectCamping.Models.ViewModels.Carts;
using FProjectCamping.Models.ViewModels.Members;
using FProjectCamping.Models.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FProjectCamping.App_Start
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			// 可以二個方向都寫, 但也可以直接用 ReverseMap() 來反轉,表示二個方向都要做
			CreateMap<Cart, CartVm>().ReverseMap();
			CreateMap<CartItem, CartItemsVm>().ReverseMap();
			CreateMap<PayOrderVm, Order>().ReverseMap();
			CreateMap<MyOrder, Order>().ReverseMap();
			CreateMap<OrderItems, OrderItem>().ReverseMap();
		}
	}
}