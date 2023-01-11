using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.OrderCommands;
public record RemoveBookFromOrder(long OrderId, long BookId) : ICommand;
