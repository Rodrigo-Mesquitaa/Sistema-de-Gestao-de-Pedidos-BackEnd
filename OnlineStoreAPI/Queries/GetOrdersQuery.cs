using MediatR;
using OnlineStoreAPI.Models;

namespace OnlineStoreAPI.Queries
{
    public class GetOrdersQuery : IRequest<IEnumerable<Order>> { }
  
}
