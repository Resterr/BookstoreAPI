using Bookstore.Shared.Exceptions.DomainExceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Domain.ValueObjects.PublisherValueObjects;
public record PublisherId
{
	public Guid Value { get; }
	public PublisherId(Guid value)
	{
		if (value == Guid.Empty)
		{
			throw new InvalidIdException(this.GetNameOfObject(), value.GetValueOrNull());
		}

		Value = value;
	}


	public static implicit operator Guid(PublisherId date)
		=> date.Value;

	public static implicit operator PublisherId(Guid value)
		=> new(value);
}
