using Bookstore.Shared.Exceptions.DomainExceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Domain.ValueObjects.OrderValueObjects;
public record OrderId
{
	public long Value { get; }
	public OrderId(long value)
	{
		if (value <= 0)
		{
			throw new InvalidIdException(this.GetNameOfObject(), value.GetValueOrNull());
		}

		Value = value;
	}

	public static implicit operator long(OrderId date)
		=> date.Value;

	public static implicit operator OrderId(long value)
		=> new(value);
}
