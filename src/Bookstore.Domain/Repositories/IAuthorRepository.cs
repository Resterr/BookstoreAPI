using Bookstore.Domain.Entities;
using Bookstore.Domain.ValueObjects.AuthorValueObjects;

namespace Bookstore.Domain.Repositories;
public interface IAuthorRepository
{
	Task<Author> GetAsync(AuthorId id);
	Task AddAsync(Author author);
	Task UpdateAsync(Author author);
	Task DeleteAsync(Author author);
}
