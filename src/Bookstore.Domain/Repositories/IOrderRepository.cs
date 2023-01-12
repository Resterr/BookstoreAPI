using Bookstore.Domain.Entities;
using Bookstore.Domain.ValueObjects.OrderValueObjects;

namespace Bookstore.Domain.Repositories;
public interface IOrderRepository
{
	Task<Order> GetAsync(OrderId id);
	Task AddAsync(Order order);
	Task UpdateAsync(Order order);
	Task DeleteAsync(Order order);
}
