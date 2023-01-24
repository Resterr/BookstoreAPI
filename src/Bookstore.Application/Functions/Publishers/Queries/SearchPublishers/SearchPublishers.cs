using Bookstore.Application.DTO;
using Bookstore.Shared.Abstractions.Queries;

namespace Bookstore.Application.Functions.Publishers.Queries.SearchPublishers;
public class SearchPublishers : IQuery<IPagedResult<PublisherDto>>
{
	public int PageNumber { get; set; }
	public int PageSize { get; set; }
	public string SearchPhrase { get; set; }
}

