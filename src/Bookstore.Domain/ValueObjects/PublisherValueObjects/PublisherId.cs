using Bookstore.Shared.Exceptions.DomainExceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Domain.ValueObjects.PublisherValueObjects;
public record PublisherId
{
	public long Value { get; }
	public PublisherId(long value)
	{
		if (value <= 0)
		{
			throw new InvalidIdException(this.GetNameOfObject(), value.GetValueOrNull());
		}

		Value = value;
	}


	public static implicit operator long(PublisherId date)
		=> date.Value;

	public static implicit operator PublisherId(long value)
		=> new(value);
}
