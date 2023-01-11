﻿using Bookstore.Application.DTO;
using Bookstore.Shared.Abstractions.Queries;

namespace Bookstore.Application.Queries.OrderQueries;
public class GetOrdersForCurrentUser : IQuery<IPagedResult<OrderDto>>
{
	public int PageNumber { get; set; }
	public int PageSize { get; set; }
}
