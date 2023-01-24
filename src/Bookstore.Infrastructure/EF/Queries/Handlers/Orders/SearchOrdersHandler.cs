using Bookstore.Application.DTO;
using Bookstore.Application.Functions.Orders.Queries.SearchOrders;
using Bookstore.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.EF.Queries.Handlers.Orders;
internal sealed class SearchOrdersHandler : IQueryHandler<SearchOrders, IPagedResult<OrderDto>>
{
	private readonly AppDbContext _dbContext;

	public SearchOrdersHandler(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<IPagedResult<OrderDto>> HandleAsync(SearchOrders query)
	{
		var dbQuery = _dbContext.Orders
			.Include(x => x.Books)
			.ThenInclude(x => x.Book)
			.Where(x => x.OrderStatus == query.OrderStatus);

		var resultQuery = await dbQuery
			.Skip(query.PageSize * (query.PageNumber - 1))
			.Take(query.PageSize)
			.Select(x => x.AsDto())
			.AsNoTracking()
			.ToListAsync();

		var totalItemsCount = dbQuery.Count();

		var result = new PagedResult<OrderDto>(resultQuery, totalItemsCount, query.PageSize, query.PageNumber);

		return result;
	}
}
