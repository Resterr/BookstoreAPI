using Bookstore.Shared.Exceptions.DomainExceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Domain.ValueObjects.OrderValueObjects;
public record OrderId
{
	public Guid Value { get; }
	public OrderId(Guid value)
	{
		if (value == Guid.Empty)
		{
			throw new InvalidIdException(this.GetNameOfObject(), value.GetValueOrNull());
		}

		Value = value;
	}

	public static implicit operator Guid(OrderId date)
		=> date.Value;

	public static implicit operator OrderId(Guid value)
		=> new(value);
}
