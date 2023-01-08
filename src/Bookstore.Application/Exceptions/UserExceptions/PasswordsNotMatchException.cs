using System.Net;
using Bookstore.Shared.Abstractions.Exceptions;

namespace Bookstore.Application.Exceptions.UserExceptions;
public class PasswordsNotMatchException : CustomException
{
	public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

	public PasswordsNotMatchException() : base($"Your password and confirm password do not match!")
	{
	}
}
