using Bookstore.Application.DTO;
using Bookstore.Shared.Abstractions.Queries;

namespace Bookstore.Application.Queries.OrderQueries;
public class GetOrdersForCurrentUser : IQuery<IEnumerable<OrderDto>>
{
}
