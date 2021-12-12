using AutoMapper;
using Ordering.Application.Feactures.Orders.Commands.CheckoutOrder;
using Ordering.Application.Feactures.Orders.Commands.UpdateOrder;
using Ordering.Application.Feactures.Orders.Queries.GetOrdersList;
using Ordering.Domain.Entities;

namespace Ordering.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrdersVm>().ReverseMap();
            CreateMap<CheckoutOrderCommand, Order>().ReverseMap();
            CreateMap<UpdateOrderCommand, Order>().ReverseMap();
       
       
        }
    }
}