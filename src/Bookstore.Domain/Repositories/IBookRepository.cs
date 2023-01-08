using Bookstore.Domain.Entities;
using Bookstore.Domain.ValueObjects.BookValueObjects;

namespace Bookstore.Domain.Repositories;
public interface IBookRepository
{
	Task<Book> GetAsync(BookId id);
	Task AddAsync(Book book);
	Task UpdateAsync(Book book);
	Task DeleteAsync(Book book);
}
