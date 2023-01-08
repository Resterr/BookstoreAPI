using System.Net;
using Bookstore.Shared.Abstractions.Exceptions;

namespace Bookstore.Domain.Exceptions.Book;
public class PublisherAlreadyExistsException : CustomException
{
	public string BookName { get; }
	public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

	public PublisherAlreadyExistsException(string bookName) : base($"Book: {bookName} already defined publisher")
	{
		BookName = bookName;
	}
}
