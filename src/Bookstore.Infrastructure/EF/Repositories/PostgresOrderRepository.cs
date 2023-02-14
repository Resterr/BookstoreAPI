using Bookstore.Domain.Entities;
using Bookstore.Domain.Repositories;
using Bookstore.Domain.ValueObjects.OrderValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.EF.Repositories;
internal sealed class PostgresOrderRepository : IOrderRepository
{
	private readonly AppDbContext _dbContext;

	public PostgresOrderRepository(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public Task<Order> GetAsync(OrderId id)
	{
		return _dbContext.Orders
			.Include(x => x.Books)
			.ThenInclude(x => x.Book)
			.Include(x => x.CreatedBy)
			.SingleOrDefaultAsync(x => x.Id == id);
	}

	public async Task AddAsync(Order order)
	{
		await _dbContext.Orders.AddAsync(order);
		await _dbContext.SaveChangesAsync();
	}

	public async Task UpdateAsync(Order order)
	{
		_dbContext.Orders.Update(order);
		await _dbContext.SaveChangesAsync();
	}

	public async Task DeleteAsync(Order order)
	{
		_dbContext.Orders.Remove(order);
		await _dbContext.SaveChangesAsync();
	}
}
