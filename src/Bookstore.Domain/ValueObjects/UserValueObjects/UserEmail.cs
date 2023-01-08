using System.Text.RegularExpressions;
using Bookstore.Domain.Exceptions.UserExceptions.ValueObjects;

namespace Bookstore.Domain.ValueObjects.UserValueObjects;
public record UserEmail
{
	private static readonly Regex Regex = new(
		@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
		@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
		RegexOptions.Compiled);

	public string Value { get; }

	public UserEmail(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new InvalidEmailException(value);
		}

		if (value.Length > 100)
		{
			throw new InvalidEmailException(value);
		}

		value = value.ToLowerInvariant();
		if (!Regex.IsMatch(value))
		{
			throw new InvalidEmailException(value);
		}


		Value = value;
	}

	public static implicit operator string(UserEmail value)
		=> value.Value;

	public static implicit operator UserEmail(string value)
		=> new(value);
}
