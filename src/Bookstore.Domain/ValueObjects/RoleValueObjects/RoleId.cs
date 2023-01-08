using Bookstore.Shared.Exceptions.DomainExceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Domain.ValueObjects.RoleValueObjects;
public record RoleId
{
	public int Value { get; }
	public RoleId(int value)
	{
		if (value <= 0)
		{
			throw new InvalidIdException(this.GetNameOfObject(), value.GetValueOrNull());
		}

		Value = value;
	}

	public static implicit operator int(RoleId date)
		=> date.Value;

	public static implicit operator RoleId(int value)
		=> new(value);
}
