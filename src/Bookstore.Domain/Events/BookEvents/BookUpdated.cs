using Bookstore.Domain.Entities;
using Bookstore.Shared.Abstractions.Domain;

namespace Bookstore.Domain.Events.BookEvents;
public record BookUpdated(Book book) : IDomainEvent;
