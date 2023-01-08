using System.Net;
using Bookstore.Shared.Abstractions.Exceptions;

namespace Bookstore.Shared.Exceptions;
public class NotFoundException : CustomException
{
	public object ObjectName { get; set; }
	public object ObjectId { get; set; }
	public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

	public NotFoundException(object objectName, object objectId) : base($"{objectName} with id: {objectId} not found")
	{
		ObjectName = objectName;
		ObjectId = objectId;
	}
}
