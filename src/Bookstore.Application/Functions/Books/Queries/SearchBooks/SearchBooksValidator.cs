using FluentValidation;

namespace Bookstore.Application.Functions.Books.Queries.SearchBooks;
internal class SearchBooksValidator : AbstractValidator<SearchBooks>
{
	public SearchBooksValidator()
	{
		RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
		RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1).LessThanOrEqualTo(100);
	}
}

