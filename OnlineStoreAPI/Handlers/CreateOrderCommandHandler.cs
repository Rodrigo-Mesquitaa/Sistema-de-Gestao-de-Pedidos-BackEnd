using MediatR;
using OnlineStoreAPI.Models;
using OnlineStoreAPI.Services;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
{
    private readonly OrderService _orderService;

    public CreateOrderCommandHandler(OrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        await _orderService.AddOrderAsync(request.Order);
        return request.Order;
    }
}