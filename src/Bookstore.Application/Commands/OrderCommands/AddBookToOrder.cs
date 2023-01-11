using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.OrderCommands;
public record AddBookToOrder(long OrderId, long BookId, int Quantity) : ICommand;
