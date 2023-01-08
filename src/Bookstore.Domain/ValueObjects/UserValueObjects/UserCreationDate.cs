using Bookstore.Domain.Exceptions.UserExceptions.ValueObjects;

namespace Bookstore.Domain.ValueObjects.UserValueObjects;
public record UserCreationDate
{
	public DateTime? Value { get; }

	public UserCreationDate(DateTime? value)
	{
		if (value is null)
		{
			throw new CreationDateIsNullException(value);
		}

		Value = value;
	}

	public static implicit operator UserCreationDate(DateTime? value) => value is null ? null : new UserCreationDate(value);

	public static implicit operator DateTime?(UserCreationDate value) => value?.Value;
}
