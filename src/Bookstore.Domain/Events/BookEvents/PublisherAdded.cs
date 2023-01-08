using Bookstore.Domain.Entities;
using Bookstore.Shared.Abstractions.Domain;

namespace Bookstore.Domain.Events.BookEvents;
public record PublisherAdded(Book book, Publisher publisher) : IDomainEvent;
