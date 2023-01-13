using Bookstore.Shared.Exceptions.DomainExceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Domain.ValueObjects.UserValueObjects;
public record UserId
{
	public Guid Value { get; }
	public UserId(Guid value)
	{
		if (value == Guid.Empty)
		{
			throw new InvalidIdException(this.GetNameOfObject(), value.GetValueOrNull());
		}

		Value = value;
	}

	public static implicit operator Guid(UserId date)
		=> date.Value;

	public static implicit operator UserId(Guid value)
		=> new(value);
}
