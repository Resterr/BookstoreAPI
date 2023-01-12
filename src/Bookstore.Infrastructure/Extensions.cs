using Bookstore.Infrastructure.Auth;
using Bookstore.Infrastructure.EF;
using Bookstore.Infrastructure.Exceptions;
using Bookstore.Infrastructure.Logging;
using Bookstore.Infrastructure.Security;
using Bookstore.Infrastructure.Time;
using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Abstractions.Services;
using Bookstore.Shared.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Infrastructure;
public static class Extensions
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddScoped<ExceptionMiddleware>();
		services.AddHttpContextAccessor();
		services.AddPostgres(configuration);
		services.AddSingleton<IClock, Clock>();
		services.AddQueries();
		services.AddSecurity();
		services.AddAuth(configuration);

		services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));

		return services;
	}

	public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
	{
		app.UseMiddleware<ExceptionMiddleware>();
		app.UseAuthentication();
		app.UseAuthorization();

		return app;
	}
}
