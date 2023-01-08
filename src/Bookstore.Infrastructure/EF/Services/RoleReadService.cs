using Bookstore.Application.Services;
using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.EF.Services;
internal sealed class RoleReadService : IRoleReadService
{
	private readonly AppDbContext _dbContext;

	public RoleReadService(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public Task<Role> DefaultRole()
	{
		return _dbContext.Roles
			.SingleOrDefaultAsync(x => x.Name == "User");
	}

	public Task<Role> AdminRole()
	{
		return _dbContext.Roles
			.SingleOrDefaultAsync(x => x.Name == "Admin");
	}
}
