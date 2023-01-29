using Bookstore.Application.DTO;
using Bookstore.Shared.Abstractions.Queries;
using Bookstore.Shared.Consts;

namespace Bookstore.Application.Functions.Orders.Queries.SearchOrders;
public class SearchOrders : IQuery<IPagedResult<OrderDto>>
{
	public int PageNumber { get; set; }
	public int PageSize { get; set; }
	public OrderStatus OrderStatus { get; set; }
}
