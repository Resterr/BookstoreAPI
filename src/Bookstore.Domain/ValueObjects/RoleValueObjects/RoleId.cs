using Bookstore.Shared.Exceptions.DomainExceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Domain.ValueObjects.RoleValueObjects;
public record RoleId
{
	public Guid Value { get; }
	public RoleId(Guid value)
	{
		if (value == Guid.Empty)
		{
			throw new InvalidIdException(this.GetNameOfObject(), value.GetValueOrNull());
		}

		Value = value;
	}

	public static implicit operator Guid(RoleId date)
		=> date.Value;

	public static implicit operator RoleId(Guid value)
		=> new(value);
}
