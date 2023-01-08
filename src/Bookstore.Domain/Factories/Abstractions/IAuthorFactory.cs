using Bookstore.Domain.Entities;
using Bookstore.Domain.ValueObjects.AuthorValueObjects;

namespace Bookstore.Domain.Factories;
public interface IAuthorFactory
{
	Author Create(AuthorId id, AuthorFullName name);
}
