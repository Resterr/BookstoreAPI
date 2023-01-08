using Bookstore.Domain.Entities;
using Bookstore.Domain.ValueObjects.PublisherValueObjects;

namespace Bookstore.Domain.Factories.Abstractions;
public interface IPublisherFactory
{
	Publisher Create(PublisherId id, PublisherName name);
}