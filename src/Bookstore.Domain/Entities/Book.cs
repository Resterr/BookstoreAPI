using Bookstore.Domain.Entities.Relations;
using Bookstore.Domain.Events.BookEvents;
using Bookstore.Domain.Exceptions.Book;
using Bookstore.Domain.ValueObjects.BookValueObjects;
using Bookstore.Shared.Abstractions.Domain;

namespace Bookstore.Domain.Entities;
public class Book : AggregateRoot<BookId>
{
	public new BookId Id { get; private set; }
	public BookName Name { get; private set; }
	public BookPrice Price { get; private set; }
	public BookCoverType CoverType { get; private set; }
	public BookNumberOfPages NumberOfPages { get; private set; }
	public BookHeight Height { get; private set; }
	public BookWidth Width { get; private set; }
	public BookQuantity Quantity { get; private set; }
	public Publisher Publisher { get; private set; }
	public List<BookAuthor> Authors { get; private set; } = new();
	public IList<OrderBook> Orders { get; private set; }

	private Book() { }

	internal Book(BookId id, BookName name, BookPrice price, BookCoverType coverType,
		BookNumberOfPages numberOfPages, BookHeight height, BookWidth width, BookQuantity quantity)
	{
		Id = id;
		Name = name;
		Price = price;
		CoverType = coverType;
		NumberOfPages = numberOfPages;
		Height = height;
		Width = width;
		Quantity = quantity;
	}

	public void UpdateBook(BookName name, BookPrice price, BookCoverType coverType,
		BookNumberOfPages numberOfPages, BookHeight height, BookWidth width)
	{
		if (name is not null) 
			Name = name;
		if (price is not null) 
			Price = price;
		if (coverType is not null)
            CoverType = coverType;
		if (numberOfPages is not null)
            NumberOfPages = numberOfPages;
		if (height is not null)
            Height = height;
		if (width is not null)
            Width = width;

		AddEvent(new BookUpdated(this));
	}

	public void AddAuthor(Author author)
	{
		var alreadyExists = Authors.Any(x => x.AuthorId == author.Id);

		if (alreadyExists)
		{
			throw new AuthorAlreadyExistsException(Name, author.FullName);
		}

		Authors.Add(new BookAuthor(this, author));

		AddEvent(new AuthorAdded(this, author));
	}

	public void RemoveAuthor(Author author)
	{
		var authorToRemove = GetAuthor(author);
		Authors.Remove(authorToRemove);

		AddEvent(new AuthorRemoved(this, author));
	}

	public void UpdateQuantity(BookQuantity quantity)
	{
		Quantity = quantity;

		AddEvent(new QuantityUpdated(this));
	}

	public void AddPublisher(Publisher publisher)
	{
		if (Publisher is not null)
		{
			throw new PublisherAlreadyExistsException(Name);
		}

		Publisher = publisher;

		AddEvent(new PublisherAdded(this, publisher));
	}

	public void ChangePublisher(Publisher publisher)
	{
		Publisher = publisher;

		AddEvent(new PublisherChanged(this, publisher));
	}

	public void RemovePublisher(Publisher publisher)
	{
		if (Publisher is null)
		{
			throw new PublisherNotFoundException(Name);
		}

		Publisher = null;

		AddEvent(new PublisherRemoved(this, publisher));
	}

	private BookAuthor GetAuthor(Author author)
	{
		var getAuthor = Authors.SingleOrDefault(x => x.AuthorId == author.Id);

		if (getAuthor is null)
		{
			throw new AuthorNotFoundException(Name, "Author");
		}

		return getAuthor;
	}
}
