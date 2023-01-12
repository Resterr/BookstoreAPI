using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.OrderCommands;
public record ChangeBookQuantity(long OrderId, long BookId, int Quantity) : ICommand;
