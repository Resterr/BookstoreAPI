using Bookstore.Domain.Entities;
using Bookstore.Shared.Abstractions.Domain;

namespace Bookstore.Domain.Events.AuthorEvents;
public record AuthorUpdated(Author author) : IDomainEvent;
