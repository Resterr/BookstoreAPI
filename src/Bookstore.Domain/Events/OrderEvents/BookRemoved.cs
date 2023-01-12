using Bookstore.Domain.Entities;
using Bookstore.Shared.Abstractions.Domain;

namespace Bookstore.Domain.Events.OrderEvents;
public record BookRemoved(Order order, Book book) : IDomainEvent;
