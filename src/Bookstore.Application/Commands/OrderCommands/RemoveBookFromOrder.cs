using Bookstore.Shared.Abstractions.Commands;

namespace Bookstore.Application.Commands.OrderCommands;
public record RemoveBookFromOrder(Guid OrderId, Guid BookId) : ICommand;
