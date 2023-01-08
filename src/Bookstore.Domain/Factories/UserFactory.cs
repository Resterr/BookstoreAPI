using Bookstore.Domain.Entities;
using Bookstore.Domain.Factories.Abstractions;
using Bookstore.Domain.ValueObjects.UserValueObjects;

namespace Bookstore.Domain.Factories;
public class UserFactory : IUserFactory
{
	public User Create(UserId id, UserEmail email, UserPassword password, UserName userName, UserFullName fullName, UserCreationDate creationDate, Role role)
		=> new(id, email, password, userName, fullName, creationDate, role);
}

