using Bookstore.Domain.Entities;
using Bookstore.Domain.Repositories;
using Bookstore.Domain.ValueObjects.PublisherValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.EF.Repositories;
internal sealed class PostgresPublisherRepository : IPublisherRepository
{
	private readonly AppDbContext _dbContext;

	public PostgresPublisherRepository(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public Task<Publisher> GetAsync(PublisherId id)
	{
		return _dbContext.Publishers.SingleOrDefaultAsync(x => x.Id == id);
	}

	public async Task AddAsync(Publisher publisher)
	{
		await _dbContext.Publishers.AddAsync(publisher);
		await _dbContext.SaveChangesAsync();
	}

	public async Task UpdateAsync(Publisher publisher)
	{
		_dbContext.Publishers.Update(publisher);
		await _dbContext.SaveChangesAsync();
	}

	public async Task DeleteAsync(Publisher publisher)
	{
		_dbContext.Publishers.Remove(publisher);
		await _dbContext.SaveChangesAsync();
	}
}
