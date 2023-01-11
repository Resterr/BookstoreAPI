using Bookstore.Application.DTO;
using Bookstore.Shared.Abstractions.Queries;
using Bookstore.Shared.Consts;

namespace Bookstore.Application.Queries.OrderQueries;
public class SearchOrders : IQuery<IEnumerable<OrderDto>>
{
	public OrderStatus OrderStatus { get; set; }
}
