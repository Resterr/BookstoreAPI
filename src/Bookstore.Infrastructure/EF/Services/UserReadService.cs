using Bookstore.Application.Services;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.EF.Services;
internal sealed class UserReadService : IUserReadService
{
	private readonly AppDbContext _dbContext;

	public UserReadService(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}
	public Task<bool> ExistsByEmailAsync(string email)
	{
		return _dbContext.Users.AnyAsync(x => x.Email == email);
	}

	public Task<bool> ExistsByUserNameAsync(string userName)
	{
		return _dbContext.Users.AnyAsync(x => x.UserName == userName);
	}
}
