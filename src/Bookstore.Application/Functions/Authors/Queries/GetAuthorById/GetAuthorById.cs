using Bookstore.Application.DTO;
using Bookstore.Shared.Abstractions.Queries;

namespace Bookstore.Application.Functions.Authors.Queries.GetAuthorById;
public class GetAuthorById : IQuery<AuthorDto>
{
	public Guid Id { get; set; }
}
