using Bookstore.Application.DTO;
using Bookstore.Application.Queries.AuthorQueries;
using Bookstore.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.EF.Queries.Handlers.AuthorQueries;
internal sealed class SearchAuthorsHandler : IQueryHandler<SearchAuthors, IEnumerable<AuthorDto>>
{
	private readonly AppDbContext _dbContext;

	public SearchAuthorsHandler(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<IEnumerable<AuthorDto>> HandleAsync(SearchAuthors query)
	{
		var dbQuery = _dbContext.Authors
			.AsQueryable();

		if (query.SearchPhrase is not null)
		{
			dbQuery = dbQuery.Where(x =>
				Microsoft.EntityFrameworkCore.EF.Functions.ILike(x.FullName, $"%{query.SearchPhrase}%"));
		}

		return await dbQuery
			.Select(x => x.AsDto())
			.AsNoTracking()
			.ToListAsync();
	}
}
