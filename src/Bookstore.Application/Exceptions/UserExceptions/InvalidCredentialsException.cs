using System.Net;
using Bookstore.Shared.Abstractions.Exceptions;

namespace Bookstore.Application.Exceptions.UserExceptions;
public class InvalidCredentialsException : CustomException
{
	public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

	public InvalidCredentialsException() : base($"Invalid credentials")
	{
	}
}
