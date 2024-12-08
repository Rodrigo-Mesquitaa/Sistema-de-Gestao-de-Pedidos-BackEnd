using MediatR;
using OnlineStoreAPI.Models;

public class CreateOrderCommand : IRequest<Order>
{
    public Order Order { get; set; }
}