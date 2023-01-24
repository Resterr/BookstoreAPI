using Bookstore.Application.DTO;
using Bookstore.Shared.Abstractions.Queries;

namespace Bookstore.Application.Functions.Books.Queries.GetBookById;
public class GetBookById : IQuery<BookDto>
{
	public Guid Id { get; set; }
}
