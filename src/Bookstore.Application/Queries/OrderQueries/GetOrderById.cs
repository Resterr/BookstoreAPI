using Bookstore.Application.DTO;
using Bookstore.Shared.Abstractions.Queries;

namespace Bookstore.Application.Queries.OrderQueries;
public class GetOrderById : IQuery<OrderDto>
{
	public Guid Id { get; set; }
}
