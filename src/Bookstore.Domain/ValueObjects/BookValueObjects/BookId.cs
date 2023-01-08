using Bookstore.Shared.Exceptions.DomainExceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Domain.ValueObjects.BookValueObjects;
public record BookId
{
	public long Value { get; }
	public BookId(long value)
	{
		if (value <= 0)
		{
			throw new InvalidIdException(this.GetNameOfObject(), value.GetValueOrNull());
		}

		Value = value;
	}

	public static implicit operator long(BookId date)
		=> date.Value;

	public static implicit operator BookId(long value)
		=> new(value);
}
