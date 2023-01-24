using Bookstore.Application.DTO;
using Bookstore.Application.Functions.Orders.Queries.GetOrdersForCurrentUser;
using Bookstore.Application.Services;
using Bookstore.Shared.Abstractions.Queries;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.EF.Queries.Handlers.Orders;
internal sealed class GetOrdersForCurrentUserHandler : IQueryHandler<GetOrdersForCurrentUser, IPagedResult<OrderDto>>
{
	private readonly AppDbContext _dbContext;
	private readonly IUserContextService _userContext;

	public GetOrdersForCurrentUserHandler(AppDbContext dbContext, IUserContextService userContext)
	{
		_dbContext = dbContext;
		_userContext = userContext;
	}

	public async Task<IPagedResult<OrderDto>> HandleAsync(GetOrdersForCurrentUser query)
	{
		var userId = _userContext.GetUserId;

		var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Id.Value == userId);

		if (user == null)
		{
			throw new NotFoundException(this.GetNameOfObject(), userId.GetValueOrNull());
		}

		var dbQuery = _dbContext.Orders
			.Include(x => x.Books)
			.ThenInclude(x => x.Book)
			.Where(x => x.CreatedBy == user);

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
