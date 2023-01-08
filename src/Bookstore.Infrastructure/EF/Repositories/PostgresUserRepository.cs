using Bookstore.Domain.Entities;
using Bookstore.Domain.Repositories;
using Bookstore.Domain.ValueObjects.UserValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.EF.Repositories;
internal sealed class PostgresUserRepository : IUserRepository
{
	private readonly AppDbContext _dbContext;

	public PostgresUserRepository(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public Task<User> GetByIdAsync(UserId id)
	{
		return _dbContext.Users
			.Include(x => x.UserRole)
			.SingleOrDefaultAsync(x => x.Id == id);
	}

	public Task<User> GetByEmailAsync(UserEmail email)
	{
		return _dbContext.Users
			.Include(x => x.UserRole)
			.SingleOrDefaultAsync(x => x.Email == email);
	}

	public async Task AddAsync(User user)
	{
		await _dbContext.Users.AddAsync(user);
		await _dbContext.SaveChangesAsync();
	}

	public async Task UpdateAsync(User user)
	{
		_dbContext.Users.Update(user);
		await _dbContext.SaveChangesAsync();
	}
}
