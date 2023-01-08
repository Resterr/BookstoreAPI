using Bookstore.Shared.Exceptions.DomainExceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Domain.ValueObjects.UserValueObjects;
public record UserId
{
	public long Value { get; }
	public UserId(long value)
	{
		if (value <= 0)
		{
			throw new InvalidIdException(this.GetNameOfObject(), value.GetValueOrNull());
		}

		Value = value;
	}

	public static implicit operator long(UserId date)
		=> date.Value;

	public static implicit operator UserId(long value)
		=> new(value);
}
