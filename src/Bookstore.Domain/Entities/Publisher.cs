using Bookstore.Domain.Events.PublisherEvents;
using Bookstore.Domain.ValueObjects.PublisherValueObjects;
using Bookstore.Shared.Abstractions.Domain;

namespace Bookstore.Domain.Entities;
public class Publisher : AggregateRoot<PublisherId>
{
	public new PublisherId Id { get; private set; }
	public PublisherName Name { get; private set; }

	private Publisher() { }

	internal Publisher(PublisherId id, PublisherName name)
	{
		Id = id;
		Name = name;
	}

	public void UpdatePublisher(PublisherName name)
	{
		Name = name;

		AddEvent(new PublisherUpdated(this));
	}
}
