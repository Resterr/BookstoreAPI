using Bookstore.Domain.Entities;
using Bookstore.Domain.Events.BookEvents;
using Bookstore.Domain.Factories;
using Bookstore.Domain.Factories.Abstractions;
using FluentAssertions;

namespace Bookstore.UnitTests.Domain;

public class BookTests
{
	#region ARRANGE

	private readonly IBookFactory _bookFactory;
	private readonly IAuthorFactory _authorFactory;
	private readonly IPublisherFactory _publisherFactory;

	public BookTests()
	{
		_bookFactory = new BookFactory();
		_authorFactory = new AuthorFactory();
		_publisherFactory = new PublisherFactory();
	}

	private Book GetBook()
	{
		var book = _bookFactory.Create(Guid.NewGuid(), "Example", 20.5, "Paperback", 150, 30.5, 10.5, 100);
		return book;
	}

	private Author GetAuthor()
	{
		var author = _authorFactory.Create(Guid.NewGuid(), "Example Author");
		return author;
	}

	private Publisher GetPublisher()
	{
		var publisher = _publisherFactory.Create(Guid.NewGuid(), "Example Publisher");
		return publisher;
	}

	#endregion

	[Theory]
	[InlineData(-1.5, -1, -1.5, -1.5)]
	[InlineData(1.5, 0, 1.5, 1.5)]
	[InlineData(0.0, 0, 0.0, 0.0)]
	public void UpdateBook_ForInvalidData_ShouldFailure(double? price, int? numberOfPages, double? height, double? width)
	{
		//ARRANGE
		var book = GetBook();

		//ACT
		var exception = Record.Exception(() => book.UpdateBook(null, price, null, numberOfPages, height, width));

		//ASSERT
		exception.Should().NotBeNull();
	}

	[Theory]
	[InlineData("NameUpdated", 9.99, "Hardcover", 200, 30.5, 20.5)]
	[InlineData(null, null, null, null, null, null)]
	public void UpdateBook_ForValidData_ShouldSuccess(string name, double? price, string coverType, int? numberOfPages, double? height, double? width)
	{
		//ARRANGE
		var book = GetBook();

		//ACT
		var exception = Record.Exception(() => book.UpdateBook(name, price, coverType, numberOfPages, height, width));

		//ASSERT
		exception.Should().BeNull();
		book.Events.Count().Should().Be(1);

		var @event = book.Events.SingleOrDefault() as BookUpdated;
		@event.Should().NotBeNull();
		@event.book.Name.Value.Should().Be(name is null ? book.Name.Value : name);
		@event.book.Price.Value.Should().Be(price is null ? book.Price.Value : price.GetValueOrDefault());
		@event.book.CoverType.Value.Should().Be(coverType is null ? book.CoverType.Value : coverType);
		@event.book.NumberOfPages.Value.Should().Be(numberOfPages is null ? book.NumberOfPages.Value : numberOfPages.GetValueOrDefault());
		@event.book.Height.Value.Should().Be(height is null ? book.Height.Value : height.GetValueOrDefault());
		@event.book.Width.Value.Should().Be(width is null ? book.Width.Value : width.GetValueOrDefault());
	}

	[Theory]
	[InlineData(-1)]
	public void UpdateQuantity_ForInvalidData_ShouldFailure(int quantity)
	{
		//ARRANGE
		var book = GetBook();

		//ACT
		var exception = Record.Exception(() => book.UpdateQuantity(quantity));

		//ASSERT
		exception.Should().NotBeNull();
	}

	[Theory]
	[InlineData(0)]
	[InlineData(1)]
	public void UpdateQuantity_ForValidData_ShouldSuccess(int quantity)
	{
		//ARRANGE
		var book = GetBook();

		//ACT
		var exception = Record.Exception(() => book.UpdateQuantity(quantity));

		//ASSERT
		exception.Should().BeNull();
		book.Events.Count().Should().Be(1);

		var @event = book.Events.SingleOrDefault() as QuantityUpdated;
		@event.Should().NotBeNull();
		@event.book.Quantity.Value.Should().Be(quantity);
	}

	[Fact]
	public void AddAuthor_ForInvalidData_ShouldFailure()
	{
		//ARRANGE
		var book = GetBook();
		var author = GetAuthor();
		book.AddAuthor(author);

		//ACT
		var exception = Record.Exception(() => book.AddAuthor(author));

		//ASSERT
		exception.Should().NotBeNull(); ;
	}

