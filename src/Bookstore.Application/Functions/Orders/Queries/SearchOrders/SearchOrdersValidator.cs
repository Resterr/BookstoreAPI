using FluentValidation;

namespace Bookstore.Application.Functions.Orders.Queries.SearchOrders;
internal class SearchOrdersValidator : AbstractValidator<SearchOrders>
{
	public SearchOrdersValidator()
	{
		RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
		RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1).LessThanOrEqualTo(100);
	}
}
