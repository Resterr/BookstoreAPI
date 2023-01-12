using Bookstore.Application.Queries.PublisherQueries;
using FluentValidation;

namespace Bookstore.Application.Validation.Queries.PublisherQueries;
internal class SearchPublishersValidator : AbstractValidator<SearchPublishers>
{
	public SearchPublishersValidator()
	{
		RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
		RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1).LessThanOrEqualTo(100);
	}
}
