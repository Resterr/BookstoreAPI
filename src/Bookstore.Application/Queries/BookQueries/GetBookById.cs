using Bookstore.Application.DTO;
using Bookstore.Shared.Abstractions.Queries;

namespace Bookstore.Application.Queries.BookQueries;
public class GetBookById : IQuery<BookDto>
{
	public Guid Id { get; set; }
}
