using Bookstore.Application.Validation.Queries;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Application.Validation;
internal static class Extensions
{
	public static IServiceCollection AddValidators(this IServiceCollection services)
	{
		services.AddFluentValidationAutoValidation();

		services.AddQueriesValidators();

		return services;
	}
}
