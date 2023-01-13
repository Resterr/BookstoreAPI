using Bookstore.Shared.Exceptions.DomainExceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Domain.ValueObjects.BookValueObjects;
public record BookId
{
	public Guid Value { get; }
	public BookId(Guid value)
	{
		if (value == Guid.Empty)
		{
			throw new InvalidIdException(this.GetNameOfObject(), value.GetValueOrNull());
		}

		Value = value;
	}

	public static implicit operator Guid(BookId date)
		=> date.Value;

	public static implicit operator BookId(Guid value)
		=> new(value);
}
