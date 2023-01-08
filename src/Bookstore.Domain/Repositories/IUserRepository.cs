using Bookstore.Domain.Entities;
using Bookstore.Domain.ValueObjects.UserValueObjects;

namespace Bookstore.Domain.Repositories;
public interface IUserRepository
{
	Task<User> GetByIdAsync(UserId id);
	Task<User> GetByEmailAsync(UserEmail email);
	Task AddAsync(User user);
	Task UpdateAsync(User user);
}
