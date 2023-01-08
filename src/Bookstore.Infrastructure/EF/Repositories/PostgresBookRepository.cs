using Bookstore.Domain.Entities;
using Bookstore.Domain.Repositories;
using Bookstore.Domain.ValueObjects.BookValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.EF.Repositories;
internal sealed class PostgresBookRepository : IBookRepository
{
	private readonly AppDbContext _dbContext;

	public PostgresBookRepository(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public Task<Book> GetAsync(BookId id)
	{
		return _dbContext.Books
			.Include(x => x.Authors)
			.ThenInclude(x => x.Author)
			.SingleOrDefaultAsync(x => x.Id == id);
	}

	public async Task AddAsync(Book book)
	{
		await _dbContext.Books.AddAsync(book);
		await _dbContext.SaveChangesAsync();
	}

	public async Task UpdateAsync(Book book)
	{
		_dbContext.Books.Update(book);
		await _dbContext.SaveChangesAsync();
	}

	public async Task DeleteAsync(Book book)
	{
		_dbContext.Books.Remove(book);
		await _dbContext.SaveChangesAsync();
	}
}
