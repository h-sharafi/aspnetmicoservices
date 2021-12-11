using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistence;

namespace Ordering.Application.Feactures.Orders.Queries.GetOrdersList
{

    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrdersVm>>
    {
            private readonly IOrderRepository _orderRepository;
            private readonly IMapper _mapper;

        public GetOrdersListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            this._mapper = mapper;
        }

        public async Task<List<OrdersVm>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
          var orderList =   await _orderRepository.GetOrdersByUserName(request.UserName);
            return _mapper.Map<List<OrdersVm>>(orderList);
        }
    }
}