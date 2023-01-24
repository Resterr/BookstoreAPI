using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Functions.Orders.Commands.RemoveOrderHandler;
public record RemoveOrder(Guid Id) : ICommand;
