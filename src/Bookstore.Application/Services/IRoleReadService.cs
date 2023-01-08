using Bookstore.Domain.Entities;

namespace Bookstore.Application.Services;
public interface IRoleReadService
{
	Task<Role> DefaultRole();
	Task<Role> AdminRole();
}
