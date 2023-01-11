using Bookstore.Application.DTO;
using Bookstore.Application.Queries.OrderQueries;
using Bookstore.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.EF.Queries.Handlers.OrderQueries;
internal sealed class SearchOrdersHandler : IQueryHandler<SearchOrders, IEnumerable<OrderDto>>
{
	private readonly AppDbContext _dbContext;

	public SearchOrdersHandler(AppDbContext dbContext)
	{
		_dbContext = dbContext; 
	}

	public async Task<IEnumerable<OrderDto>> HandleAsync(SearchOrders query)
	{
		var dbQuery = _dbContext.Orders
			.Include(x => x.Books)
			.ThenInclude(x => x.Book)
			.Where(x => x.OrderStatus == query.OrderStatus)
			.AsQueryable();

		return await dbQuery
			.Select(x => x.AsDto())
			.AsNoTracking()
			.ToListAsync();
	}
}
