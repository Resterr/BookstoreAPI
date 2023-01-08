using Bookstore.Shared.Exceptions.DomainExceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Domain.ValueObjects.BookValueObjects;
public record BookWidth
{
	public double Value { get; }

	public BookWidth(double value)
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

	public static implicit operator double(BookWidth value)
		=> value.Value;

	public static implicit operator BookWidth(double value)
		=> new(value);
}
