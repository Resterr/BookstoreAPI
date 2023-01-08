using System.Reflection;
using Bookstore.Shared.Abstractions.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Shared.Queries;
public static class Extensions
{
	public static IServiceCollection AddQueries(this IServiceCollection services)
	{
		var assembly = Assembly.GetCallingAssembly();

		services.AddSingleton<IQueryDispatcher, InMemoryQueryDispatcher>();
		services.Scan(s => s.FromAssemblies(assembly)
			.AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
			.AsImplementedInterfaces()
			.WithScopedLifetime());

		return services;
	}
}
