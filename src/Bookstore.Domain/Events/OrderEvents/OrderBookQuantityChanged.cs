using Bookstore.Domain.Entities;
using Bookstore.Domain.ValueObjects.BookValueObjects;
using Bookstore.Shared.Abstractions.Domain;

namespace Bookstore.Domain.Events.OrderEvents;
public record OrderBookQuantityChanged(Order order, Book book, BookQuantity quantity) : IDomainEvent;
