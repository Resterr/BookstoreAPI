using Bookstore.Shared.Exceptions.DomainExceptions;
using Bookstore.Shared.Services;

namespace Bookstore.Domain.ValueObjects.AuthorValueObjects;
public record AuthorId
{
	public Guid Value { get; }
	public AuthorId(Guid value)
	{
		if (value == Guid.Empty)
		{
			throw new InvalidIdException(this.GetNameOfObject(), value.GetValueOrNull());
		}

		Value = value;
	}

	public static implicit operator Guid(AuthorId date)
		=> date.Value;

	public static implicit operator AuthorId(Guid value)
		=> new(value);
}
