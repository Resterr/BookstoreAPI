using Bookstore.Application.Security;
using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bookstore.Infrastructure.EF;

internal sealed class AppInitializer : IHostedService
{
	private readonly IServiceProvider _serviceProvider;
	private readonly IConfiguration _configuration;
	private readonly IPasswordManager _passwordManager;

	public AppInitializer(IServiceProvider serviceProvider, IConfiguration configuration, IPasswordManager passwordManager)
	{
		_serviceProvider = serviceProvider;
		_configuration = configuration;
		_passwordManager = passwordManager;
	}

	public async Task StartAsync(CancellationToken cancellationToken)
	{
		using var scope = _serviceProvider.CreateScope();
		var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
		await dbContext.Database.MigrateAsync(cancellationToken);

		if (await dbContext.Roles.AnyAsync(cancellationToken) == false)
		{
			var roles = new List<Role>
			{
				new Role(Guid.NewGuid(), "SuperAdmin"),
				new Role(Guid.NewGuid(), "Admin"),
				new Role(Guid.NewGuid(), "User"),
			};

			await dbContext.Roles.AddRangeAsync(roles, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken); ;
		}

		if (await dbContext.Users.AnyAsync(cancellationToken) == false)
		{
			var superAdminEmail = _configuration.GetSection("SuperAdminAccount").GetValue<string>("Email");
			var superAdminPassword = _configuration.GetSection("SuperAdminAccount").GetValue<string>("Password");
			var superAdminRole = await dbContext.Roles.SingleAsync(x => x.Name == "SuperAdmin", cancellationToken);
			var securedPassword = _passwordManager.Secure(superAdminPassword);

			var superAdmin = new User(Guid.NewGuid(), superAdminEmail, securedPassword, "superadmin", "superadmin", DateTime.UtcNow, superAdminRole);

			await dbContext.Users.AddAsync(superAdmin, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken); ;
		}
	}

	public Task StopAsync(CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}

