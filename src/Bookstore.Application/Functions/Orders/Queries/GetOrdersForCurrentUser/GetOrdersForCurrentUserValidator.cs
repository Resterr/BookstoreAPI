using FluentValidation;

namespace Bookstore.Application.Functions.Orders.Queries.GetOrdersForCurrentUser;
internal class GetOrdersForCurrentUserValidator : AbstractValidator<GetOrdersForCurrentUser>
{
	public GetOrdersForCurrentUserValidator()
	{
		RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
		RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1).LessThanOrEqualTo(100);
	}
}
