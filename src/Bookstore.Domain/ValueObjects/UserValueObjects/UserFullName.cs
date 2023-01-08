using Bookstore.Shared.Exceptions.DomainExceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Domain.ValueObjects.UserValueObjects;
public record UserFullName
{
	public string Value { get; }

	public UserFullName(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new InvalidNameException(this.GetNameOfObject(), value.GetValueOrNull());
		}

		Value = value;
	}

	public static implicit operator UserFullName(string value) => value is null ? null : new UserFullName(value);

	public static implicit operator string(UserFullName value) => value?.Value;
}
