using Bookstore.Application.DTO;
using Bookstore.Shared.Abstractions.Queries;

namespace Bookstore.Application.Queries.AuthorQueries;
public class GetAuthorById : IQuery<AuthorDto>
{
	public long Id { get; set; }
}
