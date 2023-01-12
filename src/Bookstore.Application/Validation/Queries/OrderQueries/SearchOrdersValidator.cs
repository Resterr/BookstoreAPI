using Bookstore.Application.Queries.OrderQueries;
using FluentValidation;

namespace Bookstore.Application.Validation.Queries.OrderQueries;
internal class SearchOrdersValidator : AbstractValidator<SearchOrders>
{
	public SearchOrdersValidator()
	{
		RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
		RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1).LessThanOrEqualTo(100);
	}
}
