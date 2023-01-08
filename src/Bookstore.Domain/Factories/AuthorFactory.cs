using Bookstore.Domain.Entities;
using Bookstore.Domain.ValueObjects.AuthorValueObjects;

namespace Bookstore.Domain.Factories;
public class AuthorFactory : IAuthorFactory
{
	public Author Create(AuthorId id, AuthorFullName name)
	=> new(id, name);
}
