using System.Net;
using Bookstore.Shared.Abstractions.Exceptions;

namespace Bookstore.Shared.Exceptions.DomainExceptions;
public class InvalidValueException : CustomException
{
	public object PropertyName { get; set; }
	public object Value { get; }
	public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

	public InvalidValueException(object propertyName, object value) : base($"{propertyName} value: {value} is invalid.")
	{
		PropertyName = propertyName;
		Value = value;
	}
}
