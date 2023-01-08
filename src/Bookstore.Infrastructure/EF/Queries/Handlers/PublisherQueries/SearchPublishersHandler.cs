using Bookstore.Application.DTO;
using Bookstore.Application.Queries.PublisherQueries;
using Bookstore.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.EF.Queries.Handlers.PublisherQueries;
internal sealed class SearchPublishersHandler : IQueryHandler<SearchPublishers, IEnumerable<PublisherDto>>
{
	private readonly AppDbContext _dbContext;

	public SearchPublishersHandler(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<IEnumerable<PublisherDto>> HandleAsync(SearchPublishers query)
	{
		var dbQuery = _dbContext.Publishers
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
