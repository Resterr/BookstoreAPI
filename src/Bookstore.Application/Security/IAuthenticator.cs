using Bookstore.Application.DTO;

namespace Bookstore.Application.Security;
public interface IAuthenticator
{
	JwtDto CreateToken(long userId, string role);
}
