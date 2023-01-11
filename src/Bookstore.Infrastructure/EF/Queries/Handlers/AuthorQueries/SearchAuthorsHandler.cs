using Bookstore.Application.DTO;
using Bookstore.Application.Queries;
using Bookstore.Application.Queries.AuthorQueries;
using Bookstore.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.EF.Queries.Handlers.AuthorQueries;
internal sealed class SearchAuthorsHandler : IQueryHandler<SearchAuthors, IPagedResult<AuthorDto>>
{
	private readonly AppDbContext _dbContext;

	public SearchAuthorsHandler(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<IPagedResult<AuthorDto>> HandleAsync(SearchAuthors query)
	{
		var dbQuery = _dbContext.Authors
			.Where(x => Microsoft.EntityFrameworkCore.EF.Functions.ILike(x.FullName, $"%{query.SearchPhrase}%"));

		var resultQuery = await dbQuery
			.Skip(query.PageSize * (query.PageNumber - 1))
			.Take(query.PageSize)
			.Select(x => x.AsDto())
			.AsNoTracking()
			.ToListAsync();

		var totalItemsCount = dbQuery.Count();

		var result = new PagedResult<AuthorDto>(resultQuery, totalItemsCount, query.PageSize, query.PageNumber);

		return result;
	}
}
