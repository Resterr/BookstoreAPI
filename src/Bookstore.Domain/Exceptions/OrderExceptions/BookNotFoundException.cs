using System.Net;
using Bookstore.Shared.Abstractions.Exceptions;

namespace Bookstore.Domain.Exceptions.Order;
public class BookNotFoundException : CustomException
{
	public long OrderId { get; }
	public string BookName { get; }
	public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

	public BookNotFoundException(long orderId, string bookName) : base($"Order: {orderId} not found book: {bookName}")
	{
		OrderId = orderId;
		BookName = bookName;
	}
}
