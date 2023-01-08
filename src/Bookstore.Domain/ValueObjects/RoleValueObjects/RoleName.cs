using Bookstore.Shared.Exceptions.DomainExceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Domain.ValueObjects.RoleValueObjects;
public record RoleName
{
	public string Value { get; }

	public RoleName(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new InvalidNameException(this.GetNameOfObject(), value.GetValueOrNull());
		}

		Value = value;
	}

	public static implicit operator RoleName(string value) => value is null ? null : new RoleName(value);

	public static implicit operator string(RoleName value) => value?.Value;
}
