using System.Net;
using Bookstore.Shared.Abstractions.Exceptions;

namespace Bookstore.Application.Exceptions.UserExceptions;
public class EmailAlreadyInUseException : CustomException
{
	public object Email { get; set; }
	public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

	public EmailAlreadyInUseException(object email) : base($"Email with name: {email} already exists")
	{
		Email = email;
	}
}
