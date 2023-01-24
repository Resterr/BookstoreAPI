using Bookstore.Application.Functions.Authors.Queries.SearchAuthors;
using Bookstore.Application.Functions.Books.Queries.SearchBooks;
using Bookstore.Application.Functions.Orders.Queries.GetOrdersForCurrentUser;
using Bookstore.Application.Functions.Orders.Queries.SearchOrders;
using Bookstore.Application.Functions.Publishers.Queries.SearchPublishers;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Application.Validation;
internal static class Extensions
{
	public static IServiceCollection AddValidators(this IServiceCollection services)
	{
		services.AddFluentValidationAutoValidation();

		services.AddScoped<IValidator<SearchBooks>, SearchBooksValidator>();
		services.AddScoped<IValidator<SearchAuthors>, SearchAuthorsValidator>();
		services.AddScoped<IValidator<SearchPublishers>, SearchPublishersValidator>();
		services.AddScoped<IValidator<SearchOrders>, SearchOrdersValidator>();
		services.AddScoped<IValidator<GetOrdersForCurrentUser>, GetOrdersForCurrentUserValidator>();

		return services;
	}
}
