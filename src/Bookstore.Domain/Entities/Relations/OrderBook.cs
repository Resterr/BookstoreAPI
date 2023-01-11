using Bookstore.Domain.ValueObjects.BookValueObjects;
using Bookstore.Domain.ValueObjects.OrderValueObjects;

namespace Bookstore.Domain.Entities.Relations;
public class OrderBook
{
	public OrderId OrderId { get; private set; }
	public Order Order { get; private set; }
	public BookId BookId { get; private set; }
	public Book Book { get; private set; }
	public BookQuantity Quantity { get; private set; }

	private OrderBook() { }

	public OrderBook(Order order, Book book, BookQuantity quantity)
	{
		Order = order;
		Book = book;
		Quantity = quantity;
	}
}
