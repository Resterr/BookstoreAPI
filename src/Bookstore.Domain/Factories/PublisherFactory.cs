using Bookstore.Domain.Entities;
using Bookstore.Domain.Factories.Abstractions;
using Bookstore.Domain.ValueObjects.PublisherValueObjects;

namespace Bookstore.Domain.Factories;
public class PublisherFactory : IPublisherFactory
{
	public Publisher Create(PublisherId id, PublisherName name)
	=> new(id, name);
}
