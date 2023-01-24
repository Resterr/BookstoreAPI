using Bookstore.Application.DTO;
using Bookstore.Shared.Abstractions.Queries;

namespace Bookstore.Application.Functions.Orders.Queries.GetOrderById;
public class GetOrderById : IQuery<OrderDto>
{
	public Guid Id { get; set; }
}
