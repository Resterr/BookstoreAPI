using System.Net;

namespace Bookstore.Shared.Abstractions.Exceptions;
public abstract class CustomException : Exception
{
	public abstract HttpStatusCode StatusCode { get; }
	protected CustomException(string message) : base(message) 
	{ 
	}
}
