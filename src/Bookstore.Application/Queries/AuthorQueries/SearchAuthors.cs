using Bookstore.Application.DTO;
using Bookstore.Shared.Abstractions.Queries;

namespace Bookstore.Application.Queries.AuthorQueries;
public class SearchAuthors : IQuery<IEnumerable<AuthorDto>>
{
	public string SearchPhrase { get; set; }
}
