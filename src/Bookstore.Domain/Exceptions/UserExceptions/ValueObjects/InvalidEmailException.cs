using System.Net;
using Bookstore.Shared.Abstractions.Exceptions;

namespace Bookstore.Domain.Exceptions.UserExceptions.ValueObjects;
public class InvalidEmailException : CustomException
{
	public string Email { get; }
	public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

	public InvalidEmailException(string email) : base($"Email: {email} is invalid.")
	{
		Email = email;
	}
}
