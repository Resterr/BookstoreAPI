using Bookstore.Domain.Entities;
using Bookstore.Domain.ValueObjects.BookValueObjects;

namespace Bookstore.Domain.Factories;
public sealed class BookFactory : IBookFactory
{
	public Book Create(BookId id, BookName name, BookPrice price, BookCoverType coverType,
		BookNumberOfPages numberOfPages, BookHeight height, BookWidth width, BookQuantity quantity)
		=> new(id, name, price, coverType, numberOfPages, height, width, quantity);
}
