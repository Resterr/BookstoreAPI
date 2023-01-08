using System.Net;
using Bookstore.Shared.Abstractions.Exceptions;

namespace Bookstore.Domain.Exceptions.Book;
public class PublisherNotFoundException : CustomException
{
	public string BookName { get; set; }
	public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
	public PublisherNotFoundException(string bookName) : base($"Book: {bookName} not found publisher")
	{
		BookName = bookName;
	}
}
