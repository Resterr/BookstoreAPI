using Bookstore.Application.DTO;
using Bookstore.Application.Queries.BookQueries;
using Bookstore.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.EF.Queries.Handlers.BookQueries;
internal sealed class SearchBooksHandler : IQueryHandler<SearchBooks, IEnumerable<BookDto>>
{
	private readonly AppDbContext _dbContext;

	public SearchBooksHandler(AppDbContext dbContext)
	{
		_dbContext = dbContext;;
	}

	public async Task<IEnumerable<BookDto>> HandleAsync(SearchBooks query)
	{
		var dbQuery = _dbContext.Books
			.Include(x => x.Authors)
			.ThenInclude(x => x.Author)
			.Include(x => x.Publisher)
			.AsQueryable();

		if (query.SearchPhrase is not null)
		{
			dbQuery = dbQuery.Where(x =>
				Microsoft.EntityFrameworkCore.EF.Functions.ILike(x.Name, $"%{query.SearchPhrase}%"));
		}

		return await dbQuery
			.Select(x => x.AsDto())
			.AsNoTracking()
			.ToListAsync();
	}
}
