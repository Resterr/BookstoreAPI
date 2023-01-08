using Bookstore.Shared.Exceptions.DomainExceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Domain.ValueObjects.AuthorValueObjects;
public record AuthorFullName
{
	public string Value { get; }

	public AuthorFullName(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new InvalidNameException(this.GetNameOfObject(), value.GetValueOrNull());
		}

		Value = value;
	}

	public static implicit operator AuthorFullName(string value) => value is null ? null : new AuthorFullName(value);

	public static implicit operator string(AuthorFullName value) => value?.Value;
}
