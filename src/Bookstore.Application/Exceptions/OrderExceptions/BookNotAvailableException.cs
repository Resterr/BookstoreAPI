using System.Net;
using Bookstore.Shared.Abstractions.Exceptions;

namespace Bookstore.Application.Exceptions.OrderExceptions;
public class BookNotAvailableException : CustomException
{
	public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

	public BookNotAvailableException() : base($"Some books in order are not available")
	{
	}
}
