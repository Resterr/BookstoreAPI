using Bookstore.Application.DTO;
using Bookstore.Application.Functions.Books.Queries.GetBookById;
using Bookstore.Domain.ValueObjects.BookValueObjects;
using Bookstore.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.EF.Queries.Handlers.Books;
internal sealed class GetBookByIdHandler : IQueryHandler<GetBookById, BookDto>
{
	private readonly AppDbContext _dbContext;

	public GetBookByIdHandler(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<BookDto> HandleAsync(GetBookById query)
	{
		var bookId = new BookId(query.Id);
		var book = await _dbContext.Books
			.Include(x => x.Authors)
			.ThenInclude(x => x.Author)
			.Include(x => x.Publisher)
			.AsNoTracking()
			.SingleOrDefaultAsync(x => x.Id == bookId);

		return book?.AsDto();
	}
}

