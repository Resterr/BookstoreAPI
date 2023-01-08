using System.Net;
using Bookstore.Shared.Abstractions.Exceptions;

namespace Bookstore.Application.Exceptions.UserExceptions;
public class UserNameAlreadyInUseException : CustomException
{
	public object UserName { get; set; }
	public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

	public UserNameAlreadyInUseException(object userName) : base($"Username with name: {userName} already exists")
	{
		UserName = userName;
	}
}
