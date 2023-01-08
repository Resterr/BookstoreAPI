using Bookstore.Domain.ValueObjects.AuthorValueObjects;
using Bookstore.Domain.ValueObjects.BookValueObjects;

namespace Bookstore.Domain.Entities.Relations;
public class BookAuthor
{
	public BookId BookId { get; private set; }
	public Book Book { get; private set; }
	public AuthorId AuthorId { get; private set; }
	public Author Author { get; private set; }

	private BookAuthor() { }

	public BookAuthor(Book book, Author author)
	{
		Book = book;
		Author = author;
	}
}
