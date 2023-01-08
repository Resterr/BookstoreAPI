using Bookstore.Application.DTO;
using Bookstore.Application.Queries.PublisherQueries;
using Bookstore.Domain.ValueObjects.PublisherValueObjects;
using Bookstore.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.EF.Queries.Handlers.PublisherQueries;
internal sealed class GetPublisherByIdHandler : IQueryHandler<GetPublisherById, PublisherDto>
{
	private readonly AppDbContext _dbContext;

	public GetPublisherByIdHandler(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<PublisherDto> HandleAsync(GetPublisherById query)
	{
		var publisherId = new PublisherId(query.Id);
		var publisher = await _dbContext.Publishers
			.AsNoTracking()
			.SingleOrDefaultAsync(x => x.Id == publisherId);

		return publisher?.AsDto();
	}
}
