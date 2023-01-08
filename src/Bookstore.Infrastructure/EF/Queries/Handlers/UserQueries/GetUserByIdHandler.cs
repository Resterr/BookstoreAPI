using Bookstore.Application.DTO;
using Bookstore.Application.Queries.UserQueries;
using Bookstore.Domain.ValueObjects.UserValueObjects;
using Bookstore.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.EF.Queries.Handlers.UserQueries;
internal sealed class GetUserByIdHandler : IQueryHandler<GetUserById, UserDto>
{
	private readonly AppDbContext _dbContext;

	public GetUserByIdHandler(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<UserDto> HandleAsync(GetUserById query)
	{
		var userId = new UserId(query.Id);
		var user = await _dbContext.Users
			.Include(x => x.UserRole)
			.AsNoTracking()
			.SingleOrDefaultAsync(x => x.Id == userId);

		return user?.AsDto();
	}
}
