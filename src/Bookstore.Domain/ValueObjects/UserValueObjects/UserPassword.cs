using Bookstore.Domain.Exceptions.UserExceptions.ValueObjects;

namespace Bookstore.Domain.ValueObjects.UserValueObjects;
public record UserPassword
{
	public string Value { get; }

	public UserPassword(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new InvalidPasswordException(value);
		}

		if (value.Length < 6)
		{
			throw new InvalidPasswordException(value);
		}

		Value = value;
	}

	public static implicit operator string(UserPassword value)
		=> value.Value;

	public static implicit operator UserPassword(string value)
		=> new(value);
}
