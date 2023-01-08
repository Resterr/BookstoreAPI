using System.Net;
using Bookstore.Shared.Abstractions.Exceptions;

namespace Bookstore.Domain.Exceptions.UserExceptions.ValueObjects;
public class CreationDateIsNullException : CustomException
{
	public object Date { get; }
	public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

	public CreationDateIsNullException(object date) : base($"Creation date is null")
	{
		Date = date;
	}
}
