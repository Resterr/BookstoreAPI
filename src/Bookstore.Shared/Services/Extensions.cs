using Bookstore.Shared.Abstractions.Services;
using Bookstore.Shared.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Shared.Services;
internal static class Extensions
{
	private const string OptionsSectionName = "IdGenerator";

	public static IServiceCollection AddIdGenerator(this IServiceCollection services, IConfiguration configuration)
	{
		services.Configure<GeneratorOptions>(configuration.GetRequiredSection(OptionsSectionName));
		services.AddSingleton<IIdGeneratorService, IdGeneratorService>();

		return services;
	}
}
