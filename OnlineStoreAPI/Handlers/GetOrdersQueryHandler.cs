using MediatR;
using OnlineStoreAPI.Models;
using OnlineStoreAPI.Queries;
using OnlineStoreAPI.Services;

namespace OnlineStoreAPI.Handlers
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<Order>>
    {
        private readonly OrderService _orderService;

        public GetOrdersQueryHandler(OrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IEnumerable<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderService.GetAllOrdersAsync();
        }
    }
}
