using Bookstore.Application.DTO;

namespace Bookstore.Application.Security;
public interface ITokenStorage
{
    void Set(JwtDto jwt);
    JwtDto Get();
}
