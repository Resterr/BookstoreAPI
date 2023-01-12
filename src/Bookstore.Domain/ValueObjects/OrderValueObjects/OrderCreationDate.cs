using Bookstore.Domain.Exceptions.UserExceptions.ValueObjects;

namespace Bookstore.Domain.ValueObjects.OrderValueObjects;
public record OrderCreationDate
{
	public DateTime? Value { get; }

	public OrderCreationDate(DateTime? value)
	{
		if (value is null)
		{
			throw new CreationDateIsNullException(value);
		}

		Value = value;
	}

	public static implicit operator OrderCreationDate(DateTime? value) => value is null ? null : new OrderCreationDate(value);

	public static implicit operator DateTime?(OrderCreationDate value) => value?.Value;
}
