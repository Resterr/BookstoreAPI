using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.OrderCommands;
public record RemoveOrder(Guid Id) : ICommand;
