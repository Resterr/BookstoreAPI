﻿using System.Security.Claims;
using Bookstore.Application.Services;
using Microsoft.AspNetCore.Http;

namespace Bookstore.Infrastructure.EF.Services;
internal sealed class UserContextService : IUserContextService
{
	private readonly IHttpContextAccessor _httpContextAccessor;

	public UserContextService(IHttpContextAccessor httpContextAccessor)
	{
		_httpContextAccessor = httpContextAccessor;
	}

	public ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;

	public Guid? GetUserId => User is null ? null : Guid.Parse(User.Identity.Name);
}
