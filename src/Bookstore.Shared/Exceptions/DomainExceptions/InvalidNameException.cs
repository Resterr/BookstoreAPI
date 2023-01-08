using System.Net;
using Bookstore.Shared.Abstractions.Exceptions;

namespace Bookstore.Shared.Exceptions.DomainExceptions;
public class InvalidNameException : CustomException
{
	public object PropertyName { get; set; }
	public object Name { get; }
	public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

	public InvalidNameException(object propertyName, object name) : base($"{propertyName} name: {name} is invalid.")
	{
		PropertyName = propertyName;
		Name = name;
	}
}
