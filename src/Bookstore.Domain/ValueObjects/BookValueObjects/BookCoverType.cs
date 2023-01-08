using Bookstore.Shared.Exceptions.DomainExceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Domain.ValueObjects.BookValueObjects;
public record BookCoverType
{
	public string Value { get; }

	public BookCoverType(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new InvalidNameException(this.GetNameOfObject(), value.GetValueOrNull());
		}
		
		Value = value;
	}

	public static implicit operator string(BookCoverType value) 
		=> value.Value;

	public static implicit operator BookCoverType(string value)
		=> new(value);
}
