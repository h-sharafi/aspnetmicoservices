using AutoMapper;
using Ordering.Application.Feactures.Orders.Queries.GetOrdersList;
using Ordering.Domain.Entities;

namespace Ordering.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrdersVm>().ReverseMap();
        }
    }
} 