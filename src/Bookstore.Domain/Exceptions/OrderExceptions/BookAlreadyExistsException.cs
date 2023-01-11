using System.Net;
using Bookstore.Shared.Abstractions.Exceptions;

namespace Bookstore.Domain.Exceptions.Order;
public class BookAlreadyExistsException : CustomException
{
	public long OrderId { get; }
	public string BookName { get; }
	public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

	public BookAlreadyExistsException(long orderId, string bookName) : base($"Order: {orderId} already defined book: {bookName}")
	{
		OrderId = orderId;
		BookName = bookName;
	}
}
