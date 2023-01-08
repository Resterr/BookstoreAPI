using Bookstore.Application.DTO;
using Bookstore.Shared.Abstractions.Queries;

namespace Bookstore.Application.Queries.PublisherQueries;
public class GetPublisherById : IQuery<PublisherDto>
{
	public long Id { get; set; }
}
