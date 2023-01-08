using Bookstore.Domain.Entities;
using Bookstore.Domain.ValueObjects.BookValueObjects;

namespace Bookstore.Domain.Factories;
public interface IBookFactory
{
	Book Create(BookId id, BookName name, BookPrice price, BookCoverType coverType, BookNumberOfPages numberOfPages, BookHeight height, BookWidth width, BookQuantity quantity);
}
