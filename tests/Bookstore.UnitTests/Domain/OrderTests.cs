using Bookstore.Domain.Entities;
using Bookstore.Domain.Events.OrderEvents;
using Bookstore.Domain.Factories;
using Bookstore.Domain.Factories.Abstractions;
using Bookstore.Domain.ValueObjects.BookValueObjects;
using Bookstore.Shared.Consts;
using FluentAssertions;

namespace Bookstore.UnitTests.Domain;
public class OrderTests
{
	#region ARRANGE

	private readonly IBookFactory _bookFactory;
	private readonly IUserFactory _userFactory;
	private readonly IOrderFactory _orderFactory;

	public OrderTests()
	{
		_bookFactory = new BookFactory();
		_userFactory = new UserFactory();
		_orderFactory = new OrderFactory();
	}

	private Book GetBook()
	{
		var book = _bookFactory.Create(Guid.NewGuid(), "Example", 20.5, "Paperback", 150, 30.5, 10.5, 100);
		return book;
	}

	private User GetUser()
	{
		var role = new Role(Guid.NewGuid(), "User");
		var user = _userFactory.Create(Guid.NewGuid(), "test@mail.com", "12345678", "TestUser", "Jan Kowalski", DateTime.UtcNow, role);
		return user;
	}

	private Order GetOrder()
	{
		var listOfBooks = new Dictionary<Book, BookQuantity>
		{
			{ GetBook(), 10 }
		};
		var order = _orderFactory.Create(Guid.NewGuid(), Shared.Consts.OrderStatus.Pending, GetUser(), DateTime.UtcNow, listOfBooks);

		return order;
	}

	#endregion

	[Fact]
	public void AddBook_ForInvalidData_ShouldFailure()
	{
		//ARRANGE
		var order = GetOrder();
		var book = GetBook();
		order.AddBook(book, 10);

		//ACT
		var exception = Record.Exception(() => order.AddBook(book, 10));

		//ASSERT
		exception.Should().NotBeNull();
	}

	[Fact]
	public void AddBook_ForValidData_ShouldSuccess()
	{
		//ARRANGE
		var order = GetOrder();
		var book = GetBook();
		var quantity = 10;

		//ACT
		var exception = Record.Exception(() => order.AddBook(book, quantity));

		//ASSERT
		exception.Should().BeNull();
		order.Events.Count().Should().Be(1);

		var @event = order.Events.SingleOrDefault() as BookAdded;
		@event.Should().NotBeNull();
		@event.order.Books.SingleOrDefault(x => x.BookId == book.Id).Should().NotBeNull();
		@event.order.Books.SingleOrDefault(x => x.BookId == book.Id).Quantity.Value.Should().Be(quantity);
	}

	[Fact]
	public void ChangeOrderBookQuantity_ForInvalidData_ShouldFailure()
	{
		//ARRANGE
		var order = GetOrder();
		var book = GetBook();

		//ACT
		var exception = Record.Exception(() => order.ChangeOrderBookQuantity(book, 10));

		//ASSERT
		exception.Should().NotBeNull();
	}

	[Fact]
	public void ChangeOrderBookQuantity_ForValidData_ShouldSuccess()
	{
		//ARRANGE
		var order = GetOrder();
		var book = order.Books[0].Book;
		var quantity = 20;

		//ACT
		var exception = Record.Exception(() => order.ChangeOrderBookQuantity(book, quantity));

		//ASSERT
		exception.Should().BeNull();
		order.Events.Count().Should().Be(1);

		var @event = order.Events.SingleOrDefault() as OrderBookQuantityChanged;
		@event.Should().NotBeNull();
		@event.order.Books.SingleOrDefault(x => x.BookId == book.Id).Should().NotBeNull();
		@event.order.Books.SingleOrDefault(x => x.BookId == book.Id).Quantity.Value.Should().Be(quantity);
	}

	[Fact]
	public void RemoveBook_ForInvalidData_ShouldFailure()
	{
		//ARRANGE
		var order = GetOrder();
		var book = GetBook();

		//ACT
		var exception = Record.Exception(() => order.RemoveBook(book));

		//ASSERT
		exception.Should().NotBeNull();
	}

	[Fact]
	public void RemoveBook_ForValidData_ShouldSuccess()
	{
		//ARRANGE
		var order = GetOrder();
		var book = order.Books[0].Book;

		//ACT
		var exception = Record.Exception(() => order.RemoveBook(book));

		//ASSERT
		exception.Should().BeNull();
		order.Events.Count().Should().Be(1);

		var @event = order.Events.SingleOrDefault() as BookRemoved;
		@event.order.Books.SingleOrDefault(x => x.BookId == book.Id).Should().BeNull();
	}
}

