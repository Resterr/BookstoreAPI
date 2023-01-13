using Bookstore.Application.DTO;

namespace Bookstore.Application.Security;
public interface IAuthenticator
{
	JwtDto CreateToken(Guid userId, string role);
}
