using Bookstore.Application.Validation;
using Bookstore.Domain.Factories;
using Bookstore.Domain.Factories.Abstractions;
using Bookstore.Shared.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Application;
public static class Extensions
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddCommands();
		services.AddValidators();

		services.AddSingleton<IBookFactory, BookFactory>();
		services.AddSingleton<IAuthorFactory, AuthorFactory>();
		services.AddSingleton<IPublisherFactory, PublisherFactory>();
		services.AddSingleton<IUserFactory, UserFactory>();
		services.AddSingleton<IOrderFactory, OrderFactory>();

		return services;
	}
}

