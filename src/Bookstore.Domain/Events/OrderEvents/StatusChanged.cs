using Bookstore.Domain.Entities;
using Bookstore.Shared.Abstractions.Domain;
using Bookstore.Shared.Consts;

namespace Bookstore.Domain.Events.OrderEvents;
public record StatusChanged(Order order, OrderStatus orderStatus) : IDomainEvent;
