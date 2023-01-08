using Bookstore.Shared.Exceptions.DomainExceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Domain.ValueObjects.BookValueObjects;
public record BookName
{
	public string Value { get; }

	public BookName(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new InvalidNameException(this.GetNameOfObject(), value.GetValueOrNull());
		}

		Value = value;
	}

	public static implicit operator BookName(string value) => value is null ? null : new BookName(value);

	public static implicit operator string(BookName value) => value?.Value;
}
