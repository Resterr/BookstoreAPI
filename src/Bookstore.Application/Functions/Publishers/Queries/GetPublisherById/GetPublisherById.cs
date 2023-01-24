using Bookstore.Application.DTO;
using Bookstore.Shared.Abstractions.Queries;

namespace Bookstore.Application.Functions.Publishers.Queries.GetPublisherById;
public class GetPublisherById : IQuery<PublisherDto>
{
	public Guid Id { get; set; }
}
