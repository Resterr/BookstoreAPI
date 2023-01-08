using Bookstore.Shared.Exceptions.DomainExceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Domain.ValueObjects.AuthorValueObjects;
public record AuthorId
{
	public long Value { get; }
	public AuthorId(long value)
	{
		if (value == 0)
		{
			throw new InvalidIdException(this.GetNameOfObject(), value.GetValueOrNull());
		}

		Value = value;
	}

	public static implicit operator long(AuthorId date)
		=> date.Value;

	public static implicit operator AuthorId(long value)
		=> new(value);
}
