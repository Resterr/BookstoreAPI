using Bookstore.Shared.Abstractions.Domain;
using Bookstore.Domain.Events.AuthorEvents;
using Bookstore.Domain.ValueObjects.AuthorValueObjects;
using Bookstore.Domain.Entities.Relations;

namespace Bookstore.Domain.Entities;
public class Author : AggregateRoot<AuthorId>
{
	public new AuthorId Id { get; private set; }
	public AuthorFullName FullName { get; private set; }
	public IList<BookAuthor> Books { get; private set; }

	private Author() { }

	internal Author(AuthorId id, AuthorFullName fullName)
	{
		Id = id;
		FullName = fullName;
	}

	public void UpdateAuthor(AuthorFullName fullName)
	{
		FullName = fullName;

		AddEvent(new AuthorUpdated(this));
	}
}
