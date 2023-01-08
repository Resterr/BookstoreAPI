using System.Net;
using Bookstore.Shared.Abstractions.Exceptions;

namespace Bookstore.Domain.Exceptions.UserExceptions.ValueObjects;
public class InvalidPasswordException : CustomException
{
	public string Password { get; }
	public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

	public InvalidPasswordException(string password) : base($"Password: {password} is invalid.")
	{
		Password = password;
	}
}
