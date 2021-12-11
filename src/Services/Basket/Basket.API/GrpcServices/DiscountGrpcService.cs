using Dicount.Grpc.Protos;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DoscountProtoService.DoscountProtoServiceClient _doscountProtoServiceClient;

        public DiscountGrpcService(DoscountProtoService.DoscountProtoServiceClient doscountProtoServiceClient)
        {
            this._doscountProtoServiceClient = doscountProtoServiceClient;
        }
        public async Task<CouponModel> GetDiscount(string productName)
        {
            var discountRequiest = new GetDiscountRequest { ProductName = productName };
            return await _doscountProtoServiceClient.GetDiscountAsync(discountRequiest);

        }
    }
}
