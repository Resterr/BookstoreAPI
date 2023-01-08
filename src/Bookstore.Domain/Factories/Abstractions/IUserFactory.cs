using Bookstore.Domain.Entities;
using Bookstore.Domain.ValueObjects.UserValueObjects;

namespace Bookstore.Domain.Factories.Abstractions;
public interface IUserFactory
{
	User Create(UserId id, UserEmail email, UserPassword password, UserName userName, UserFullName fullName, UserCreationDate creationDate, Role role);
}
