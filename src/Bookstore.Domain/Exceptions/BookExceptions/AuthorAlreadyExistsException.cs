using System.Net;
using Bookstore.Shared.Abstractions.Exceptions;

namespace Bookstore.Domain.Exceptions.Book;
public class AuthorAlreadyExistsException : CustomException
{
	public string BookName { get; }
	public string AuthorName { get; }
	public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

	public AuthorAlreadyExistsException(string bookName, string authorName) : base($"Book: {bookName} already defined author: {authorName}")
	{
		BookName = bookName;
		AuthorName = authorName;
	}
}
