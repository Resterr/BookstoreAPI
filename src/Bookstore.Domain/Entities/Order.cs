using Bookstore.Domain.Entities.Relations;
using Bookstore.Domain.Events.OrderEvents;
using Bookstore.Domain.Exceptions.Order;
using Bookstore.Domain.ValueObjects.BookValueObjects;
using Bookstore.Domain.ValueObjects.OrderValueObjects;
using Bookstore.Shared.Abstractions.Domain;
using Bookstore.Shared.Consts;
using Bookstore.Shared.Exceptions.DomainExceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Domain.Entities;
public class Order : AggregateRoot<OrderId>
{
	public new OrderId Id { get; private set; }
	public OrderStatus OrderStatus { get; private set; }
	public User CreatedBy { get; private set; }
	public OrderCreationDate CreationDate { get; private set; }
	public List<OrderBook> Books { get; private set; } = new();

	private Order() { }

	internal Order(OrderId id, OrderStatus orderStatus, User createdBy, OrderCreationDate creationDate, IDictionary<Book, BookQuantity> books)
	{
		Id = id;
		OrderStatus = orderStatus;
		CreatedBy = createdBy;
		CreationDate = creationDate;

		foreach (var book in books)
		{
			Books.Add(new OrderBook(this, book.Key, book.Value));
		}
	}

	public void AddBook(Book book, BookQuantity quantity)
	{
		var alreadyExists = Books.Any(x => x.BookId == book.Id);

		if (alreadyExists)
		{
			throw new BookAlreadyExistsException(this.Id, book.Name);
		}

		Books.Add(new OrderBook(this, book, quantity));

		AddEvent(new BookAdded(this, book, quantity));
	}

	public void ChangeOrderBookQuantity(Book book, BookQuantity quantity)
	{
		var bookToChange = GetBook(book);

		Books.Remove(bookToChange);
		Books.Add(new OrderBook(this, book, quantity));

		AddEvent(new OrderBookQuantityChanged(this, book, quantity));
	}

	public void RemoveBook(Book book)
	{
		var bookToRemove = GetBook(book);

		Books.Remove(bookToRemove);

		AddEvent(new BookRemoved(this, book));
	}

	public void StatusChange(OrderStatus orderStatus)
	{
		if(!Enum.IsDefined(typeof(OrderStatus), orderStatus))
		{
			throw new InvalidValueException(OrderStatus.GetNameOfObject(), orderStatus.GetValueOrNull());
		}

		OrderStatus = orderStatus;

		AddEvent(new StatusChanged(this, orderStatus));
	}

	private OrderBook GetBook(Book book)
	{
		var getBook = Books.SingleOrDefault(x => x.BookId == book.Id);

		if (getBook is null)
		{
			throw new BookNotFoundException(this.Id, book.Name);
		}

		return getBook;
	}
}

