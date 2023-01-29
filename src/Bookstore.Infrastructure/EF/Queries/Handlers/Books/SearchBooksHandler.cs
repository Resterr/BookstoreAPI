using Bookstore.Application.DTO;
using Bookstore.Application.Functions.Books.Queries.SearchBooks;
using Bookstore.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.EF.Queries.Handlers.Books;
internal sealed class SearchBooksHandler : IQueryHandler<SearchBooks, IPagedResult<BookDto>>
{
	private readonly AppDbContext _dbContext;

	public SearchBooksHandler(AppDbContext dbContext)
	{
		_dbContext = dbContext;;
	}

	public async Task<IPagedResult<BookDto>> HandleAsync(SearchBooks query)
	{
		var dbQuery = _dbContext.Books
			.Include(x => x.Authors)
			.ThenInclude(x => x.Author)
			.Include(x => x.Publisher)
			.Where(x => Microsoft.EntityFrameworkCore.EF.Functions.ILike(x.Name, $"%{query.SearchPhrase}%"));

		var resultQuery = await dbQuery
			.Skip(query.PageSize * (query.PageNumber - 1))
			.Take(query.PageSize)
			.Select(x => x.AsDto())
			.AsNoTracking()
			.ToListAsync();

		var totalItemsCount = dbQuery.Count();

		var result = new PagedResult<BookDto>(resultQuery, totalItemsCount, query.PageSize, query.PageNumber);

		return result;
	}
}
