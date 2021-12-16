using EventBus.Message.Events;
using MassTransit;
using AutoMapper;
using Ordering.Application.Feactures.Orders.Commands.CheckoutOrder;
using MediatR;

namespace Ordering.API.EventBusConsumer
{
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<BasketCheckoutEvent> _logger;

        public BasketCheckoutConsumer(IMapper mapper, ILogger<BasketCheckoutEvent> logger = null, IMediator mediator = null)
        {
            _mapper = mapper;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            var command = _mapper.Map<CheckoutOrderCommand>(context.Message);
            var result = await _mediator.Send(command);
         
            _logger.LogInformation("BasketCheckoutEvent consumed successfully. Created Order Id : {newOrderId}", result);
      
        }
    }
}