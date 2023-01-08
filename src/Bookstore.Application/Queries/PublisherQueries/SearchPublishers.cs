using Bookstore.Application.DTO;
using Bookstore.Shared.Abstractions.Queries;

namespace Bookstore.Application.Queries.PublisherQueries;
public class SearchPublishers : IQuery<IEnumerable<PublisherDto>>
{
	public string SearchPhrase { get; set; }
}

