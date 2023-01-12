using Bookstore.Application.Queries.AuthorQueries;
using Bookstore.Application.Queries.BookQueries;
using Bookstore.Application.Queries.OrderQueries;
using Bookstore.Application.Queries.PublisherQueries;
using Bookstore.Application.Validation.Queries.AuthorQueries;
using Bookstore.Application.Validation.Queries.BookQueries;
using Bookstore.Application.Validation.Queries.OrderQueries;
using Bookstore.Application.Validation.Queries.PublisherQueries;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Application.Validation.Queries;
internal static class Extensions
{
	public static IServiceCollection AddQueriesValidators(this IServiceCollection services)
	{
		services.AddScoped<IValidator<SearchBooks>, SearchBooksValidator>();
		services.AddScoped<IValidator<SearchAuthors>, SearchAuthorsValidator>();
		services.AddScoped<IValidator<SearchPublishers>, SearchPublishersValidator>();
		services.AddScoped<IValidator<SearchOrders>, SearchOrdersValidator>();
		services.AddScoped<IValidator<GetOrdersForCurrentUser>, GetOrdersForCurrentUserValidator>();

		return services;
	}
}
