using Bookstore.Shared.Exceptions.DomainExceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Domain.ValueObjects.BookValueObjects;
public record BookPrice
{
	public double Value { get; }

	public BookPrice(double value)
	{
		if (value.Equals(null))
		{
			throw new InvalidValueException(this.GetNameOfObject(), value.GetValueOrNull());
		}

		if (value < 0.0)
		{
			throw new InvalidValueException(this.GetNameOfObject(), value.GetValueOrNull());
		}

		Value = value;
	}

	public static implicit operator double(BookPrice value)
		=> value.Value;

	public static implicit operator BookPrice(double value)
		=> new(value);
}
