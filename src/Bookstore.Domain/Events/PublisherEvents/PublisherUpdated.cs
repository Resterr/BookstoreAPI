using Bookstore.Domain.Entities;
using Bookstore.Shared.Abstractions.Domain;

namespace Bookstore.Domain.Events.PublisherEvents;
public record PublisherUpdated(Publisher publisher) : IDomainEvent;
