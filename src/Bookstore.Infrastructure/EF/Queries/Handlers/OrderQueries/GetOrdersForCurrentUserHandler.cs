using Bookstore.Application.DTO;
using Bookstore.Application.Queries.OrderQueries;
using Bookstore.Application.Services;
using Bookstore.Shared.Abstractions.Queries;
using Bookstore.Shared.Exceptions;
using Bookstore.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.EF.Queries.Handlers.OrderQueries;
internal sealed class GetOrdersForCurrentUserHandler : IQueryHandler<GetOrdersForCurrentUser, IEnumerable<OrderDto>>
{
	private readonly AppDbContext _dbContext;
	private readonly IUserContextService _userContext;

	public GetOrdersForCurrentUserHandler(AppDbContext dbContext, IUserContextService userContext)
	{
		_dbContext = dbContext; _userContext = userContext;
		;
	}

	public async Task<IEnumerable<OrderDto>> HandleAsync(GetOrdersForCurrentUser query)
	{
		var userId = _userContext.GetUserId;

		var user =  await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == userId);

		if (user == null)
		{
			throw new NotFoundException(this.GetNameOfObject(), userId.GetValueOrNull());
		}

		var dbQuery = _dbContext.Orders
			.Include(x => x.Books)
			.ThenInclude(x => x.Book)
			.Where(x => x.CreatedBy == user)
			.AsQueryable();

		return await dbQuery
			.Select(x => x.AsDto())
			.AsNoTracking()
			.ToListAsync();
	}
}
