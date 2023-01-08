using Bookstore.Application.Services;
using Bookstore.Domain.Repositories;
using Bookstore.Infrastructure.EF.Options;
using Bookstore.Infrastructure.EF.Repositories;
using Bookstore.Infrastructure.EF.Services;
using Bookstore.Shared.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Infrastructure.EF;
internal static class Extensions
{
	public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddHostedService<AppInitializer>();

		services.AddScoped<IUserReadService, UserReadService>();
		services.AddScoped<IRoleReadService, RoleReadService>();
		services.AddScoped<IUserContextService, UserContextService>();

		services.AddScoped<IBookRepository, PostgresBookRepository>();
		services.AddScoped<IAuthorRepository, PostgresAuthorRepository>();
		services.AddScoped<IPublisherRepository, PostgresPublisherRepository>();
		services.AddScoped<IUserRepository, PostgresUserRepository>();
		

		var options = configuration.GetOptions<PostgresOptions>("Postgres");
		services.AddDbContext<AppDbContext>(ctx => ctx.UseNpgsql(options.ConnectionString));

		return services;
	}
}
