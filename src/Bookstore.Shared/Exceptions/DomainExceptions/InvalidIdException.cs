using System.Net;
using Bookstore.Shared.Abstractions.Exceptions;

namespace Bookstore.Shared.Exceptions.DomainExceptions;
public class InvalidIdException : CustomException
{
	public object PropertyName { get; set; }
	public object Id { get; }
	public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

	public InvalidIdException(object propertyName, object id) : base($"{propertyName} id: {id} is invalid.")
	{
		PropertyName = propertyName;
		Id = id;
	}
}
