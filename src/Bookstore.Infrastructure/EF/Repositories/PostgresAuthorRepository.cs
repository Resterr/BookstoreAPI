using Bookstore.Domain.Entities;
using Bookstore.Domain.Repositories;
using Bookstore.Domain.ValueObjects.AuthorValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.EF.Repositories;
internal sealed class PostgresAuthorRepository : IAuthorRepository
{
	private readonly AppDbContext _dbContext;

	public PostgresAuthorRepository(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public Task<Author> GetAsync(AuthorId id)
	{
		return _dbContext.Authors.SingleOrDefaultAsync(x => x.Id == id);
	}

	public async Task AddAsync(Author author)
	{
		await _dbContext.Authors.AddAsync(author);
		await _dbContext.SaveChangesAsync();
	}

	public async Task UpdateAsync(Author author)
	{
		_dbContext.Authors.Update(author);
		await _dbContext.SaveChangesAsync();
	}

	public async Task DeleteAsync(Author author)
	{
		_dbContext.Authors.Remove(author);
		await _dbContext.SaveChangesAsync();
	}
}
