using AutoMapper;
using Dicount.Grpc.Protos;
using Discount.Grpc.Entities;

namespace Dicount.Grpc.Mapper
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
