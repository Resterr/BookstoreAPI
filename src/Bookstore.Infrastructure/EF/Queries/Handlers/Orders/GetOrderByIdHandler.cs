using Bookstore.Application.DTO;
using Bookstore.Application.Functions.Orders.Queries.GetOrderById;
using Bookstore.Domain.ValueObjects.OrderValueObjects;
using Bookstore.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.EF.Queries.Handlers.Orders;
internal sealed class GetOrderByIdHandler : IQueryHandler<GetOrderById, OrderDto>
{
	private readonly AppDbContext _dbContext;

	public GetOrderByIdHandler(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<OrderDto> HandleAsync(GetOrderById query)
	{
		var orderId = new OrderId(query.Id);
		var order = await _dbContext.Orders
			.Include(x => x.Books)
			.ThenInclude(x => x.Book)
			.Include(x => x.CreatedBy)
			.AsNoTracking()
			.SingleOrDefaultAsync(x => x.Id == orderId);

		return order?.AsDto();
	}
}
