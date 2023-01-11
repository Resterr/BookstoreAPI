using Bookstore.Application.DTO;
using Bookstore.Shared.Abstractions.Queries;

namespace Bookstore.Application.Queries.AuthorQueries;
public class SearchAuthors : IQuery<IPagedResult<AuthorDto>>
{
	public int PageNumber { get; set; }
	public int PageSize { get; set; }
	public string SearchPhrase { get; set; }
}
