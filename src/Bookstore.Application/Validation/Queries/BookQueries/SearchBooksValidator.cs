using Bookstore.Application.Queries.BookQueries;
using FluentValidation;

namespace Bookstore.Application.Validation.Queries.BookQueries;
internal class SearchBooksValidator : AbstractValidator<SearchBooks>
{
	public SearchBooksValidator()
	{
		RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
		RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1).LessThanOrEqualTo(100);
	}
}

