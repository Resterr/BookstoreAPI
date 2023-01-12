using Bookstore.Domain.Entities;
using Bookstore.Domain.Factories.Abstractions;
using Bookstore.Domain.ValueObjects.BookValueObjects;
using Bookstore.Domain.ValueObjects.OrderValueObjects;
using Bookstore.Shared.Consts;

namespace Bookstore.Domain.Factories;
public class OrderFactory : IOrderFactory
{
	public Order Create(OrderId orderId, OrderStatus orderStatus, User createdBy, OrderCreationDate orderCreationDate, IDictionary<Book, BookQuantity> books)
		=> new(orderId, orderStatus, createdBy, orderCreationDate, books);
}
