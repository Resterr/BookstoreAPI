using Bookstore.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Shared;
public static class Extensions
{
	public static IServiceCollection AddShared(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddIdGenerator(configuration);
		return services;
	}
}
