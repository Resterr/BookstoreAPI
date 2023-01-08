using Bookstore.Shared.Exceptions.DomainExceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Domain.ValueObjects.BookValueObjects;
public record BookQuantity
{
	public int Value { get; }

	public BookQuantity(int value)
	{
		if (value.Equals(null))
		{
			throw new InvalidValueException(this.GetNameOfObject(), value.GetValueOrNull());
		}

		if (value < 0)
		{
			throw new InvalidValueException(this.GetNameOfObject(), value.GetValueOrNull());
		}

		Value = value;
	}

	public static implicit operator int(BookQuantity value)
		=> value.Value;

	public static implicit operator BookQuantity(int value)
		=> new(value);
}
