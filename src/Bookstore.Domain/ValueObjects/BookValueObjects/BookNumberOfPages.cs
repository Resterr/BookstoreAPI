using Bookstore.Shared.Exceptions.DomainExceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Domain.ValueObjects.BookValueObjects;
public record BookNumberOfPages
{
	public int Value { get; }

	public BookNumberOfPages(int value)
	{
		if (value.Equals(null))
		{
			throw new InvalidValueException(this.GetNameOfObject(), value.GetValueOrNull());
		}

		if (value < 1)
		{
			throw new InvalidValueException(this.GetNameOfObject(), value.GetValueOrNull());
		}

		Value = value;
	}

	public static implicit operator int(BookNumberOfPages value)
		=> value.Value;

	public static implicit operator BookNumberOfPages(int value)
		=> new(value);
}
