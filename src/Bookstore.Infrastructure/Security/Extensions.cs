using Bookstore.Application.Security;
using Bookstore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Infrastructure.Security;
internal static class Extensions
{
	public static IServiceCollection AddSecurity(this IServiceCollection services)
	{
		services
			.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>()
			.AddSingleton<IPasswordManager, PasswordManager>();

		return services;
	}
}
