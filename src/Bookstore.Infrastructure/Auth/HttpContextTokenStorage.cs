using Bookstore.Application.DTO;
using Bookstore.Application.Security;
using Microsoft.AspNetCore.Http;

namespace Bookstore.Infrastructure.Auth;
internal sealed class HttpContextTokenStorage : ITokenStorage
{
    private const string _tokenKey = "jwt";
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpContextTokenStorage(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void Set(JwtDto jwt) => _httpContextAccessor.HttpContext?.Items.TryAdd(_tokenKey, jwt);

    public JwtDto Get()
    {
        if (_httpContextAccessor.HttpContext is null)
        {
            return null;
        }

        if (_httpContextAccessor.HttpContext.Items.TryGetValue(_tokenKey, out var jwt))
        {
            return jwt as JwtDto;
        }

        return null;
    }
}
