using Bookstore.Application.DTO;
using Bookstore.Application.Queries.AuthorQueries;
using Bookstore.Domain.ValueObjects.AuthorValueObjects;
using Bookstore.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.EF.Queries.Handlers.AuthorQueries;
internal sealed class GetAuthorByIdHandler : IQueryHandler<GetAuthorById, AuthorDto>
{
	private readonly AppDbContext _dbContext;

	public GetAuthorByIdHandler(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<AuthorDto> HandleAsync(GetAuthorById query)
	{
		var authorId = new AuthorId(query.Id);
		var author = await _dbContext.Authors
			.AsNoTracking()
			.SingleOrDefaultAsync(x => x.Id == authorId);

		return author?.AsDto();
	}
}

