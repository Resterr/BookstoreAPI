using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.OrderCommands;
public record ChangeBookQuantity(Guid OrderId, Guid BookId, int Quantity) : ICommand;
