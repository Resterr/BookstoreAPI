using System.Net;
using Bookstore.Shared.Abstractions.Exceptions;

namespace Bookstore.Domain.Exceptions.Book;
public class AuthorNotFoundException : CustomException
{
	public string BookName { get; set; }
	public string AuthorName { get; set; }
	public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

	public AuthorNotFoundException(string bookName, string authorName) : base($"Book: {bookName} not found author: {authorName}")
	{
		BookName = bookName;
		AuthorName = authorName;
	}
}
