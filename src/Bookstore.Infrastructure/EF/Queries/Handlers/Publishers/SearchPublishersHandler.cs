using Bookstore.Application.DTO;
using Bookstore.Application.Functions.Publishers.Queries.SearchPublishers;
using Bookstore.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.EF.Queries.Handlers.Publishers;
internal sealed class SearchPublishersHandler : IQueryHandler<SearchPublishers, IPagedResult<PublisherDto>>
{
	private readonly AppDbContext _dbContext;

	public SearchPublishersHandler(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<IPagedResult<PublisherDto>> HandleAsync(SearchPublishers query)
	{
		var dbQuery = _dbContext.Publishers
			.Where(x => Microsoft.EntityFrameworkCore.EF.Functions.ILike(x.Name, $"%{query.SearchPhrase}%"));

		var resultQuery = await dbQuery
			.Skip(query.PageSize * (query.PageNumber - 1))
			.Take(query.PageSize)
			.Select(x => x.AsDto())
			.AsNoTracking()
			.ToListAsync();

		var totalItemsCount = dbQuery.Count();

		var result = new PagedResult<PublisherDto>(resultQuery, totalItemsCount, query.PageSize, query.PageNumber);

		return result;
	}
}
