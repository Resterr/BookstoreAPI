using System.Net;
using Bookstore.Shared.Abstractions.Exceptions;

namespace Bookstore.Application.Exceptions.OrderExceptions;
public class SameQuantityValueException : CustomException
{
	public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

	public SameQuantityValueException() : base($"Cannot change the quantity value to the same as it was")
	{
	}
}
