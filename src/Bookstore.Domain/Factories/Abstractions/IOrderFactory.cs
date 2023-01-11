using Bookstore.Domain.Entities;
using Bookstore.Domain.ValueObjects.BookValueObjects;
using Bookstore.Domain.ValueObjects.OrderValueObjects;
using Bookstore.Shared.Consts;

namespace Bookstore.Domain.Factories.Abstractions;
public interface IOrderFactory
{
	Order Create(OrderId orderId, OrderStatus orderStatus, User createdBy, OrderCreationDate orderCreationDate, IDictionary<Book, BookQuantity> books);
}