	[Fact]
	public void AddAuthor_ForValidData_ShouldSuccess()
	{
		//ARRANGE
		var book = GetBook();
		var author = GetAuthor();

		//ACT
		var exception = Record.Exception(() => book.AddAuthor(author));

		//ASSERT
		exception.Should().BeNull();
		book.Events.Count().Should().Be(1);

		var @event = book.Events.SingleOrDefault() as AuthorAdded;
		@event.Should().NotBeNull();
		@event.book.Authors.Select(x => x.AuthorId == author.Id).Should().NotBeNull();
	}

	[Fact]
	public void RemoveAuthor_ForInvalidData_ShouldFailure()
	{
		//ARRANGE
		var book = GetBook();
		var author = GetAuthor();

		//ACT
		var exception = Record.Exception(() => book.RemoveAuthor(author));

		//ASSERT
		exception.Should().NotBeNull();
	}

	[Fact]
	public void RemoveAuthor_ForValidData_ShouldSuccess()
	{
		//ARRANGE
		var book = GetBook();
		var author = GetAuthor();
		book.AddAuthor(author);
		book.ClearEvents();

		//ACT
		var exception = Record.Exception(() => book.RemoveAuthor(author));

		//ASSERT
		exception.Should().BeNull();
		book.Events.Count().Should().Be(1);

		var @event = book.Events.SingleOrDefault() as AuthorRemoved;
		@event.Should().NotBeNull();
		@event.book.Authors.SingleOrDefault(x => x.AuthorId == author.Id).Should().BeNull();
	}

	[Fact]
	public void AddPublisher_ForInvalidData_ShouldFailure()
	{
		//ARRANGE
		var book = GetBook();
		var publisher = GetPublisher();
		book.AddPublisher(publisher);

		//ACT
		var exception = Record.Exception(() => book.AddPublisher(publisher));

		//ASSERT
		exception.Should().NotBeNull();
	}

	[Fact]
	public void AddPublisher_ForValidData_ShouldSuccess()
	{
		//ARRANGE
		var book = GetBook();
		var publisher = GetPublisher();

		//ACT
		var exception = Record.Exception(() => book.AddPublisher(publisher));

		//ASSERT
		exception.Should().BeNull();
		book.Events.Count().Should().Be(1);

		var @event = book.Events.SingleOrDefault() as PublisherAdded;
		@event.Should().NotBeNull();
		@event.book.Publisher.Id.Should().Be(publisher.Id);
	}

	[Fact]
	public void ChangePublisher_ForInvalidData_ShouldFailure()
	{
		//ARRANGE
		var book = GetBook();
		var publisher = GetPublisher();
		book.AddPublisher(publisher);
		book.ClearEvents();

		//ACT
		var exception = Record.Exception(() => book.ChangePublisher(publisher));

		//ASSERT
		exception.Should().NotBeNull();
	}

	[Fact]
	public void ChangePublisher_ForValidData_ShouldSuccess()
	{
		//ARRANGE
		var book = GetBook();
		var publisher = GetPublisher();
		var publisherToChange = GetPublisher();
		book.AddPublisher(publisher);
		book.ClearEvents();

		//ACT
		var exception = Record.Exception(() => book.ChangePublisher(publisherToChange));

		//ASSERT
		exception.Should().BeNull();
		book.Events.Count().Should().Be(1);

		var @event = book.Events.SingleOrDefault() as PublisherChanged;
		@event.Should().NotBeNull();
		@event.book.Publisher.Id.Should().Be(publisherToChange.Id);
	}

	[Fact]
	public void RemovePublisher_ForInvalidData_ShouldFailure()
	{
		//ARRANGE
		var book = GetBook();
		var publisher = GetPublisher();

		//ACT
		var exception = Record.Exception(() => book.RemovePublisher());

		//ASSERT
		exception.Should().NotBeNull();
	}

	[Fact]
	public void RemovePublisher_ForValidData_ShouldSuccess()
	{
		//ARRANGE
		var book = GetBook();
		var publisher = GetPublisher();
		book.AddPublisher(publisher);
		book.ClearEvents();

		//ACT
		var exception = Record.Exception(() => book.RemovePublisher());

		//ASSERT
		exception.Should().BeNull();
		book.Events.Count().Should().Be(1);

		var @event = book.Events.SingleOrDefault() as PublisherRemoved;
		@event.Should().NotBeNull();
		@event.book.Publisher.Should().BeNull();
	}
}
