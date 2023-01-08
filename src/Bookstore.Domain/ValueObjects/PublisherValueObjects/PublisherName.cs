using Bookstore.Shared.Exceptions.DomainExceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Domain.ValueObjects.PublisherValueObjects;
public record PublisherName
{
	public string Value { get; }

	public PublisherName(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new InvalidNameException(this.GetNameOfObject(), value.GetValueOrNull());
		}

		Value = value;
	}

	public static implicit operator PublisherName(string value) => value is null ? null : new PublisherName(value);

	public static implicit operator string(PublisherName value) => value?.Value;
}
