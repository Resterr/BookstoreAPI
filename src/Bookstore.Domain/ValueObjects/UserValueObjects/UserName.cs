using Bookstore.Shared.Exceptions.DomainExceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Domain.ValueObjects.UserValueObjects;
public record UserName
{
	public string Value { get; }

	public UserName(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new InvalidNameException(this.GetNameOfObject(), value.GetValueOrNull());
		}

		Value = value;
	}

	public static implicit operator UserName(string value) => value is null ? null : new UserName(value);

	public static implicit operator string(UserName value) => value?.Value;
}
