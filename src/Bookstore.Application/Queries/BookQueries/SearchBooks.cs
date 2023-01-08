using Bookstore.Application.DTO;
using Bookstore.Shared.Abstractions.Queries;

namespace Bookstore.Application.Queries.BookQueries;
public class SearchBooks : IQuery<IEnumerable<BookDto>>
{
	public string SearchPhrase { get; set; }
}
