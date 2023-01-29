using FluentValidation;

namespace Bookstore.Application.Functions.Authors.Queries.SearchAuthors;
internal class SearchAuthorsValidator : AbstractValidator<SearchAuthors>
{
	public SearchAuthorsValidator()
	{
		RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
		RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1).LessThanOrEqualTo(100);
	}
}
