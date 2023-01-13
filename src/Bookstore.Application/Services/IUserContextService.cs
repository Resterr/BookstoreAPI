using System.Security.Claims;

namespace Bookstore.Application.Services;
public interface IUserContextService
{
	ClaimsPrincipal User { get; }
	Guid? GetUserId { get;}
}
